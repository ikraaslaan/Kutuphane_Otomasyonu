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
    public partial class RastgeleKitap : Form
    {
        sqlbaglantısı baglantı = new sqlbaglantısı();
        public RastgeleKitap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanından rastgele bir kitap seçme sorgusu
                string komut = "SELECT TOP 1 * FROM Tbl_KitapBilgileri ORDER BY NEWID()";

                // SQL bağlantısı ve komut oluşturma
                SqlCommand cmd = new SqlCommand(komut, baglantı.baglantı());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Kitap bilgilerini RichTextBox'a yazdırma
                    richTextBox1.Text = $" {dr["KitapIsim"]}"; 
                                       
                }
                else
                {
                    MessageBox.Show("Herhangi bir kitap bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dr.Close();
                baglantı.baglantı().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
