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
    public partial class KullaniciEkleme : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı(); // Sql bağlantısı
        public KullaniciEkleme()
        {
            InitializeComponent();
            Listele();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e) // Ekle butonu
        {
            try
            {
                // Kullanıcı bilgileri boş kontrolü
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                    string.IsNullOrWhiteSpace(txtKullaniciSoyadi.Text) ||
                    string.IsNullOrWhiteSpace(txtTc.Text) ||
                    string.IsNullOrWhiteSpace(txtSifre.Text) ||
                    string.IsNullOrWhiteSpace(mskNo.Text))
                {
                    MessageBox.Show("Tüm alanları doldurmanız gerekmektedir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand kontrol = new SqlCommand("select count (*) from Tbl_KullaniciBilgileri where KullaniciAd= @b", baglantı.baglantı());
                kontrol.Parameters.AddWithValue("@b", txtKullaniciAdi.Text);
                int kayit = (int)kontrol.ExecuteScalar();
                if (kayit > 0)
                {
                    MessageBox.Show("Bu kullanıcı bulunmaktadır. ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                // Kullanıcı tablosuna kullanıcı ekleme komutu

                SqlCommand Ekle = new SqlCommand("insert into Tbl_KullaniciBilgileri (KullaniciAd,KullaniciSoyad,KullaniciTC,KullaniciSifre,TelefonNumarasi) values" +
                 "(@a,@a2,@a3,@a4,@a5)", baglantı.baglantı());

                Ekle.Parameters.AddWithValue("@a", txtKullaniciAdi.Text);
                Ekle.Parameters.AddWithValue("@a2", txtKullaniciSoyadi.Text);
                Ekle.Parameters.AddWithValue("@a3", txtTc.Text);
                Ekle.Parameters.AddWithValue("@a4", txtSifre.Text);
                Ekle.Parameters.AddWithValue("@a5", mskNo.Text);

                Ekle.ExecuteNonQuery();
                baglantı.baglantı().Close();
                Listele();
                BilgileriSil();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            public void Listele() // Kullanıcı tablosunu inceler
        {
            try
            {
                String komut = " Select * from Tbl_KullaniciBilgileri";
                SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

