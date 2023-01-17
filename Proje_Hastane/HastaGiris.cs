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
    public partial class HastaGiris : Form
    {
        public HastaGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayıtForm hkf = new HastaKayıtForm();
            hkf.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Select * from tbl_hasta where TCKimlikNo=@a1 and Sifre=@a2",bag.baglanti());
            komut.Parameters.AddWithValue("@a1", msktc.Text);
            komut.Parameters.AddWithValue("@a2", tctsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                HastaDetay hd = new HastaDetay();         
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
