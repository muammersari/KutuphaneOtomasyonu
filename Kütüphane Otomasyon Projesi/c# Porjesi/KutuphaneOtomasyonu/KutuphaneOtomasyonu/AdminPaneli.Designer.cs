
namespace KutuphaneOtomasyonu
{
    partial class AdminPaneli
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_kitapEkle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_kitapSayisi = new System.Windows.Forms.Button();
            this.txt_ogretmenKitapSayisi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ogrenciKitapSayisi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_iadeZamani = new System.Windows.Forms.Button();
            this.txt_ogretmenIadeZamani = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ogrenciIadeZamani = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.data_AlinanKitapveIade = new System.Windows.Forms.DataGridView();
            this.data_StatuOnayBekleyenler = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_iadeBekleyenKitaplar = new System.Windows.Forms.Button();
            this.btn_alinanKitaplar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_yenile = new System.Windows.Forms.Button();
            this.btn_tumKitaplar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_AlinanKitapveIade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_StatuOnayBekleyenler)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.btn_kitapEkle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kitap İşlemleri";
            // 
            // btn_kitapEkle
            // 
            this.btn_kitapEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_kitapEkle.Location = new System.Drawing.Point(109, 42);
            this.btn_kitapEkle.Name = "btn_kitapEkle";
            this.btn_kitapEkle.Size = new System.Drawing.Size(100, 32);
            this.btn_kitapEkle.TabIndex = 0;
            this.btn_kitapEkle.Text = "Kitap Ekle";
            this.btn_kitapEkle.UseVisualStyleBackColor = true;
            this.btn_kitapEkle.Click += new System.EventHandler(this.btn_kitapEkle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Controls.Add(this.btn_kitapSayisi);
            this.groupBox2.Controls.Add(this.txt_ogretmenKitapSayisi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_ogrenciKitapSayisi);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kitap Sayısı Düzenleme";
            // 
            // btn_kitapSayisi
            // 
            this.btn_kitapSayisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_kitapSayisi.Location = new System.Drawing.Point(109, 89);
            this.btn_kitapSayisi.Name = "btn_kitapSayisi";
            this.btn_kitapSayisi.Size = new System.Drawing.Size(100, 31);
            this.btn_kitapSayisi.TabIndex = 2;
            this.btn_kitapSayisi.Text = "Kaydet";
            this.btn_kitapSayisi.UseVisualStyleBackColor = true;
            this.btn_kitapSayisi.Click += new System.EventHandler(this.btn_kitapSayisi_Click);
            // 
            // txt_ogretmenKitapSayisi
            // 
            this.txt_ogretmenKitapSayisi.Location = new System.Drawing.Point(109, 57);
            this.txt_ogretmenKitapSayisi.Name = "txt_ogretmenKitapSayisi";
            this.txt_ogretmenKitapSayisi.Size = new System.Drawing.Size(100, 26);
            this.txt_ogretmenKitapSayisi.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Öğretmen : ";
            // 
            // txt_ogrenciKitapSayisi
            // 
            this.txt_ogrenciKitapSayisi.Location = new System.Drawing.Point(109, 25);
            this.txt_ogrenciKitapSayisi.Name = "txt_ogrenciKitapSayisi";
            this.txt_ogrenciKitapSayisi.Size = new System.Drawing.Size(100, 26);
            this.txt_ogrenciKitapSayisi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Öğrenci : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Öğrenci : ";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Controls.Add(this.btn_iadeZamani);
            this.groupBox3.Controls.Add(this.txt_ogretmenIadeZamani);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txt_ogrenciIadeZamani);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(12, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 129);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kitap İade Zamanı Düzenleme";
            // 
            // btn_iadeZamani
            // 
            this.btn_iadeZamani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_iadeZamani.Location = new System.Drawing.Point(109, 92);
            this.btn_iadeZamani.Name = "btn_iadeZamani";
            this.btn_iadeZamani.Size = new System.Drawing.Size(100, 31);
            this.btn_iadeZamani.TabIndex = 8;
            this.btn_iadeZamani.Text = "Kaydet";
            this.btn_iadeZamani.UseVisualStyleBackColor = true;
            this.btn_iadeZamani.Click += new System.EventHandler(this.btn_iadeZamani_Click);
            // 
            // txt_ogretmenIadeZamani
            // 
            this.txt_ogretmenIadeZamani.Location = new System.Drawing.Point(109, 60);
            this.txt_ogretmenIadeZamani.Name = "txt_ogretmenIadeZamani";
            this.txt_ogretmenIadeZamani.Size = new System.Drawing.Size(100, 26);
            this.txt_ogretmenIadeZamani.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Öğretmen : ";
            // 
            // txt_ogrenciIadeZamani
            // 
            this.txt_ogrenciIadeZamani.Location = new System.Drawing.Point(109, 28);
            this.txt_ogrenciIadeZamani.Name = "txt_ogrenciIadeZamani";
            this.txt_ogrenciIadeZamani.Size = new System.Drawing.Size(100, 26);
            this.txt_ogrenciIadeZamani.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Öğrenci : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Öğrenci : ";
            // 
            // data_AlinanKitapveIade
            // 
            this.data_AlinanKitapveIade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_AlinanKitapveIade.BackgroundColor = System.Drawing.Color.Azure;
            this.data_AlinanKitapveIade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_AlinanKitapveIade.Location = new System.Drawing.Point(0, 64);
            this.data_AlinanKitapveIade.Name = "data_AlinanKitapveIade";
            this.data_AlinanKitapveIade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_AlinanKitapveIade.Size = new System.Drawing.Size(1259, 343);
            this.data_AlinanKitapveIade.TabIndex = 2;
            this.data_AlinanKitapveIade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_AlinanKitapveIade_CellDoubleClick);
            // 
            // data_StatuOnayBekleyenler
            // 
            this.data_StatuOnayBekleyenler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_StatuOnayBekleyenler.BackgroundColor = System.Drawing.Color.Azure;
            this.data_StatuOnayBekleyenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_StatuOnayBekleyenler.Location = new System.Drawing.Point(6, 38);
            this.data_StatuOnayBekleyenler.Name = "data_StatuOnayBekleyenler";
            this.data_StatuOnayBekleyenler.Size = new System.Drawing.Size(970, 299);
            this.data_StatuOnayBekleyenler.TabIndex = 3;
            this.data_StatuOnayBekleyenler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_StatuOnayBekleyenler_CellDoubleClick_1);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox4.Controls.Add(this.data_StatuOnayBekleyenler);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(289, 56);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(982, 343);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Onay Bekleyenler";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox6.Controls.Add(this.btn_iadeBekleyenKitaplar);
            this.groupBox6.Controls.Add(this.btn_tumKitaplar);
            this.groupBox6.Controls.Add(this.btn_alinanKitaplar);
            this.groupBox6.Controls.Add(this.data_AlinanKitapveIade);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(12, 418);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1271, 398);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Listeler";
            // 
            // btn_iadeBekleyenKitaplar
            // 
            this.btn_iadeBekleyenKitaplar.Location = new System.Drawing.Point(1100, 23);
            this.btn_iadeBekleyenKitaplar.Name = "btn_iadeBekleyenKitaplar";
            this.btn_iadeBekleyenKitaplar.Size = new System.Drawing.Size(159, 35);
            this.btn_iadeBekleyenKitaplar.TabIndex = 5;
            this.btn_iadeBekleyenKitaplar.Text = "İade Bekleyenler";
            this.btn_iadeBekleyenKitaplar.UseVisualStyleBackColor = true;
            this.btn_iadeBekleyenKitaplar.Click += new System.EventHandler(this.btn_iadeBekleyenKitaplar_Click);
            // 
            // btn_alinanKitaplar
            // 
            this.btn_alinanKitaplar.Location = new System.Drawing.Point(949, 23);
            this.btn_alinanKitaplar.Name = "btn_alinanKitaplar";
            this.btn_alinanKitaplar.Size = new System.Drawing.Size(145, 35);
            this.btn_alinanKitaplar.TabIndex = 5;
            this.btn_alinanKitaplar.Text = "Alınan Kitaplar";
            this.btn_alinanKitaplar.UseVisualStyleBackColor = true;
            this.btn_alinanKitaplar.Click += new System.EventHandler(this.btn_alinanKitaplar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(1180, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Hoşgeldiniz";
            // 
            // btn_yenile
            // 
            this.btn_yenile.Location = new System.Drawing.Point(289, 27);
            this.btn_yenile.Name = "btn_yenile";
            this.btn_yenile.Size = new System.Drawing.Size(75, 23);
            this.btn_yenile.TabIndex = 6;
            this.btn_yenile.Text = "yenile";
            this.btn_yenile.UseVisualStyleBackColor = true;
            this.btn_yenile.Click += new System.EventHandler(this.btn_yenile_Click);
            // 
            // btn_tumKitaplar
            // 
            this.btn_tumKitaplar.Location = new System.Drawing.Point(798, 23);
            this.btn_tumKitaplar.Name = "btn_tumKitaplar";
            this.btn_tumKitaplar.Size = new System.Drawing.Size(145, 35);
            this.btn_tumKitaplar.TabIndex = 5;
            this.btn_tumKitaplar.Text = "Tüm Kitaplar";
            this.btn_tumKitaplar.UseVisualStyleBackColor = true;
            this.btn_tumKitaplar.Click += new System.EventHandler(this.btn_tumKitaplar_Click);
            // 
            // AdminPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1295, 828);
            this.Controls.Add(this.btn_yenile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminPaneli";
            this.Text = "Admin Paneli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminPaneli_FormClosing);
            this.Load += new System.EventHandler(this.KutuphaneBilgiSistemi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_AlinanKitapveIade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_StatuOnayBekleyenler)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_kitapEkle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ogretmenKitapSayisi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ogrenciKitapSayisi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_kitapSayisi;
        private System.Windows.Forms.Button btn_iadeZamani;
        private System.Windows.Forms.TextBox txt_ogretmenIadeZamani;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ogrenciIadeZamani;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView data_AlinanKitapveIade;
        private System.Windows.Forms.DataGridView data_StatuOnayBekleyenler;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btn_alinanKitaplar;
        public System.Windows.Forms.Button btn_iadeBekleyenKitaplar;
        public System.Windows.Forms.Button btn_yenile;
        public System.Windows.Forms.Button btn_tumKitaplar;
    }
}