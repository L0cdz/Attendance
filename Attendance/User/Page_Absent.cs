using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Attendance
{
    public partial class Page_Absent : Form
    {
        public Page_Absent()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        private void Page_Absent_Load(object sender, EventArgs e)
        {
            for(int i = 0; i<Program.listAbsent.Count; i++)
            {
                cbb_Absent.Items.Add(Program.listAbsent[i]);
            }
        }


        String selectItem = "";
        private void btn_Absent_Click(object sender, EventArgs e)
        {
            Connection();
            conn.Open();
            selectItem = cbb_Absent.SelectedItem.ToString();
            String[] arrayItem = selectItem.Split(" ");
            String[] arrayDay = arrayItem[0].Split("/");
            String tmpDay = arrayDay[2] + "-" + arrayDay[0] + "-" + arrayDay[1];
            String st = "INSERT INTO `absent`(`id`, `subject`, `shift`, `dayTime`) VALUES ('123', " + "'" + arrayItem[3] + "'" + "," + "'" + arrayItem[4] + "'" + "," + "'" + tmpDay + "'" + ")";
            MySqlCommand sqlcom = new MySqlCommand(st, conn);

            try
             {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("insert successful");
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }

             conn.Close();
                //MySqlCommand mySqlCommand = new MySqlCommand("select *from calender", conn);
                //MySqlDataReader Reader = mySqlCommand.ExecuteReader();
             this.Close();
        }
    }
}
