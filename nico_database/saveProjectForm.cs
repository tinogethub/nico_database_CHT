using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nico_database
{
    public partial class saveProjectForm : Form
    {
        public saveProjectForm()
        {
            InitializeComponent();
        }

        public Boolean saveAs = false;

        private void saveProject_Load(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.saveProjectName = "";
            Close();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            if (saveName.Text != "")
            {
                Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                if (saveAs != true)
                {
                    lForm1.saveProjectName = saveName.Text;
                    lForm1.saveAsProjectName = "";
                }
                else
                {
                    lForm1.saveProjectName = "";
                    lForm1.saveAsProjectName = saveName.Text;
                }
                
            }
            Close();
        }

        private void saveName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdApply.Focus();
                cmdApply_Click(sender, e);
            }
        }
    }
}
