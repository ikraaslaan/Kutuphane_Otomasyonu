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
    public partial class KullaniciSilmecs : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı(); // Sql bağlantısı
        public KullaniciSilmecs()
        {
            InitializeComponent();
            Listele();
        }

        private void KullaniciSilmecs_Load(object sender, EventArgs e)
        {

        }
        public void Listele() // Kullanıcı tablosunu listeler
        {
            String komut = " Select * from Tbl_KullaniciBilgileri ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnEkle_Click(object sender, EventArgs e) // Silme butonu
        {
            try
            {
                // Gridden seçilen satırın Tc değerini KullaniciTC değişkenine atar
                object focusedValue = gridView1.GetFocusedRowCellValue("KullaniciTc");

                // Null veya boş değer kontrolü
                if (focusedValue == null || string.IsNullOrWhiteSpace(focusedValue.ToString()))
                {
                    MessageBox.Show("Lütfen bir satır seçiniz ve geçerli bir TC numarası olduğundan emin olun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // KullaniciTC'yi bir değişkene atar
                string KullaniciTC = focusedValue.ToString();

                // Onay isteme
                DialogResult onay = MessageBox.Show($" {KullaniciTC} Kimlik Numaralı Kullanıcıyı Kalıcı Olarak Silmek İstiyor Musunuz? ", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (onay == DialogResult.Yes) // Onay verilirse
                {
                    txtKullaniciAdi.Text = gridView1.GetFocusedRowCellValue("KullaniciAd").ToString();
                    txtKullaniciSoyadi.Text = gridView1.GetFocusedRowCellValue("KullaniciSoyad").ToString();
                    txtTc.Text = gridView1.GetFocusedRowCellValue("KullaniciTc").ToString();
                    txtSifre.Text = gridView1.GetFocusedRowCellValue("KullaniciSifre").ToString();
                    mskNo.Text = gridView1.GetFocusedRowCellValue("TelefonNumarasi").ToString();

                    // Kullanıcı TC'sine göre Kullanıcı tablosundan veri siler
                    SqlCommand sil = new SqlCommand("delete from Tbl_KullaniciBilgileri where KullaniciTC = @c", baglantı.baglantı());
                    sil.Parameters.AddWithValue("@c", KullaniciTC);
                    sil.ExecuteNonQuery();
                    baglantı.baglantı().Close();
                    Listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSec_Click(object sender, EventArgs e)
        {
           
        }
    }
}

