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

namespace Proje_Hastane
{
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from tbl_Sekreter where SekreterTC=@a1 and SekreterSifre=@a2", bag.baglanti());
            komut.Parameters.AddWithValue("@a1", msktc.Text);
            komut.Parameters.AddWithValue("@a2", tctsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                lbltc hd = new lbltc();
                hd.tc = msktc.Text;
                hd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Şifre veya Kullanıcı Adı");
            }
            bag.baglanti().Close();
        }
    }
}
