using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace nico_database
{
    public partial class show_chart : Form
    {
        public show_chart()
        {
            InitializeComponent();
        }

        private void chart1_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    DataPoint myPoint = (DataPoint)e.HitTestResult.Object;
                    //e.Text = "X value: " + myPoint.XValue + Environment.NewLine;
                    string[] gd = myPoint.AxisLabel.ToString().Split(' ');
                    e.Text = "date : " + gd[0] + Environment.NewLine;
                    e.Text += "time : " + gd[1] + Environment.NewLine;
                    e.Text += "value : " + myPoint.YValues[0].ToString("N") + Environment.NewLine;
                    break;
                default:
                    break;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.chart1.Width, this.chart1.Height);
            chart1.DrawToBitmap(bm, new Rectangle(0, 0, this.chart1.Width, this.chart1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void printChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            chart1.ChartAreas[0].AxisY2.ScaleView.ZoomReset();
        }

        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) * 2;
                double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) * 2;
                double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) * 2;
                double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) * 2;
                
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
            }
            else
            {
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;
                
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
            }
        }

        private void show_chart_Load(object sender, EventArgs e)
        {
            chart1.MouseWheel += new System.Windows.Forms.MouseEventHandler(chData_MouseWheel);
        }

        
    }
}
