using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        private void DoktorDetay_Load(object sender, EventArgs e)
        {
            //adsoyadyeri

            lblkbtc.Text = tc;
            SqlCommand komut = new SqlCommand("Select (doktorAd+ ' ' + doktorSoyad) as DoktorAd  from tbl_Doktor where doktorTC=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", lblkbtc.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                lblkbadsoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();
            //randevulistesi
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from tbl_Randevular where RandevuDoktor='" + lblkbadsoyad.Text + "' and RandevuDurum=1", bgl.baglanti());
            da1.Fill(dt1);
            btncıkıs.DataSource = dt1;
        }

        private void btnduyuru_Click(object sender, EventArgs e)
        {
            Duyurular d = new Duyurular();
            d.Show();
        }

        private void btnbilgi_Click(object sender, EventArgs e)
        {
            DoktorBilgiDüzenle dbd = new DoktorBilgiDüzenle();
            dbd.tcno = lblkbtc.Text;
            dbd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btncıkıs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = btncıkıs.SelectedCells[0].RowIndex;
            richTextBox1.Text = btncıkıs.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
