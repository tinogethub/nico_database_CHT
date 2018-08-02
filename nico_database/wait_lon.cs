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
    public partial class wait_lon : Form
    {
        public wait_lon()
        {
            InitializeComponent();
        }

        private void wait_lon_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.White;
            Application.DoEvents();
        }
    }
}
