using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net.Sockets;
using System.IO;
using System.Web;

namespace nico_database
{
    public partial class config_OutputObjectPop : Form
    {
        public string target = "";
        public string ip = "";
        public string NVtype = "";
        public int listIndex = 0;

        MailMessage email = new MailMessage();
        SmtpClient SMTP = new SmtpClient();

        //string dbHost = "127.0.0.1";//資料庫位址
        //string dbUser = "root";//資料庫使用者帳號
        //string dbPass = "root";//資料庫使用者密碼
        //string dbName = "nico_db";//資料庫名稱
        
        public config_OutputObjectPop()
        {
            InitializeComponent();
        }

        private void inputVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (inputVal.Text != "")
                {
                    CMDApply.Focus();
                    CMDApply_Click(sender, e);
                }
            }
        }

        private void config_OutputObjectPop_Load(object sender, EventArgs e)
        {
            string[] path = target.Split('@');
            if (path[2] == "lon")
            {
                inputVal.Text = "0.0 0";
            }
            else if (path[2] == "nico")
            {

            }
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            if (inputVal.Text != "")
            {
                if(target != "")
                {
                    string[] path = target.Split('@');
                    //SmartServer.SOAP ss = new SmartServer.SOAP();
                    SOAP20_DLL.SOAP ws = new SOAP20_DLL.SOAP();
                    //ss.writeNV(ip, path[2], inputVal.Text);
                    string requestVal = ws.writeNV(ip, path[2], inputVal.Text);
                    OutputPopObjectstruct edit = (OutputPopObjectstruct)memoryData.OutputPopData[listIndex];

                    string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");
                    //save to database
                    if (memoryData.database.Count != 0)
                    {
                        database SQLstr = (database)memoryData.database[0];

                        //save to database
                        //open database   ///////////////////////////////////////////////////////////////////////
                        string connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                        MySqlConnection conn = new MySqlConnection(connStr);
                        MySqlCommand addList = conn.CreateCommand();
                        conn.Open();

                        string sql = @"SELECT * FROM output_list WHERE site='" + edit.site + "' and fab='" + edit.fab + "' and area='" + edit.area
                                     + "' and device='" + edit.device + "' and function='" + edit.function + "' and NVname='" + edit.NV + "' ";

                        MySqlCommand cmdCHK = new MySqlCommand(sql, conn);
                        MySqlDataReader dataCHK = cmdCHK.ExecuteReader();
                        int listid = 0;

                        if (dataCHK.HasRows == true)
                        {
                            dataCHK.Read();
                            //有查到資料
                            listid = int.Parse(dataCHK.GetString(0));
                            dataCHK.Close();

                            addList.CommandText = @"update nico_db.output_list set description = '" + edit.description + "' where id = " + listid;
                            addList.ExecuteNonQuery();

                            MySqlCommand addValue = conn.CreateCommand();

                            addValue.CommandText = @"Insert into output_value(list_id,NVvalue_txt,date,time) values('" + listid + "','"
                                                      + inputVal.Text + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                            addValue.ExecuteNonQuery();

                        }
                        else
                        {
                            dataCHK.Close();
                            // MySqlCommand addList = conn.CreateCommand();

                            //沒有查到資料
                            addList.CommandText = @"Insert into output_list(site,fab,area,device,function,NVname,NVtype,description,ip) values('"
                                 + edit.site + "','" + edit.fab + "','" + edit.area + "','" + edit.device + "','" + edit.function + "','"
                                 + edit.NV + "','" + edit.NVtype + "','" + edit.description + "','" + edit.ip + "');";

                            addList.ExecuteNonQuery();
                            //get list_id
                            dataCHK = cmdCHK.ExecuteReader();
                            dataCHK.Read();
                            if (dataCHK.HasRows == true)
                            {
                                listid = int.Parse(dataCHK.GetString(0));
                                dataCHK.Close();
                            }

                            //write to output_value
                            MySqlCommand addValue = conn.CreateCommand();

                            addValue.CommandText = @"Insert into output_value(list_id,NVvalue_txt,date,time) values('" + listid + "','"
                                                      + inputVal.Text + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";

                            addValue.ExecuteNonQuery();
                        }

                        conn.Close();
                        //close database    ////////////////////////////////////////////////////////////////////////

                    }


                    //send email
                    if (edit.mail == true)
                    {
                        for (int m = 0; m < memoryData.GroupContact2.Count; m++)
                        {
                            ContactGroup2 mg = (ContactGroup2)memoryData.GroupContact2[m];
                            if (edit.contactGroup == mg.groupname)
                            {
                                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                                {   // 讀取整數值
                                    BinaryReader reader = new BinaryReader(input);
                                    string data = reader.ReadString();

                                    int numOfBytes = data.Length / 8;
                                    byte[] bytes = new byte[numOfBytes];
                                    for (int ri = 0; ri < numOfBytes; ++ri)
                                    {
                                        bytes[ri] = Convert.ToByte(data.Substring(8 * ri, 8), 2);
                                    }
                                    //File.WriteAllBytes(fileName, bytes);
                                    string val = GetString(bytes);
                                    string[] SpStr = val.Split('$');
                                    string SMTPhost = SpStr[1];
                                    string SMTPport = SpStr[2];
                                    Boolean SSL = Boolean.Parse(SpStr[3]);
                                    string userName = SpStr[4];
                                    string userPassword = SpStr[5];

                                    string targetpath = edit.site + "/" + edit.fab + "/" + edit.area + "/" + edit.device + "/" + edit.function + "/" + edit.NV;


                                    for (int sg = 0; sg < mg.groupmember.Count; sg++)
                                    {
                                        Contactstruct sgm = (Contactstruct)mg.groupmember[sg];
                                        if (sgm.mail != null && sgm.mail != "")
                                        {
                                            email.From = new MailAddress(userName);  //寄件人
                                            email.Subject = "IO trigger!  target : " + targetpath;  //標題
                                            email.Body = "trigger time = " + formatForMySqlDate + " " + formatForMySqlTime + Environment.NewLine
                                                         + "trigger value = " + inputVal.Text + Environment.NewLine + edit.description;  //內容
                                            email.To.Add(sgm.mail);  //收件人
                                            SMTP.EnableSsl = true;
                                            SMTP.Port = int.Parse(SMTPport); //smtp port
                                            SMTP.Host = SMTPhost;  //smtp host(主機ip)
                                            SMTP.Credentials = new System.Net.NetworkCredential(userName, userPassword);  //寄件人,密碼
                                            SMTP.Send(email);
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("not target!");
                }

            }
        }
        //↓↓↓↓↓↓↓↓↓↓ string to binary using  ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        //Formats a byte[] into a binary string (010010010010100101010)
        public string Format(byte[] data)
        {
            //storage for the resulting string
            string result = string.Empty;
            //iterate through the byte[]
            foreach (byte value in data)
            {
                //storage for the individual byte
                string binarybyte = Convert.ToString(value, 2);
                //if the binarybyte is not 8 characters long, its not a proper result
                while (binarybyte.Length < 8)
                {
                    //prepend the value with a 0
                    binarybyte = "0" + binarybyte;
                }
                //append the binarybyte to the result
                result += binarybyte;
            }
            //return the result
            return result;
        }
        //↑↑↑↑↑↑↑↑↑↑ string to binary using  ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    }
}
