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
    public partial class Student : Form
    {
        String sqlconnect = "server=PC-20201020UTPB\\SQLEXPRESS;database=Asm2;uid=sa;pwd=123456";
        SqlConnection con;
        SqlDataReader dr;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void btnXemlichhoc_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(sqlconnect);

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM ScholCalenderr";
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

        private void btnXemdiem_Click(object sender, EventArgs e)
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
    }
}
