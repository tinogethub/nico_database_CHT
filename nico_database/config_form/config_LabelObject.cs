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
    public partial class config_LabelObject : Form
    {
        public string LabelName;
        public config_LabelObject()
        {
            InitializeComponent();
        }

        private void config_LabelObject_Load(object sender, EventArgs e)
        {
            previewLab.Text = Labtext.Text;

            for (int i = 0; i < memoryData.LabelData.Count; i++)
            {
                LabelObjstruct ol = (LabelObjstruct)memoryData.LabelData[i];
                
                if (ol.name == LabelName)
                {
                    Labtext.Text = ol.text;
                    textX.Text = ol.x.ToString();
                    textY.Text = ol.y.ToString();
                    previewLab.Text = ol.text;
                    previewLab.Font = ol.font;
                    previewLab.BorderStyle = ol.border;
                    previewLab.ForeColor = Color.FromArgb(ol.color);

                    if (ol.border.ToString() == "None") { borderStyle.SelectedIndex = 0; }
                    else if (ol.border.ToString() == "FixedSingle") { borderStyle.SelectedIndex = 1; }
                    else if (ol.border.ToString() == "Fixed3D") { borderStyle.SelectedIndex = 2; }

                }
            }
            
            Labtext.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Relab = null;
            Close();
        }

        private void FontCMD_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.Font = previewLab.Font;
            fd.Color = previewLab.ForeColor;
            try
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    previewLab.Font = fd.Font;
                    previewLab.ForeColor = fd.Color;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void Labtext_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            previewLab.Tag = textX.Text + "_" + textY.Text;
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.Relab = previewLab;

            for (int i = 0; i < memoryData.LabelData.Count; i++)
            {
                LabelObjstruct getstr = (LabelObjstruct)memoryData.LabelData[i];
                
                if (getstr.name == LabelName)
                {
                    getstr.color = previewLab.ForeColor.ToArgb();
                    getstr.font = previewLab.Font;
                    getstr.text = previewLab.Text;
                    getstr.border = previewLab.BorderStyle;
                    getstr.backcolor = previewLab.BackColor.ToArgb();
                    getstr.x = int.Parse(textX.Text);
                    getstr.y = int.Parse(textY.Text);
                    memoryData.LabelData[i] = getstr;
                    break;
                }
            }

            this.Close();  
        }

        private void config_LabelObject_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void Labtext_KeyUp(object sender, KeyEventArgs e)
        {
            previewLab.Text = Labtext.Text;
        }

        private void ColorCMD_Click(object sender, EventArgs e)
        {
            ColorDialog mycolor = new ColorDialog();
            mycolor.Color = previewLab.BackColor;
            if (mycolor.ShowDialog() == DialogResult.OK)
            {
                previewLab.BackColor = mycolor.Color;
            }
        }

        private void borderStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (borderStyle.SelectedIndex == 0) { previewLab.BorderStyle = BorderStyle.None; }
            else if (borderStyle.SelectedIndex == 1) { previewLab.BorderStyle = BorderStyle.FixedSingle ; }
            else if (borderStyle.SelectedIndex == 2) { previewLab.BorderStyle = BorderStyle.Fixed3D ; }
        }
    }
}
