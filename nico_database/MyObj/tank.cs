using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iocomp.MyObj
{
    public partial class tank : UserControl
    {
        public tank()
        {
            InitializeComponent();
        }

        private void labName_Paint(object sender, PaintEventArgs e)
        {
            int  tankX = axTank.Location.X;
            int tankW = axTank.Size.Width;
            int tankMid = tankX + (tankW / 2);

            int labW = labName.Size.Width / 2;
            labName.Left = tankMid - labW;
        }

        private void labValue_Paint(object sender, PaintEventArgs e)
        {
            int tankX = axTank.Location.X;
            int tankW = axTank.Size.Width;
            int tankMid = tankX + (tankW / 2);

            int labW = labValue .Size.Width / 2;
            labValue.Left = tankMid - labW+3;
        }
    }
}
