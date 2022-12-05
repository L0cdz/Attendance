using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance
{
    public partial class Page_History : Form
    {
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

        public Page_History()
        {
            InitializeComponent();
        }

        private void Page_History_Load(object sender, EventArgs e)
        {
            Connection();
            conn.Open();
            string query = "Select *from history";
            MySqlCommand cmn = new MySqlCommand(query, conn);
            MySqlDataReader mySqlDataReader = cmn.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(mySqlDataReader);
            dataGridView1.DataSource = dt;
            dt.Columns[0].ColumnName = "ID Calender";
            dt.Columns[1].ColumnName = "Subject";
            dt.Columns[2].ColumnName = "Absent Shift";
            dt.Columns[3].ColumnName = "Absent Day";
            dt.Columns[4].ColumnName = "Compensate Shift";
            dt.Columns[5].ColumnName = "Compensate Day";
            dt.Columns[6].ColumnName = "ID Account";
            conn.Close();
        }
    }
}
