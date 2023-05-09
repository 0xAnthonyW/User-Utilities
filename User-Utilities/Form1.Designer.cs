namespace User_Utilities
{
    partial class UserUtilities
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            output = new ListBox();
            PWresetBtn = new Button();
            PWexpireBtn = new Button();
            RTclockBtn = new Button();
            NetwrkBtn = new Button();
            SmrtCrdBtn = new Button();
            SuspendLayout();
            // 
            // output
            // 
            output.FormattingEnabled = true;
            output.ItemHeight = 15;
            output.Location = new Point(132, 5);
            output.Name = "output";
            output.Size = new Size(343, 259);
            output.TabIndex = 0;
            // 
            // PWresetBtn
            // 
            PWresetBtn.Location = new Point(12, 5);
            PWresetBtn.Name = "PWresetBtn";
            PWresetBtn.Size = new Size(104, 25);
            PWresetBtn.TabIndex = 1;
            PWresetBtn.Text = "Password Reset";
            PWresetBtn.UseVisualStyleBackColor = true;
            PWresetBtn.Click += PWresetBtn_Click;
            // 
            // PWexpireBtn
            // 
            PWexpireBtn.Location = new Point(12, 36);
            PWexpireBtn.Name = "PWexpireBtn";
            PWexpireBtn.Size = new Size(104, 25);
            PWexpireBtn.TabIndex = 2;
            PWexpireBtn.Text = "Password Expire";
            PWexpireBtn.UseVisualStyleBackColor = true;
            PWexpireBtn.Click += PWexpireBtn_Click;
            // 
            // RTclockBtn
            // 
            RTclockBtn.Location = new Point(12, 67);
            RTclockBtn.Name = "RTclockBtn";
            RTclockBtn.Size = new Size(104, 25);
            RTclockBtn.TabIndex = 3;
            RTclockBtn.Text = "Real Time Clock";
            RTclockBtn.UseVisualStyleBackColor = true;
            RTclockBtn.Click += RTclockBtn_Click;
            // 
            // NetwrkBtn
            // 
            NetwrkBtn.Location = new Point(12, 98);
            NetwrkBtn.Name = "NetwrkBtn";
            NetwrkBtn.Size = new Size(104, 25);
            NetwrkBtn.TabIndex = 4;
            NetwrkBtn.Text = "Wi-Fi Reset";
            NetwrkBtn.UseVisualStyleBackColor = true;
            NetwrkBtn.Click += NetwrkBtn_Click;
            // 
            // SmrtCrdBtn
            // 
            SmrtCrdBtn.Location = new Point(12, 129);
            SmrtCrdBtn.Name = "SmrtCrdBtn";
            SmrtCrdBtn.Size = new Size(104, 25);
            SmrtCrdBtn.TabIndex = 5;
            SmrtCrdBtn.Text = "CAC Card Driver";
            SmrtCrdBtn.UseVisualStyleBackColor = true;
            SmrtCrdBtn.Click += SmrtCrdBtn_Click;
            // 
            // UserUtilities
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(487, 269);
            Controls.Add(SmrtCrdBtn);
            Controls.Add(NetwrkBtn);
            Controls.Add(RTclockBtn);
            Controls.Add(PWexpireBtn);
            Controls.Add(PWresetBtn);
            Controls.Add(output);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserUtilities";
            Text = "User Utilities";
            ResumeLayout(false);
        }

        #endregion

        private ListBox output;
        private Button PWresetBtn;
        private Button PWexpireBtn;
        private Button RTclockBtn;
        private Button NetwrkBtn;
        private Button SmrtCrdBtn;
    }
}