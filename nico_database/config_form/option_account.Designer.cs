namespace nico_database
{
    partial class option_account
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
            this.user = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.account_admin = new System.Windows.Forms.RadioButton();
            this.account_designer = new System.Windows.Forms.RadioButton();
            this.account_viewer = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.CMD_add = new System.Windows.Forms.Button();
            this.CMD_edit = new System.Windows.Forms.Button();
            this.CMD_del = new System.Windows.Forms.Button();
            this.CMD_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "user name";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(261, 12);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(141, 23);
            this.user.TabIndex = 1;
            this.user.Text = "admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(261, 41);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(141, 23);
            this.password.TabIndex = 4;
            this.password.Text = "*****";
            // 
            // account_admin
            // 
            this.account_admin.AutoSize = true;
            this.account_admin.Checked = true;
            this.account_admin.Location = new System.Drawing.Point(244, 82);
            this.account_admin.Name = "account_admin";
            this.account_admin.Size = new System.Drawing.Size(108, 20);
            this.account_admin.TabIndex = 26;
            this.account_admin.TabStop = true;
            this.account_admin.Text = "administrator";
            this.account_admin.UseVisualStyleBackColor = true;
            // 
            // account_designer
            // 
            this.account_designer.AutoSize = true;
            this.account_designer.Location = new System.Drawing.Point(244, 108);
            this.account_designer.Name = "account_designer";
            this.account_designer.Size = new System.Drawing.Size(81, 20);
            this.account_designer.TabIndex = 26;
            this.account_designer.Text = "designer";
            this.account_designer.UseVisualStyleBackColor = true;
            // 
            // account_viewer
            // 
            this.account_viewer.AutoSize = true;
            this.account_viewer.Location = new System.Drawing.Point(244, 134);
            this.account_viewer.Name = "account_viewer";
            this.account_viewer.Size = new System.Drawing.Size(66, 20);
            this.account_viewer.TabIndex = 26;
            this.account_viewer.Text = "viewer";
            this.account_viewer.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(162, 228);
            this.listBox1.TabIndex = 29;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // CMD_add
            // 
            this.CMD_add.Location = new System.Drawing.Point(182, 178);
            this.CMD_add.Name = "CMD_add";
            this.CMD_add.Size = new System.Drawing.Size(107, 26);
            this.CMD_add.TabIndex = 30;
            this.CMD_add.Text = "add new";
            this.CMD_add.UseVisualStyleBackColor = true;
            this.CMD_add.Click += new System.EventHandler(this.CMD_add_Click);
            // 
            // CMD_edit
            // 
            this.CMD_edit.Location = new System.Drawing.Point(295, 178);
            this.CMD_edit.Name = "CMD_edit";
            this.CMD_edit.Size = new System.Drawing.Size(107, 26);
            this.CMD_edit.TabIndex = 31;
            this.CMD_edit.Text = "apply edit";
            this.CMD_edit.UseVisualStyleBackColor = true;
            this.CMD_edit.Click += new System.EventHandler(this.CMD_edit_Click);
            // 
            // CMD_del
            // 
            this.CMD_del.Location = new System.Drawing.Point(182, 210);
            this.CMD_del.Name = "CMD_del";
            this.CMD_del.Size = new System.Drawing.Size(107, 26);
            this.CMD_del.TabIndex = 32;
            this.CMD_del.Text = "delete";
            this.CMD_del.UseVisualStyleBackColor = true;
            this.CMD_del.Click += new System.EventHandler(this.CMD_del_Click);
            // 
            // CMD_exit
            // 
            this.CMD_exit.Location = new System.Drawing.Point(295, 210);
            this.CMD_exit.Name = "CMD_exit";
            this.CMD_exit.Size = new System.Drawing.Size(107, 26);
            this.CMD_exit.TabIndex = 33;
            this.CMD_exit.Text = "exit";
            this.CMD_exit.UseVisualStyleBackColor = true;
            this.CMD_exit.Click += new System.EventHandler(this.CMD_exit_Click);
            // 
            // option_account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(411, 248);
            this.Controls.Add(this.CMD_exit);
            this.Controls.Add(this.CMD_del);
            this.Controls.Add(this.CMD_edit);
            this.Controls.Add(this.CMD_add);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.account_viewer);
            this.Controls.Add(this.account_designer);
            this.Controls.Add(this.account_admin);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "option_account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "option_account";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.option_account_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.RadioButton account_admin;
        private System.Windows.Forms.RadioButton account_designer;
        private System.Windows.Forms.RadioButton account_viewer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button CMD_add;
        private System.Windows.Forms.Button CMD_edit;
        private System.Windows.Forms.Button CMD_del;
        private System.Windows.Forms.Button CMD_exit;
    }
}