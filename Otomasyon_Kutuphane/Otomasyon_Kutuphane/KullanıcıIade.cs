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
    public partial class KullanıcıIade : Form
    {
        public string TC;
        sqlbaglantısı baglantı = new sqlbaglantısı();
        DateTime dt = DateTime.Now;

        public KullanıcıIade()
        {
            InitializeComponent();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KullanıcıIade_Load(object sender, EventArgs e)
        {
            Listele();
            txtTc.Text = TC;
            txtTc.ReadOnly = true;
        }

        public void Listele()
        {
            String komut = " Select * from OduncBilgileri where IadeTarihi is null and KullaniciTc=@tc ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            da.SelectCommand.Parameters.AddWithValue("@tc", TC);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnSeç_Click(object sender, EventArgs e)
        {
            txtIsbn.Text = gridView1.GetFocusedRowCellValue("ISBN").ToString();
            txtSonteslim.Text = gridView1.GetFocusedRowCellValue("SonTeslimTarihi").ToString();
        }

        private void btnIade_Click(object sender, EventArgs e)
        {
            SqlCommand iade = new SqlCommand("Update OduncBilgileri set IadeTarihi=@a where kullaniciTc=@a2", baglantı.baglantı());
            iade.Parameters.AddWithValue("@a", dt.ToString("yyyy-MM-dd"));
            iade.Parameters.AddWithValue("@a2", txtTc.Text);
            iade.ExecuteNonQuery();

            SqlCommand kitapGuncelle = new SqlCommand("UPDATE Tbl_KitapBilgileri SET MevcutKitapSayisi= MevcutKitapSayisi + 1 where ISBN=@isbn", baglantı.baglantı());
            kitapGuncelle.Parameters.AddWithValue("@isbn", txtIsbn.Text);
            kitapGuncelle.ExecuteNonQuery();
            MessageBox.Show("Kitap iade alındı ve stok güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
