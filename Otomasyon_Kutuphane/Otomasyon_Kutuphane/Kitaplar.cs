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
    public partial class Kitaplar : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı(); // Sql bağlantısı
        public Kitaplar()
        {
            InitializeComponent();
            cmbKategori.Items.Clear(); // CmbKategoriyi temizler
            cmbKategori.Items.AddRange(new string[] { "Roman", "Hikaye", "Kurgu Dışı" }); // CmbKategoriye değişken atama
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Kitaplar_Load(object sender, EventArgs e)
        {
            Listele();

        }
        public void Listele() // Kitap Tablosunu listeler
        {
            String komut = " Select * from Tbl_KitapBilgileri ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        
        public void Arama(string Ad) // Girilen değişkene göre Kitap Tablosunu listeler
        {
            string komut = "SELECT * FROM Tbl_KitapBilgileri WHERE KitapIsim = @p1";
            using (SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı()))
            {
                da.SelectCommand.Parameters.AddWithValue("@p1", Ad);

                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Aradığınız Kitap Bulunamadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTur.Items.Clear(); // CmbTur temizlenir
            switch (cmbKategori.SelectedItem.ToString()) // CmbKategori değişkenine göre CmbTure değer atanır
            {
                case "Roman":
                    cmbTur.Items.AddRange(new string[] { "Komedi", "Psikoloji", "Macera", "Aşk-Romantik", "Dram", "Polisiye", "Fantastik", "Bilim Kurgu", "Tarihi Roman" ,"Postmodern"});
                    break;
                case "Hikaye":
                    cmbTur.Items.AddRange(new string[] { "Çocuk Hikayeleri", "Komedi", "Macera", "Aşk-Romantik", "Dram", "Polisiye", "Fantastik", "Bilim Kurgu", "Tarihi Hikaye" });
                    break;
                case "Kurgu Dışı":
                    cmbTur.Items.AddRange(new string[] { "Biyografi-Otobiyografi", "Anı(Hatırat)", "Gezi Yazıları", "Deneme", "Makale-İnceleme", "Araştırma", "Tarih", "Bilimsel Yayınlar", "Psikoloji", "Sosyoloji", "Felsefe", "Akademik-Eğitim", "Kişisel Gelişim", "Sanat-Hobi", "Din-İnanç", "Eğlence-Popüler Kültür", "Teknik-Mesleki Kitaplar" });

                    break;

                default:
                    cmbTur.Items.Add("Tür Bulunamadı.");
                    break;

            }

        }

        private void btnFiltrele_Click(object sender, EventArgs e) // Filtrele butonu
        {
            Filtrele();
        }
        public void Filtrele() // CmbKategori ve CmbTur değişkenlerine göre Kitap Tablosunu listeler
        {
            try
            {
                string komut = "SELECT * FROM Tbl_KitapBilgileri WHERE KitapKategorisi = @p1 and KitapTuru=@p2 ";
                using (SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı()))
                {
                    da.SelectCommand.Parameters.AddWithValue("@p1", cmbKategori.Text);
                    da.SelectCommand.Parameters.AddWithValue("@p2", cmbTur.Text);

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Aradığınız Kriterde Kitap Bulunamamıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Arama(txtIsım.Text);
        }
    }
}
