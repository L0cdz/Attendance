using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Attendance.User
{
    public partial class Page_Compensate : Form
    {
        public Page_Compensate()
        {
            InitializeComponent();
        }
        static MySqlConnection conn = null;
        static void Connection()
        {
            String connStr = "server=" + Program.sever.ToString() + ";" + "user=" + Program.username.ToString() + ";" + "database=" + Program.database.ToString() + ";" + "password=" + Program.password.ToString() + ";";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                // MessageBox.Show("Connection Open");
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        String selectShift = "";
        private void Page_Compensate_Load(object sender, EventArgs e)
        {
            cbbShift.Items.Add("Ca1");
            cbbShift.Items.Add("Ca2");
            cbbShift.Items.Add("Ca3");
            cbbShift.Items.Add("Ca4");

            try
            {
                Connection();
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select *from history", conn);
                MySqlDataReader Reader = mySqlCommand.ExecuteReader();
                String id = Program.id.ToString();

                while (Reader.Read())
                {
                    if (id.Equals(Reader.GetString("idAccount")) && "None".Equals(Reader.GetString("compensateDay")))
                    {
                        String idCalender = Reader.GetString("idCalender");
                        String subject = Reader.GetString("subject");
                        String shift = Reader.GetString("absentShift");
                        String day = Reader.GetString("absentDay");
                        String rs = idCalender + " " + subject + " " + shift + " " + day + " " + id;
                        cbbCompensate.Items.Add(rs);
                    }
                    else
                    {
                        ;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("asdfjaksfjalks");
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCompensate_Click(object sender, EventArgs e)
        {
            Connection();
            conn.Open();

            selectShift = cbbShift.SelectedItem.ToString();
            MessageBox.Show(selectShift);

            if (selectShift == "")
            {
                MessageBox.Show("Please select shift!");
                this.Close();
                btnCompensate.Click += new System.EventHandler(this.btnCompensate_Click);
            }

            String[] arrayItem = cbbCompensate.SelectedItem.ToString().Split(" ");

            String subject = "";
            for (int i = 1; i < arrayItem.Length - 3; i++)
            {
                subject += arrayItem[i] + " ";
            }

            String st = "UPDATE history set compensateShift = '" + selectShift + "', compensateDay =" + "'" + Program.compensateDay + "' WHERE idCalender =" + arrayItem[0];
            String st2 = "UPDATE calender set status = 1, shift = '" + selectShift + "', dayTime = '" + Program.compensateDay + "' WHERE `idCalender` = '" + arrayItem[0] + "'";
            MessageBox.Show(st);
            MessageBox.Show(st2);
            MySqlCommand sqlcom = new MySqlCommand(st, conn);
            MySqlCommand sqlcom2 = new MySqlCommand(st2, conn);
            try
            {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("insert successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("eror");
            }

            conn.Close();
            //MySqlCommand mySqlCommand = new MySqlCommand("select *from calender", conn);
            //MySqlDataReader Reader = mySqlCommand.ExecuteReader();
            this.Close();

            Page_Main page_Main = new Page_Main();
            page_Main.Show();
            this.Hide();
        }
    }
}
