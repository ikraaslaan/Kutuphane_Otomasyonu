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
    
    public partial class PopulerKitaplar : Form
    {
        sqlbaglantısı baglanti = new sqlbaglantısı();

        public PopulerKitaplar()
        {
            InitializeComponent();
        }

        private void PopulerKitaplar_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele() // Kitap tablosunu listeler ve ToplamOduncSayisi'na göre sıralar
        {
            string komut = "SELECT * FROM Tbl_KitapBilgileri ORDER BY ToplamOduncSayısı DESC";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglanti.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

    }
}
