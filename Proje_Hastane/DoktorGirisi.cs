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
    public partial class DoktorGirisi : Form
    {
        public DoktorGirisi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void DoktorGirisi_Load(object sender, EventArgs e)
        {
          
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_Doktor where doktorTC=@a1 and doktorSifre=@a2", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", msktc.Text);
            komut.Parameters.AddWithValue("@a2", tctsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetay dt = new DoktorDetay();
                dt.tc = msktc.Text;
                dt.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre ve ya Kullanıcı Adı Yanlış!");
            }
            bgl.baglanti().Close();
        }
    }
}
