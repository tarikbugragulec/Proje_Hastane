using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btndoktorgiris_Click(object sender, EventArgs e)
        {
            DoktorGirisi dg = new DoktorGirisi();
            dg.Show();
            this.Hide();
        }

        private void btnhastagiris_Click(object sender, EventArgs e)
        {
            HastaGiris hg = new HastaGiris();
            hg.Show();
            this.Hide();
        }

        private void btnsekretergiris_Click(object sender, EventArgs e)
        {
            SekreterGiris sg = new SekreterGiris();
            sg.Show();
            this.Hide();
        }
    }
}
