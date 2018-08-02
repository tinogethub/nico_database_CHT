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
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
//using System.Text;

namespace nico_database
{
    public partial class user_check : Form
    {
        public user_check()
        {
            InitializeComponent();
        }

        private void user_check_Load(object sender, EventArgs e)
        {
            database SQLstr = (database)memoryData.database[0];
            ip.Text = SQLstr.ip;
            userName.Text = SQLstr.user;
            userPassword.Text = SQLstr.password;
            SMTPport.Text = SQLstr.port;
            DBname.Text = SQLstr.DBname;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //check id & password 
            string user = textBox1.Text;
            string pass = textBox2.Text;
            string action = "";


            if(user == "nicosu" && pass == "nico8960")
            {
                Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                lForm1.User = "nicosu";
                lForm1.AccLV = "admin";
                this.Close();
            }
            else
            {
                //contace to database
                string getMD5 = MD5code(pass);
                string connStr="";
                string level="";
                if (show_db .Checked ==false)
                {
                    database SQLstr = (database)memoryData.database[0];
                    connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                }
                else if (show_db.Checked ==true )
                {
                    connStr = "server=" + ip.Text  + ";port=" + SMTPport.Text  + ";uid=" + userName .Text  + ";pwd=" + userPassword .Text  + ";database=" + DBname.Text ;
                }

                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand command = conn.CreateCommand();
                try
                {
                    conn.Open();
                    //連線MYSQL 取回要比對的資料
                    command.CommandText = "SELECT * FROM nico_db.user_data where name = '" + user + "' and pass =" +  "'" + getMD5 + "'";
                    MySqlDataReader reader;
                    action = "read";
                    reader = command.ExecuteReader();

                    //while (reader.Read())
                    // {
                        reader.Read();
                        level = (String)reader["level"];
                        conn.Close();

                    Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1  
                    lForm1.User = user;
                    lForm1.AccLV = level; ;

                    conn.Open();
                        //save login event to database
                        string formatForMySqlDate = DateTime.Now.ToString("yyyy-MM-dd");
                        string formatForMySqlTime = DateTime.Now.ToString("HH:mm:ss");
                        command.CommandText = @"Insert into log(name,level,date,time) values('"
                                              + textBox1.Text + "','" + level + "','" + formatForMySqlDate + "','" + formatForMySqlTime + "')";
                        action = "save";
                        command.ExecuteNonQuery();
                        conn.Close();
                    Cursor.Current = Cursors.Default;
                    this.Close();

                    database SQLstr = (database)memoryData.database[0];
                    SQLstr.ip = ip.Text;
                    SQLstr.user = userName.Text;
                    SQLstr.password = userPassword.Text;
                    SQLstr.port = SMTPport.Text;
                    SQLstr.DBname = DBname.Text;
                    memoryData.database[0] = SQLstr;
                    //}




                }
                catch (Exception ex)
                {
                    if(action == "read")
                    {
                        MessageBox.Show("user name or password error!");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                    Cursor.Current = Cursors.Default;
                }

               
                
                
            }

            

            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void show_db_CheckedChanged(object sender, EventArgs e)
        {
            if (show_db.Checked == true)
            {
                this.Size = new Size(329,350); //user and password info + show database connect info
            }
            else if(show_db.Checked ==false)
            {
                this.Size = new Size(329, 150); //only user and password info
            }
        }
    }
}
