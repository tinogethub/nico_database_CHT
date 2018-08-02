using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace nico_database
{
    public partial class config_AlarmObjectNVType : Form
    {
        public config_AlarmObjectNVType()
        {
            InitializeComponent();
        }

        private void config_AlarmObjectNVType_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader rd = new StreamReader(Application.StartupPath + @"\Resources\SNVTtype.txt");
                while (rd.EndOfStream == false)
                {
                    //string[] getConfig = rd.ReadLine().Split('#');
                    string getNV = rd.ReadLine();
                    NVType.Items.Add(getNV);
                }

                NVType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            if (button1.Checked == true)
            {
                lForm1.ReoutputNV = "alarm@" + NVType.Text;

                if (NVType.Text == "SNVT_switch")
                {
                    if (radioButton1.Checked == true)
                    { lForm1.nvPart = "value"; }
                    else if (radioButton2.Checked == true)
                    { lForm1.nvPart = "status"; }
                }
                else
                {
                    lForm1.nvPart = "";
                }

            }
            else if (button2.Checked == true)
            {
                lForm1.ReoutputNV = "alarm@device";
                lForm1.nvPart = "";
            }
            Close();
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReoutputNV = null;
            Close();
        }

        private void button1_CheckedChanged(object sender, EventArgs e)
        {
            if (button1.Checked == true)
            {
                NVType.Enabled = true;
            }
        }

        private void button2_CheckedChanged(object sender, EventArgs e)
        {
            if (button2.Checked == true)
            {
                NVType.Enabled = false;
            }
        }

        private void NVType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NVType.Text == "SNVT_switch")
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

    }
}
