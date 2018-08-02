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
    public partial class config_InputObjectNVType : Form
    {
        public config_InputObjectNVType()
        {
            InitializeComponent();
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReoutputNV = null;
            Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.ReoutputNV = NVType.Text;
            Close();
        }

        private void config_InputObjectNVType_Load(object sender, EventArgs e)
        {
            //load sample
            /////////////////////////////////////////////////////////////////////////////////////

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
    }
}
