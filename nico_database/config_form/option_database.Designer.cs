namespace nico_database
{
    partial class option_database
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
            this.CMDApply = new System.Windows.Forms.Button();
            this.CMDCancel = new System.Windows.Forms.Button();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SMTPport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DBname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CMDApply
            // 
            this.CMDApply.Location = new System.Drawing.Point(210, 167);
            this.CMDApply.Margin = new System.Windows.Forms.Padding(4);
            this.CMDApply.Name = "CMDApply";
            this.CMDApply.Size = new System.Drawing.Size(73, 28);
            this.CMDApply.TabIndex = 21;
            this.CMDApply.Text = "apply";
            this.CMDApply.UseVisualStyleBackColor = true;
            this.CMDApply.Click += new System.EventHandler(this.CMDApply_Click);
            // 
            // CMDCancel
            // 
            this.CMDCancel.Location = new System.Drawing.Point(129, 167);
            this.CMDCancel.Margin = new System.Windows.Forms.Padding(4);
            this.CMDCancel.Name = "CMDCancel";
            this.CMDCancel.Size = new System.Drawing.Size(73, 28);
            this.CMDCancel.TabIndex = 20;
            this.CMDCancel.Text = "cancel";
            this.CMDCancel.UseVisualStyleBackColor = true;
            this.CMDCancel.Click += new System.EventHandler(this.CMDCancel_Click);
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(112, 70);
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(171, 23);
            this.userPassword.TabIndex = 27;
            this.userPassword.Text = "root";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(112, 41);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(171, 23);
            this.userName.TabIndex = 26;
            this.userName.Text = "root";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(112, 12);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(171, 23);
            this.ip.TabIndex = 25;
            this.ip.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "user";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "ip address";
            // 
            // SMTPport
            // 
            this.SMTPport.Location = new System.Drawing.Point(112, 99);
            this.SMTPport.Name = "SMTPport";
            this.SMTPport.Size = new System.Drawing.Size(41, 23);
            this.SMTPport.TabIndex = 29;
            this.SMTPport.Text = "3306";
            this.SMTPport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "database name";
            // 
            // DBname
            // 
            this.DBname.Location = new System.Drawing.Point(112, 128);
            this.DBname.Name = "DBname";
            this.DBname.Size = new System.Drawing.Size(171, 23);
            this.DBname.TabIndex = 31;
            this.DBname.Text = "nico_db";
            // 
            // option_database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(295, 204);
            this.Controls.Add(this.DBname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SMTPport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMDApply);
            this.Controls.Add(this.CMDCancel);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "option_database";
            this.Text = "+";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.option_database_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.Button CMDCancel;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SMTPport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DBname;
    }
}