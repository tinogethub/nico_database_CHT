namespace nico_database
{
    partial class search_tagData
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
            this.radio_value = new System.Windows.Forms.RadioButton();
            this.radio_between = new System.Windows.Forms.RadioButton();
            this.panel_date = new System.Windows.Forms.Panel();
            this.to_time = new System.Windows.Forms.DateTimePicker();
            this.from_time = new System.Windows.Forms.DateTimePicker();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.from_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_value = new System.Windows.Forms.Panel();
            this.value1 = new System.Windows.Forms.TextBox();
            this.combo_value = new System.Windows.Forms.ComboBox();
            this.panel_between = new System.Windows.Forms.Panel();
            this.value2 = new System.Windows.Forms.TextBox();
            this.combo_between2 = new System.Windows.Forms.ComboBox();
            this.combo_between1 = new System.Windows.Forms.ComboBox();
            this.panel_allValue = new System.Windows.Forms.Panel();
            this.check_date = new System.Windows.Forms.CheckBox();
            this.check_value = new System.Windows.Forms.CheckBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.limit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.value3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_date.SuspendLayout();
            this.panel_value.SuspendLayout();
            this.panel_between.SuspendLayout();
            this.panel_allValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radio_value
            // 
            this.radio_value.AutoSize = true;
            this.radio_value.Checked = true;
            this.radio_value.Location = new System.Drawing.Point(8, 13);
            this.radio_value.Name = "radio_value";
            this.radio_value.Size = new System.Drawing.Size(60, 21);
            this.radio_value.TabIndex = 0;
            this.radio_value.TabStop = true;
            this.radio_value.Text = "value";
            this.radio_value.UseVisualStyleBackColor = true;
            this.radio_value.CheckedChanged += new System.EventHandler(this.radio_value_CheckedChanged);
            // 
            // radio_between
            // 
            this.radio_between.AutoSize = true;
            this.radio_between.Location = new System.Drawing.Point(8, 60);
            this.radio_between.Name = "radio_between";
            this.radio_between.Size = new System.Drawing.Size(81, 21);
            this.radio_between.TabIndex = 1;
            this.radio_between.Text = "between";
            this.radio_between.UseVisualStyleBackColor = true;
            this.radio_between.CheckedChanged += new System.EventHandler(this.radio_between_CheckedChanged);
            // 
            // panel_date
            // 
            this.panel_date.Controls.Add(this.to_time);
            this.panel_date.Controls.Add(this.from_time);
            this.panel_date.Controls.Add(this.to_date);
            this.panel_date.Controls.Add(this.from_date);
            this.panel_date.Controls.Add(this.label2);
            this.panel_date.Controls.Add(this.label1);
            this.panel_date.Location = new System.Drawing.Point(79, 12);
            this.panel_date.Name = "panel_date";
            this.panel_date.Size = new System.Drawing.Size(409, 76);
            this.panel_date.TabIndex = 3;
            // 
            // to_time
            // 
            this.to_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.to_time.Location = new System.Drawing.Point(264, 42);
            this.to_time.Name = "to_time";
            this.to_time.ShowUpDown = true;
            this.to_time.Size = new System.Drawing.Size(134, 24);
            this.to_time.TabIndex = 5;
            // 
            // from_time
            // 
            this.from_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.from_time.Location = new System.Drawing.Point(264, 4);
            this.from_time.Name = "from_time";
            this.from_time.ShowUpDown = true;
            this.from_time.Size = new System.Drawing.Size(134, 24);
            this.from_time.TabIndex = 4;
            // 
            // to_date
            // 
            this.to_date.Location = new System.Drawing.Point(58, 42);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(200, 24);
            this.to_date.TabIndex = 3;
            // 
            // from_date
            // 
            this.from_date.Location = new System.Drawing.Point(58, 4);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(198, 24);
            this.from_date.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "from";
            // 
            // panel_value
            // 
            this.panel_value.Controls.Add(this.value1);
            this.panel_value.Controls.Add(this.combo_value);
            this.panel_value.Location = new System.Drawing.Point(95, 3);
            this.panel_value.Name = "panel_value";
            this.panel_value.Size = new System.Drawing.Size(184, 41);
            this.panel_value.TabIndex = 4;
            // 
            // value1
            // 
            this.value1.Location = new System.Drawing.Point(74, 8);
            this.value1.Name = "value1";
            this.value1.Size = new System.Drawing.Size(100, 24);
            this.value1.TabIndex = 1;
            this.value1.Text = "0";
            this.value1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // combo_value
            // 
            this.combo_value.FormattingEnabled = true;
            this.combo_value.Items.AddRange(new object[] {
            "<",
            "<=",
            "==",
            ">=",
            ">"});
            this.combo_value.Location = new System.Drawing.Point(17, 8);
            this.combo_value.Name = "combo_value";
            this.combo_value.Size = new System.Drawing.Size(51, 25);
            this.combo_value.TabIndex = 0;
            this.combo_value.Text = "==";
            // 
            // panel_between
            // 
            this.panel_between.Controls.Add(this.label4);
            this.panel_between.Controls.Add(this.value3);
            this.panel_between.Controls.Add(this.value2);
            this.panel_between.Controls.Add(this.combo_between2);
            this.panel_between.Controls.Add(this.combo_between1);
            this.panel_between.Enabled = false;
            this.panel_between.Location = new System.Drawing.Point(95, 50);
            this.panel_between.Name = "panel_between";
            this.panel_between.Size = new System.Drawing.Size(368, 41);
            this.panel_between.TabIndex = 5;
            // 
            // value2
            // 
            this.value2.Location = new System.Drawing.Point(74, 9);
            this.value2.Name = "value2";
            this.value2.Size = new System.Drawing.Size(100, 24);
            this.value2.TabIndex = 2;
            this.value2.Text = "0";
            this.value2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // combo_between2
            // 
            this.combo_between2.FormattingEnabled = true;
            this.combo_between2.Items.AddRange(new object[] {
            "<",
            "<=",
            "==",
            ">=",
            ">"});
            this.combo_between2.Location = new System.Drawing.Point(203, 9);
            this.combo_between2.Name = "combo_between2";
            this.combo_between2.Size = new System.Drawing.Size(51, 25);
            this.combo_between2.TabIndex = 1;
            this.combo_between2.Text = "<=";
            // 
            // combo_between1
            // 
            this.combo_between1.FormattingEnabled = true;
            this.combo_between1.Items.AddRange(new object[] {
            "<",
            "<=",
            "==",
            ">=",
            ">"});
            this.combo_between1.Location = new System.Drawing.Point(17, 9);
            this.combo_between1.Name = "combo_between1";
            this.combo_between1.Size = new System.Drawing.Size(51, 25);
            this.combo_between1.TabIndex = 0;
            this.combo_between1.Text = ">=";
            // 
            // panel_allValue
            // 
            this.panel_allValue.Controls.Add(this.panel_value);
            this.panel_allValue.Controls.Add(this.panel_between);
            this.panel_allValue.Controls.Add(this.radio_value);
            this.panel_allValue.Controls.Add(this.radio_between);
            this.panel_allValue.Enabled = false;
            this.panel_allValue.Location = new System.Drawing.Point(79, 94);
            this.panel_allValue.Name = "panel_allValue";
            this.panel_allValue.Size = new System.Drawing.Size(469, 97);
            this.panel_allValue.TabIndex = 6;
            // 
            // check_date
            // 
            this.check_date.AutoSize = true;
            this.check_date.Checked = true;
            this.check_date.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_date.Location = new System.Drawing.Point(12, 12);
            this.check_date.Name = "check_date";
            this.check_date.Size = new System.Drawing.Size(55, 21);
            this.check_date.TabIndex = 7;
            this.check_date.Text = "date";
            this.check_date.UseVisualStyleBackColor = true;
            this.check_date.CheckedChanged += new System.EventHandler(this.check_date_CheckedChanged);
            // 
            // check_value
            // 
            this.check_value.AutoSize = true;
            this.check_value.Location = new System.Drawing.Point(12, 94);
            this.check_value.Name = "check_value";
            this.check_value.Size = new System.Drawing.Size(61, 21);
            this.check_value.TabIndex = 8;
            this.check_value.Text = "value";
            this.check_value.UseVisualStyleBackColor = true;
            this.check_value.CheckedChanged += new System.EventHandler(this.check_value_CheckedChanged);
            // 
            // cmdApply
            // 
            this.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdApply.Location = new System.Drawing.Point(464, 208);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(78, 25);
            this.cmdApply.TabIndex = 33;
            this.cmdApply.Text = "apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Location = new System.Drawing.Point(381, 208);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(78, 25);
            this.cmdCancel.TabIndex = 32;
            this.cmdCancel.Text = "cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // limit
            // 
            this.limit.Location = new System.Drawing.Point(148, 210);
            this.limit.Name = "limit";
            this.limit.Size = new System.Drawing.Size(64, 24);
            this.limit.TabIndex = 34;
            this.limit.Text = "10";
            this.limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "data limit";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 271);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(487, 119);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.Visible = false;
            // 
            // value3
            // 
            this.value3.Location = new System.Drawing.Point(260, 9);
            this.value3.Name = "value3";
            this.value3.Size = new System.Drawing.Size(100, 24);
            this.value3.TabIndex = 3;
            this.value3.Text = "0";
            this.value3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "~";
            // 
            // search_tagData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(555, 247);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.limit);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.check_value);
            this.Controls.Add(this.check_date);
            this.Controls.Add(this.panel_allValue);
            this.Controls.Add(this.panel_date);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "search_tagData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "search_tagData";
            this.Load += new System.EventHandler(this.search_tagData_Load);
            this.panel_date.ResumeLayout(false);
            this.panel_date.PerformLayout();
            this.panel_value.ResumeLayout(false);
            this.panel_value.PerformLayout();
            this.panel_between.ResumeLayout(false);
            this.panel_between.PerformLayout();
            this.panel_allValue.ResumeLayout(false);
            this.panel_allValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_value;
        private System.Windows.Forms.RadioButton radio_between;
        private System.Windows.Forms.Panel panel_date;
        private System.Windows.Forms.DateTimePicker to_time;
        private System.Windows.Forms.DateTimePicker from_time;
        private System.Windows.Forms.DateTimePicker to_date;
        private System.Windows.Forms.DateTimePicker from_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_value;
        private System.Windows.Forms.TextBox value1;
        private System.Windows.Forms.ComboBox combo_value;
        private System.Windows.Forms.Panel panel_between;
        private System.Windows.Forms.TextBox value2;
        private System.Windows.Forms.ComboBox combo_between2;
        private System.Windows.Forms.ComboBox combo_between1;
        private System.Windows.Forms.Panel panel_allValue;
        private System.Windows.Forms.CheckBox check_date;
        private System.Windows.Forms.CheckBox check_value;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox limit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox value3;
    }
}