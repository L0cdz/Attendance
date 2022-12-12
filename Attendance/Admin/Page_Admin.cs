using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance
{

    public partial class Page_Admin : Form
    {
        static MySqlConnection conn = null;
        #region Peoperties
        private List<List<Button>> list;
        public List<List<Button>> List
        {
            get { return list; }
            set { list = value; }
        }
        private List<String> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion

        public Page_Admin()
        {
            InitializeComponent();

            Load_calender();
        }

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
        void Load_calender()
        {
            List = new List<List<Button>>();
            int margin = 20;
            Button index = new Button() { Width = 0, Height = 0, Location = new Point(margin, 60) };
            for (int i = 0; i < 6; i++)
            {
                List.Add(new List<Button>());
                for (int j = 0; j < 7; j++)
                {
                    Button btn = new Button() { Width = 100, Height = 60 };
                    btn.Location = new Point(index.Location.X + index.Width + margin, index.Location.Y);
                    panel_body.Controls.Add(btn);

                    List[i].Add(btn);
                    index = btn;
                }
                index = new Button() { Width = 0, Height = 0, Location = new Point(margin, index.Location.Y + 60) };

            }
            SetDefauldate();
        }
        int dayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0 || date.Year % 400 == 0))
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                default:
                    return 30; ;

            }
        }
        void AddNumberIntoMatrixByDate(DateTime date)
        {
            DeleteCalender();
            DateTime dateTime = new DateTime(date.Year, date.Month, 1);

            int line = 0;

            for (int i = 1; i <= dayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(dateTime.DayOfWeek.ToString());
                Button btn = List[line][column];
                btn.Text = i.ToString();
                if (btn.Text == "")
                {
                    btn.Enabled = false;

                }
                btn.Click += new System.EventHandler(this.btnDay_Click);
                if (column >= 6)
                {
                    line++;
                }
                dateTime = dateTime.AddDays(1);

            }

        }

      
        void DeleteCalender()
        {
            for (int i = 0; i < List.Count; i++)
            {
                for (int j = 0; j < List[i].Count; j++)
                {
                    Button btn = List[i][j];
                    btn.Text = "";
                }
            }
        }
        void SetDefauldate()
        {
            dateTimePicker.Value = DateTime.Now;
        }



        private void btnDay_Click(object sender, EventArgs e)
        {

            Connection();
           


            int Result; // Biến chứa giá trị kết quả khi ép kiểu thành công
            var s = ((Button)sender).Text;
            Result = int.Parse(s);



            String btn_date = new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, Result).ToString();
            String id = Program.id.ToString();

            try
            {
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select *from calender", conn);
                MySqlDataReader Reader = mySqlCommand.ExecuteReader();

                while (Reader.Read())
                {
                    if (btn_date.Equals(Reader.GetString("dayTime")) && id.Equals(Reader.GetString("idAccount")))
                    {
                        String subject = Reader.GetString("subject");
                        String shift = Reader.GetString("shift");
                        MessageBox.Show(btn_date.ToString() + "\n" + subject + "\n" + shift);
                    }
                    else
                    {
                        MessageBox.Show("Nothing!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            string msg = "";
            // MessageBox.Show(List.ToString());



        }

        private Form curentFormChild;
        private void OpenChildForm(Form childForm)
        {
            panel_body.Controls.Clear();
            panel_dayTeach.Controls.Clear();
            panel_search.Dispose();
            
            if (curentFormChild != null)
            {
                curentFormChild.Close();
            }
            curentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; 
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        //grid view in ra cac tai khoan
        private void btnAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Page_Account());
        }

        //duyet bao vang - bao bu
        private void btnWatch_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Page_Watch());
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            SetDefauldate();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddMonths(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddMonths(1);
        }

        //Thay đổi ngày dựa theo ngày được chọn trên DateTimePicker
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        //btn quay về màn hình chính
        private void btnHome_Click(object sender, EventArgs e)
        {
            Page_Admin page_Admin = new Page_Admin();
            page_Admin.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn Muốn Đăng Xuất?", "Xác Nhận", MessageBoxButtons.YesNoCancel);
            if (rs == DialogResult.Yes)
            {
               
                Page_Login page_Login = new Page_Login();
                page_Login.Show();
                this.Close();
            }
            else
            {
                ;
            }
        }

        private void Page_Admin_Load(object sender, EventArgs e)
        {
            Connection();
            try
            {
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select *from account", conn);
                MySqlDataReader Reader = mySqlCommand.ExecuteReader();

                while (Reader.Read())
                {
                    if (Program.id.Equals(Reader.GetString("idAccount")))
                    {
                        tbName.Text = Reader.GetString("name");
                        conn.Clone();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            MessageBox.Show("Invalid");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}

