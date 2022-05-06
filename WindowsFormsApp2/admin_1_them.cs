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
    public partial class admin_1_them : Form
    {
        public int tuan;
        Button b;
        public string mapm;
        public admin_1_them(int tuan,Button b,string mapm)
        {
            this.tuan = tuan;
            this.b = b;
            this.mapm = mapm;
            InitializeComponent();
        }

        private void admin_1_them_Load(object sender, EventArgs e)
        {
            /*
  
            int thu = b.Name[1] - 48;
            int kip = b.Name[2] - 48;
            string malhp = "";
            string magv = "";
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s1 = "select malhp,magv from lich_dkth where tuan=" + this.tuan + " and thu = " + thu + " and tietdk=" + kip + "--and mapm=" + this.mapm;
            SqlCommand cmd = new SqlCommand(s1, connection);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                malhp = sdr["malhp"].ToString();
                magv = sdr["magv"].ToString();

            }
            textBox1.Text = magv;
            textBox2.Text = malhp;
            */
            // datasource cho nhan vien
            List<string> nhanvien = new List<string>();
            int tuan = this.tuan;
            int thu = this.b.Name[1] - 48;
            int kip = this.b.Name[2] - 48;
            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server, khong can ket noi
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s1 = "select manv from nhanvien except select manv from lich_dkth,lich_th where tuan=" + this.tuan + " and thu = " + thu + " and tietdk=" + kip+" and lich_dkth.maldk=lich_th.maldk";
            SqlCommand cmd = new SqlCommand(s1, connection);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                nhanvien.Add(sdr["manv"].ToString());
                //Console.WriteLine(sdr["mapm"]);
            }
            connection.Close();

            


            //cho du lieu vao 2 combobox 
            comboBox1.DataSource = nhanvien;

            if (comboBox1.Items.Count == 0)
            {
                label2.Visible = true;
                button1.Enabled = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mapm=this.mapm;
            int tuan=this.tuan;
            int thu=this.b.Name[1]-48;
            int kip=this.b.Name[2]-48;
            string manv = comboBox1.SelectedItem.ToString();

            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server, khong can ket noi
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");

            //SqlDataAdapter da = new SqlDataAdapter("themlichdangki", connection);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlCommand a = new SqlCommand();

            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "themlichthuchanh";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            
            cmd.Parameters.Add("@MApm", SqlDbType.VarChar).Value = mapm;
            cmd.Parameters.Add("@tuan", SqlDbType.Int).Value = tuan;
            cmd.Parameters.Add("@thu", SqlDbType.Int).Value = thu;
            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            cmd.Parameters.Add("@kip", SqlDbType.Int).Value = kip;



            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            this.b.Text = "Done";
            this.Close();

        }
    }
}
