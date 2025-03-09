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
    public partial class KitapOnerme : Form
    {
        sqlbaglantısı baglanti = new sqlbaglantısı();
        public KitapOnerme()
        {
            InitializeComponent();
        }

        private void KitapOnerme_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele() // Kitap Tablosunu listeler
        {
            String komut2 = "Select * From Tbl_KitapBilgileri";
            SqlDataAdapter lst = new SqlDataAdapter(komut2, baglanti.baglantı());
            DataSet ds = new DataSet();
            lst.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            TxtAd.Text = gridView1.GetFocusedRowCellValue("KitapIsim").ToString();
            TxtYazar.Text = gridView1.GetFocusedRowCellValue("Yazar").ToString();
            MskİSBN.Text = gridView1.GetFocusedRowCellValue("ISBN").ToString();
            MskYayınYılı.Text = gridView1.GetFocusedRowCellValue("YayinYili").ToString();
            MskSayi.Text = gridView1.GetFocusedRowCellValue("MevcutKitapSayisi").ToString();
            CmbKategori.Text = gridView1.GetFocusedRowCellValue("KitapKategorisi").ToString();
            CmbTur.Text = gridView1.GetFocusedRowCellValue("KitapTuru").ToString();
            TxtYayınEvi.Text = gridView1.GetFocusedRowCellValue("YayinEvi").ToString();
        }

        private void btnOner_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into Tbl_Onerilen (KitapIsim,Yazar,ISBN,YayinYili,MevcutKitapSayisi,KitapKategorisi,KitapTuru,YayinEvi) " +
                    "values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8)", baglanti.baglantı());
            ekle.Parameters.AddWithValue("@a1", TxtAd.Text);
            ekle.Parameters.AddWithValue("@a2", TxtYazar.Text);
            ekle.Parameters.AddWithValue("@a3", MskİSBN.Text);
            ekle.Parameters.AddWithValue("@a4", MskYayınYılı.Text);
            ekle.Parameters.AddWithValue("@a5", MskSayi.Text);
            ekle.Parameters.AddWithValue("@a6", CmbKategori.Text);
            ekle.Parameters.AddWithValue("@a7", CmbTur.Text);
            ekle.Parameters.AddWithValue("@a8", TxtYayınEvi.Text);

            ekle.ExecuteNonQuery();
            MessageBox.Show("Kitabı Önerdiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
