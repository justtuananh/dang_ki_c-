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
namespace WindowsFormsApp2
{
    public partial class xem_xoa_lich : Form
    {
        public string magv;
        int tuan;
        Button b;
        public xem_xoa_lich(string magv, int tuan, Button b)
        {
            InitializeComponent();
            this.magv = magv;
            this.tuan = tuan;
            this.b = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xem_xoa_lich_Load(object sender, EventArgs e)
        {
            int thu = this.b.Name[1] - 48;
            int kip = this.b.Name[2] - 48;
            string malhp = "";
            string mapm = "";
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s1 = "select malhp,mapm,magv from lich_dkth where tuan=" + this.tuan + " and thu = " + thu + " and tietdk=" + kip;
            SqlCommand cmd = new SqlCommand(s1, connection);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               if (sdr["magv"].ToString() == this.magv)
                {
                    malhp = sdr["malhp"].ToString();
                    mapm = sdr["mapm"].ToString();
               }

            }
            textBox1.Text = malhp;
            textBox2.Text = mapm;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int thu = this.b.Name[1] - 48;
            int kip = this.b.Name[2] - 48;
            



            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server, khong can ket noi
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");

            //SqlDataAdapter da = new SqlDataAdapter("themlichdangki", connection);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlCommand a = new SqlCommand();

            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "xoalichdangki";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            cmd.Parameters.Add("@tuan", SqlDbType.Int).Value = this.tuan;
            cmd.Parameters.Add("@thu", SqlDbType.Int).Value = thu;
            cmd.Parameters.Add("@MAGV", SqlDbType.VarChar).Value = this.magv;
            cmd.Parameters.Add("@kip", SqlDbType.Int).Value = kip;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            b.Text = "+";
            this.Close();
        }
    }
}
