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
    public partial class HastaKayıtForm : Form
    {
        public HastaKayıtForm()
        {
            InitializeComponent();
        }
        public string adsoyad;
        sqlbaglantisi sbag = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_hasta (HastaAd,HastaSoyad,TCKimlikNo,Numara,Sifre,Cinsiyet) values (@a1,@a2,@a3,@a4,@a5,@a6)", sbag.baglanti());
            komut.Parameters.AddWithValue("@a1", txtad.Text);
            komut.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@a3", txttc.Text);
            komut.Parameters.AddWithValue("@a4", masktcno.Text);
            komut.Parameters.AddWithValue("@a5", txtsifre.Text);
            komut.Parameters.AddWithValue("@a6", cmbbxcinsiyet.Text);
            komut.ExecuteNonQuery();
            sbag.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşti Şifreniz : " + MessageBox.Show("Şifreniz : " + txtsifre.Text));

        }
    }
}
