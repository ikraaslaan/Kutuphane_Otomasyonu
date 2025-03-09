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
    public partial class YöneticiAnasayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public YöneticiAnasayfa()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e) // Kitap ekleme formunu açar
        {
            KitapEkleme ke = new KitapEkleme();
            ke.MdiParent = this;
            ke.Show();

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e) // Kitap silme formunu açar
        {
            KitapSilme ks = new KitapSilme();
            ks.MdiParent = this;
            ks.Show();
        }

        private void YöneticiAnasayfa_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e) // Kitap güncelleme formunu açar
        {
            KitapGuncelleme kg = new KitapGuncelleme();
            kg.MdiParent = this;
            kg.Show();

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e) // Kullanıcı ekleme formunu açar
        {
            KullaniciEkleme ke = new KullaniciEkleme();
            ke.MdiParent = this;
            ke.Show();

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e) // Kullanıcı silme formunu açar
        {
            KullaniciSilmecs ks = new KullaniciSilmecs();
            ks.MdiParent = this;
            ks.Show();

        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e) // Kullanıcı güncelleme formunu açar
        {
            KullaniciGuncelle kg = new KullaniciGuncelle();
            kg.MdiParent = this;
            kg.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) // Kitaplar formunu açar
        {
            Kitaplar tk = new Kitaplar();
            tk.MdiParent = this;
            tk.Show();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)// Ödünç verme formunu açar
        {
            OducVerme ov = new OducVerme();
            ov.MdiParent = this;
            ov.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            IadeEtme ia = new IadeEtme();
            ia.MdiParent = this;
            ia.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            KitapOnerme ko = new KitapOnerme();
            ko.MdiParent = this;
            ko.Show();

        }
    }
}