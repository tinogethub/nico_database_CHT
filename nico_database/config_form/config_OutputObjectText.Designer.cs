namespace nico_database
{
    partial class config_OutputObjectText
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
            this.targetindex = new System.Windows.Forms.Label();
            this.deviceList = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Labtext = new System.Windows.Forms.TextBox();
            this.edit = new System.Windows.Forms.GroupBox();
            this.textheight = new System.Windows.Forms.TextBox();
            this.textwidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textY = new System.Windows.Forms.TextBox();
            this.textX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.GroupContact = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.edit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetindex
            // 
            this.targetindex.AutoSize = true;
            this.targetindex.Location = new System.Drawing.Point(71, 508);
            this.targetindex.Name = "targetindex";
            this.targetindex.Size = new System.Drawing.Size(0, 17);
            this.targetindex.TabIndex = 73;
            this.targetindex.Visible = false;
            // 
            // deviceList
            // 
            this.deviceList.Location = new System.Drawing.Point(12, 37);
            this.deviceList.Name = "deviceList";
            this.deviceList.ShowNodeToolTips = true;
            this.deviceList.Size = new System.Drawing.Size(490, 461);
            this.deviceList.TabIndex = 72;
            this.deviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.deviceList_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 71;
            this.label2.Text = "Target :";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 10F);
            this.button3.Location = new System.Drawing.Point(657, 472);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 26);
            this.button3.TabIndex = 70;
            this.button3.Text = "apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10F);
            this.button2.Location = new System.Drawing.Point(551, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 69;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Labtext
            // 
            this.Labtext.Font = new System.Drawing.Font("Arial", 10F);
            this.Labtext.ForeColor = System.Drawing.Color.Maroon;
            this.Labtext.Location = new System.Drawing.Point(74, 7);
            this.Labtext.Name = "Labtext";
            this.Labtext.ReadOnly = true;
            this.Labtext.Size = new System.Drawing.Size(428, 23);
            this.Labtext.TabIndex = 68;
            this.Labtext.TabStop = false;
            // 
            // edit
            // 
            this.edit.Controls.Add(this.textheight);
            this.edit.Controls.Add(this.textwidth);
            this.edit.Controls.Add(this.label4);
            this.edit.Controls.Add(this.label5);
            this.edit.Controls.Add(this.textY);
            this.edit.Controls.Add(this.textX);
            this.edit.Controls.Add(this.label3);
            this.edit.Controls.Add(this.label1);
            this.edit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.edit.Location = new System.Drawing.Point(508, 12);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(249, 100);
            this.edit.TabIndex = 74;
            this.edit.TabStop = false;
            this.edit.Text = "location";
            // 
            // textheight
            // 
            this.textheight.Location = new System.Drawing.Point(187, 66);
            this.textheight.Name = "textheight";
            this.textheight.ReadOnly = true;
            this.textheight.Size = new System.Drawing.Size(45, 24);
            this.textheight.TabIndex = 59;
            this.textheight.Text = "0";
            // 
            // textwidth
            // 
            this.textwidth.Location = new System.Drawing.Point(75, 66);
            this.textwidth.Name = "textwidth";
            this.textwidth.Size = new System.Drawing.Size(45, 24);
            this.textwidth.TabIndex = 58;
            this.textwidth.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(126, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "height :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(19, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "width :";
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(157, 23);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(45, 24);
            this.textY.TabIndex = 55;
            this.textY.Text = "0";
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(75, 23);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(45, 24);
            this.textX.TabIndex = 54;
            this.textX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(126, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 53;
            this.label3.Text = "Y :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(44, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "X :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.description);
            this.groupBox1.Controls.Add(this.GroupContact);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(508, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 252);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "event";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 76;
            this.label6.Text = "message :";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(6, 142);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(237, 100);
            this.description.TabIndex = 77;
            // 
            // GroupContact
            // 
            this.GroupContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupContact.Enabled = false;
            this.GroupContact.FormattingEnabled = true;
            this.GroupContact.Location = new System.Drawing.Point(26, 53);
            this.GroupContact.Name = "GroupContact";
            this.GroupContact.Size = new System.Drawing.Size(196, 25);
            this.GroupContact.TabIndex = 78;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox3.Location = new System.Drawing.Point(135, 26);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(94, 21);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "send SMS";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox2.Location = new System.Drawing.Point(26, 26);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(103, 21);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "send e-mail";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(26, 87);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "event log";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // config_OutputObjectText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(767, 507);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.targetindex);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Labtext);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_OutputObjectText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "config_OutputObjectText";
            this.Load += new System.EventHandler(this.config_OutputObjectText_Load);
            this.edit.ResumeLayout(false);
            this.edit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label targetindex;
        public System.Windows.Forms.TreeView deviceList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Labtext;
        private System.Windows.Forms.GroupBox edit;
        private System.Windows.Forms.TextBox textheight;
        private System.Windows.Forms.TextBox textwidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.ComboBox GroupContact;
    }
}