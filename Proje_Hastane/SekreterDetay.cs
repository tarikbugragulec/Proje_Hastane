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
    public partial class lbltc : Form
    {
        public lbltc()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        private void lbltc_Load(object sender, EventArgs e)
        {
            //adsoyadyeri

            lbltcno.Text = tc;
            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad from tbl_Sekreter where SekreterTC=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", lbltcno.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                labelAD.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //branşları aktaema
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd from tbl_Brans", bgl.baglanti());
            da.Fill(dt);
            LBLad.DataSource = dt;
            //doktorlar
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select (doktorAd + ' ' + doktorSoyad) as 'Doktorlar',doktorBrans from tbl_Doktor", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            //branşı comboboxa aktarma
            SqlCommand komut3 = new SqlCommand("select BransAd from tbl_Brans", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cbbrans.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();

            

           

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,RandevuDurum)values (@a1,@a2,@a3,@a4,@a5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", mttarih.Text);
            komut.Parameters.AddWithValue("@a2", mtsaat.Text);
            komut.Parameters.AddWithValue("@a3", cbbrans.Text);
            komut.Parameters.AddWithValue("@a4", cbdoktor.Text);
            komut.Parameters.AddWithValue("@a5", checkBox1.Checked);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbdoktor.Items.Clear();
            cbdoktor.Text = "";
            SqlCommand komut5 = new SqlCommand("Select doktorAd,doktorSoyad from tbl_Doktor where doktorBrans=@a1", bgl.baglanti());
            komut5.Parameters.AddWithValue("@a1", cbbrans.Text);
            SqlDataReader dr4 = komut5.ExecuteReader();
            while (dr4.Read())
            {
                cbdoktor.Items.Add(dr4[0] + " " + dr4[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Duyuru (Duyuru) values (@a1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btndoktorpanel_Click(object sender, EventArgs e)
        {
            DoktorPaneli dp = new DoktorPaneli();
            dp.Show();

        }

        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            Brans b = new Brans();
            b.Show();

        }

        private void btnrandevu_Click(object sender, EventArgs e)
        {
            RandevuListesi rl = new RandevuListesi();
            rl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Duyurular d = new Duyurular();
            d.Show();
        }
    }
}
