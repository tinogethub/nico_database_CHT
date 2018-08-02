using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace nico_database
{
    public partial class user_check2 : Form
    {
        public user_check2()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            string level = "";
            string getMD5 = MD5code(pass);
            string connStr;
            database SQLstr = (database)memoryData.database[0];
            connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand command = conn.CreateCommand();

            try
            {
                conn.Open();

                //連線MYSQL 取回要比對的資料
                command.CommandText = "SELECT * FROM nico_db.user_data where name = '" + user + "' and pass =" + "'" + getMD5 + "'";
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                if (reader.HasRows !=false )
                {
                    reader.Read();
                    level = (String)reader["level"];
                    if(level == "admin")
                    {
                        option_account le = new option_account();
                        le.MYSQL_str = connStr;
                        le.Show();

                        conn.Close();
                        this.Close();
                    }
                    else
                    {
                        conn.Close();
                        MessageBox.Show("need administrator account!");
                    }
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("user name or password error!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String MD5code(String str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            Byte[] data = md5Hasher.ComputeHash((new System.Text.ASCIIEncoding()).GetBytes(str));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                apply.Focus();
                apply_Click(sender, e);
            }
        }
    }
}
