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
    public partial class KitapEkleme : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı();//Sql bağlantısı
        public KitapEkleme()
        {
            InitializeComponent();
            CmbKategori.Items.Clear(); //CmbKategoriyi temizler
            CmbKategori.Items.AddRange(new string[] { "Roman", "Hikaye", "Kurgu Dışı" }); // CmbKategoriye değişken atar
        }





        private void btnEkle_Click(object sender, EventArgs e) // Ekle butonu
        {
            try
            {
                // Kitap tablosundaki ISBN kontrolü
                SqlCommand komut = new SqlCommand("Select count (*) From Tbl_KitapBilgileri where ISBN =@a1", baglantı.baglantı());
                komut.Parameters.AddWithValue("@a1", MskİSBN.Text);
                int kayit = (int)komut.ExecuteScalar();
                if (kayit > 0) // Aynı ISBN mevcutsa
                {
                    MessageBox.Show("Bu ISBN Başka Bir Kitaba Aittir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                // Kitap Tablosuna ekleme komutu

                SqlCommand btn = new SqlCommand("Insert into Tbl_KitapBilgileri (KitapIsim,Yazar,ISBN,YayinYili,ToplamKitapSayisi,MevcutKitapSayisi,KitapKategorisi,KitapTuru,YayinEvi) " +
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
                MessageBox.Show("Kitap Eklendi", "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Listele() // Kitap Tablosunu listeler
        {
            String komut2 = "Select * From Tbl_KitapBilgileri";
            SqlDataAdapter lst = new SqlDataAdapter(komut2, baglantı.baglantı());
            DataSet ds = new DataSet();
            lst.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        private void KitapEkleme_Load(object sender, EventArgs e)
        {
            Listele();
        }


        private void CmbKategori_SelectedIndexChanged(object sender, EventArgs e) // CmbKategorinin değişmesi
        {
            CmbTur.Items.Clear(); // CmbTuru temizler
            switch (CmbKategori.SelectedItem.ToString()) // CmbKategori değişkenine göre CmbTure değişken atar
            {
                case "Roman":
                    CmbTur.Items.AddRange(new string[] { "Komedi", "Psikoloji", "Macera", "Aşk-Romantik", "Dram", "Polisiye", "Fantastik", "Bilim Kurgu", "Tarihi Roman" });
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

        private void KitapEkleme_Load_1(object sender, EventArgs e)
        {
            Listele();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
