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
    public partial class OnerilenKitap : Form
    {
        sqlbaglantısı baglanti = new sqlbaglantısı();
        public OnerilenKitap()
        {
            InitializeComponent();
        }

        private void OnerilenKitap_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele() // Kitap Tablosunu listeler
        {
            String komut2 = "Select * From Tbl_Onerilen";
            SqlDataAdapter lst = new SqlDataAdapter(komut2, baglanti.baglantı());
            DataSet ds = new DataSet();
            lst.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }
    }
}
