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
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }
        public string tc;
       
        sqlbaglantisi bgl = new sqlbaglantisi();
        
        private void HastaDetay_Load(object sender, EventArgs e)
        {
            //AdSoyadÇekme
            lblkbtc.Text = tc;
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from tbl_Hasta where TCKimlikNo=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", lblkbtc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblkbadsoyad.Text = dr[0] + " "+ dr[1];
            }
            bgl.baglanti().Close();
            //randevuGeçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Randevular where HastaTc=" + tc, bgl.baglanti());
            da.Fill(dt);
            txtid.DataSource = dt;

            //branslarıçekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from tbl_Brans", bgl.baglanti());
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                cmbbrans.Items.Add(dr1[0].ToString());
            }
            bgl.baglanti().Close();

        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            cmbdoktor.Text = "";
            SqlCommand komut = new SqlCommand("Select doktorAd,doktorSoyad from tbl_Doktor where doktorBrans=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", cmbbrans.Text);
            SqlDataReader dr3 = komut.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter komut = new SqlDataAdapter("Select * from tbl_Randevular where RandevuBrans = '" + cmbbrans.Text + "'"+" and RandevuDoktor ='" + cmbdoktor.Text + "' and RandevuDurum=0", bgl.baglanti());
            komut.Fill(dt);
            aktifrandevugb.DataSource = dt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BilgiDüzenle bg = new BilgiDüzenle();
            bg.TC = lblkbtc.Text;
            bg.Show();
        }

        private void cmbrandevual_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_Randevular set RandevuDurum=1, HastaTc=@A1,HastaSikayet=@a2 where RandevuId=@a3", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", lblkbtc.Text);
            komut.Parameters.AddWithValue("@a2", cmbsikayet.Text);
            komut.Parameters.AddWithValue("@a3", textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı");
        }

        private void aktifrandevugb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = aktifrandevugb.SelectedCells[0].RowIndex;
            textBox1.Text = aktifrandevugb.Rows[secilen].Cells[0].Value.ToString();
        }
    }
}
