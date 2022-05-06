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
    public partial class admin_1_xem_xoa : Form
    {
        public int tuan;
        Button b;
        public string mapm;
        public admin_1_xem_xoa(int tuan, Button b, string mapm)
        {
            this.tuan = tuan;
            this.b = b;
            this.mapm = mapm;
            InitializeComponent();
        }

        private void admin_1_xem_xoa_Load(object sender, EventArgs e)
        {

            int thu = b.Name[1] - 48;
            int kip = b.Name[2] - 48;
            string malhp = "";
            string magv = "";
            string manv = "";
            string mapm = this.mapm;
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s1 = "select malhp,magv,manv,mapm from lich_dkth,lich_th where tuan="+this.tuan+" and thu = " + thu + " and tietdk=" + kip + " and lich_dkth.maldk=lich_th.maldk";
            SqlCommand cmd = new SqlCommand(s1, connection);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["mapm"].ToString() == mapm)
                {
                    malhp = sdr["malhp"].ToString();
                    magv = sdr["magv"].ToString();
                    manv = sdr["manv"].ToString();
                    Console.WriteLine(mapm);
                    Console.WriteLine(malhp);
                    Console.WriteLine(magv);
                    Console.WriteLine(manv);
                   
                }

            }
            textBox1.Text = magv;
            textBox2.Text = malhp;
            textBox3.Text = manv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // cau lenh xoa lich
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
            cmd.CommandText = "xoalichthuchanh";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            cmd.Parameters.Add("@tuan", SqlDbType.Int).Value = this.tuan;
            cmd.Parameters.Add("@thu", SqlDbType.Int).Value = thu;
            cmd.Parameters.Add("@MApm", SqlDbType.VarChar).Value = this.mapm;
            cmd.Parameters.Add("@kip", SqlDbType.Int).Value = kip;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            b.Text = "+";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
