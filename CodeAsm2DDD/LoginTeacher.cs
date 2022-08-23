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
    public partial class LoginTeacher : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public LoginTeacher()
        {
            InitializeComponent();
            con = new SqlConnection("server=PC-20201020UTPB\\SQLEXPRESS;database=Asm2;uid=sa;pwd=123456");  // tạo kết nối tới database
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string password = txtPassword.Text;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Teacher where TID='" + txtID.Text + "' AND Name='" + txtName.Text + "' AND Password= '" + txtPassword.Text + "'";
            dr = cmd.ExecuteReader();// Thực thi đọc lệnh
            if (dr.Read())
            {
                MessageBox.Show("Login sucess fully");
                Quanlysinhvien1 obj = new Quanlysinhvien1();
                obj.Show();// hien thi form Quanlysinhvien1
                this.Hide();// an form hien tai
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
                con.Close();
            }
        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
