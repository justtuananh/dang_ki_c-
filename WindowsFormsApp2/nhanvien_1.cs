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
    public partial class nhanvien_1 : Form
    {
        public string manv;
        int tuan;

        public nhanvien_1(string manv)
        {
            this.manv = manv;   
            InitializeComponent();
        }

        private void nhanvien_1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string magv = manv;
            int tuan = comboBox1.SelectedIndex + 1;
            khoitaobandau(magv, tuan, b21);
            khoitaobandau(magv, tuan, b22);
            khoitaobandau(magv, tuan, b23);
            khoitaobandau(magv, tuan, b24);
            khoitaobandau(magv, tuan, b25);
            khoitaobandau(magv, tuan, b26);
            khoitaobandau(magv, tuan, b31);
            khoitaobandau(magv, tuan, b32);
            khoitaobandau(magv, tuan, b33);
            khoitaobandau(magv, tuan, b34);
            khoitaobandau(magv, tuan, b35);
            khoitaobandau(magv, tuan, b36);
            khoitaobandau(magv, tuan, b41);
            khoitaobandau(magv, tuan, b42);
            khoitaobandau(magv, tuan, b43);
            khoitaobandau(magv, tuan, b44);
            khoitaobandau(magv, tuan, b45);
            khoitaobandau(magv, tuan, b46);
            khoitaobandau(magv, tuan, b51);
            khoitaobandau(magv, tuan, b52);
            khoitaobandau(magv, tuan, b53);
            khoitaobandau(magv, tuan, b54);
            khoitaobandau(magv, tuan, b55);
            khoitaobandau(magv, tuan, b56);
            khoitaobandau(magv, tuan, b61);
            khoitaobandau(magv, tuan, b62);
            khoitaobandau(magv, tuan, b63);
            khoitaobandau(magv, tuan, b64);
            khoitaobandau(magv, tuan, b65);
            khoitaobandau(magv, tuan, b66);
            khoitaobandau(magv, tuan, b71);
            khoitaobandau(magv, tuan, b72);
            khoitaobandau(magv, tuan, b73);
            khoitaobandau(magv, tuan, b74);
            khoitaobandau(magv, tuan, b75);
            khoitaobandau(magv, tuan, b76);
            khoitaobandau(magv, tuan, b81);
            khoitaobandau(magv, tuan, b82);
            khoitaobandau(magv, tuan, b83);
            khoitaobandau(magv, tuan, b84);
            khoitaobandau(magv, tuan, b85);
            khoitaobandau(magv, tuan, b86);
        }
        private void khoitaobandau(string manv, int tuan, Button b)
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
            cmd.CommandText = "kiemtratontai_nhanvien";

            cmd.Parameters.Add("@MAnv", SqlDbType.VarChar).Value = manv;
            cmd.Parameters.Add("@tuandk", SqlDbType.Int).Value = tuan;
            cmd.Parameters.Add("@thudk", SqlDbType.Int).Value = thu;
            cmd.Parameters.Add("@tietdk", SqlDbType.Int).Value = kip;
            cmd.Connection = conn;
            kq = cmd.ExecuteScalar();
            code = Convert.ToInt32(kq);
            if (code == 1)
            {
                //b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                b.Text = "Done";
                b.Enabled = true;
            }
            else
            {
                //b.BackColor = System.Drawing.Color.CornflowerBlue;
                //b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                //                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                b.Text = "-";
                b.Enabled = false;
            }

        }

        private void b21_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Text == "-") return;

            int tuan = comboBox1.SelectedIndex + 1;
            nhanvien_1_xem n = new nhanvien_1_xem(this.manv, b, tuan);
            n.ShowDialog();

        }
    }
}
