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
    public partial class FrmYoneticiGiris : Form
    {
        public FrmYoneticiGiris()
        {
            InitializeComponent();
        }
        sqlbaglantısı baglantı = new sqlbaglantısı(); // Sql bağlantısı
        private void BtnGirisYap_Click(object sender, EventArgs e) // Giriş butonu
        {
            try
            {

                SqlCommand komut = new SqlCommand("Select * from Tbl_YoneticiBilgileri where YoneticiTc=@b and YoneticiSifre=@b2", baglantı.baglantı());
                komut.Parameters.AddWithValue("@b", MskTC.Text);
                komut.Parameters.AddWithValue("@b2", MskSifre.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Giriş Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    YöneticiAnasayfa ye = new YöneticiAnasayfa();
                    ye.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Yanlış Tc & Şifre", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglantı.baglantı().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
    
}
