using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;        //mail using
using System.Web;       //mail using
using System.Net.Mail;  //mail using
using System.Net.Sockets;  //smtp test

namespace nico_database
{
    public partial class option_mail : Form
    {
        MailMessage email = new MailMessage();
        SmtpClient SMTP = new SmtpClient();
        public option_mail()
        {
            InitializeComponent();
        }

        private void sendtest_Click(object sender, EventArgs e)
        {
            string st = Handshake();
            if (st == "true")
            {
                MessageBox.Show("connect SMTP succese!");
            }
            else
            {
                string[] msg = st.Split('$');
                MessageBox.Show(msg[1]);
            }

        }

        private void option_mail_Load(object sender, EventArgs e)
        {
            try
            {
                //using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                //{   // 讀取整數值
                //    BinaryReader reader = new BinaryReader(input);
                //    string data = reader.ReadString();
                //    string[] spStr = data.Split('$');
                //    SMTPhost.Text = spStr[1];
                //    SMTPport.Text = spStr[2];
                //    SSL.Checked = Boolean.Parse(spStr[3]);
                //    userName.Text = spStr[4];
                //    userPassword.Text = spStr[5];
                //}
                //////////////////////////////////////////////
                using (FileStream input = new FileStream(Application.StartupPath + @"\Resources\SMTP.dat", FileMode.Open))
                {   // 讀取整數值
                    BinaryReader reader = new BinaryReader(input);
                    string data = reader.ReadString();

                    int numOfBytes = data.Length / 8;
                    byte[] bytes = new byte[numOfBytes];
                    for (int i = 0; i < numOfBytes; ++i)
                    {
                        bytes[i] = Convert.ToByte(data.Substring(8 * i, 8), 2);
                    }
                    //File.WriteAllBytes(fileName, bytes);
                    string val = GetString(bytes);
                    string[] SpStr = val.Split('$');
                    SMTPhost.Text = SpStr[1];
                    SMTPport.Text = SpStr[2];
                    SSL.Checked = Boolean.Parse(SpStr[3]);
                    userName.Text = SpStr[4];
                    userPassword.Text = SpStr[5];
                    input.Dispose();
                }


            }
            catch   // (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("file not found !!");
            }
        }

        public string Handshake()
        {
            try
            {
                TcpClient tcp = new TcpClient();
                //tcp.Connect(<smtpHost>, 25);
                tcp.Connect(SMTPhost.Text, int.Parse(SMTPport.Text));
                return "true";
            }
            catch (Exception myException)
            {
                return "false$" + myException.Message.ToString();
            }
        }

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("$" + SMTPhost.Text);
            buffer.Append("$" + SMTPport.Text);
            buffer.Append("$" + SSL.Checked.ToString());
            buffer.Append("$" + userName.Text);
            buffer.Append("$" + userPassword.Text);
            //buffer.Append(Environment.NewLine);
                    
            
            //using (FileStream output = File.Create(Application.StartupPath + @"\Resources\SMTP.dat"))
            //{         // 寫入整數值
            //    BinaryWriter writer = new BinaryWriter(output);
            //    writer.Write(buffer.ToString());
            //}
            /////////////////////////////////////
            byte[] bstr = GetBytes(buffer.ToString());
            string str = Format(bstr);
            using (FileStream output = File.Create(Application.StartupPath + @"\Resources\SMTP.dat"))
            {         // 寫入整數值
                BinaryWriter writer = new BinaryWriter(output);

                writer.Write(str);
            }

            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                email.From = new MailAddress(userName.Text);  //寄件人
                email.Subject = "mail test";  //標題
                email.Body = "mail test success!";  //內容
                email.To.Add(userName.Text);  //收件人
                SMTP.EnableSsl = SSL.Checked;
                SMTP.Port = int.Parse(SMTPport.Text); //smtp port
                SMTP.Host = SMTPhost.Text;  //smtp hostname ot ipaddress
                SMTP.Credentials = new System.Net.NetworkCredential(userName.Text, userPassword.Text);  //寄件人,密碼
                SMTP.Send(email);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
