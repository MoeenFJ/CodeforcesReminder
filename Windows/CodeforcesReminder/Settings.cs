using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeforcesReminder
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        bool startup;
        private void Settings_Load(object sender, EventArgs e)
        {
           
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("CodeforcesReminder", Application.ExecutablePath);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue("CodeforcesReminder", false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
