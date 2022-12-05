using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
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
    public partial class Page_Watch : Form
    {
        public Page_Watch()
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        Bitmap print;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(print, 0, 0);
        }
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            print = new Bitmap(this.Size.Width, this.Height, g);
            Graphics gp = Graphics.FromImage(print);
            gp.CopyFromScreen(-80, 150, 0, 0, new Size(866, 401));
            printPreviewDialog1.ShowDialog();

        }

        private void Page_Watch_Load(object sender, EventArgs e)
        {
            Connection();
            conn.Open();
            string query = "Select *from history";
            MySqlCommand cmn = new MySqlCommand(query, conn);
            MySqlDataReader mySqlDataReader = cmn.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(mySqlDataReader);
            dataGridViewWatch.DataSource = dt;
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
