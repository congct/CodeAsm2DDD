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

    public partial class StudentLogin : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public StudentLogin()
        {
            InitializeComponent();
            con = new SqlConnection("server=PC-20201020UTPB\\SQLEXPRESS;database=Asm2;uid=sa;pwd=123456");  // tạo kết nối tới database
        }

        private void StudentLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtName.Text;
                string password = txtPassword.Text;
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Student where SID='" + txtID.Text + "' AND Name='" + txtName.Text + "' AND Password= '" + txtPassword.Text + "'";
                dr = cmd.ExecuteReader();// Thực thi đọc lệnh
                if (dr.Read())
                {
                    MessageBox.Show("Login sucess fully");
                    Student obj = new Student();
                    obj.Show();// hien thi form 2 ra
                    this.Hide();// an form hien tai
                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
