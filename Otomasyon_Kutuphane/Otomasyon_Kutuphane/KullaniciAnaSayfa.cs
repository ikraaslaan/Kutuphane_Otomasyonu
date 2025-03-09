using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Otomasyon_Kutuphane
{
    public partial class KullaniciAnaSayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       public string TC;

        public KullaniciAnaSayfa()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Kitaplar k = new Kitaplar();
            k.MdiParent = this;
            k.Show();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            OduncGecmisi og = new OduncGecmisi();
            og.TC = TC;
            og.MdiParent = this;
            og.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnerilenKitap ok = new OnerilenKitap();
            ok.MdiParent = this;
            ok.Show();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopulerKitaplar pk = new PopulerKitaplar();
            pk.MdiParent = this;
            pk.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            OduncAlma oa = new OduncAlma();
            oa.TC = TC;
            oa.MdiParent = this;
            oa.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            KullanıcıIade kı = new KullanıcıIade();
            kı.TC = TC;
            kı.MdiParent = this;
            kı.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            RastgeleKitap rk = new RastgeleKitap();
            rk.MdiParent = this;
            rk.Show();
        }
    }
}