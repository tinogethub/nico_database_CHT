using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nico_database
{
    public partial class AddDeviceTreeNode : Form
    {
        public string getValue;
        public AddDeviceTreeNode()
        {
            InitializeComponent();
        }

        public void SetValue()
        {
            this.nodeName.Text = getValue;
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            Device_manager lForm1 = (Device_manager)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.GetAddDeviceName = null; //使用父窗口指針賦值  
            Close();
        }

        private void AddDeviceTreeNode_Load(object sender, EventArgs e)
        {
            nodeName.Select();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            if (nodeName.Text != "")
            {
                ListBox add = new ListBox();
                add.Items.Add(nodeName.Text);
                Device_manager lForm1 = (Device_manager)this.Owner;//把Form2的父窗口指針賦給lForm1  
                lForm1.GetAddDeviceName = add; //使用父窗口指針賦值  

                this.Close();
            }
          
        }

        private void nodeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CMDApply.Focus();
                CMDApply_Click(sender, e);
            }
        }

        private void AddDeviceTreeNode_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Device_manager lForm1 = (Device_manager)this.Owner;//把Form2的父窗口指針賦給lForm1  
            //lForm1.GetAddDeviceName = null; //使用父窗口指針賦值  
            //Close();
        }  



    }
}
