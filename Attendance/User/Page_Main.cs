using Attendance.User;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Attendance
{
    public partial class Page_Main : Form
    {
        static MySqlConnection conn = null;
        #region Peoperties
        private List<List<Button>> list;
        public List<List<Button>> List
        {
            get { return list; }
            set { list = value; }
        }
        private List<String> dateOfWeek = new List<string>(){ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion
  
        public Page_Main()
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
            Button index = new Button() { Width=0,Height=0,Location=new Point(margin,60)};
            for(int i = 0; i < 6; i++)
            {
                List.Add(new List<Button>());
                for (int j = 0; j < 7; j++)
                {
                    Button btn = new Button() { Width = 100,  Height = 60};
                    btn.Location = new Point(index.Location.X + index.Width+margin, index.Location.Y);
                    panel_body.Controls.Add(btn);
                   
                    List[i].Add(btn);
                    index = btn;
                }
                index = new Button() { Width = 0, Height = 0, Location = new Point(margin, index.Location.Y+60) };

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
                    return 30;;

            }
        }

        void AddColorIntoMatrixByDate(DateTime date)
        {
            DateTime dateTime = new DateTime(date.Year, date.Month, 1);
            String id = Program.id.ToString();
            int line = 0;
            int i = 1;
            while(i<= dayOfMonth(date))
            {
                Connection();
                int column = dateOfWeek.IndexOf(dateTime.DayOfWeek.ToString());
                Button btn = List[line][column];

                try
                {
                    conn.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("select *from calender", conn);
                    MySqlDataReader Reader = mySqlCommand.ExecuteReader();
                    String dateTime2 = dateTime.ToString();

                    while (Reader.Read())
                    {
                        if (dateTime2.Equals(Reader.GetString("dayTime")) && id.Equals(Reader.GetString("idAccount")))
                        {
                            btn.BackColor = Color.Green;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ;

                }
                finally
                {
                    conn.Close();
                }
                dateTime = dateTime.AddDays(1);

                if (column >= 6)
                {
                    line++;
                }
                i += 1;
            }
        }

        void AddNumberIntoMatrixByDate(DateTime date)
        {
            DeleteCalender();
            DateTime dateTime = new DateTime(date.Year,date.Month,1);
            int line = 0;

            for(int i=1; i <= dayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(dateTime.DayOfWeek.ToString());
                Button btn = List[line][column];
                btn.Text = i.ToString();
                btn.Click -= new System.EventHandler(this.btnDay_Click);
                if (btn.Text == "")
                {
                    btn.Enabled = false;

                }
                else
                {
                    btn.Enabled = true;
                    btn.Click += new System.EventHandler(this.btnDay_Click);
                }
                
                if (column >= 6)
                {
                    line++;
                }
                dateTime = dateTime.AddDays(1);
      
            }

        }

        void DeleteCalender()
        {
            for(int i=0;i<List.Count; i++)
            {
                for(int j = 0; j < List[i].Count; j++)
                {
                    Button btn = List[i][j];
                    btn.Text = "";
                    btn.BackColor= Color.White;
                    btn.Enabled= false;
                }
            }
        }
        void SetDefauldate()
        {
            dateTimePicker.Value = DateTime.Now;
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DeleteCalender();
            panel_teach.Controls.Clear();
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
            AddColorIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddMonths(1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddMonths(-1);
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            SetDefauldate();
        }

        private void btnAbsent_Click(object sender, EventArgs e)
        {
            Page_Absent page_Absent = new Page_Absent();
            page_Absent.Show();
        }
        private void btnCompensate_Click(object sender, EventArgs e)
        {
            Page_Compensate page_Compensate = new Page_Compensate();
            page_Compensate.Show();
        }
        private void btnDay_Click(object sender, EventArgs e)
        {
            panel_teach.Controls.Clear();
            Button btnAbsent = new Button() { Width = 95, Height = 30 }; ;
            btnAbsent = new Button();
            btnAbsent.Text = "Vắng";
            btnAbsent.Location = new Point(37, 14); ;
            btnAbsent.Click += new System.EventHandler(this.btnAbsent_Click);

            Button btnCompensate = new Button() { Width = 95, Height = 30 }; ;
            btnCompensate = new Button();
            btnCompensate.Text = "Bù";
            btnCompensate.Location = new Point(37, 49); ;
            btnCompensate.Click += new System.EventHandler(this.btnCompensate_Click);

            panel_btn.Controls.Add(btnAbsent);
            panel_btn.Controls.Add(btnCompensate);


            int Result; // Biến chứa giá trị kết quả khi ép kiểu thành công
            var s = ((Button)sender).Text;
            Result = int.Parse(s);



            String btn_date = new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, Result).ToString();
            String id = Program.id.ToString();
            int x = 343;
            int y = 39;
            try
            {
                Connection();
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select *from calender", conn);
                MySqlDataReader Reader = mySqlCommand.ExecuteReader();

                while(Program.listAbsent.Count > 0)
                {
                    Program.listAbsent.RemoveAt(0);
                }

                while (Reader.Read())
                {
                    if (btn_date.Equals(Reader.GetString("dayTime")) && id.Equals(Reader.GetString("idAccount")))
                    {
                        String subject = Reader.GetString("subject");
                        String shift = Reader.GetString("shift");
                        //MessageBox.Show(btn_date.ToString() + "\n" + subject + "\n" + shift);
                        Label result = new Label() { Width = 2000, Height = 30 }; ; ;
                        result.Text = btn_date.ToString() + " " + subject + " " + shift;
                        result.Location = new Point(x, y);
                        panel_teach.Controls.Add(result);
                        y += 30;
                        Program.listAbsent.Add(result.Text);
                    }
                    else
                    {
                        ;
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
        }

        //button thong tin
        private void btnInfor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Page_Information());
            
        }

        private Form curentFormChild;

        private void OpenChildForm(Form childForm)
        {
            panel_body.Controls.Clear();
            panel_btn.Dispose();
            panel_teach.Dispose();
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

        private void btnHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Page_History());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Page_Main page_Main = new Page_Main();
            page_Main.Show();
            this.Hide();
        }

        private void Page_Main_Load(object sender, EventArgs e)
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

        private void btnSignout_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn Muốn Đăng Xuất?","Xác Nhận",MessageBoxButtons.YesNoCancel);
            if(rs == DialogResult.Yes)
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

        private void panel_teach_Paint(object sender, PaintEventArgs e)
        {
            ;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ;
        }
    }
}
