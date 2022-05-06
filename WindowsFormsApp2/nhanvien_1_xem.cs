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
    public partial class nhanvien_1_xem : Form
    {
        public string manv;
        Button b;
        int tuan;
        public nhanvien_1_xem(string manv,Button b,int tuan)
        {
            this.manv = manv;
            this.b = b;
            this.tuan = tuan;
            InitializeComponent();
        }

        private void nhanvien_1_xem_Load(object sender, EventArgs e)
        {
            string magv="";
            string mapm="";
            string malhp="";
            int thu = b.Name[1] - 48;
            int kip = b.Name[2] - 48;

            SqlConnection connection = new SqlConnection("server=LAPTOP-T5RPN2PG; database=QLPM ;integrated security=true");
            string s1 = "select malhp,magv,mapm,manv from lich_dkth,lich_th where tuan=" + this.tuan + " and thu = " + thu + " and tietdk=" + kip + " and lich_dkth.maldk=lich_th.maldk";
            SqlCommand cmd = new SqlCommand(s1, connection);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["manv"].ToString() == manv)
                {
                    malhp = sdr["malhp"].ToString();
                    magv = sdr["magv"].ToString();
                    mapm = sdr["mapm"].ToString();


                }

            }
            textBox1.Text = magv;
            textBox2.Text = malhp;
            textBox3.Text = mapm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
