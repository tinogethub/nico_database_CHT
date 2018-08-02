namespace nico_database
{
    partial class option_mail
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SSL = new System.Windows.Forms.CheckBox();
            this.SMTPhost = new System.Windows.Forms.TextBox();
            this.SMTPport = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.sendtest = new System.Windows.Forms.Button();
            this.CMDApply = new System.Windows.Forms.Button();
            this.CMDCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP  host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "mail address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "SMTP  port";
            // 
            // SSL
            // 
            this.SSL.AutoSize = true;
            this.SSL.Checked = true;
            this.SSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SSL.Location = new System.Drawing.Point(158, 46);
            this.SSL.Name = "SSL";
            this.SSL.Size = new System.Drawing.Size(79, 20);
            this.SSL.TabIndex = 4;
            this.SSL.Text = "SSL use";
            this.SSL.UseVisualStyleBackColor = true;
            // 
            // SMTPhost
            // 
            this.SMTPhost.Location = new System.Drawing.Point(104, 12);
            this.SMTPhost.Name = "SMTPhost";
            this.SMTPhost.Size = new System.Drawing.Size(248, 23);
            this.SMTPhost.TabIndex = 5;
            // 
            // SMTPport
            // 
            this.SMTPport.Location = new System.Drawing.Point(104, 44);
            this.SMTPport.Name = "SMTPport";
            this.SMTPport.Size = new System.Drawing.Size(41, 23);
            this.SMTPport.TabIndex = 6;
            this.SMTPport.Text = "25";
            this.SMTPport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(104, 78);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(248, 23);
            this.userName.TabIndex = 7;
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(104, 110);
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(149, 23);
            this.userPassword.TabIndex = 8;
            // 
            // sendtest
            // 
            this.sendtest.Font = new System.Drawing.Font("Arial", 9F);
            this.sendtest.ForeColor = System.Drawing.Color.Maroon;
            this.sendtest.Location = new System.Drawing.Point(259, 43);
            this.sendtest.Name = "sendtest";
            this.sendtest.Size = new System.Drawing.Size(80, 25);
            this.sendtest.TabIndex = 9;
            this.sendtest.Text = "SMTP test";
            this.sendtest.UseVisualStyleBackColor = true;
            this.sendtest.Click += new System.EventHandler(this.sendtest_Click);
            // 
            // CMDApply
            // 
            this.CMDApply.Location = new System.Drawing.Point(279, 149);
            this.CMDApply.Margin = new System.Windows.Forms.Padding(4);
            this.CMDApply.Name = "CMDApply";
            this.CMDApply.Size = new System.Drawing.Size(73, 28);
            this.CMDApply.TabIndex = 19;
            this.CMDApply.Text = "apply";
            this.CMDApply.UseVisualStyleBackColor = true;
            this.CMDApply.Click += new System.EventHandler(this.CMDApply_Click);
            // 
            // CMDCancel
            // 
            this.CMDCancel.Location = new System.Drawing.Point(198, 149);
            this.CMDCancel.Margin = new System.Windows.Forms.Padding(4);
            this.CMDCancel.Name = "CMDCancel";
            this.CMDCancel.Size = new System.Drawing.Size(73, 28);
            this.CMDCancel.TabIndex = 18;
            this.CMDCancel.Text = "cancel";
            this.CMDCancel.UseVisualStyleBackColor = true;
            this.CMDCancel.Click += new System.EventHandler(this.CMDCancel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(259, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 25);
            this.button1.TabIndex = 20;
            this.button1.Text = "send test mail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // option_mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(363, 186);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CMDApply);
            this.Controls.Add(this.CMDCancel);
            this.Controls.Add(this.sendtest);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.SMTPport);
            this.Controls.Add(this.SMTPhost);
            this.Controls.Add(this.SSL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "option_mail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "option_mail";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.option_mail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SSL;
        private System.Windows.Forms.TextBox SMTPhost;
        private System.Windows.Forms.TextBox SMTPport;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Button sendtest;
        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.Button CMDCancel;
        private System.Windows.Forms.Button button1;
    }
}