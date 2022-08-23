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
    public partial class Quanlysinhvien1 : Form
    {
        String sqlconnect = "server=PC-20201020UTPB\\SQLEXPRESS;database=Asm2;uid=sa;pwd=123456"; // Tạo kết nối tới database
        SqlConnection con;
        SqlDataReader dr;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public Quanlysinhvien1()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng command
                SqlCommand cmd = con.CreateCommand();
                // Thiết lập câu lệnh insert
                cmd.CommandText = "insert into Scoress values(@SCID,@English," + "@Majors)";
                // Tạo tham số và gán giá trị cho tham số
                cmd.Parameters.Add("@SCID", SqlDbType.Float, 5).Value = txtID.Text;
                cmd.Parameters.Add("@English", SqlDbType.Float, 50).Value = txtEngLish.Text;
                cmd.Parameters.Add("@Majors", SqlDbType.Float, 50).Value = txtMajors.Text;
                // Thực hiện truy vấn
                cmd.ExecuteNonQuery();
                MessageBox.Show("Entry has been successfully Added!", "Added");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Quanlysinhvien1_Load(object sender, EventArgs e)
        {
            // khởi tạo và mở connection
            con = new SqlConnection(sqlconnect);
            con.Open();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng command
                SqlCommand cmd = con.CreateCommand();
                // Thiết lập thủ tục update
                cmd.CommandText = "Update from Student where SCID=@SCID";
                // Thiết lập loại câu lệnh
                cmd.CommandType = CommandType.StoredProcedure;
                // Tạo tham số và gán giá trị cho tham số
                cmd.Parameters.Add("@SCID", SqlDbType.Float, 50).Value = txtID.Text;
                cmd.Parameters.Add("@English", SqlDbType.Float, 50).Value = txtEngLish.Text;
                cmd.Parameters.Add("@Majors", SqlDbType.Float, 50).Value = txtMajors.Text;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Hỏi trước khi xóa
            if (MessageBox.Show("Bạn có muốn xóa không?", "Delte Date",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Tạo đối tượng
                SqlCommand cmd = con.CreateCommand();
                // Tạo câu lệnh command
                cmd.CommandText = "Delete from Scoress where SCID=@SCID";
                // Gán tham số
                cmd.Parameters.Add("@SCID", SqlDbType.VarChar, 5).Value = txtID.Text;
                // Kiểm tra xem có xóa thành công không?
                if (cmd.ExecuteNonQuery() != 1)
                    MessageBox.Show("Không tồn tại điểm có mã như trên", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(sqlconnect);

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Scoress";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(sqlconnect);

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM TeachingSchedule";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
