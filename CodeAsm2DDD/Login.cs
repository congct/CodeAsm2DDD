using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CodeAsm2DDD
{
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
            con = new SqlConnection("server=PC-20201020UTPB\\SQLEXPRESS;database=Asm2;uid=sa;pwd=123456");  // tạo kết nối tới database
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bntLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            StudentLogin obj = new StudentLogin();
            obj.Show();// hien thi form StudentLogin
            this.Hide();// an form hien tai
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginAdmin obj = new LoginAdmin();
            obj.Show();// hien thi form LoginAdmin
            this.Hide();// an form hien tai
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginTeacher obj = new LoginTeacher();
            obj.Show();// hien thi form LoginTeacher
            this.Hide();// an form hien tai
        }
    }
}
