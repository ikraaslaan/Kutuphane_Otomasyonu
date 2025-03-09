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
    public partial class KullaniciGuncelle : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı(); // Sql bağlantısı
        public KullaniciGuncelle()
        {
            InitializeComponent();
            Listele();
        }

        private void KullaniciGuncelle_Load(object sender, EventArgs e)
        {
            txtTc.ReadOnly = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e) // Gridden verileri araçlara taşır
        {
            txtKullaniciAdi.Text = gridView1.GetFocusedRowCellValue("KullaniciAd").ToString();
            txtKullaniciSoyadi.Text = gridView1.GetFocusedRowCellValue("KullaniciSoyad").ToString();
            txtTc.Text = gridView1.GetFocusedRowCellValue("KullaniciTc").ToString();
            txtSifre.Text = gridView1.GetFocusedRowCellValue("KullaniciSifre").ToString();
            mskNo.Text = gridView1.GetFocusedRowCellValue("TelefonNumarasi").ToString();
        }
        public void Listele() // Kullanıcı Tablosunu listeler
        {
            String komut = " Select * from Tbl_KullaniciBilgileri ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnEkle_Click(object sender, EventArgs e) // Güncelleme butonu
        {
            try
            {
                
                // Kullanıcı Tablosunu güncelleme komutu
                SqlCommand guncelle = new SqlCommand("Update Tbl_KullaniciBilgileri set KullaniciSoyad=@d3,KullaniciAd=@d4,KullaniciSifre=@d5 ,TelefonNumarasi=@d6 where KullaniciTc=@d2", baglantı.baglantı());
                guncelle.Parameters.AddWithValue("@d2", txtTc.Text);
                guncelle.Parameters.AddWithValue("@d3", txtKullaniciSoyadi.Text);
                guncelle.Parameters.AddWithValue("@d4", txtKullaniciAdi.Text);
                guncelle.Parameters.AddWithValue("@d5", txtSifre.Text);
                guncelle.Parameters.AddWithValue("@d6", mskNo.Text);
                guncelle.ExecuteNonQuery();
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
            txtKullaniciAdi.Text = "";
            txtKullaniciSoyadi.Text = "";
            txtTc.Text = "";
            txtSifre.Text = "";
            mskNo.Text = "";

        }

    }
}
