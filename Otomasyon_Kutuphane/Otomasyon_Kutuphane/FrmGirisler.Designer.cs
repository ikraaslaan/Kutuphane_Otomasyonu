namespace Otomasyon_Kutuphane
{
    partial class FrmGirisler
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGirisler));
            this.BtnKullaniciGirisi = new System.Windows.Forms.Button();
            this.BtnYoneticiGirisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnKullaniciGirisi
            // 
            this.BtnKullaniciGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKullaniciGirisi.BackgroundImage")));
            this.BtnKullaniciGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKullaniciGirisi.Location = new System.Drawing.Point(48, 97);
            this.BtnKullaniciGirisi.Name = "BtnKullaniciGirisi";
            this.BtnKullaniciGirisi.Size = new System.Drawing.Size(232, 186);
            this.BtnKullaniciGirisi.TabIndex = 0;
            this.BtnKullaniciGirisi.UseVisualStyleBackColor = true;
            this.BtnKullaniciGirisi.Click += new System.EventHandler(this.BtnKullaniciGirisi_Click);
            // 
            // BtnYoneticiGirisi
            // 
            this.BtnYoneticiGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnYoneticiGirisi.BackgroundImage")));
            this.BtnYoneticiGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnYoneticiGirisi.Location = new System.Drawing.Point(420, 97);
            this.BtnYoneticiGirisi.Name = "BtnYoneticiGirisi";
            this.BtnYoneticiGirisi.Size = new System.Drawing.Size(232, 186);
            this.BtnYoneticiGirisi.TabIndex = 1;
            this.BtnYoneticiGirisi.UseVisualStyleBackColor = true;
            this.BtnYoneticiGirisi.Click += new System.EventHandler(this.BtnYoneticiGirisi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(77, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Girişi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(454, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yönetici Girişi";
            // 
            // FrmGirisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(723, 439);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnYoneticiGirisi);
            this.Controls.Add(this.BtnKullaniciGirisi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmGirisler";
            this.Text = "Kütüphane Otomasyon Giriş Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnKullaniciGirisi;
        private System.Windows.Forms.Button BtnYoneticiGirisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

