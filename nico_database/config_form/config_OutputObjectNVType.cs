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
    public partial class config_OutputObjectNVType : Form
    {
        public config_OutputObjectNVType()
        {
            InitializeComponent();
        }

        private void config_OutputObjectNVType_Load(object sender, EventArgs e)
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

        private void NVType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton tar = (RadioButton)sender;

            if (tar.Name == "button1" && tar.Checked == true)
            { 
                NVType.Enabled = true; 
            }
            else if (tar.Name == "button2" && tar.Checked == true)
            {
                NVType.Enabled = false;
                NVType.Text = "SNVT_switch";
            }
            else if (tar.Name == "button3" && tar.Checked == true)
            {
                NVType.Enabled = true;
            }
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReoutputNV = null;
            Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            string info = "";
            
            if (button1.Checked == true)
            {
                info = "outputText";
            }
            else if (button2.Checked == true)
            {
                info = "switch";
            }
            else if (button3.Checked == true)
            {
                info = "pop";
            }
            info = info + "@" + NVType.Text;

            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReoutputNV = info;
            Close();
        }


    }
}
