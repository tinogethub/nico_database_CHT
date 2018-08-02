namespace nico_database
{
    partial class Layer_edit
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.copyLayer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.layerDisplayZoom = new System.Windows.Forms.Button();
            this.layerDisplayClear = new System.Windows.Forms.Button();
            this.layerDisplayColor = new System.Windows.Forms.Button();
            this.layerDisplayFull = new System.Windows.Forms.Button();
            this.layerIMGChoose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.layerName = new System.Windows.Forms.TextBox();
            this.layerDelAllCmd = new System.Windows.Forms.Button();
            this.layerDelCmd = new System.Windows.Forms.Button();
            this.layerAddCmd = new System.Windows.Forms.Button();
            this.layerRenameCmd = new System.Windows.Forms.Button();
            this.layerListBox = new System.Windows.Forms.ListBox();
            this.layerBackgroundGroup = new System.Windows.Forms.GroupBox();
            this.layerBackground = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.layerBackgroundGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.copyLayer);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.layerListBox);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 311);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Layer list";
            // 
            // copyLayer
            // 
            this.copyLayer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.copyLayer.Location = new System.Drawing.Point(397, 271);
            this.copyLayer.Name = "copyLayer";
            this.copyLayer.Size = new System.Drawing.Size(67, 25);
            this.copyLayer.TabIndex = 11;
            this.copyLayer.Text = "duplicate";
            this.copyLayer.UseVisualStyleBackColor = true;
            this.copyLayer.Visible = false;
            this.copyLayer.Click += new System.EventHandler(this.copyLayer_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(283, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "exit edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.layerDisplayZoom);
            this.groupBox5.Controls.Add(this.layerDisplayClear);
            this.groupBox5.Controls.Add(this.layerDisplayColor);
            this.groupBox5.Controls.Add(this.layerDisplayFull);
            this.groupBox5.Controls.Add(this.layerIMGChoose);
            this.groupBox5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox5.Location = new System.Drawing.Point(266, 146);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(254, 119);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Layer image edit";
            // 
            // layerDisplayZoom
            // 
            this.layerDisplayZoom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerDisplayZoom.Location = new System.Drawing.Point(17, 87);
            this.layerDisplayZoom.Name = "layerDisplayZoom";
            this.layerDisplayZoom.Size = new System.Drawing.Size(108, 26);
            this.layerDisplayZoom.TabIndex = 9;
            this.layerDisplayZoom.Text = "1:1 image";
            this.layerDisplayZoom.UseVisualStyleBackColor = true;
            this.layerDisplayZoom.Click += new System.EventHandler(this.layerDisplayZoom_Click);
            // 
            // layerDisplayClear
            // 
            this.layerDisplayClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerDisplayClear.Location = new System.Drawing.Point(131, 87);
            this.layerDisplayClear.Name = "layerDisplayClear";
            this.layerDisplayClear.Size = new System.Drawing.Size(108, 26);
            this.layerDisplayClear.TabIndex = 8;
            this.layerDisplayClear.Text = "clear";
            this.layerDisplayClear.UseVisualStyleBackColor = true;
            this.layerDisplayClear.Click += new System.EventHandler(this.layerDisplayClear_Click);
            // 
            // layerDisplayColor
            // 
            this.layerDisplayColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerDisplayColor.Location = new System.Drawing.Point(131, 55);
            this.layerDisplayColor.Name = "layerDisplayColor";
            this.layerDisplayColor.Size = new System.Drawing.Size(108, 26);
            this.layerDisplayColor.TabIndex = 7;
            this.layerDisplayColor.Text = "backcolor";
            this.layerDisplayColor.UseVisualStyleBackColor = true;
            this.layerDisplayColor.Click += new System.EventHandler(this.layerDisplayColor_Click);
            // 
            // layerDisplayFull
            // 
            this.layerDisplayFull.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerDisplayFull.Location = new System.Drawing.Point(17, 55);
            this.layerDisplayFull.Name = "layerDisplayFull";
            this.layerDisplayFull.Size = new System.Drawing.Size(108, 26);
            this.layerDisplayFull.TabIndex = 6;
            this.layerDisplayFull.Text = "full image";
            this.layerDisplayFull.UseVisualStyleBackColor = true;
            this.layerDisplayFull.Click += new System.EventHandler(this.layerDisplayFull_Click);
            // 
            // layerIMGChoose
            // 
            this.layerIMGChoose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerIMGChoose.Location = new System.Drawing.Point(17, 23);
            this.layerIMGChoose.Name = "layerIMGChoose";
            this.layerIMGChoose.Size = new System.Drawing.Size(222, 26);
            this.layerIMGChoose.TabIndex = 4;
            this.layerIMGChoose.Text = "choose background image";
            this.layerIMGChoose.UseVisualStyleBackColor = true;
            this.layerIMGChoose.Click += new System.EventHandler(this.layerIMGChoose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.layerName);
            this.groupBox4.Controls.Add(this.layerDelAllCmd);
            this.groupBox4.Controls.Add(this.layerDelCmd);
            this.groupBox4.Controls.Add(this.layerAddCmd);
            this.groupBox4.Controls.Add(this.layerRenameCmd);
            this.groupBox4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox4.Location = new System.Drawing.Point(266, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 118);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Layer edit";
            // 
            // layerName
            // 
            this.layerName.Location = new System.Drawing.Point(17, 23);
            this.layerName.Name = "layerName";
            this.layerName.Size = new System.Drawing.Size(222, 24);
            this.layerName.TabIndex = 5;
            this.layerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.layerName_KeyDown);
            // 
            // layerDelAllCmd
            // 
            this.layerDelAllCmd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerDelAllCmd.Location = new System.Drawing.Point(131, 85);
            this.layerDelAllCmd.Name = "layerDelAllCmd";
            this.layerDelAllCmd.Size = new System.Drawing.Size(108, 26);
            this.layerDelAllCmd.TabIndex = 4;
            this.layerDelAllCmd.Text = "del all";
            this.layerDelAllCmd.UseVisualStyleBackColor = true;
            this.layerDelAllCmd.Click += new System.EventHandler(this.layerDelAllCmd_Click);
            // 
            // layerDelCmd
            // 
            this.layerDelCmd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerDelCmd.Location = new System.Drawing.Point(17, 85);
            this.layerDelCmd.Name = "layerDelCmd";
            this.layerDelCmd.Size = new System.Drawing.Size(108, 26);
            this.layerDelCmd.TabIndex = 2;
            this.layerDelCmd.Text = "del layer";
            this.layerDelCmd.UseVisualStyleBackColor = true;
            this.layerDelCmd.Click += new System.EventHandler(this.layerDelCmd_Click);
            // 
            // layerAddCmd
            // 
            this.layerAddCmd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerAddCmd.Location = new System.Drawing.Point(17, 53);
            this.layerAddCmd.Name = "layerAddCmd";
            this.layerAddCmd.Size = new System.Drawing.Size(108, 26);
            this.layerAddCmd.TabIndex = 1;
            this.layerAddCmd.Text = "add layer";
            this.layerAddCmd.UseVisualStyleBackColor = true;
            this.layerAddCmd.Click += new System.EventHandler(this.layerAddCmd_Click);
            // 
            // layerRenameCmd
            // 
            this.layerRenameCmd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerRenameCmd.Location = new System.Drawing.Point(131, 53);
            this.layerRenameCmd.Name = "layerRenameCmd";
            this.layerRenameCmd.Size = new System.Drawing.Size(108, 26);
            this.layerRenameCmd.TabIndex = 3;
            this.layerRenameCmd.Text = "rename layer";
            this.layerRenameCmd.UseVisualStyleBackColor = true;
            this.layerRenameCmd.Click += new System.EventHandler(this.layerRenameCmd_Click);
            // 
            // layerListBox
            // 
            this.layerListBox.FormattingEnabled = true;
            this.layerListBox.ItemHeight = 17;
            this.layerListBox.Items.AddRange(new object[] {
            "0"});
            this.layerListBox.Location = new System.Drawing.Point(6, 22);
            this.layerListBox.Name = "layerListBox";
            this.layerListBox.Size = new System.Drawing.Size(254, 276);
            this.layerListBox.TabIndex = 0;
            this.layerListBox.SelectedIndexChanged += new System.EventHandler(this.layerListBox_SelectedIndexChanged);
            // 
            // layerBackgroundGroup
            // 
            this.layerBackgroundGroup.Controls.Add(this.layerBackground);
            this.layerBackgroundGroup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.layerBackgroundGroup.Location = new System.Drawing.Point(542, 6);
            this.layerBackgroundGroup.Name = "layerBackgroundGroup";
            this.layerBackgroundGroup.Size = new System.Drawing.Size(370, 311);
            this.layerBackgroundGroup.TabIndex = 2;
            this.layerBackgroundGroup.TabStop = false;
            this.layerBackgroundGroup.Text = "layer_0";
            // 
            // layerBackground
            // 
            this.layerBackground.BackColor = System.Drawing.SystemColors.Control;
            this.layerBackground.Location = new System.Drawing.Point(8, 59);
            this.layerBackground.Name = "layerBackground";
            this.layerBackground.Size = new System.Drawing.Size(352, 198);
            this.layerBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.layerBackground.TabIndex = 0;
            this.layerBackground.TabStop = false;
            // 
            // Layer_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(923, 326);
            this.Controls.Add(this.layerBackgroundGroup);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Layer_edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layer_edit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Layer_edit_FormClosed);
            this.Load += new System.EventHandler(this.Layer_edit_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.layerBackgroundGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button layerDisplayClear;
        private System.Windows.Forms.Button layerDisplayColor;
        private System.Windows.Forms.Button layerDisplayFull;
        private System.Windows.Forms.Button layerIMGChoose;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox layerName;
        private System.Windows.Forms.Button layerDelAllCmd;
        private System.Windows.Forms.Button layerDelCmd;
        private System.Windows.Forms.Button layerAddCmd;
        private System.Windows.Forms.Button layerRenameCmd;
        public System.Windows.Forms.ListBox layerListBox;
        private System.Windows.Forms.GroupBox layerBackgroundGroup;
        private System.Windows.Forms.PictureBox layerBackground;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button layerDisplayZoom;
        private System.Windows.Forms.Button copyLayer;

    }
}