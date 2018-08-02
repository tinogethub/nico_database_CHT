using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nico_database
{
    public partial class errorIP : Form
    {
        public errorIP()
        {
            InitializeComponent();
        }

        private void errorIP_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < memoryData.errorIp.Count; i++)
            {
                erroripList.Items.Add(memoryData.errorIp[i]);
            }
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            memoryData.errorIp.Clear();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            erroripList.Items.Clear();
            for (int i = 0; i < memoryData.errorIp.Count; i++)
            {
                erroripList.Items.Add(memoryData.errorIp[i]);
            }
        }
    }
}
