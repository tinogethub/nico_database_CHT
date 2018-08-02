namespace nico_database
{
    partial class AddDeviceTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDeviceTree));
            this.g2 = new System.Windows.Forms.GroupBox();
            this.useInput = new System.Windows.Forms.CheckBox();
            this.LonDeviceListPath = new System.Windows.Forms.ListBox();
            this.LonDeviceList = new System.Windows.Forms.ListBox();
            this.CMDgetLonDevice = new System.Windows.Forms.Button();
            this.Lonip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.g1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.nicoip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CMDApply = new System.Windows.Forms.Button();
            this.CMDCancel = new System.Windows.Forms.Button();
            this.potocolType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.waitIMG = new System.Windows.Forms.PictureBox();
            this.backSOAP = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tempListpath = new System.Windows.Forms.ListBox();
            this.useTemp = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tempList = new System.Windows.Forms.ListBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.g2.SuspendLayout();
            this.g1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitIMG)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // g2
            // 
            this.g2.Controls.Add(this.useInput);
            this.g2.Controls.Add(this.LonDeviceListPath);
            this.g2.Controls.Add(this.LonDeviceList);
            this.g2.Controls.Add(this.CMDgetLonDevice);
            this.g2.Controls.Add(this.Lonip);
            this.g2.Controls.Add(this.label3);
            this.g2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.g2.Location = new System.Drawing.Point(12, 39);
            this.g2.Name = "g2";
            this.g2.Size = new System.Drawing.Size(253, 299);
            this.g2.TabIndex = 12;
            this.g2.TabStop = false;
            this.g2.Text = "select device";
            // 
            // useInput
            // 
            this.useInput.AutoSize = true;
            this.useInput.Checked = true;
            this.useInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useInput.Location = new System.Drawing.Point(220, 40);
            this.useInput.Name = "useInput";
            this.useInput.Size = new System.Drawing.Size(15, 14);
            this.useInput.TabIndex = 9;
            this.useInput.UseVisualStyleBackColor = true;
            this.useInput.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LonDeviceListPath
            // 
            this.LonDeviceListPath.FormattingEnabled = true;
            this.LonDeviceListPath.ItemHeight = 17;
            this.LonDeviceListPath.Location = new System.Drawing.Point(323, 106);
            this.LonDeviceListPath.Name = "LonDeviceListPath";
            this.LonDeviceListPath.Size = new System.Drawing.Size(221, 174);
            this.LonDeviceListPath.TabIndex = 8;
            // 
            // LonDeviceList
            // 
            this.LonDeviceList.FormattingEnabled = true;
            this.LonDeviceList.ItemHeight = 17;
            this.LonDeviceList.Location = new System.Drawing.Point(21, 103);
            this.LonDeviceList.Name = "LonDeviceList";
            this.LonDeviceList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.LonDeviceList.Size = new System.Drawing.Size(221, 191);
            this.LonDeviceList.TabIndex = 7;
            this.LonDeviceList.SelectedIndexChanged += new System.EventHandler(this.LonDeviceList_SelectedIndexChanged);
            // 
            // CMDgetLonDevice
            // 
            this.CMDgetLonDevice.Location = new System.Drawing.Point(21, 68);
            this.CMDgetLonDevice.Name = "CMDgetLonDevice";
            this.CMDgetLonDevice.Size = new System.Drawing.Size(221, 29);
            this.CMDgetLonDevice.TabIndex = 6;
            this.CMDgetLonDevice.Text = "get device";
            this.CMDgetLonDevice.UseVisualStyleBackColor = true;
            this.CMDgetLonDevice.Click += new System.EventHandler(this.CMDgetLonDevice_Click);
            // 
            // Lonip
            // 
            this.Lonip.Location = new System.Drawing.Point(92, 34);
            this.Lonip.Margin = new System.Windows.Forms.Padding(4);
            this.Lonip.Name = "Lonip";
            this.Lonip.Size = new System.Drawing.Size(117, 24);
            this.Lonip.TabIndex = 4;
            this.Lonip.Text = "192.168.1.222";
            this.Lonip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lonip_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(18, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "input ip :";
            // 
            // g1
            // 
            this.g1.Controls.Add(this.label2);
            this.g1.Controls.Add(this.comboBox1);
            this.g1.Controls.Add(this.nicoip);
            this.g1.Controls.Add(this.label1);
            this.g1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.g1.Location = new System.Drawing.Point(562, 48);
            this.g1.Name = "g1";
            this.g1.Size = new System.Drawing.Size(253, 107);
            this.g1.TabIndex = 11;
            this.g1.TabStop = false;
            this.g1.Text = "select device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "device :";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "8108D",
            "8404D"});
            this.comboBox1.Location = new System.Drawing.Point(81, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 25);
            this.comboBox1.TabIndex = 0;
            // 
            // nicoip
            // 
            this.nicoip.Location = new System.Drawing.Point(81, 34);
            this.nicoip.Margin = new System.Windows.Forms.Padding(4);
            this.nicoip.Name = "nicoip";
            this.nicoip.Size = new System.Drawing.Size(150, 24);
            this.nicoip.TabIndex = 2;
            this.nicoip.Text = "192.168.1.222";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "input ip :";
            // 
            // CMDApply
            // 
            this.CMDApply.Location = new System.Drawing.Point(392, 309);
            this.CMDApply.Margin = new System.Windows.Forms.Padding(4);
            this.CMDApply.Name = "CMDApply";
            this.CMDApply.Size = new System.Drawing.Size(112, 28);
            this.CMDApply.TabIndex = 8;
            this.CMDApply.Text = "apply";
            this.CMDApply.UseVisualStyleBackColor = true;
            this.CMDApply.Click += new System.EventHandler(this.CMDApply_Click);
            // 
            // CMDCancel
            // 
            this.CMDCancel.Location = new System.Drawing.Point(272, 309);
            this.CMDCancel.Margin = new System.Windows.Forms.Padding(4);
            this.CMDCancel.Name = "CMDCancel";
            this.CMDCancel.Size = new System.Drawing.Size(112, 28);
            this.CMDCancel.TabIndex = 7;
            this.CMDCancel.Text = "cancel";
            this.CMDCancel.UseVisualStyleBackColor = true;
            this.CMDCancel.Click += new System.EventHandler(this.CMDCancel_Click);
            // 
            // potocolType
            // 
            this.potocolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.potocolType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.potocolType.FormattingEnabled = true;
            this.potocolType.Items.AddRange(new object[] {
            "Lon",
            "Nico"});
            this.potocolType.Location = new System.Drawing.Point(81, 8);
            this.potocolType.Name = "potocolType";
            this.potocolType.Size = new System.Drawing.Size(68, 25);
            this.potocolType.TabIndex = 13;
            this.potocolType.SelectedIndexChanged += new System.EventHandler(this.potocolType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(12, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "potocol :";
            // 
            // waitIMG
            // 
            this.waitIMG.Image = ((System.Drawing.Image)(resources.GetObject("waitIMG.Image")));
            this.waitIMG.Location = new System.Drawing.Point(187, 99);
            this.waitIMG.Name = "waitIMG";
            this.waitIMG.Size = new System.Drawing.Size(150, 150);
            this.waitIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.waitIMG.TabIndex = 15;
            this.waitIMG.TabStop = false;
            this.waitIMG.Visible = false;
            // 
            // backSOAP
            // 
            this.backSOAP.WorkerReportsProgress = true;
            this.backSOAP.WorkerSupportsCancellation = true;
            this.backSOAP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backSOAP_DoWork);
            this.backSOAP.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backSOAP_ProgressChanged);
            this.backSOAP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backSOAP_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(516, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = false;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(807, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "none";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // connectStop
            // 
            this.connectStop.ForeColor = System.Drawing.Color.Maroon;
            this.connectStop.Location = new System.Drawing.Point(187, 259);
            this.connectStop.Margin = new System.Windows.Forms.Padding(4);
            this.connectStop.Name = "connectStop";
            this.connectStop.Size = new System.Drawing.Size(150, 28);
            this.connectStop.TabIndex = 17;
            this.connectStop.Text = "connect stop";
            this.connectStop.UseVisualStyleBackColor = true;
            this.connectStop.Visible = false;
            this.connectStop.Click += new System.EventHandler(this.connectStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tempListpath);
            this.groupBox1.Controls.Add(this.useTemp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tempList);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(271, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 263);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "temporary";
            // 
            // tempListpath
            // 
            this.tempListpath.Enabled = false;
            this.tempListpath.FormattingEnabled = true;
            this.tempListpath.ItemHeight = 17;
            this.tempListpath.Location = new System.Drawing.Point(6, 270);
            this.tempListpath.Name = "tempListpath";
            this.tempListpath.Size = new System.Drawing.Size(221, 72);
            this.tempListpath.TabIndex = 22;
            this.tempListpath.Visible = false;
            // 
            // useTemp
            // 
            this.useTemp.AutoSize = true;
            this.useTemp.Location = new System.Drawing.Point(206, 40);
            this.useTemp.Name = "useTemp";
            this.useTemp.Size = new System.Drawing.Size(15, 14);
            this.useTemp.TabIndex = 21;
            this.useTemp.UseVisualStyleBackColor = true;
            this.useTemp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(11, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "ip :";
            // 
            // tempList
            // 
            this.tempList.Enabled = false;
            this.tempList.FormattingEnabled = true;
            this.tempList.ItemHeight = 17;
            this.tempList.Location = new System.Drawing.Point(6, 69);
            this.tempList.Name = "tempList";
            this.tempList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.tempList.Size = new System.Drawing.Size(221, 191);
            this.tempList.TabIndex = 19;
            this.tempList.SelectedIndexChanged += new System.EventHandler(this.tempList_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(45, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(150, 25);
            this.comboBox2.TabIndex = 18;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // AddDeviceTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(516, 368);
            this.Controls.Add(this.connectStop);
            this.Controls.Add(this.waitIMG);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.potocolType);
            this.Controls.Add(this.g2);
            this.Controls.Add(this.g1);
            this.Controls.Add(this.CMDApply);
            this.Controls.Add(this.CMDCancel);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDeviceTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDeviceTree";
            this.Load += new System.EventHandler(this.AddDeviceTree_Load);
            this.Resize += new System.EventHandler(this.AddDeviceTree_Resize);
            this.g2.ResumeLayout(false);
            this.g2.PerformLayout();
            this.g1.ResumeLayout(false);
            this.g1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitIMG)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox g2;
        private System.Windows.Forms.ListBox LonDeviceListPath;
        private System.Windows.Forms.ListBox LonDeviceList;
        private System.Windows.Forms.Button CMDgetLonDevice;
        private System.Windows.Forms.TextBox Lonip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox g1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox nicoip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CMDApply;
        private System.Windows.Forms.Button CMDCancel;
        private System.Windows.Forms.ComboBox potocolType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox waitIMG;
        private System.ComponentModel.BackgroundWorker backSOAP;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button connectStop;
        private System.Windows.Forms.CheckBox useInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox useTemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox tempList;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListBox tempListpath;
    }
}