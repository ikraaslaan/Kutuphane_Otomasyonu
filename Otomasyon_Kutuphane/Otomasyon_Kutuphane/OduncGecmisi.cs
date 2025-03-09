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

namespace Otomasyon_Kutuphane
{
    public partial class OduncGecmisi : Form
    {
        sqlbaglantısı baglanti = new sqlbaglantısı();
        public string TC;


        public OduncGecmisi()
        {
            InitializeComponent();
        }

        private void OduncGecmisi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele() // Kitap Tablosunu listeler
        {
            String komut2 = "Select * From OduncBilgileri where KullaniciTc=@tc";
            SqlDataAdapter lst = new SqlDataAdapter(komut2, baglanti.baglantı());
            lst.SelectCommand.Parameters.AddWithValue("@tc", TC);
            DataSet ds = new DataSet();
            lst.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

    }
}
