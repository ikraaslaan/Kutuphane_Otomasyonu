﻿using System;
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
    public partial class OduncAlma : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı();
        public string TC;
        DateTime dt = DateTime.Now;


        public OduncAlma()
        {
            InitializeComponent();
        }

        private void OduncAlma_Load(object sender, EventArgs e)
        {
            Listele();
            txtTc.Text = TC;
            txtTc.ReadOnly = true;
            dateTimePicker1.MinDate = dt;
            dateTimePicker1.MaxDate = dt.AddDays(15); 

        }
        public void Listele() // Kitap tablosunu listeler
        {
            String komut = " Select * from Tbl_KitapBilgileri ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnBilgi_Click(object sender, EventArgs e)
        {
            txtKitapAdi.Text = gridView1.GetFocusedRowCellValue("KitapIsim").ToString();
            txtISBN.Text = gridView1.GetFocusedRowCellValue("ISBN").ToString();
        }

        private void btnOdunc_Click(object sender, EventArgs e)
        {
            SqlCommand OduncSınırı = new SqlCommand("Select Count(*) from OduncBilgileri where KullaniciTc = @t and IadeTarihi is null", baglantı.baglantı());
            OduncSınırı.Parameters.AddWithValue("@t", txtTc.Text);
            int OduncSayısı = (int)OduncSınırı.ExecuteScalar();
            if (OduncSayısı > 4)
            {
                MessageBox.Show("5'ten Fazla Kitap Ödünç Verilemez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ödünç Verme
            SqlCommand Odunc = new SqlCommand("INSERT INTO OduncBilgileri (KullaniciTc, ISBN, SonTeslimTarihi, TeslimAlmaTarihi) VALUES (@o1, @o2, @o3, @o4)", baglantı.baglantı());
            Odunc.Parameters.AddWithValue("@o1", txtTc.Text);
            Odunc.Parameters.AddWithValue("@o2", txtISBN.Text);
            Odunc.Parameters.AddWithValue("@o3", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            Odunc.Parameters.AddWithValue("@o4", dt.ToString("yyyy-MM-dd"));
            Odunc.ExecuteNonQuery();

            // Toplam ödünç sayısını artırma ve mevcut kitap sayısını azaltma
            SqlCommand kitapGuncelle = new SqlCommand("UPDATE Tbl_KitapBilgileri SET ToplamOduncSayısı = ToplamOduncSayısı + 1, MevcutKitapSayisi = MevcutKitapSayisi - 1 WHERE ISBN = @isbn AND MevcutKitapSayisi > 0", baglantı.baglantı());
            kitapGuncelle.Parameters.AddWithValue("@isbn", txtISBN.Text);
            int affectedRows = kitapGuncelle.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                MessageBox.Show("Kitap stokta bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Önerilen kitapları güncelleme
            SqlCommand Oduncguncelle = new SqlCommand("UPDATE Tbl_Onerilen SET ToplamOduncSayısı = ToplamOduncSayısı + 1 WHERE ISBN = @isbn", baglantı.baglantı());
            Oduncguncelle.Parameters.AddWithValue("@isbn", txtISBN.Text);
            Oduncguncelle.ExecuteNonQuery();

            MessageBox.Show("Kitap Ödünç Verildi ve toplam ödünç sayısı güncellendi.", "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Listeyi güncelleme
            Listele();
        }
    }
}
