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
    public partial class LoginAdmin : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public LoginAdmin()
        {
            InitializeComponent();
            con = new SqlConnection("server=PC-20201020UTPB\\SQLEXPRESS;database=Asm2;uid=sa;pwd=123456");  // tạo kết nối tới database
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string password = txtPassword.Text;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Admin where AID='" + txtID.Text + "' AND Name='" + txtName.Text + "' AND password= '" + txtPassword.Text + "' AND Email= '" + txtEmail.Text + "'";
            dr = cmd.ExecuteReader();// Thực thi đọc lệnh
            if (dr.Read())
            {
                MessageBox.Show("Login sucess fully");
                Quanlysinhvien obj = new Quanlysinhvien();
                obj.Show();// hien thi form đăng nhập thành công
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
