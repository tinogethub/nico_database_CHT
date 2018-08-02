namespace nico_database
{
    partial class user_check2_add
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
            this.account_viewer = new System.Windows.Forms.RadioButton();
            this.account_designer = new System.Windows.Forms.RadioButton();
            this.account_admin = new System.Windows.Forms.RadioButton();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.apply = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // account_viewer
            // 
            this.account_viewer.AutoSize = true;
            this.account_viewer.Location = new System.Drawing.Point(93, 140);
            this.account_viewer.Name = "account_viewer";
            this.account_viewer.Size = new System.Drawing.Size(68, 21);
            this.account_viewer.TabIndex = 31;
            this.account_viewer.Text = "viewer";
            this.account_viewer.UseVisualStyleBackColor = true;
            // 
            // account_designer
            // 
            this.account_designer.AutoSize = true;
            this.account_designer.Location = new System.Drawing.Point(93, 114);
            this.account_designer.Name = "account_designer";
            this.account_designer.Size = new System.Drawing.Size(82, 21);
            this.account_designer.TabIndex = 32;
            this.account_designer.Text = "designer";
            this.account_designer.UseVisualStyleBackColor = true;
            // 
            // account_admin
            // 
            this.account_admin.AutoSize = true;
            this.account_admin.Checked = true;
            this.account_admin.Location = new System.Drawing.Point(93, 88);
            this.account_admin.Name = "account_admin";
            this.account_admin.Size = new System.Drawing.Size(111, 21);
            this.account_admin.TabIndex = 33;
            this.account_admin.TabStop = true;
            this.account_admin.Text = "administrator";
            this.account_admin.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(93, 48);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(141, 24);
            this.password.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "password";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(93, 19);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(141, 24);
            this.user.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "user name";
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(159, 187);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 28);
            this.apply.TabIndex = 35;
            this.apply.Text = "apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(69, 187);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 28);
            this.cancel.TabIndex = 34;
            this.cancel.Text = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // user_check2_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(244, 223);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.account_viewer);
            this.Controls.Add(this.account_designer);
            this.Controls.Add(this.account_admin);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "user_check2_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "user_check2_add";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.user_check2_add_FormClosing);
            this.Load += new System.EventHandler(this.user_check2_add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton account_viewer;
        private System.Windows.Forms.RadioButton account_designer;
        private System.Windows.Forms.RadioButton account_admin;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
    }
}