namespace nico_database
{
    partial class search_tagData_Show
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMD_print = new System.Windows.Forms.Button();
            this.CMD_csv = new System.Windows.Forms.Button();
            this.CMD_chart = new System.Windows.Forms.Button();
            this.CMD_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.site = new System.Windows.Forms.Label();
            this.fab = new System.Windows.Forms.Label();
            this.area = new System.Windows.Forms.Label();
            this.device = new System.Windows.Forms.Label();
            this.function = new System.Windows.Forms.Label();
            this.nv = new System.Windows.Forms.Label();
            this.nvType = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.Label();
            this.index = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.time,
            this.value});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(420, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 150;
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "time";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 120;
            // 
            // value
            // 
            this.value.DataPropertyName = "NVvalue_real";
            this.value.HeaderText = "value";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Width = 150;
            // 
            // CMD_print
            // 
            this.CMD_print.Location = new System.Drawing.Point(479, 353);
            this.CMD_print.Name = "CMD_print";
            this.CMD_print.Size = new System.Drawing.Size(94, 26);
            this.CMD_print.TabIndex = 1;
            this.CMD_print.Text = "Print";
            this.CMD_print.UseVisualStyleBackColor = true;
            this.CMD_print.Visible = false;
            this.CMD_print.Click += new System.EventHandler(this.CMD_print_Click);
            // 
            // CMD_csv
            // 
            this.CMD_csv.Location = new System.Drawing.Point(479, 322);
            this.CMD_csv.Name = "CMD_csv";
            this.CMD_csv.Size = new System.Drawing.Size(94, 26);
            this.CMD_csv.TabIndex = 2;
            this.CMD_csv.Text = "Export";
            this.CMD_csv.UseVisualStyleBackColor = true;
            this.CMD_csv.Click += new System.EventHandler(this.CMD_csv_Click);
            // 
            // CMD_chart
            // 
            this.CMD_chart.Location = new System.Drawing.Point(579, 322);
            this.CMD_chart.Name = "CMD_chart";
            this.CMD_chart.Size = new System.Drawing.Size(94, 26);
            this.CMD_chart.TabIndex = 3;
            this.CMD_chart.Text = "Chart";
            this.CMD_chart.UseVisualStyleBackColor = true;
            this.CMD_chart.Click += new System.EventHandler(this.CMD_chart_Click);
            // 
            // CMD_exit
            // 
            this.CMD_exit.Location = new System.Drawing.Point(579, 354);
            this.CMD_exit.Name = "CMD_exit";
            this.CMD_exit.Size = new System.Drawing.Size(94, 26);
            this.CMD_exit.TabIndex = 4;
            this.CMD_exit.Text = "Close";
            this.CMD_exit.UseVisualStyleBackColor = true;
            this.CMD_exit.Click += new System.EventHandler(this.CMD_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "site : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "fab : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "area : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "device : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "function : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "NVname : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "NVtype : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "description : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(498, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "ip : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(460, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "index id : ";
            // 
            // site
            // 
            this.site.AutoSize = true;
            this.site.Location = new System.Drawing.Point(528, 12);
            this.site.Name = "site";
            this.site.Size = new System.Drawing.Size(53, 17);
            this.site.TabIndex = 15;
            this.site.Text = "label11";
            // 
            // fab
            // 
            this.fab.AutoSize = true;
            this.fab.Location = new System.Drawing.Point(528, 37);
            this.fab.Name = "fab";
            this.fab.Size = new System.Drawing.Size(54, 17);
            this.fab.TabIndex = 16;
            this.fab.Text = "label12";
            // 
            // area
            // 
            this.area.AutoSize = true;
            this.area.Location = new System.Drawing.Point(528, 62);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(54, 17);
            this.area.TabIndex = 17;
            this.area.Text = "label13";
            // 
            // device
            // 
            this.device.AutoSize = true;
            this.device.Location = new System.Drawing.Point(528, 87);
            this.device.Name = "device";
            this.device.Size = new System.Drawing.Size(54, 17);
            this.device.TabIndex = 18;
            this.device.Text = "label14";
            // 
            // function
            // 
            this.function.AutoSize = true;
            this.function.Location = new System.Drawing.Point(528, 112);
            this.function.Name = "function";
            this.function.Size = new System.Drawing.Size(54, 17);
            this.function.TabIndex = 19;
            this.function.Text = "label15";
            // 
            // nv
            // 
            this.nv.AutoSize = true;
            this.nv.Location = new System.Drawing.Point(528, 139);
            this.nv.Name = "nv";
            this.nv.Size = new System.Drawing.Size(54, 17);
            this.nv.TabIndex = 20;
            this.nv.Text = "label16";
            // 
            // nvType
            // 
            this.nvType.AutoSize = true;
            this.nvType.Location = new System.Drawing.Point(528, 164);
            this.nvType.Name = "nvType";
            this.nvType.Size = new System.Drawing.Size(54, 17);
            this.nvType.TabIndex = 21;
            this.nvType.Text = "label17";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(528, 189);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(54, 17);
            this.description.TabIndex = 22;
            this.description.Text = "label18";
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Location = new System.Drawing.Point(528, 214);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(54, 17);
            this.ip.TabIndex = 23;
            this.ip.Text = "label19";
            // 
            // index
            // 
            this.index.AutoSize = true;
            this.index.Location = new System.Drawing.Point(528, 239);
            this.index.Name = "index";
            this.index.Size = new System.Drawing.Size(54, 17);
            this.index.TabIndex = 24;
            this.index.Text = "label20";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(441, 265);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 17);
            this.label21.TabIndex = 25;
            this.label21.Text = "data count : ";
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(528, 265);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(54, 17);
            this.count.TabIndex = 26;
            this.count.Text = "label22";
            // 
            // search_tagData_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(709, 391);
            this.Controls.Add(this.count);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.index);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.description);
            this.Controls.Add(this.nvType);
            this.Controls.Add(this.nv);
            this.Controls.Add(this.function);
            this.Controls.Add(this.device);
            this.Controls.Add(this.area);
            this.Controls.Add(this.fab);
            this.Controls.Add(this.site);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMD_exit);
            this.Controls.Add(this.CMD_chart);
            this.Controls.Add(this.CMD_csv);
            this.Controls.Add(this.CMD_print);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "search_tagData_Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "search_tagData_Show";
            this.Load += new System.EventHandler(this.search_tagData_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CMD_print;
        private System.Windows.Forms.Button CMD_csv;
        private System.Windows.Forms.Button CMD_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label site;
        public System.Windows.Forms.Label fab;
        public System.Windows.Forms.Label area;
        public System.Windows.Forms.Label device;
        public System.Windows.Forms.Label function;
        public System.Windows.Forms.Label nv;
        public System.Windows.Forms.Label nvType;
        public System.Windows.Forms.Label description;
        public System.Windows.Forms.Label ip;
        public System.Windows.Forms.Label index;
        public System.Windows.Forms.Label count;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.Button CMD_chart;
    }
}