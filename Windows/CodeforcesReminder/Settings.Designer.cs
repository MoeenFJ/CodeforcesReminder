namespace CodeforcesReminder
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clsBtn = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clsBtn
            // 
            this.clsBtn.Location = new System.Drawing.Point(12, 70);
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Size = new System.Drawing.Size(117, 23);
            this.clsBtn.TabIndex = 2;
            this.clsBtn.Text = "Close";
            this.clsBtn.UseVisualStyleBackColor = true;
            this.clsBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(11, 12);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(118, 23);
            this.add.TabIndex = 0;
            this.add.Text = "Add to startup";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(12, 41);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(117, 23);
            this.remove.TabIndex = 1;
            this.remove.Text = "Remove from startup";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(139, 101);
            this.Controls.Add(this.clsBtn);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button clsBtn;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
    }
}