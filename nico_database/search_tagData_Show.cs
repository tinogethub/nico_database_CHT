using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace nico_database
{
    public partial class search_tagData_Show : Form
    {
        public string getPath="";
        public DataTable dt = new DataTable("chart_data");

        public search_tagData_Show()
        {
            InitializeComponent();
        }

        private void search_tagData_Show_Load(object sender, EventArgs e)
        {

        }

        private void CMD_chart_Click(object sender, EventArgs e)
        {
            // 根據 資料行0 (Name) 做 大到小 排序 
            //dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Descending);
            // 根據 資料行0 (Name) 做 小到大 排序 
            //dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            show_chart chartform = new show_chart();

            chartform.chart1.DataSource = dt;
            chartform.chart1.Series[0].ChartType = SeriesChartType.Line;
            chartform.chart1.Series[0].XValueMember = "dt";
            chartform.chart1.Series[0].YValueMembers = "NVvalue_real";

            chartform.chart1.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
            chartform.chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
            chartform.chart1.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;
            chartform.chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;

            chartform.chart1.DataBind();

            chartform.Show();
        }

        private void CMD_csv_Click(object sender, EventArgs e)
        {
            //string input_date2 = textBox1.Text;
            string strValue = string.Empty;
            //CSV 匯出的標題 要先塞一樣的格式字串 充當標題
            strValue = "id,list_id,NVvalue_txt,NVvalue_real,date,time";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dataGridView1[j, i].Value.ToString()))
                    {
                        if (j > 0)
                            strValue = strValue + "," + dataGridView1[j, i].Value.ToString();
                        else
                        {
                            if (string.IsNullOrEmpty(strValue))
                                strValue = dataGridView1[j, i].Value.ToString();
                            else
                                strValue = strValue + Environment.NewLine + dataGridView1[j, i].Value.ToString();
                        }
                    }
                }

            }
            //存成檔案（注意！！當有中文字的時候 存檔案一定要用 UTF8）
            //Stream myStream;
            SaveFileDialog fs = new SaveFileDialog() ;
            fs.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            fs.FilterIndex = 1;
            fs.RestoreDirectory = true;
            string savepath = "";
            if (fs.ShowDialog() == DialogResult.OK)
            {

                //if ((myStream = fs.OpenFile()) != null)
                //{
                string strFile = fs.FileName; //+ ".csv";

                    if (!string.IsNullOrEmpty(strValue))
                    {
                        File.WriteAllText(strFile, strValue, Encoding.UTF8);
                        MessageBox.Show("export success");
                    }

                    // Code to write the stream goes here.
                    //myStream.Close();
                //}
            }
            

        }

        private void CMD_print_Click(object sender, EventArgs e)
        {
            
        }

        private void CMD_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
