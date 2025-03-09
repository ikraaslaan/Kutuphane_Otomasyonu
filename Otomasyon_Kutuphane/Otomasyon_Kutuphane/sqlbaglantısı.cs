using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Otomasyon_Kutuphane
{
    class sqlbaglantısı
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=IKRA;Initial Catalog=Otomasyon_Kutuphane;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
