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
    public partial class DoktorBilgiDüzenle : Form
    {
        public DoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcno;
        private void DoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            txttc.Text = tcno;

            SqlCommand komut = new SqlCommand("select * from tbl_Doktor where doktorTC=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", tcno);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbbrans.Text = dr[3].ToString();
                txtsifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_Doktor set doktorAd=@a1,doktorSoyad=@a2,doktorBrans=@a3,doktorSifre=@a4 where doktorTC=@a5", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", txtad.Text);
            komut.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@a3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@a4", txtsifre.Text);
            komut.Parameters.AddWithValue("@a5", txttc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncellendi..");
        }
    }
}
