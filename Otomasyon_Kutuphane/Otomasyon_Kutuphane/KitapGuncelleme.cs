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
    public partial class KitapGuncelleme : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı(); //Sql bağlantısı
        public KitapGuncelleme()
        {
            InitializeComponent();
            Listele();
            MskİSBN.ReadOnly = true;
            CmbKategori.Items.Clear(); //CmbKategoriyi temizler
            CmbKategori.Items.AddRange(new string[] { "Roman", "Hikaye", "Kurgu Dışı" }); // CmbKategoriye değişken atar
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("Update Tbl_KitapBilgileri set KitapIsim=@a1, Yazar=@a2,YayinYili=@a4,ToplamKitapSayisi=@a5,MevcutKitapSayisi=@a6,KitapKategorisi=@a7,KitapTuru=@a8,YayinEvi=@a9 where ISBN=@a3" , baglantı.baglantı());
            guncelle.Parameters.AddWithValue("@a1", TxtAd.Text);
            guncelle.Parameters.AddWithValue("@a2", TxtYazar.Text);
            guncelle.Parameters.AddWithValue("@a3", MskİSBN.Text);
            guncelle.Parameters.AddWithValue("@a4", MskYayınYılı.Text);
            guncelle.Parameters.AddWithValue("@a5", MskSayi.Text);
            guncelle.Parameters.AddWithValue("@a6", MskSayi.Text);
            guncelle.Parameters.AddWithValue("@a7", CmbKategori.Text);
            guncelle.Parameters.AddWithValue("@a8", CmbTur.Text);
            guncelle.Parameters.AddWithValue("@a9", TxtYayınEvi.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kitap Bilgileri Güncellendi");
            Listele();

        }

        private void simpleButton1_Click(object sender, EventArgs e) // Gridden verileri araçlara taşır
        {
            TxtAd.Text = gridView1.GetFocusedRowCellValue("KitapIsim").ToString();
            TxtYazar.Text = gridView1.GetFocusedRowCellValue("Yazar").ToString();
            MskİSBN.Text = gridView1.GetFocusedRowCellValue("ISBN").ToString();
            MskYayınYılı.Text = gridView1.GetFocusedRowCellValue("YayinYili").ToString();
            MskSayi.Text = gridView1.GetFocusedRowCellValue("ToplamKitapSayisi").ToString();
            MskSayi.Text = gridView1.GetFocusedRowCellValue("MevcutKitapSayisi").ToString();
            CmbKategori.Text = gridView1.GetFocusedRowCellValue("KitapKategorisi").ToString();
            CmbTur.Text = gridView1.GetFocusedRowCellValue("KitapTuru").ToString();
            TxtYayınEvi.Text = gridView1.GetFocusedRowCellValue("YayinEvi").ToString();
        }
        public void Listele() // Kitap tablosunu listeler
        {
            String komut = " Select * from Tbl_KitapBilgileri ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnGuncelle_Click(object sender, EventArgs e) // Güncelle butonu
        {
            try
            {
                // Kitap tablosunu güncelleme komutu
                SqlCommand btn = new SqlCommand("Insert into KitapBilgileri (KitapIsim,Yazar,ISBN,YayinYili,ToplamKitapSayisi,MevcutKitapSayisi,KitapKategorisi,KitapTuru,YayinEvi) " +
                "values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)", baglantı.baglantı());
                btn.Parameters.AddWithValue("@a1", TxtAd.Text);
                btn.Parameters.AddWithValue("@a2", TxtYazar.Text);
                btn.Parameters.AddWithValue("@a3", MskİSBN.Text);
                btn.Parameters.AddWithValue("@a4", MskYayınYılı.Text);
                btn.Parameters.AddWithValue("@a5", MskSayi.Text);
                btn.Parameters.AddWithValue("@a6", MskSayi.Text);
                btn.Parameters.AddWithValue("@a7", CmbKategori.Text);
                btn.Parameters.AddWithValue("@a8", CmbTur.Text);
                btn.Parameters.AddWithValue("@a9", TxtYayınEvi.Text);
                btn.ExecuteNonQuery();
                baglantı.baglantı().Close();
                Listele();
                BilgileriSil();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void BilgileriSil() // Araçları temizler
        {
            TxtAd.Text = "";
            TxtYazar.Text = "";
            MskİSBN.Text = "";
            MskYayınYılı.Text = "";
            MskSayi.Text = "";
            CmbKategori.Text = "";
            CmbTur.Text = "";
            TxtYayınEvi.Text = "";
        }

        private void KitapGuncelle_Load(object sender, EventArgs e)
        {
            MskİSBN.ReadOnly = true; // mskİSBN sadece okunur
        }

        private void KitapGuncelleme_Load(object sender, EventArgs e)
        {
            CmbKategori.Items.Clear(); //CmbKategoriyi temizler
            CmbKategori.Items.AddRange(new string[] { "Roman", "Hikaye", "Kurgu Dışı" }); // CmbKategoriye değişken atar
        }

        private void CmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
                CmbTur.Items.Clear(); // CmbTur temizlenir
                switch (CmbKategori.SelectedItem.ToString()) // CmbKategori değişkenine göre CmbTure değer atanır
                {
                    case "Roman":
                        CmbTur.Items.AddRange(new string[] { "Komedi", "Psikoloji", "Macera", "Aşk-Romantik", "Dram", "Polisiye", "Fantastik", "Bilim Kurgu", "Tarihi Roman", "Postmodern" });
                        break;
                    case "Hikaye":
                        CmbTur.Items.AddRange(new string[] { "Çocuk Hikayeleri", "Komedi", "Macera", "Aşk-Romantik", "Dram", "Polisiye", "Fantastik", "Bilim Kurgu", "Tarihi Hikaye" });
                        break;
                    case "Kurgu Dışı":
                        CmbTur.Items.AddRange(new string[] { "Biyografi-Otobiyografi", "Anı(Hatırat)", "Gezi Yazıları", "Deneme", "Makale-İnceleme", "Araştırma", "Tarih", "Bilimsel Yayınlar", "Psikoloji", "Sosyoloji", "Felsefe", "Akademik-Eğitim", "Kişisel Gelişim", "Sanat-Hobi", "Din-İnanç", "Eğlence-Popüler Kültür", "Teknik-Mesleki Kitaplar" });

                        break;

                    default:
                        CmbTur.Items.Add("Tür Bulunamadı.");
                        break;

                }

            
        }
    }
}


