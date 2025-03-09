using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon_Kutuphane
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }
        private void BtnKullaniciGirisi_Click(object sender, EventArgs e)
        {
            FrmKullaniciGiris fr = new FrmKullaniciGiris();
            fr.Show();
            this.Hide();
        }

        private void BtnYoneticiGirisi_Click(object sender, EventArgs e)
        {
            FrmYoneticiGiris fr = new FrmYoneticiGiris ();
            fr.Show();
            this.Hide() ;
        }
    }
}
