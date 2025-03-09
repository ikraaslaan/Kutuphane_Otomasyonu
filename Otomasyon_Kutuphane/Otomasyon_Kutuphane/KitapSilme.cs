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
    public partial class KitapSilme : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı(); //Sql bağlantısı
        public KitapSilme()
        {
            InitializeComponent();
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ISBN = gridView1.GetFocusedRowCellValue("ISBN").ToString(); // Seçilen satırda ISBN değerini ISBN değişkenine atar

            //Onay isteme
            DialogResult onay = MessageBox.Show($"ISBN Numarası {ISBN} Olan Kitabı Kalıcı Olarak Silmek İster Misiniz? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (onay == DialogResult.Yes) // Onay verirse
            {
                txtAd.Text = gridView1.GetFocusedRowCellValue("KitapIsim").ToString();
                txtYazar.Text = gridView1.GetFocusedRowCellValue("Yazar").ToString();
                mskİSBN.Text = gridView1.GetFocusedRowCellValue("ISBN").ToString();
                mskYayınYılı.Text = gridView1.GetFocusedRowCellValue("YayinYili").ToString();
                mskSayi.Text = gridView1.GetFocusedRowCellValue("ToplamKitapSayisi").ToString();
                mskSayi.Text = gridView1.GetFocusedRowCellValue("MevcutKitapSayisi").ToString();
                cmbKategori.Text = gridView1.GetFocusedRowCellValue("KitapKategorisi").ToString();
                cmbTur.Text = gridView1.GetFocusedRowCellValue("KitapTuru").ToString();
                txtYayınEvi.Text = gridView1.GetFocusedRowCellValue("YayinEvi").ToString();

                // Kitap tablosundan ISBN'ye göre kitap siler
                SqlCommand sil = new SqlCommand("delete from Tbl_KitapBilgileri where ISBN = @c", baglantı.baglantı());
                sil.Parameters.AddWithValue("@c", ISBN);
                sil.ExecuteNonQuery();
                baglantı.baglantı().Close();
                Listele();
            }
        }

        private void KitapSilme_Load(object sender, EventArgs e)
        {

        }
        public void Listele() // Kitap tablosunu listeler
        {
            String komut = " Select * from Tbl_KitapBilgileri ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

       

        
    }
}

