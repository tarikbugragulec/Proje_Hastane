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
    public partial class BilgiDüzenle : Form
    {
        public BilgiDüzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        public string TC;
        private void BilgiDüzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = TC;
            SqlCommand komut = new SqlCommand("Select * from tbl_Hasta where TCKimlikNo=@a1", bag.baglanti());
            komut.Parameters.Add("@a1", TC);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                maskno.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
                cmbbxcinsiyet.Text = dr[6].ToString();
            }
            bag.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_Hasta set HastaAd=@a1,HastaSoyad=@a2,Numara=@a3,Sifre=@a4,Cinsiyet=@a5 where TCKimlikNo=@a6", bag.baglanti());
            komut.Parameters.AddWithValue("@a1",txtad.Text);
            komut.Parameters.AddWithValue("@a2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@a3",maskno.Text);
            komut.Parameters.AddWithValue("@a4",txtsifre.Text);
            komut.Parameters.AddWithValue("@a5",cmbbxcinsiyet.Text);
            komut.Parameters.AddWithValue("@a6", msktc.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi!");
            bag.baglanti().Close();
        }
    }
}
