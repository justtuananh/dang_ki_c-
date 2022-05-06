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
using System.Collections;
namespace WindowsFormsApp2
{
    public partial class themlich : Form
    {
        public string magv;
        public int tuan;
        Button b;
        public themlich(string magv,int tuan,Button b)
        {
            InitializeComponent();
            this.b = b;
            this.tuan = tuan;
            this.magv = magv;
        }

        private void themlich_Load(object sender, EventArgs e)
        {
            List<string> lophocphan = new List<string>();
            List<string> phongmay = new List<string>();
            int thu = this.b.Name[1] - 48;
            int kip = this.b.Name[2] - 48;
            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server, khong can ket noi
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s1= "select mapm from phongmay except select mapm from lich_dkth where tuan="+ this.tuan+" and thu = "+thu+" and tietdk="+kip;
            SqlCommand cmd = new SqlCommand(s1,connection);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader(); 
            while (sdr.Read())
            {
                phongmay.Add(sdr["mapm"].ToString());
                //Console.WriteLine(sdr["mapm"]);
            }
            connection.Close();

            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server, khong can ket noi
            SqlConnection connection1 = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s2 = "select malhp from lophocphan except select malhp from lich_dkth where tuan=" + this.tuan + " and thu = " + thu + " and tietdk=" + kip;
            SqlCommand cmd1 = new SqlCommand(s2, connection1);
            connection1.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                lophocphan.Add(sdr1["malhp"].ToString());
            }
            connection1.Close();



            //cho du lieu vao 2 combobox 
            comboBox1.DataSource = lophocphan;
            comboBox2.DataSource = phongmay;
            if(comboBox2.Items.Count==0 || comboBox1.Items.Count==0)
            {
                button1.Enabled = false;
                label4.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server, khong can ket noi
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");

            //SqlDataAdapter da = new SqlDataAdapter("themlichdangki", connection);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SqlCommand a = new SqlCommand();

            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "themlichdangki";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            int thu = this.b.Name[1] - 48;
            int kip = this.b.Name[2] - 48;
            int n = magv.Length;
            string maldk = this.magv[n-1].ToString() + "_"+this.tuan+"_"+thu+"_"+kip;
            cmd.Parameters.Add("@MALDK", SqlDbType.VarChar).Value = maldk;
            cmd.Parameters.Add("@NGAYDK", SqlDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@tuan", SqlDbType.Int).Value = this.tuan;
            cmd.Parameters.Add("@thu", SqlDbType.Int).Value = thu;
            cmd.Parameters.Add("@MApm", SqlDbType.VarChar).Value = comboBox2.SelectedValue;
            cmd.Parameters.Add("@MAGV", SqlDbType.VarChar).Value = this.magv;
            cmd.Parameters.Add("@MALHP", SqlDbType.VarChar).Value = comboBox1.SelectedValue;
            cmd.Parameters.Add("@tietdk", SqlDbType.Int).Value = kip;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            b.Text = "Done";
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
