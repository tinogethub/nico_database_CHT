using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace nico_database
{
    public partial class AddDeviceTree : Form
    {
        public AddDeviceTree()
        {
            InitializeComponent();
            backSOAP.WorkerReportsProgress = true;
            backSOAP.WorkerSupportsCancellation = true;
        }

        wait_lon wait = new wait_lon();
        private ListBox backSOAPrun = new ListBox();
        private ListBox backSOAPrunPath = new ListBox();

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            Device_manager lForm1 = (Device_manager)this.Owner;//把Form2的父窗口指針賦給lForm1  
            lForm1.GetAddDeviceName = null; //使用父窗口指針賦值  
            Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            string returnValue = "",returnStr = "";
            string returnIP = "";
            ListBox returnObj = new ListBox();
            if (potocolType.SelectedIndex ==1)
            {
                if (nicoip.Text != "")
                {
                    returnIP = nicoip.Text;
                    returnValue = comboBox1.Text;
                    returnStr = "nico%" + returnIP + "%" + returnValue;
                    returnObj.Items.Add(returnStr);
                    Device_manager lForm1 = (Device_manager)this.Owner;//把Form2的父窗口指針賦給lForm1  
                    //lForm1.GetAddDeviceName = "nico%" + returnIP + "%" + returnValue; //使用父窗口指針賦值  
                    lForm1.GetAddDeviceName = returnObj;

                    if (useInput.Checked == true)
                    {
                        lForm1.reip = Lonip.Text;    
                    }
                    else if (useTemp.Checked == true)
                    {
                        lForm1.reip = comboBox2.Text;    
                    }

                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ip address empty!");
                }
            }
            else if (potocolType.SelectedIndex == 0)
            {

                if (LonDeviceList.SelectedItem != null || tempList.SelectedItem!=null )
                {
                    if (Lonip.Text != "")
                    {
                        if (useInput.Checked == true)
                        {
                            for (int itemcount = 0; itemcount < LonDeviceList.Items.Count; itemcount++)
                            {
                                if (LonDeviceList.GetSelected(itemcount) == true)
                                {
                                    returnIP = Lonip.Text;
                                    returnValue = LonDeviceListPath.Items[itemcount].ToString();
                                    returnStr = "lon%" + returnIP + "%" + returnValue;
                                    returnObj.Items.Add(returnStr);
                                }
                            }
                        }
                        else if (useTemp.Checked == true)
                        {
                            for (int itemcount = 0; itemcount < tempList.Items.Count; itemcount++)
                            {
                                if (tempList.GetSelected(itemcount) == true)
                                {
                                    returnIP = comboBox2.Text;
                                    returnValue = tempListpath.Items[itemcount].ToString();
                                    returnStr = "lon%" + returnIP + "%" + returnValue;
                                    returnObj.Items.Add(returnStr);
                                }
                            }
                        }


                        Device_manager lForm1 = (Device_manager)this.Owner;//把Form2的父窗口指針賦給lForm1  
                        //lForm1.GetAddDeviceName = "lon%" + returnIP + "%" + returnValue; //使用父窗口指針賦值  
                        lForm1.GetAddDeviceName = returnObj;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ip address empty!");
                    }

                }
                else
                {
                    MessageBox.Show("device empty!");
                }
            }
            
        }

        private void AddDeviceTree_Load(object sender, EventArgs e)
        {
            potocolType.SelectedIndex = 0;
            Lonip.Select();

            if (memoryData.LonDeviceTemp.Count != 0)
            {
                for (int i = 0; i < memoryData.LonDeviceTemp.Count; i++)
                {
                    LonDeviceIp add = (LonDeviceIp)memoryData.LonDeviceTemp[i];
                    comboBox2.Items.Add(add.ip);
                }
            }
        }

        private void CMDgetLonDevice_Click(object sender, EventArgs e)
        {
            if (backSOAP.IsBusy != true)
            {
                // Start the asynchronous operation.
                backSOAP.RunWorkerAsync();
                g1.Enabled = false;
                g2.Enabled = false;
                waitIMG.Visible = true;
                //connectStop.Visible = true;
                StatusLabel.Text = "connect to SmartServer(" + Lonip.Text + ")...";
            }

        }

        private void LonDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LonDeviceListPath.SelectedIndex = LonDeviceList.SelectedIndex;
        }

        private void Lonip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CMDgetLonDevice.Focus();
                CMDgetLonDevice_Click(sender, e);
            }
        }

        private void potocolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (potocolType.SelectedIndex == 1)
            {
                //g2.Visible = true;
                //g1.Visible = false;
                this.Size = new Size(290, 251);
                g1.Location = new Point(12, 39);
                CMDCancel.Location = new Point(33, 153);
                CMDApply.Location = new Point(153, 153);
                g2.Location = new Point(509, 12);
            }
            else if (potocolType.SelectedIndex == 0)
            {
                //g2.Visible = false;
                //g1.Visible = true;
                this.Size = new Size(532, 406);
                g2.Location = new Point(12, 39);
                CMDCancel.Location = new Point(272, 309);
                CMDApply.Location = new Point(392, 309);
                g1.Location = new Point(509, 12);
            }
        }
        private int soapcount = 0;
        private void backSOAP_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            if (worker.CancellationPending == true)
            {
                e.Cancel = true;

            }
            else
            {
                if (soapcount <= 20)
                { soapcount += 1; }
                else { soapcount = 0; }

                // Perform a time consuming operation and report progress.
                //System.Threading.Thread.Sleep(500);
                //worker.ReportProgress(i * 10);
                try
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    //SmartServer.SOAP rs = new SmartServer.SOAP();   //get device tree list
                    SOAP20_DLL.SOAP rs = new SOAP20_DLL.SOAP();   //read or write NV

                    //string getLon = rs.request(Lonip.Text);
                    string getLon = rs.request (Lonip.Text);

                    backSOAPrun.Items.Clear();
                    backSOAPrunPath.Items.Clear();
                    //MessageBox.Show(getLon);
                    string[] spDevice = getLon.Split('※');
                    //searchBar.Maximum = spDevice.Length - 1;
                    for (int i = 1; i <= spDevice.Length - 1; i++)
                    {
                        string[] dd = spDevice[i].Split('$');
                        backSOAPrun.Items.Add(dd[0]);
                        backSOAPrunPath.Items.Add(spDevice[i]);
                        //LonDeviceListPath.Items.Add(spDevice[i]);
                        //searchBar.Value = i;
                        worker.ReportProgress(i * 10);
                    }

                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Cursor.Current = Cursors.Default;
                }
                finally
                {

                }
            }
        }

        private void backSOAP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backSOAP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //resultLabel.Text = "Canceled!";
                StatusLabel.Text = "connect canceled!";
                waitIMG.Visible = false;
                connectStop.Visible = false;
                g1.Enabled = true;
                g2.Enabled = true;
                
            }
            else if (e.Error != null)
            {
                //resultLabel.Text = "Error: " + e.Error.Message;
                StatusLabel.Text = "Error: " + e.Error.Message;
                waitIMG.Visible = false;
                connectStop.Visible = false;
                g1.Enabled = true;
                g2.Enabled = true;
                
            }
            else
            {
                Boolean chkip = false;
                int chkipindex = 0;
                for (int i = 0; i< memoryData.LonDeviceTemp.Count; i++)
                {
                    LonDeviceIp chk = (LonDeviceIp)memoryData.LonDeviceTemp[i];
                    if (Lonip.Text == chk.ip)
                    {
                        chkip = true;
                        chkipindex = i;
                        break;
                    }
                }

                LonDeviceIp addip = new LonDeviceIp();
                ArrayList adddevice = new ArrayList();
                ArrayList addpath = new ArrayList();
                if (chkip != true)
                {
                    addip.ip = Lonip.Text;
                    comboBox2.Items.Add(Lonip.Text);
                }
                    


                tempList.Items.Clear();
                LonDeviceList.Items.Clear();
                LonDeviceListPath.Items.Clear();

                for (int i = 0; i < backSOAPrun.Items.Count; i++)
                {
                        adddevice.Add(backSOAPrun.Items[i]);
                        addpath.Add(backSOAPrunPath.Items[i]);

                        tempList.Items.Add(backSOAPrun.Items[i]);
                        LonDeviceList.Items.Add(backSOAPrun.Items[i]);
                        LonDeviceListPath.Items.Add(backSOAPrunPath.Items[i]);
                }

                if (chkip != true)
                {
                    addip.device = adddevice;
                    addip.path = addpath;
                    memoryData.LonDeviceTemp.Add(addip);
                }
                else
                {
                    LonDeviceIp edit = (LonDeviceIp)memoryData.LonDeviceTemp[chkipindex];

                    edit.device.Clear();
                    edit.path.Clear();

                    edit.device = adddevice;
                    edit.path = addpath;
                    memoryData.LonDeviceTemp[chkipindex] = edit;
                }
                comboBox2.Text = Lonip.Text;
                //resultLabel.Text = "Done!";
                StatusLabel.Text = "connect down";
                waitIMG.Visible = false;
                connectStop.Visible = false;
                g1.Enabled = true;
                g2.Enabled = true;
                soapcount = 0;
                //pictureBox1.Visible = false;
               // ic.Close();
            }
        }

        private void connectStop_Click(object sender, EventArgs e)
        {
            if (backSOAP.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backSOAP.CancelAsync();
            }
        }

        private void AddDeviceTree_Resize(object sender, EventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            CheckBox chk = (CheckBox)sender;
            if (chk.Name == "useInput")
            {
                if (chk.Checked == true)
                {
                    useInput.Checked = true;
                    Lonip.Enabled = true;
                    LonDeviceList.Enabled = true;
                    useTemp.Checked = false;
                    comboBox2.Enabled = false;
                    tempList.Enabled = false;
                }
                else if (chk.Checked == false)
                {
                    useInput.Checked = false;
                    Lonip.Enabled = false;
                    LonDeviceList.Enabled = false;
                    useTemp.Checked = true;
                    comboBox2.Enabled = true;
                    tempList.Enabled = true;
                }
            }
            else if (chk.Name == "useTemp")
            {
                if (chk.Checked == true)
                {
                    useInput.Checked = false;
                    Lonip.Enabled = false;
                    LonDeviceList.Enabled = false;
                    useTemp.Checked = true;
                    comboBox2.Enabled = true;
                    tempList.Enabled = true;
                }
                else if (useTemp.Checked == false)
                {
                    useInput.Checked = true;
                    Lonip.Enabled = true;
                    LonDeviceList.Enabled = true;
                    useTemp.Checked = false;
                    comboBox2.Enabled = false;
                    tempList.Enabled = false;
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lonip.Text = comboBox2.Text;
            for (int i = 0; i < memoryData.LonDeviceTemp.Count; i++) 
            {
                LonDeviceIp tar = (LonDeviceIp)memoryData.LonDeviceTemp[i];
                if (tar.ip == comboBox2.Text)
                {
                    tempList.Items.Clear();
                    tempListpath.Items.Clear();
                    for (int c = 0; c < tar.device.Count; c++)
                    {
                        tempList.Items.Add(tar.device[c]);
                        tempListpath.Items.Add(tar.path[c]);
                    }
                }
            }
        }

        private void tempList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempListpath.SelectedIndex = tempList.SelectedIndex;
        }


      
    }
}
