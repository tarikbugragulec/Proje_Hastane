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
    public partial class DoktorPaneli : Form
    {
        public DoktorPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            //dokotrçekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from tbl_Doktor", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            // SqlCommand komut3 = new SqlCommand("select BransAd from tbl_Brans", bgl.baglanti());
            SqlCommand komut3 = new SqlCommand("select BransAd from tbl_Brans", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox1.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_doktor (doktorAd,doktorSoyad,doktorBrans,doktorTC,doktorSifre) values (@a1,@a2,@a3,@a4,@a5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", txtad.Text);
            komut.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@a3", comboBox1.Text);
            komut.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@a5", textBox3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_Doktor where doktorId=@a1", bgl.baglanti());
            komut.Parameters.Add("@a1", maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update tbl_Doktor set doktorAd=@a1,doktorSoyad=@a2,doktorBrans=@a3,doktorSifre=@a5 where doktorTC=@a4", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1",txtad.Text);
            komut.Parameters.AddWithValue("@a2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@a3",comboBox1.Text);
            komut.Parameters.AddWithValue("@a5",textBox3.Text);
            komut.Parameters.AddWithValue("a4",maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kişi Güncellendi");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
