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
    public partial class Quanlysinhvien : Form
    {
        String sqlconnect = "server=PC-20201020UTPB\\SQLEXPRESS;database=Asm2;uid=sa;pwd=123456"; //Tạo kết nối tới database
        SqlConnection con;
        SqlDataReader dr;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public Quanlysinhvien()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Quanlysinhvien_Load(object sender, EventArgs e)
        {
            // khởi tạo và mở connection
            con = new SqlConnection(sqlconnect);
            con.Open();

        }

        private void bntADD_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng command
                SqlCommand cmd = con.CreateCommand();
                // Thiết lập câu lệnh insert
                cmd.CommandText = "insert into Student values(@SID,@Name," + "@Password,@Email,@Sex,@Birthday)";
                // Tạo tham số và gán giá trị cho tham số
                cmd.Parameters.Add("@SID", SqlDbType.VarChar, 5).Value = txtID.Text;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = txtName.Text;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = txtPassword.Text;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = txtEmail.Text;
                cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = chkSex.Checked;
                cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                // Thực hiện truy vấn
                cmd.ExecuteNonQuery();
                MessageBox.Show("Entry has been successfully Added!", "Added");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bntEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng command
                SqlCommand cmd = con.CreateCommand();
                // Thiết lập thủ tục update
                cmd.CommandText = "Update from Student where SID=@SID";
                // Thiết lập loại câu lệnh
                cmd.CommandType = CommandType.StoredProcedure;
                // Tạo tham số và gán giá trị cho tham số
                cmd.Parameters.Add("@SID", SqlDbType.VarChar, 50).Value = txtID.Text;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = txtName.Text;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = txtPassword.Text;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = txtEmail.Text;
                cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = chkSex.Checked;
                cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                // Thực thi truy vấn
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhập thành công");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            // Hỏi trước khi xóa
            if (MessageBox.Show("Bạn có muốn xóa không?", "Delte Date",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Tạo đối tượng
                SqlCommand cmd = con.CreateCommand();
                // Tạo câu lệnh command
                cmd.CommandText = "Delete from Student where SID=@SID";
                // Gán tham số
                cmd.Parameters.Add("@SID", SqlDbType.VarChar, 5).Value = txtID.Text;
                // Kiểm tra xem có xóa thành công không?
                if (cmd.ExecuteNonQuery() != 1)
                    MessageBox.Show("Không tồn tại sinh viên có mã như trên", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Xóa thành công");
                }   
            }
            }
        private void DisplayDataStudent()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter("select * from Student", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void bntShow_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(sqlconnect);
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Student";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
    
