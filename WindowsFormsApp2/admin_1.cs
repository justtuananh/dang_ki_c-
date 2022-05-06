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
    public partial class admin_1 : Form
    {
        public admin_1()
        {
            InitializeComponent();
        }

        private void admin_1_Load(object sender, EventArgs e)
        {
            List<string> phongmay = new List<string>();
            
            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server, khong can ket noi
            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s1 = "select mapm from phongmay";
            SqlCommand cmd = new SqlCommand(s1, connection);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                phongmay.Add(sdr["mapm"].ToString());
                //Console.WriteLine(sdr["mapm"]);
            }
            connection.Close();
            comboBox2.DataSource = phongmay;
            comboBox1.SelectedIndex = 0;
            
        }
        private void khoitaobandau(string mapm, int tuan, Button b)
        {
            int thu = b.Name[1] - 48;
            int kip = b.Name[2] - 48;

            object kq;
            int code;

            SqlConnection conn = new SqlConnection();
            string connectionstring = "server=LAPTOP-T5RPN2PG;database=qlpm;integrated security=true";
            conn.ConnectionString = connectionstring;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "kiemtratontai_thuhanh";

            cmd.Parameters.Add("@MApm", SqlDbType.VarChar).Value = mapm;
            cmd.Parameters.Add("@tuandk", SqlDbType.Int).Value = tuan;
            cmd.Parameters.Add("@thudk", SqlDbType.Int).Value = thu;
            cmd.Parameters.Add("@tietdk", SqlDbType.Int).Value = kip;
            cmd.Connection = conn;
            kq = cmd.ExecuteScalar();
            code = Convert.ToInt32(kq);
            if (code == 1)
            {
                b.Text = "+";
                b.Enabled = true;
                
            }
            if(code==2)
            {
                b.Text = "Done";
                b.Enabled = true;
            }
            if(code==3)
            {
                b.Text = "-";
                b.Enabled = false;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tuan = comboBox1.SelectedIndex + 1;
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b21);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b22);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b23);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b24);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b25);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b26);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b31);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b32);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b33);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b34);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b35);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b36);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b41);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b42);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b43);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b44);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b45);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b46);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b51);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b52);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b53);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b54);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b55);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b56);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b61);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b62);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b63);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b64);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b65);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b66);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b71);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b72);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b73);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b74);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b75);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b76);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b81);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b82);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b83);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b84);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b85);
            khoitaobandau(comboBox2.SelectedItem.ToString(), tuan, b86);
        }

        private void b21_Click(object sender, EventArgs e)
        {
            int tuan= comboBox1.SelectedIndex + 1;
            string mapm = comboBox2.SelectedItem.ToString();
            Button b = sender as Button;
            if (b.Text == "+")
            {

                admin_1_them a = new admin_1_them(tuan, b, mapm);
                a.ShowDialog();
                return;
            }
            if (b.Text == "-")
            {

                return;
            }
            if (b.Text == "Done")
            {
                admin_1_xem_xoa a = new admin_1_xem_xoa(tuan, b, mapm);
                a.ShowDialog();
                return;
            }
        }
    }
}
