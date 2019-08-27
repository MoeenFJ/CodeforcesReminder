using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace CodeforcesReminder
{
    class MainContext : ApplicationContext
    {
        //Component declarations
        private NotifyIcon nf;
        private ContextMenuStrip menu;
        private ToolStripMenuItem closeMenuItem,refreshMenuItem;
        private static readonly HttpClient client = new HttpClient();
        private Timer timer;
        string rfrshBtnTxt = "Refresh";
        private int stime = 0;
        private Dictionary<int,bool> notifys;
        private List<Contest> Contests;
        class Contest
        {
            public int id { get; set; }
            public string name { get; set; }
            public int remTime { get; set; }
        }
        public MainContext()
        {
            
            InitializeComponent();
            notifys = new Dictionary<int, bool>();
            Contests = new List<Contest>();
            nf.Visible = true;
            Update();
            timer.Interval = 1000; // in miliseconds
            timer.Start();
        }
        
        private void InitializeComponent()
        {
            nf = new NotifyIcon();
            menu = new ContextMenuStrip();
            nf.Text = "Codeforces Contest Reminder";
            nf.ContextMenuStrip = menu;
            nf.Icon = Properties.Resources.Icon;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            stime++;
            for(int i =0;i<Contests.Count;i++)
            {
                menu.Items[i + 2].Text = Contests[i].name + " | " +getTime(Contests[i].remTime-stime) +(notifys[Contests[i].id]==false?" | Muted":"");
                if(notifys[Contests[i].id]&&Contests[i].remTime-stime<=0)
                {
                    nf.BalloonTipText = "Contest : \""+Contests[i].name + "\" Started!";
                    nf.BalloonTipTitle = "Attention";
                    nf.ShowBalloonTip(3000);
                }
            }
            if(stime >= 300)
                Update();
        }
        string getTime(int time)
        {
            if (time >= 86400)
                return (time/86400) + " Days";
            if (time > 0)
                return (time / 3600).ToString("D2") + ":"+((time / 60) % 60).ToString("D2") + ":"+(time % 60).ToString("D2");

            return "Started";
        }

        async void Update()
        {
            menu.Items.Clear();
            Contests.Clear();
            int point = 0;
            stime = 0;
            string req = "{}";
            rfrshBtnTxt = "Refresh";
            bool isCon = true;
            try
            {
                 req = await client.GetStringAsync("https://codeforces.com/api/contest.list");
                
            }
            catch
            {
                rfrshBtnTxt = "Can`t connect,Click to retry";
                isCon = false;
            }
            menu.Items.Add(rfrshBtnTxt, null, new EventHandler(refreshMenuItem_Click));
            menu.Items.Add("-");
            JObject json = JObject.Parse(req);
            while (isCon && (json["result"][point]["phase"].ToString() == "BEFORE" || json["result"][point]["phase"].ToString() == "CODING"))
            {
                Contest c = new Contest();
                
                int remTime = (-Int32.Parse(json["result"][point]["relativeTimeSeconds"].ToString()));
                string name = json["result"][point]["name"].ToString();
                int cid = Int32.Parse(json["result"][point]["id"].ToString());
                menu.Items.Add(name + " | " + getTime(remTime),null, (sender, e) => contestMenuItem_Click(sender, e, cid,remTime));
                c.id = cid;
                c.name = name;
                
                c.remTime = remTime;
         
                Contests.Add(c);
                if (!notifys.ContainsKey(cid))
                    notifys.Add(cid, true);
                if (notifys[cid] && remTime <= 3600 && remTime > 0)
                {
                    nf.BalloonTipText = "Only " + (remTime / 60) + " Minutes To Contest: \n" + name;
                    nf.BalloonTipTitle = "Attention";
                    nf.ShowBalloonTip(3000);
                }
                point++;
            }
            menu.Items.Add("-");
            menu.Items.Add("Settings", null, new EventHandler(settingsMenuItem_Click));
            menu.Items.Add("Exit",null,new EventHandler(closeMenuItem_Click));
        }
        private void contestMenuItem_Click(object sender, EventArgs e,int id,int time)
        {
            if(time-stime<=0)
                Process.Start("https://codeforces.com/contest/" + id.ToString());
            else
                notifys[id] = !notifys[id];
        }
        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }
        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
            stime = 0;
            Update();
            
        }

    }
}