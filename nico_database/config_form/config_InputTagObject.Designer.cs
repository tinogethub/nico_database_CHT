namespace nico_database
{
    partial class config_InputTagObject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config_InputTagObject));
            this.ColorCMD = new System.Windows.Forms.Button();
            this.textY = new System.Windows.Forms.TextBox();
            this.textX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.previewLab = new System.Windows.Forms.Label();
            this.Labtext = new System.Windows.Forms.TextBox();
            this.FontCMD = new System.Windows.Forms.Button();
            this.checkUnit = new System.Windows.Forms.CheckBox();
            this.unitList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LogUse = new System.Windows.Forms.RadioButton();
            this.LogNot = new System.Windows.Forms.RadioButton();
            this.LogTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deviceList = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.formatList = new System.Windows.Forms.ComboBox();
            this.borderStyle = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.targetindex = new System.Windows.Forms.Label();
            this.formatUser = new System.Windows.Forms.TextBox();
            this.smartserverLab = new System.Windows.Forms.Label();
            this.lonPollTime = new System.Windows.Forms.TextBox();
            this.smartserverLab2 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColorCMD
            // 
            this.ColorCMD.Image = ((System.Drawing.Image)(resources.GetObject("ColorCMD.Image")));
            this.ColorCMD.Location = new System.Drawing.Point(774, 58);
            this.ColorCMD.Name = "ColorCMD";
            this.ColorCMD.Size = new System.Drawing.Size(34, 30);
            this.ColorCMD.TabIndex = 52;
            this.ColorCMD.UseVisualStyleBackColor = true;
            this.ColorCMD.Click += new System.EventHandler(this.ColorCMD_Click);
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(696, 221);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(45, 24);
            this.textY.TabIndex = 51;
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(614, 221);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(45, 24);
            this.textX.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(665, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Y :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(583, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Target :";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 10F);
            this.button3.Location = new System.Drawing.Point(708, 472);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 26);
            this.button3.TabIndex = 46;
            this.button3.Text = "apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10F);
            this.button2.Location = new System.Drawing.Point(602, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 45;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.previewLab);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(508, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 89);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "label font preview ";
            // 
            // previewLab
            // 
            this.previewLab.AutoSize = true;
            this.previewLab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.previewLab.Location = new System.Drawing.Point(12, 24);
            this.previewLab.Name = "previewLab";
            this.previewLab.Size = new System.Drawing.Size(40, 17);
            this.previewLab.TabIndex = 0;
            this.previewLab.Text = "1234";
            // 
            // Labtext
            // 
            this.Labtext.Font = new System.Drawing.Font("Arial", 10F);
            this.Labtext.ForeColor = System.Drawing.Color.Maroon;
            this.Labtext.Location = new System.Drawing.Point(74, 7);
            this.Labtext.Name = "Labtext";
            this.Labtext.ReadOnly = true;
            this.Labtext.Size = new System.Drawing.Size(428, 23);
            this.Labtext.TabIndex = 43;
            this.Labtext.TabStop = false;
            // 
            // FontCMD
            // 
            this.FontCMD.Image = ((System.Drawing.Image)(resources.GetObject("FontCMD.Image")));
            this.FontCMD.Location = new System.Drawing.Point(774, 22);
            this.FontCMD.Name = "FontCMD";
            this.FontCMD.Size = new System.Drawing.Size(34, 30);
            this.FontCMD.TabIndex = 42;
            this.FontCMD.UseVisualStyleBackColor = true;
            this.FontCMD.Click += new System.EventHandler(this.FontCMD_Click);
            // 
            // checkUnit
            // 
            this.checkUnit.AutoSize = true;
            this.checkUnit.Location = new System.Drawing.Point(702, 180);
            this.checkUnit.Name = "checkUnit";
            this.checkUnit.Size = new System.Drawing.Size(62, 21);
            this.checkUnit.TabIndex = 53;
            this.checkUnit.Text = "show";
            this.checkUnit.UseVisualStyleBackColor = true;
            this.checkUnit.CheckedChanged += new System.EventHandler(this.checkUnit_CheckedChanged);
            // 
            // unitList
            // 
            this.unitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitList.Enabled = false;
            this.unitList.FormattingEnabled = true;
            this.unitList.Items.AddRange(new object[] {
            "°C",
            "°F",
            "%",
            "%RH",
            "Lux",
            "A",
            "V",
            "W",
            "KW",
            "KWH"});
            this.unitList.Location = new System.Drawing.Point(614, 178);
            this.unitList.Name = "unitList";
            this.unitList.Size = new System.Drawing.Size(76, 25);
            this.unitList.TabIndex = 54;
            this.unitList.SelectedIndexChanged += new System.EventHandler(this.unitList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(568, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "Log :";
            // 
            // LogUse
            // 
            this.LogUse.AutoSize = true;
            this.LogUse.Location = new System.Drawing.Point(614, 264);
            this.LogUse.Name = "LogUse";
            this.LogUse.Size = new System.Drawing.Size(69, 21);
            this.LogUse.TabIndex = 56;
            this.LogUse.Text = "enable";
            this.LogUse.UseVisualStyleBackColor = true;
            this.LogUse.CheckedChanged += new System.EventHandler(this.LogUse_CheckedChanged);
            // 
            // LogNot
            // 
            this.LogNot.AutoSize = true;
            this.LogNot.Checked = true;
            this.LogNot.Location = new System.Drawing.Point(614, 291);
            this.LogNot.Name = "LogNot";
            this.LogNot.Size = new System.Drawing.Size(72, 21);
            this.LogNot.TabIndex = 56;
            this.LogNot.TabStop = true;
            this.LogNot.Text = "disable";
            this.LogNot.UseVisualStyleBackColor = true;
            this.LogNot.CheckedChanged += new System.EventHandler(this.LogUse_CheckedChanged);
            // 
            // LogTime
            // 
            this.LogTime.Enabled = false;
            this.LogTime.Location = new System.Drawing.Point(689, 263);
            this.LogTime.Name = "LogTime";
            this.LogTime.Size = new System.Drawing.Size(55, 24);
            this.LogTime.TabIndex = 57;
            this.LogTime.Text = "1";
            this.LogTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(750, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "second.";
            // 
            // deviceList
            // 
            this.deviceList.Location = new System.Drawing.Point(12, 37);
            this.deviceList.Name = "deviceList";
            this.deviceList.ShowNodeToolTips = true;
            this.deviceList.Size = new System.Drawing.Size(490, 461);
            this.deviceList.TabIndex = 59;
            this.deviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.deviceList_AfterSelect);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 60;
            this.label6.Text = "Unit :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(523, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 61;
            this.label7.Text = "text format :";
            // 
            // formatList
            // 
            this.formatList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatList.FormattingEnabled = true;
            this.formatList.Items.AddRange(new object[] {
            "General",
            "-1234",
            "-1234.1",
            "-1234.12",
            "-1,234",
            "-1,234.12",
            "Customize"});
            this.formatList.Location = new System.Drawing.Point(614, 138);
            this.formatList.Name = "formatList";
            this.formatList.Size = new System.Drawing.Size(107, 25);
            this.formatList.TabIndex = 62;
            this.formatList.SelectedIndexChanged += new System.EventHandler(this.formatList_SelectedIndexChanged);
            // 
            // borderStyle
            // 
            this.borderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borderStyle.FormattingEnabled = true;
            this.borderStyle.Items.AddRange(new object[] {
            "None",
            "FixedSingle",
            "Fixed3D"});
            this.borderStyle.Location = new System.Drawing.Point(614, 107);
            this.borderStyle.Name = "borderStyle";
            this.borderStyle.Size = new System.Drawing.Size(153, 25);
            this.borderStyle.TabIndex = 64;
            this.borderStyle.SelectedIndexChanged += new System.EventHandler(this.borderStyle_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(508, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.label8.TabIndex = 63;
            this.label8.Text = "Border  Style :";
            // 
            // targetindex
            // 
            this.targetindex.AutoSize = true;
            this.targetindex.Location = new System.Drawing.Point(523, 472);
            this.targetindex.Name = "targetindex";
            this.targetindex.Size = new System.Drawing.Size(0, 17);
            this.targetindex.TabIndex = 65;
            this.targetindex.Visible = false;
            // 
            // formatUser
            // 
            this.formatUser.Location = new System.Drawing.Point(727, 138);
            this.formatUser.Name = "formatUser";
            this.formatUser.Size = new System.Drawing.Size(81, 24);
            this.formatUser.TabIndex = 66;
            this.formatUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formatUser_KeyUp);
            // 
            // smartserverLab
            // 
            this.smartserverLab.AutoSize = true;
            this.smartserverLab.Location = new System.Drawing.Point(573, 330);
            this.smartserverLab.Name = "smartserverLab";
            this.smartserverLab.Size = new System.Drawing.Size(95, 17);
            this.smartserverLab.TabIndex = 67;
            this.smartserverLab.Text = "Sample rate :";
            this.smartserverLab.Visible = false;
            // 
            // lonPollTime
            // 
            this.lonPollTime.Location = new System.Drawing.Point(674, 327);
            this.lonPollTime.Name = "lonPollTime";
            this.lonPollTime.Size = new System.Drawing.Size(70, 24);
            this.lonPollTime.TabIndex = 68;
            this.lonPollTime.Text = "300";
            this.lonPollTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lonPollTime.Visible = false;
            this.lonPollTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lonPollTime_KeyPress);
            // 
            // smartserverLab2
            // 
            this.smartserverLab2.AutoSize = true;
            this.smartserverLab2.Location = new System.Drawing.Point(750, 330);
            this.smartserverLab2.Name = "smartserverLab2";
            this.smartserverLab2.Size = new System.Drawing.Size(60, 17);
            this.smartserverLab2.TabIndex = 69;
            this.smartserverLab2.Text = "second.";
            this.smartserverLab2.Visible = false;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(602, 377);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(206, 80);
            this.description.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(509, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 71;
            this.label9.Text = "description :";
            this.label9.Visible = false;
            // 
            // config_InputTagObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(819, 506);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.description);
            this.Controls.Add(this.smartserverLab2);
            this.Controls.Add(this.lonPollTime);
            this.Controls.Add(this.smartserverLab);
            this.Controls.Add(this.formatUser);
            this.Controls.Add(this.targetindex);
            this.Controls.Add(this.borderStyle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.formatList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LogTime);
            this.Controls.Add(this.LogNot);
            this.Controls.Add(this.LogUse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unitList);
            this.Controls.Add(this.checkUnit);
            this.Controls.Add(this.ColorCMD);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Labtext);
            this.Controls.Add(this.FontCMD);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_InputTagObject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "config_InputTagObject";
            this.Load += new System.EventHandler(this.config_InputTagObject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ColorCMD;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label previewLab;
        private System.Windows.Forms.TextBox Labtext;
        private System.Windows.Forms.Button FontCMD;
        private System.Windows.Forms.CheckBox checkUnit;
        private System.Windows.Forms.ComboBox unitList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton LogUse;
        private System.Windows.Forms.RadioButton LogNot;
        private System.Windows.Forms.TextBox LogTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox formatList;
        public System.Windows.Forms.TreeView deviceList;
        private System.Windows.Forms.ComboBox borderStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label targetindex;
        private System.Windows.Forms.TextBox formatUser;
        private System.Windows.Forms.TextBox lonPollTime;
        private System.Windows.Forms.Label smartserverLab2;
        private System.Windows.Forms.Label smartserverLab;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label9;
    }
}