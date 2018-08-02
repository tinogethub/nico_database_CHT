using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace nico_database
{
    public partial class option_database : Form
    {
        public option_database()
        {
            InitializeComponent();
        }

        public string savepath = "";

        private void option_database_Load(object sender, EventArgs e)
        {
            //string cnstr = string.Format("server={0};database={1};uid={2};pwd={3}", Server, Database, dbuid, dbpwd);//標準連線設定
            //string cnstr = string.Format("server={0};database={1};uid={2};pwd={3}; Connect Timeout=180", Server, Database, dbuid, dbpwd);//逾時連線時間設定
            //string cnstr = string.Format("server={0};database={1};uid={2};pwd={3}; Port=3306", Server, Database, dbuid, dbpwd);//通訊端口設定，MySQL的預設端口為3306
            //string cnstr = string.Format("server={0};database={1};uid={2};pwd={3}; Charset=utf8", Server, Database, dbuid, dbpwd);//編碼設定

            if (memoryData.database.Count != 0)
            {
                database tar = (database)memoryData.database[0];
                ip.Text = tar.ip;
                SMTPport.Text = tar.port;
                userName.Text = tar.user;
                userPassword.Text = tar.password;
                DBname.Text = tar.DBname;
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

        private void CMDCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDApply_Click(object sender, EventArgs e)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("$" + ip.Text);
            buffer.Append("$" + userName.Text);
            buffer.Append("$" + userPassword.Text);
            buffer.Append("$" + SMTPport.Text);
            buffer.Append("$" + DBname.Text);

            byte[] bstr = GetBytes(buffer.ToString());
            string str = Format(bstr);
            using (FileStream output = File.Create(Application.StartupPath + @"\Resources\database.dat"))
            {         // 寫入整數值
                BinaryWriter writer = new BinaryWriter(output);

                writer.Write(str);
            }

            database add = new database();
            add.ip = ip.Text;
            add.port = SMTPport.Text;
            add.user = userName.Text;
            add.password = userPassword.Text;
            add.DBname = DBname.Text;

            if (memoryData.database.Count != 0)
            {
                memoryData.database[0] = add;
            }
            else
            {
                memoryData.database.Add(add);
            }

            this.Close();
        }
        

    }
}
