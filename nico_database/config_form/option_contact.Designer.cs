namespace nico_database
{
    partial class option_contact
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editGroup = new System.Windows.Forms.Button();
            this.grouplist = new System.Windows.Forms.ListBox();
            this.groupRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.delGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addGroup = new System.Windows.Forms.Button();
            this.contactRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.delContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editContact = new System.Windows.Forms.Button();
            this.addContact = new System.Windows.Forms.Button();
            this.CMDApply = new System.Windows.Forms.Button();
            this.contactDescription = new System.Windows.Forms.TextBox();
            this.contactPhone = new System.Windows.Forms.TextBox();
            this.contactMail = new System.Windows.Forms.TextBox();
            this.contactName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contactlist = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupRightMenu.SuspendLayout();
            this.contactRightMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editGroup);
            this.groupBox1.Controls.Add(this.grouplist);
            this.groupBox1.Controls.Add(this.addGroup);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 484);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "contact group";
            // 
            // editGroup
            // 
            this.editGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.editGroup.Location = new System.Drawing.Point(111, 22);
            this.editGroup.Name = "editGroup";
            this.editGroup.Size = new System.Drawing.Size(99, 25);
            this.editGroup.TabIndex = 28;
            this.editGroup.Text = "edit group";
            this.editGroup.UseVisualStyleBackColor = true;
            this.editGroup.Click += new System.EventHandler(this.editGroup_Click);
            // 
            // grouplist
            // 
            this.grouplist.ContextMenuStrip = this.groupRightMenu;
            this.grouplist.FormattingEnabled = true;
            this.grouplist.ItemHeight = 16;
            this.grouplist.Items.AddRange(new object[] {
            "all contact"});
            this.grouplist.Location = new System.Drawing.Point(6, 53);
            this.grouplist.Name = "grouplist";
            this.grouplist.Size = new System.Drawing.Size(204, 420);
            this.grouplist.TabIndex = 1;
            this.grouplist.SelectedIndexChanged += new System.EventHandler(this.grouplist_SelectedIndexChanged);
            // 
            // groupRightMenu
            // 
            this.groupRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.editGroupToolStripMenuItem,
            this.toolStripSeparator1,
            this.delGroupToolStripMenuItem,
            this.toolStripSeparator4});
            this.groupRightMenu.Name = "groupRightMenu";
            this.groupRightMenu.Size = new System.Drawing.Size(136, 82);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addGroupToolStripMenuItem.Text = "add group";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.editGroupToolStripMenuItem.Text = "edit group";
            this.editGroupToolStripMenuItem.Click += new System.EventHandler(this.editGroupToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // delGroupToolStripMenuItem
            // 
            this.delGroupToolStripMenuItem.Name = "delGroupToolStripMenuItem";
            this.delGroupToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.delGroupToolStripMenuItem.Text = "del group";
            this.delGroupToolStripMenuItem.Click += new System.EventHandler(this.delGroupToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(132, 6);
            // 
            // addGroup
            // 
            this.addGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addGroup.Location = new System.Drawing.Point(6, 22);
            this.addGroup.Name = "addGroup";
            this.addGroup.Size = new System.Drawing.Size(99, 25);
            this.addGroup.TabIndex = 27;
            this.addGroup.Text = "add group";
            this.addGroup.UseVisualStyleBackColor = true;
            this.addGroup.Click += new System.EventHandler(this.addGroup_Click);
            // 
            // contactRightMenu
            // 
            this.contactRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.toolStripSeparator2,
            this.delContactToolStripMenuItem,
            this.toolStripSeparator3});
            this.contactRightMenu.Name = "contactRightMenu";
            this.contactRightMenu.Size = new System.Drawing.Size(143, 82);
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.addContactToolStripMenuItem.Text = "add contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.addContactToolStripMenuItem_Click);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.editContactToolStripMenuItem.Text = "edit contact";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.editContactToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // delContactToolStripMenuItem
            // 
            this.delContactToolStripMenuItem.Name = "delContactToolStripMenuItem";
            this.delContactToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.delContactToolStripMenuItem.Text = "del contact";
            this.delContactToolStripMenuItem.Click += new System.EventHandler(this.delContactToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(139, 6);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.editContact);
            this.groupBox2.Controls.Add(this.addContact);
            this.groupBox2.Controls.Add(this.CMDApply);
            this.groupBox2.Controls.Add(this.contactDescription);
            this.groupBox2.Controls.Add(this.contactPhone);
            this.groupBox2.Controls.Add(this.contactMail);
            this.groupBox2.Controls.Add(this.contactName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.contactlist);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(232, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 484);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "contact info";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // editContact
            // 
            this.editContact.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.editContact.Location = new System.Drawing.Point(111, 22);
            this.editContact.Name = "editContact";
            this.editContact.Size = new System.Drawing.Size(99, 25);
            this.editContact.TabIndex = 28;
            this.editContact.Text = "edit contact";
            this.editContact.UseVisualStyleBackColor = true;
            this.editContact.Click += new System.EventHandler(this.editContact_Click);
            // 
            // addContact
            // 
            this.addContact.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addContact.Location = new System.Drawing.Point(6, 22);
            this.addContact.Name = "addContact";
            this.addContact.Size = new System.Drawing.Size(99, 25);
            this.addContact.TabIndex = 26;
            this.addContact.Text = "add contact";
            this.addContact.UseVisualStyleBackColor = true;
            this.addContact.Click += new System.EventHandler(this.addContact_Click);
            // 
            // CMDApply
            // 
            this.CMDApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CMDApply.Location = new System.Drawing.Point(425, 446);
            this.CMDApply.Margin = new System.Windows.Forms.Padding(4);
            this.CMDApply.Name = "CMDApply";
            this.CMDApply.Size = new System.Drawing.Size(91, 28);
            this.CMDApply.TabIndex = 21;
            this.CMDApply.Text = "exit";
            this.CMDApply.UseVisualStyleBackColor = true;
            this.CMDApply.Click += new System.EventHandler(this.CMDApply_Click);
            // 
            // contactDescription
            // 
            this.contactDescription.BackColor = System.Drawing.Color.White;
            this.contactDescription.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.contactDescription.Location = new System.Drawing.Point(307, 170);
            this.contactDescription.Multiline = true;
            this.contactDescription.Name = "contactDescription";
            this.contactDescription.ReadOnly = true;
            this.contactDescription.Size = new System.Drawing.Size(209, 109);
            this.contactDescription.TabIndex = 8;
            // 
            // contactPhone
            // 
            this.contactPhone.BackColor = System.Drawing.Color.White;
            this.contactPhone.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.contactPhone.Location = new System.Drawing.Point(307, 131);
            this.contactPhone.Name = "contactPhone";
            this.contactPhone.ReadOnly = true;
            this.contactPhone.Size = new System.Drawing.Size(155, 23);
            this.contactPhone.TabIndex = 7;
            // 
            // contactMail
            // 
            this.contactMail.BackColor = System.Drawing.Color.White;
            this.contactMail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.contactMail.Location = new System.Drawing.Point(307, 90);
            this.contactMail.Name = "contactMail";
            this.contactMail.ReadOnly = true;
            this.contactMail.Size = new System.Drawing.Size(209, 23);
            this.contactMail.TabIndex = 6;
            // 
            // contactName
            // 
            this.contactName.BackColor = System.Drawing.Color.White;
            this.contactName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.contactName.Location = new System.Drawing.Point(307, 53);
            this.contactName.Name = "contactName";
            this.contactName.ReadOnly = true;
            this.contactName.Size = new System.Drawing.Size(209, 23);
            this.contactName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(224, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(253, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(255, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "e-mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(258, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "name";
            // 
            // contactlist
            // 
            this.contactlist.ContextMenuStrip = this.contactRightMenu;
            this.contactlist.FormattingEnabled = true;
            this.contactlist.ItemHeight = 16;
            this.contactlist.Location = new System.Drawing.Point(6, 53);
            this.contactlist.Name = "contactlist";
            this.contactlist.Size = new System.Drawing.Size(204, 420);
            this.contactlist.TabIndex = 0;
            this.contactlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contactlist_MouseClick);
            this.contactlist.SelectedIndexChanged += new System.EventHandler(this.contactlist_SelectedIndexChanged);
            this.contactlist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.contactlist_MouseDown);
            // 
            // option_contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(774, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "option_contact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "option_contact";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.option_contact_FormClosing);
            this.Load += new System.EventHandler(this.option_contact_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupRightMenu.ResumeLayout(false);
            this.contactRightMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox contactlist;
        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.ContextMenuStrip groupRightMenu;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem delGroupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contactRightMenu;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem delContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button addGroup;
        private System.Windows.Forms.Button addContact;
        private System.Windows.Forms.TextBox contactDescription;
        private System.Windows.Forms.TextBox contactPhone;
        private System.Windows.Forms.TextBox contactMail;
        private System.Windows.Forms.TextBox contactName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editContact;
        private System.Windows.Forms.ListBox grouplist;
        private System.Windows.Forms.Button editGroup;


    }
}