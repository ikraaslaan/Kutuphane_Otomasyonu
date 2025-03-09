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
    public partial class IadeEtme : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı();
        DateTime dt = DateTime.Now;
        public IadeEtme()
        {
            InitializeComponent();
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
            MessageBox.Show("Kitap iade alındı ve stok güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();
                


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSeç_Click(object sender, EventArgs e)
        {
            txtTc.Text = gridView1.GetFocusedRowCellValue("KullaniciTc").ToString();
            txtIsbn.Text = gridView1.GetFocusedRowCellValue("ISBN").ToString();
            txtSonteslim.Text = gridView1.GetFocusedRowCellValue("SonTeslimTarihi").ToString();

        }
        public void Listele() 
        {
            String komut = " Select * from OduncBilgileri where IadeTarihi is null ";
            SqlDataAdapter da = new SqlDataAdapter(komut, baglantı.baglantı());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void IadeEtme_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
