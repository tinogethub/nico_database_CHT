namespace nico_database
{
    partial class config_OutputObjectButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config_OutputObjectButton));
            this.deviceList = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Labtext = new System.Windows.Forms.TextBox();
            this.buttontype = new System.Windows.Forms.GroupBox();
            this.offimage = new System.Windows.Forms.Button();
            this.onimage = new System.Windows.Forms.Button();
            this.OFFlab = new System.Windows.Forms.Label();
            this.ONlab = new System.Windows.Forms.Label();
            this.userOFF = new System.Windows.Forms.PictureBox();
            this.userON = new System.Windows.Forms.PictureBox();
            this.buttonType5 = new System.Windows.Forms.RadioButton();
            this.knob1Img = new System.Windows.Forms.PictureBox();
            this.buttonType4 = new System.Windows.Forms.RadioButton();
            this.push2Img = new System.Windows.Forms.PictureBox();
            this.buttonType3 = new System.Windows.Forms.RadioButton();
            this.pushImg = new System.Windows.Forms.PictureBox();
            this.switchImg = new System.Windows.Forms.PictureBox();
            this.buttonType2 = new System.Windows.Forms.RadioButton();
            this.buttonType1 = new System.Windows.Forms.RadioButton();
            this.valuetype = new System.Windows.Forms.GroupBox();
            this.valueType4 = new System.Windows.Forms.RadioButton();
            this.valueType3Text = new System.Windows.Forms.TextBox();
            this.valueType3 = new System.Windows.Forms.RadioButton();
            this.valueType2 = new System.Windows.Forms.RadioButton();
            this.valueType1 = new System.Windows.Forms.RadioButton();
            this.targetindex = new System.Windows.Forms.Label();
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
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.GroupContact = new System.Windows.Forms.ComboBox();
            this.buttontype.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knob1Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.push2Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchImg)).BeginInit();
            this.valuetype.SuspendLayout();
            this.edit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceList
            // 
            this.deviceList.Location = new System.Drawing.Point(12, 37);
            this.deviceList.Name = "deviceList";
            this.deviceList.ShowNodeToolTips = true;
            this.deviceList.Size = new System.Drawing.Size(490, 461);
            this.deviceList.TabIndex = 64;
            this.deviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.deviceList_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Target :";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 10F);
            this.button3.Location = new System.Drawing.Point(791, 472);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 26);
            this.button3.TabIndex = 62;
            this.button3.Text = "apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10F);
            this.button2.Location = new System.Drawing.Point(685, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 61;
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
            this.Labtext.TabIndex = 60;
            this.Labtext.TabStop = false;
            // 
            // buttontype
            // 
            this.buttontype.Controls.Add(this.offimage);
            this.buttontype.Controls.Add(this.onimage);
            this.buttontype.Controls.Add(this.OFFlab);
            this.buttontype.Controls.Add(this.ONlab);
            this.buttontype.Controls.Add(this.userOFF);
            this.buttontype.Controls.Add(this.userON);
            this.buttontype.Controls.Add(this.buttonType5);
            this.buttontype.Controls.Add(this.knob1Img);
            this.buttontype.Controls.Add(this.buttonType4);
            this.buttontype.Controls.Add(this.push2Img);
            this.buttontype.Controls.Add(this.buttonType3);
            this.buttontype.Controls.Add(this.pushImg);
            this.buttontype.Controls.Add(this.switchImg);
            this.buttontype.Controls.Add(this.buttonType2);
            this.buttontype.Controls.Add(this.buttonType1);
            this.buttontype.ForeColor = System.Drawing.Color.RoyalBlue;
            this.buttontype.Location = new System.Drawing.Point(508, 7);
            this.buttontype.Name = "buttontype";
            this.buttontype.Size = new System.Drawing.Size(195, 363);
            this.buttontype.TabIndex = 65;
            this.buttontype.TabStop = false;
            this.buttontype.Text = "button type";
            // 
            // offimage
            // 
            this.offimage.Image = ((System.Drawing.Image)(resources.GetObject("offimage.Image")));
            this.offimage.Location = new System.Drawing.Point(80, 314);
            this.offimage.Name = "offimage";
            this.offimage.Size = new System.Drawing.Size(28, 36);
            this.offimage.TabIndex = 56;
            this.offimage.UseVisualStyleBackColor = true;
            this.offimage.Click += new System.EventHandler(this.offimage_Click);
            // 
            // onimage
            // 
            this.onimage.Image = ((System.Drawing.Image)(resources.GetObject("onimage.Image")));
            this.onimage.Location = new System.Drawing.Point(80, 260);
            this.onimage.Name = "onimage";
            this.onimage.Size = new System.Drawing.Size(28, 36);
            this.onimage.TabIndex = 55;
            this.onimage.UseVisualStyleBackColor = true;
            this.onimage.Click += new System.EventHandler(this.onimage_Click);
            // 
            // OFFlab
            // 
            this.OFFlab.AutoSize = true;
            this.OFFlab.ForeColor = System.Drawing.Color.Crimson;
            this.OFFlab.Location = new System.Drawing.Point(50, 324);
            this.OFFlab.Name = "OFFlab";
            this.OFFlab.Size = new System.Drawing.Size(24, 17);
            this.OFFlab.TabIndex = 54;
            this.OFFlab.Text = "off";
            // 
            // ONlab
            // 
            this.ONlab.AutoSize = true;
            this.ONlab.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ONlab.Location = new System.Drawing.Point(50, 270);
            this.ONlab.Name = "ONlab";
            this.ONlab.Size = new System.Drawing.Size(24, 17);
            this.ONlab.TabIndex = 53;
            this.ONlab.Text = "on";
            // 
            // userOFF
            // 
            this.userOFF.Enabled = false;
            this.userOFF.Image = ((System.Drawing.Image)(resources.GetObject("userOFF.Image")));
            this.userOFF.Location = new System.Drawing.Point(114, 309);
            this.userOFF.Name = "userOFF";
            this.userOFF.Size = new System.Drawing.Size(45, 45);
            this.userOFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userOFF.TabIndex = 9;
            this.userOFF.TabStop = false;
            // 
            // userON
            // 
            this.userON.Enabled = false;
            this.userON.Image = ((System.Drawing.Image)(resources.GetObject("userON.Image")));
            this.userON.Location = new System.Drawing.Point(114, 256);
            this.userON.Name = "userON";
            this.userON.Size = new System.Drawing.Size(45, 45);
            this.userON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userON.TabIndex = 8;
            this.userON.TabStop = false;
            // 
            // buttonType5
            // 
            this.buttonType5.AutoSize = true;
            this.buttonType5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonType5.Location = new System.Drawing.Point(16, 229);
            this.buttonType5.Name = "buttonType5";
            this.buttonType5.Size = new System.Drawing.Size(94, 21);
            this.buttonType5.TabIndex = 7;
            this.buttonType5.Text = "customize";
            this.buttonType5.UseVisualStyleBackColor = true;
            this.buttonType5.CheckedChanged += new System.EventHandler(this.buttonType1_CheckedChanged);
            // 
            // knob1Img
            // 
            this.knob1Img.Enabled = false;
            this.knob1Img.Image = ((System.Drawing.Image)(resources.GetObject("knob1Img.Image")));
            this.knob1Img.Location = new System.Drawing.Point(133, 162);
            this.knob1Img.Name = "knob1Img";
            this.knob1Img.Size = new System.Drawing.Size(45, 45);
            this.knob1Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.knob1Img.TabIndex = 6;
            this.knob1Img.TabStop = false;
            // 
            // buttonType4
            // 
            this.buttonType4.AutoSize = true;
            this.buttonType4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonType4.Location = new System.Drawing.Point(16, 175);
            this.buttonType4.Name = "buttonType4";
            this.buttonType4.Size = new System.Drawing.Size(101, 21);
            this.buttonType4.TabIndex = 5;
            this.buttonType4.Text = "knob button";
            this.buttonType4.UseVisualStyleBackColor = true;
            this.buttonType4.CheckedChanged += new System.EventHandler(this.buttonType1_CheckedChanged);
            // 
            // push2Img
            // 
            this.push2Img.Enabled = false;
            this.push2Img.Image = ((System.Drawing.Image)(resources.GetObject("push2Img.Image")));
            this.push2Img.Location = new System.Drawing.Point(129, 106);
            this.push2Img.Name = "push2Img";
            this.push2Img.Size = new System.Drawing.Size(53, 50);
            this.push2Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.push2Img.TabIndex = 4;
            this.push2Img.TabStop = false;
            // 
            // buttonType3
            // 
            this.buttonType3.AutoSize = true;
            this.buttonType3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonType3.Location = new System.Drawing.Point(16, 120);
            this.buttonType3.Name = "buttonType3";
            this.buttonType3.Size = new System.Drawing.Size(102, 21);
            this.buttonType3.TabIndex = 3;
            this.buttonType3.Text = "push button";
            this.buttonType3.UseVisualStyleBackColor = true;
            this.buttonType3.CheckedChanged += new System.EventHandler(this.buttonType1_CheckedChanged);
            // 
            // pushImg
            // 
            this.pushImg.Enabled = false;
            this.pushImg.Image = ((System.Drawing.Image)(resources.GetObject("pushImg.Image")));
            this.pushImg.Location = new System.Drawing.Point(129, 50);
            this.pushImg.Name = "pushImg";
            this.pushImg.Size = new System.Drawing.Size(53, 50);
            this.pushImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pushImg.TabIndex = 2;
            this.pushImg.TabStop = false;
            // 
            // switchImg
            // 
            this.switchImg.Image = ((System.Drawing.Image)(resources.GetObject("switchImg.Image")));
            this.switchImg.Location = new System.Drawing.Point(129, 22);
            this.switchImg.Name = "switchImg";
            this.switchImg.Size = new System.Drawing.Size(53, 22);
            this.switchImg.TabIndex = 1;
            this.switchImg.TabStop = false;
            // 
            // buttonType2
            // 
            this.buttonType2.AutoSize = true;
            this.buttonType2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonType2.Location = new System.Drawing.Point(16, 66);
            this.buttonType2.Name = "buttonType2";
            this.buttonType2.Size = new System.Drawing.Size(102, 21);
            this.buttonType2.TabIndex = 0;
            this.buttonType2.Text = "push button";
            this.buttonType2.UseVisualStyleBackColor = true;
            this.buttonType2.CheckedChanged += new System.EventHandler(this.buttonType1_CheckedChanged);
            // 
            // buttonType1
            // 
            this.buttonType1.AutoSize = true;
            this.buttonType1.Checked = true;
            this.buttonType1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonType1.Location = new System.Drawing.Point(16, 23);
            this.buttonType1.Name = "buttonType1";
            this.buttonType1.Size = new System.Drawing.Size(68, 21);
            this.buttonType1.TabIndex = 0;
            this.buttonType1.TabStop = true;
            this.buttonType1.Text = "switch";
            this.buttonType1.UseVisualStyleBackColor = true;
            this.buttonType1.CheckedChanged += new System.EventHandler(this.buttonType1_CheckedChanged);
            // 
            // valuetype
            // 
            this.valuetype.Controls.Add(this.valueType4);
            this.valuetype.Controls.Add(this.valueType3Text);
            this.valuetype.Controls.Add(this.valueType3);
            this.valuetype.Controls.Add(this.valueType2);
            this.valuetype.Controls.Add(this.valueType1);
            this.valuetype.ForeColor = System.Drawing.Color.RoyalBlue;
            this.valuetype.Location = new System.Drawing.Point(709, 7);
            this.valuetype.Name = "valuetype";
            this.valuetype.Size = new System.Drawing.Size(182, 113);
            this.valuetype.TabIndex = 66;
            this.valuetype.TabStop = false;
            this.valuetype.Text = "action";
            // 
            // valueType4
            // 
            this.valueType4.AutoSize = true;
            this.valueType4.Checked = true;
            this.valueType4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.valueType4.Location = new System.Drawing.Point(16, 77);
            this.valueType4.Name = "valueType4";
            this.valueType4.Size = new System.Drawing.Size(157, 21);
            this.valueType4.TabIndex = 3;
            this.valueType4.TabStop = true;
            this.valueType4.Text = "SNVT_switch toggle";
            this.valueType4.UseVisualStyleBackColor = true;
            this.valueType4.CheckedChanged += new System.EventHandler(this.valueType1_CheckedChanged);
            // 
            // valueType3Text
            // 
            this.valueType3Text.Enabled = false;
            this.valueType3Text.Location = new System.Drawing.Point(119, 161);
            this.valueType3Text.Name = "valueType3Text";
            this.valueType3Text.Size = new System.Drawing.Size(63, 24);
            this.valueType3Text.TabIndex = 2;
            this.valueType3Text.Text = "0";
            this.valueType3Text.Visible = false;
            // 
            // valueType3
            // 
            this.valueType3.AutoSize = true;
            this.valueType3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.valueType3.Location = new System.Drawing.Point(16, 162);
            this.valueType3.Name = "valueType3";
            this.valueType3.Size = new System.Drawing.Size(97, 21);
            this.valueType3.TabIndex = 1;
            this.valueType3.Text = "Customize";
            this.valueType3.UseVisualStyleBackColor = true;
            this.valueType3.Visible = false;
            this.valueType3.CheckedChanged += new System.EventHandler(this.valueType1_CheckedChanged);
            // 
            // valueType2
            // 
            this.valueType2.AutoSize = true;
            this.valueType2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.valueType2.Location = new System.Drawing.Point(16, 50);
            this.valueType2.Name = "valueType2";
            this.valueType2.Size = new System.Drawing.Size(134, 21);
            this.valueType2.TabIndex = 1;
            this.valueType2.Text = "SNVT_switch off";
            this.valueType2.UseVisualStyleBackColor = true;
            this.valueType2.CheckedChanged += new System.EventHandler(this.valueType1_CheckedChanged);
            // 
            // valueType1
            // 
            this.valueType1.AutoSize = true;
            this.valueType1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.valueType1.Location = new System.Drawing.Point(16, 23);
            this.valueType1.Name = "valueType1";
            this.valueType1.Size = new System.Drawing.Size(134, 21);
            this.valueType1.TabIndex = 1;
            this.valueType1.Text = "SNVT_switch on";
            this.valueType1.UseVisualStyleBackColor = true;
            this.valueType1.CheckedChanged += new System.EventHandler(this.valueType1_CheckedChanged);
            // 
            // targetindex
            // 
            this.targetindex.AutoSize = true;
            this.targetindex.Location = new System.Drawing.Point(508, 476);
            this.targetindex.Name = "targetindex";
            this.targetindex.Size = new System.Drawing.Size(0, 17);
            this.targetindex.TabIndex = 67;
            this.targetindex.Visible = false;
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
            this.edit.Location = new System.Drawing.Point(709, 127);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(182, 130);
            this.edit.TabIndex = 68;
            this.edit.TabStop = false;
            this.edit.Text = "location";
            // 
            // textheight
            // 
            this.textheight.Location = new System.Drawing.Point(102, 53);
            this.textheight.Name = "textheight";
            this.textheight.Size = new System.Drawing.Size(45, 24);
            this.textheight.TabIndex = 59;
            this.textheight.Text = "22";
            // 
            // textwidth
            // 
            this.textwidth.Location = new System.Drawing.Point(102, 23);
            this.textwidth.Name = "textwidth";
            this.textwidth.Size = new System.Drawing.Size(45, 24);
            this.textwidth.TabIndex = 58;
            this.textwidth.Text = "53";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(41, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "height :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(46, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "width :";
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(128, 95);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(45, 24);
            this.textY.TabIndex = 55;
            this.textY.Text = "0";
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(46, 95);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(45, 24);
            this.textX.TabIndex = 54;
            this.textX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(97, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 53;
            this.label3.Text = "Y :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "X :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GroupContact);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(709, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 113);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "event";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox3.Location = new System.Drawing.Point(22, 122);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(94, 21);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "send SMS";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox2.Location = new System.Drawing.Point(22, 50);
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
            this.checkBox1.Location = new System.Drawing.Point(22, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "event log";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(518, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "message :";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(601, 386);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(286, 67);
            this.description.TabIndex = 71;
            // 
            // GroupContact
            // 
            this.GroupContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupContact.Enabled = false;
            this.GroupContact.FormattingEnabled = true;
            this.GroupContact.Location = new System.Drawing.Point(6, 77);
            this.GroupContact.Name = "GroupContact";
            this.GroupContact.Size = new System.Drawing.Size(170, 25);
            this.GroupContact.TabIndex = 79;
            // 
            // config_OutputObjectButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(899, 506);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.targetindex);
            this.Controls.Add(this.valuetype);
            this.Controls.Add(this.buttontype);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Labtext);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_OutputObjectButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "config_OutputObjectButton";
            this.Load += new System.EventHandler(this.config_OutputObjectButton_Load);
            this.buttontype.ResumeLayout(false);
            this.buttontype.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knob1Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.push2Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchImg)).EndInit();
            this.valuetype.ResumeLayout(false);
            this.valuetype.PerformLayout();
            this.edit.ResumeLayout(false);
            this.edit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView deviceList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Labtext;
        private System.Windows.Forms.GroupBox buttontype;
        private System.Windows.Forms.PictureBox pushImg;
        private System.Windows.Forms.PictureBox switchImg;
        private System.Windows.Forms.RadioButton buttonType2;
        private System.Windows.Forms.RadioButton buttonType1;
        private System.Windows.Forms.GroupBox valuetype;
        private System.Windows.Forms.RadioButton valueType3;
        private System.Windows.Forms.RadioButton valueType2;
        private System.Windows.Forms.RadioButton valueType1;
        private System.Windows.Forms.TextBox valueType3Text;
        private System.Windows.Forms.PictureBox push2Img;
        private System.Windows.Forms.RadioButton buttonType3;
        private System.Windows.Forms.PictureBox knob1Img;
        private System.Windows.Forms.RadioButton buttonType4;
        private System.Windows.Forms.Label targetindex;
        private System.Windows.Forms.GroupBox edit;
        private System.Windows.Forms.TextBox textheight;
        private System.Windows.Forms.TextBox textwidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton valueType4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label OFFlab;
        private System.Windows.Forms.Label ONlab;
        private System.Windows.Forms.PictureBox userOFF;
        private System.Windows.Forms.PictureBox userON;
        private System.Windows.Forms.RadioButton buttonType5;
        private System.Windows.Forms.Button offimage;
        private System.Windows.Forms.Button onimage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.ComboBox GroupContact;
    }
}