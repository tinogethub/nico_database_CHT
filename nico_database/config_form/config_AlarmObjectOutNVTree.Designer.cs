namespace nico_database
{
    partial class config_AlarmObjectOutNVTree
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
            this.Labtext = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.valueON = new System.Windows.Forms.RadioButton();
            this.valueOFF = new System.Windows.Forms.RadioButton();
            this.valueCustomize = new System.Windows.Forms.RadioButton();
            this.inputValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // targetindex
            // 
            this.targetindex.AutoSize = true;
            this.targetindex.Location = new System.Drawing.Point(508, 476);
            this.targetindex.Name = "targetindex";
            this.targetindex.Size = new System.Drawing.Size(0, 17);
            this.targetindex.TabIndex = 71;
            this.targetindex.Visible = false;
            // 
            // deviceList
            // 
            this.deviceList.Location = new System.Drawing.Point(7, 37);
            this.deviceList.Name = "deviceList";
            this.deviceList.ShowNodeToolTips = true;
            this.deviceList.Size = new System.Drawing.Size(490, 461);
            this.deviceList.TabIndex = 70;
            this.deviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.deviceList_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "Target :";
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
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 10F);
            this.button3.Location = new System.Drawing.Point(397, 504);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 26);
            this.button3.TabIndex = 73;
            this.button3.Text = "apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10F);
            this.button2.Location = new System.Drawing.Point(291, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 72;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // valueON
            // 
            this.valueON.AutoSize = true;
            this.valueON.Checked = true;
            this.valueON.Location = new System.Drawing.Point(7, 506);
            this.valueON.Name = "valueON";
            this.valueON.Size = new System.Drawing.Size(42, 21);
            this.valueON.TabIndex = 74;
            this.valueON.TabStop = true;
            this.valueON.Text = "on";
            this.valueON.UseVisualStyleBackColor = true;
            this.valueON.CheckedChanged += new System.EventHandler(this.valueON_CheckedChanged);
            // 
            // valueOFF
            // 
            this.valueOFF.AutoSize = true;
            this.valueOFF.Location = new System.Drawing.Point(55, 506);
            this.valueOFF.Name = "valueOFF";
            this.valueOFF.Size = new System.Drawing.Size(42, 21);
            this.valueOFF.TabIndex = 75;
            this.valueOFF.TabStop = true;
            this.valueOFF.Text = "off";
            this.valueOFF.UseVisualStyleBackColor = true;
            this.valueOFF.CheckedChanged += new System.EventHandler(this.valueOFF_CheckedChanged);
            // 
            // valueCustomize
            // 
            this.valueCustomize.AutoSize = true;
            this.valueCustomize.Location = new System.Drawing.Point(103, 506);
            this.valueCustomize.Name = "valueCustomize";
            this.valueCustomize.Size = new System.Drawing.Size(94, 21);
            this.valueCustomize.TabIndex = 76;
            this.valueCustomize.TabStop = true;
            this.valueCustomize.Text = "customize";
            this.valueCustomize.UseVisualStyleBackColor = true;
            // 
            // inputValue
            // 
            this.inputValue.Location = new System.Drawing.Point(203, 505);
            this.inputValue.Name = "inputValue";
            this.inputValue.Size = new System.Drawing.Size(71, 24);
            this.inputValue.TabIndex = 77;
            this.inputValue.Text = "0";
            // 
            // config_AlarmObjectOutNVTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(505, 536);
            this.Controls.Add(this.inputValue);
            this.Controls.Add(this.valueCustomize);
            this.Controls.Add(this.valueOFF);
            this.Controls.Add(this.valueON);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.targetindex);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Labtext);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_AlarmObjectOutNVTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "config_AlarmObjectOutNVTree";
            this.Load += new System.EventHandler(this.config_AlarmObjectOutNVTree_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView deviceList;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label targetindex;
        public System.Windows.Forms.TextBox Labtext;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton valueON;
        private System.Windows.Forms.RadioButton valueOFF;
        private System.Windows.Forms.RadioButton valueCustomize;
        private System.Windows.Forms.TextBox inputValue;
    }
}