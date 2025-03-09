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
    public partial class FrmKullaniciGiris : Form
    {
        public FrmKullaniciGiris()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı(); // Sql Bağlantısı
        private void LnkKayıtOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKayitOl fr = new FrmKayitOl();
            fr.Show();
            
        }

        private void BtnGirisYap_Click(object sender, EventArgs e) // Giriş butonu
        {
            try
            {
                // Araçtaki verilerden Kullanıcı tablosundan veri seçer
                SqlCommand komut = new SqlCommand("Select * From Tbl_KullaniciBilgileri where KullaniciTC=@p3 and KullaniciSifre=@p4", bgl.baglantı());
                komut.Parameters.AddWithValue("@p3", MskTC.Text);
                komut.Parameters.AddWithValue("@p4", TxtSifre.Text);
                SqlDataReader dr = komut.ExecuteReader(); // Seçilen veri okunur
                if (dr.Read()) // Eğer veri varsa
                {
                    KullaniciAnaSayfa fr = new KullaniciAnaSayfa();
                    fr.TC = MskTC.Text;
                    fr.Show(); // Kullanıcı ekranını açar
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı TC & Şifre");
                }
                bgl.baglantı().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
