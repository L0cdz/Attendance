using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
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
using System.Linq.Expressions;
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


        private void btn_Absent_Click(object sender, EventArgs e)
        {
            Connection();
            conn.Open();
            String[] arrayItem = cbb_Absent.SelectedItem.ToString().Split(" ");

            String subject = "";
            for(int i=2; i<arrayItem.Length-2; i++)
            {
                subject+= arrayItem[i] + " ";
            }

            String st = "INSERT INTO `history`(`idCalender`, `subject`, `absentShift`, `absentDay`, `compensateShift`, `compensateDay`, `idAccount`) VALUES ('" + arrayItem[0] + "','" + subject.Trim() + "','" + arrayItem[arrayItem.Length-2]  + "','" + arrayItem[1] + "','" + "None" + "','" + "None" + "','" + arrayItem[arrayItem.Length - 1] + "')";
            String st2 = "UPDATE calender set status = 0 WHERE `idCalender` = '" + arrayItem[0] + "'";

            MySqlCommand sqlcom = new MySqlCommand(st, conn);
            MySqlCommand sqlcom2 = new MySqlCommand(st2, conn);

            try
             {
                sqlcom.ExecuteNonQuery();

                sqlcom2.ExecuteNonQuery();
            }
             catch (SqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }

             conn.Close();
                //MySqlCommand mySqlCommand = new MySqlCommand("select *from calender", conn);
                //MySqlDataReader Reader = mySqlCommand.ExecuteReader();
             this.Close();

            Page_Main page_Main = new Page_Main();
            page_Main.Show();
        }
    }
}
