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

namespace nico_database
{
    public partial class search_tagData : Form
    {
        public string TargetPath = "";
        
        public search_tagData()
        {
            InitializeComponent();
        }

        private void search_tagData_Load(object sender, EventArgs e)
        {

        }

        private void check_date_CheckedChanged(object sender, EventArgs e)
        {
            if (check_date.Checked == true)
            {
                panel_date.Enabled = true;
            }
            else
            {
                panel_date.Enabled = false;
            }
        }

        private void check_value_CheckedChanged(object sender, EventArgs e)
        {
            if (check_value.Checked == true )
            {
                panel_allValue.Enabled = true;
            }
            else
            {
                panel_allValue.Enabled = false;
            }
        }

        private void radio_value_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_value .Checked == true )
            {
                panel_value.Enabled = true;
            }
            else
            {
                panel_value.Enabled = false;
            }
        }

        private void radio_between_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_between .Checked == true )
            {
                panel_between.Enabled = true;
            }
            else
            {
                panel_between.Enabled = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            string[] InputInfo = TargetPath.Split('/');
            string site = InputInfo[0];
            string fab = InputInfo[1];
            string area = InputInfo[2];
            string device = InputInfo[3];
            string function = InputInfo[4];
            string nv = InputInfo[5];
            string nvType = InputInfo[6];
            string description = InputInfo[7];
            string ip = InputInfo[8];
            int getid = 0;

            string connStr = "";

            if (check_date .Checked== true && check_value.Checked==false)
            {
                try
                {
                    string date1, date2, time1, time2;

                    date1 = from_date.Value.ToString("yyyy-MM-dd");
                    date2 = to_date.Value.ToString("yyyy-MM-dd");
                    time1 = from_time.Value.ToString("HH:mm:ss");
                    time2 = to_time.Value.ToString("HH:mm:ss");

                    database SQLstr = (database)memoryData.database[0];
                    connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                    MySqlConnection conn = new MySqlConnection(connStr);
                    MySqlCommand command = conn.CreateCommand();
                    conn.Open();
                    command.CommandText = "SELECT * FROM nico_db.input_list where site = '" + site 
                        + "' and fab = '" + fab + "' and area = '" + area + "' and device = '" + device 
                        +"' and function = '" + function + "' and NVname = '" + nv + "' and ip = '" + ip + "'";
                    
                    MySqlDataReader reader;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows != false)
                        {
                            reader.Read();

                            //string level = (String)reader["id"];
                            getid = (int)reader["id"];
                            conn.Close();
                            conn.Open();

                            //Sql  String
                            string mySelectQuery = "SELECT * FROM nico_db.input_value where list_id ='" + getid 
                                + "' and date between '" + date1 + "' and '" + date2 + "' and time between '" + time1 
                                + "' and '" + time2 + "' limit " + limit.Text ;
                            //這個 adapter是Mysql的 adapter;
                            MySqlDataAdapter adapter = new MySqlDataAdapter(mySelectQuery, conn);

                            DataTable dt = new DataTable("log");
                            adapter.Fill(dt);
                            //insert column
                            System.Data.DataColumn newColumn = new System.Data.DataColumn("dt", typeof(System.String));
                            dt.Columns.Add(newColumn);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dt.Rows[i].BeginEdit();
                                dt.Rows[i]["dt"] = dt.Rows[i].ItemArray[4] + " " + dt.Rows[i].ItemArray[5];

                                dt.Rows[i].EndEdit();
                            }

                            dataGridView1.DataSource = dt;
                            dataGridView1.DataSource = dt;
                            
                            search_tagData_Show showForm = new search_tagData_Show();
                            showForm.dataGridView1.DataSource = dt;
                            showForm.dataGridView1.Columns[0].Visible = false;
                            showForm.dataGridView1.Columns[1].Visible = false;
                            showForm.dataGridView1.Columns[2].Visible = false;
                            showForm.dataGridView1.Columns[6].Visible = false;

                            showForm.site.Text = site;
                            showForm.fab.Text = fab;
                            showForm.area.Text = area;
                            showForm.device.Text = device;
                            showForm.function.Text = function;
                            showForm.nv.Text = nv;
                            showForm.nvType.Text = nvType;
                            showForm.description.Text = description;
                            showForm.ip.Text = ip;
                            showForm.index.Text = getid.ToString();
                            showForm.count.Text = dt.Rows.Count.ToString();
                            showForm.CMD_chart.Enabled = true;
                            showForm.dt = dt;
                            showForm.Show();

                            conn.Close();
                            break;
                            

                        }
                        else
                        {
                            MessageBox.Show("data not found!");
                            conn.Close();
                        }
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (check_date.Checked == true && check_value.Checked == true)
            {
                try
                {
                    string date1, date2, time1, time2;
                    string svalue1, svalue2, set1, set2;

                    date1 = from_date.Value.ToString("yyyy-MM-dd");
                    date2 = to_date.Value.ToString("yyyy-MM-dd");
                    time1 = from_time.Value.ToString("HH:mm:ss");
                    time2 = to_time.Value.ToString("HH:mm:ss");
                    

                    database SQLstr = (database)memoryData.database[0];
                    connStr = "server=" + SQLstr.ip + ";port=" + SQLstr.port + ";uid=" + SQLstr.user + ";pwd=" + SQLstr.password + ";database=" + SQLstr.DBname;
                    MySqlConnection conn = new MySqlConnection(connStr);
                    MySqlCommand command = conn.CreateCommand();
                    conn.Open();
                    command.CommandText = "SELECT * FROM nico_db.input_list where site = '" + site
                        + "' and fab = '" + fab + "' and area = '" + area + "' and device = '" + device
                        + "' and function = '" + function + "' and NVname = '" + nv + "' and ip = '" + ip + "'";

                    MySqlDataReader reader;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows != false)
                        {
                            reader.Read();

                            //string level = (String)reader["id"];
                            getid = (int)reader["id"];
                            conn.Close();
                            conn.Open();
                            string mySelectQuery="";
                            if (radio_value.Checked == true)
                            {
                                svalue1 = value1.Text;
                                set1 = combo_value.Text;

                                //Sql  String
                                mySelectQuery = "SELECT * FROM nico_db.input_value where list_id ='" + getid
                                    + "' and date between '" + date1 + "' and '" + date2 + "' and time between '" + time1
                                    + "' and '" + time2 + "' " + "and NVvalue_real " + set1 + " '" + svalue1 + "'" + " limit " + limit.Text;
                            }
                            else if (radio_between.Checked == true)
                            {
                                svalue1 = value2.Text;
                                svalue2 = value3.Text;
                                set1 = combo_between1.Text;
                                set2 = combo_between2.Text;

                                //Sql  String
                                mySelectQuery = "SELECT * FROM nico_db.input_value where list_id ='" + getid
                                    + "' and date between '" + date1 + "' and '" + date2 + "' and time between '" + time1
                                    + "' and '" + time2 + "' and NVvalue_real "+ set1 + " " + svalue1 
                                    + " and NVvalue_real "+ set2 + " " + svalue2 + " limit " + limit.Text;
                            }

                            
                            //這個 adapter是Mysql的 adapter;
                            MySqlDataAdapter adapter = new MySqlDataAdapter(mySelectQuery, conn);

                            DataTable dt = new DataTable("log");
                            adapter.Fill(dt);

                            //insert column
                            System.Data.DataColumn newColumn = new System.Data.DataColumn("dt", typeof(System.String));
                            dt.Columns.Add(newColumn);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dt.Rows[i].BeginEdit();
                                dt.Rows[i]["dt"] = dt.Rows[i].ItemArray[4] + " " + dt.Rows[i].ItemArray[5];

                                dt.Rows[i].EndEdit();
                            }

                            dataGridView1.DataSource = dt;


                            search_tagData_Show showForm = new search_tagData_Show();
                            showForm.dataGridView1.DataSource = dt;
                            showForm.dataGridView1.Columns[0].Visible = false;
                            showForm.dataGridView1.Columns[1].Visible = false;
                            showForm.dataGridView1.Columns[2].Visible = false;
                            showForm.dataGridView1.Columns[6].Visible = false;

                            showForm.site.Text = site;
                            showForm.fab.Text = fab;
                            showForm.area.Text = area;
                            showForm.device.Text = device;
                            showForm.function.Text = function;
                            showForm.nv.Text = nv;
                            showForm.nvType.Text = nvType;
                            showForm.description.Text = description;
                            showForm.ip.Text = ip;
                            showForm.index.Text = getid.ToString();
                            showForm.count.Text = dt.Rows.Count.ToString();
                            showForm.CMD_chart.Enabled = false;
                            showForm.dt = dt;
                            showForm.Show();

                            conn.Close();
                            break;


                        }
                        else
                        {
                            MessageBox.Show("data not found!");
                            conn.Close();
                        }
                    }

                    //this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (check_date.Checked == false && check_value.Checked == true)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (check_date.Checked == false && check_value.Checked == false)
            {
                //no action
            }
        }
    }
}
