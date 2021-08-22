
namespace KutuphaneOtomasyonu
{
    partial class KutuphaneBilgiSistemi
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_arama = new System.Windows.Forms.Label();
            this.combobox_ktriterSec = new System.Windows.Forms.ComboBox();
            this.txt_arama = new System.Windows.Forms.TextBox();
            this.checkbox_kalmayanKitaplar = new System.Windows.Forms.CheckBox();
            this.btn_iadeSuresiGecenKitaplar = new System.Windows.Forms.Button();
            this.btn_aldigimKitaplar = new System.Windows.Forms.Button();
            this.btn_tumKitaplar = new System.Windows.Forms.Button();
            this.combobox_kritereGoreSec = new System.Windows.Forms.ComboBox();
            this.lbl_kriteregoresec = new System.Windows.Forms.Label();
            this.lbl_kullaniciadi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Beige;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1143, 560);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(3, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1156, 603);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kriter :";
            // 
            // lbl_arama
            // 
            this.lbl_arama.AutoSize = true;
            this.lbl_arama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_arama.Location = new System.Drawing.Point(30, 85);
            this.lbl_arama.Name = "lbl_arama";
            this.lbl_arama.Size = new System.Drawing.Size(42, 20);
            this.lbl_arama.TabIndex = 14;
            this.lbl_arama.Text = "Ara :";
            // 
            // combobox_ktriterSec
            // 
            this.combobox_ktriterSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combobox_ktriterSec.FormattingEnabled = true;
            this.combobox_ktriterSec.Items.AddRange(new object[] {
            "Kitap İsmi",
            "Yazar Adı"});
            this.combobox_ktriterSec.Location = new System.Drawing.Point(78, 44);
            this.combobox_ktriterSec.Name = "combobox_ktriterSec";
            this.combobox_ktriterSec.Size = new System.Drawing.Size(227, 28);
            this.combobox_ktriterSec.TabIndex = 13;
            // 
            // txt_arama
            // 
            this.txt_arama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_arama.Location = new System.Drawing.Point(78, 82);
            this.txt_arama.Name = "txt_arama";
            this.txt_arama.Size = new System.Drawing.Size(548, 26);
            this.txt_arama.TabIndex = 12;
            this.txt_arama.TextChanged += new System.EventHandler(this.txt_arama_TextChanged);
            // 
            // checkbox_kalmayanKitaplar
            // 
            this.checkbox_kalmayanKitaplar.AutoSize = true;
            this.checkbox_kalmayanKitaplar.BackColor = System.Drawing.Color.Transparent;
            this.checkbox_kalmayanKitaplar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkbox_kalmayanKitaplar.ForeColor = System.Drawing.Color.Red;
            this.checkbox_kalmayanKitaplar.Location = new System.Drawing.Point(78, 117);
            this.checkbox_kalmayanKitaplar.Name = "checkbox_kalmayanKitaplar";
            this.checkbox_kalmayanKitaplar.Size = new System.Drawing.Size(270, 22);
            this.checkbox_kalmayanKitaplar.TabIndex = 11;
            this.checkbox_kalmayanKitaplar.Text = "Kalan sayısı 0 olan kitapları gösterme";
            this.checkbox_kalmayanKitaplar.UseVisualStyleBackColor = false;
            this.checkbox_kalmayanKitaplar.Click += new System.EventHandler(this.checkbox_kalmayanKitaplar_Click);
            // 
            // btn_iadeSuresiGecenKitaplar
            // 
            this.btn_iadeSuresiGecenKitaplar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_iadeSuresiGecenKitaplar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_iadeSuresiGecenKitaplar.ForeColor = System.Drawing.Color.White;
            this.btn_iadeSuresiGecenKitaplar.Location = new System.Drawing.Point(936, 109);
            this.btn_iadeSuresiGecenKitaplar.Name = "btn_iadeSuresiGecenKitaplar";
            this.btn_iadeSuresiGecenKitaplar.Size = new System.Drawing.Size(207, 37);
            this.btn_iadeSuresiGecenKitaplar.TabIndex = 8;
            this.btn_iadeSuresiGecenKitaplar.Text = "İade Süresi Geçen Kitaplar";
            this.btn_iadeSuresiGecenKitaplar.UseVisualStyleBackColor = false;
            this.btn_iadeSuresiGecenKitaplar.Click += new System.EventHandler(this.btn_iadeSuresiGecenKitaplar_Click);
            // 
            // btn_aldigimKitaplar
            // 
            this.btn_aldigimKitaplar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_aldigimKitaplar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_aldigimKitaplar.ForeColor = System.Drawing.Color.White;
            this.btn_aldigimKitaplar.Location = new System.Drawing.Point(771, 109);
            this.btn_aldigimKitaplar.Name = "btn_aldigimKitaplar";
            this.btn_aldigimKitaplar.Size = new System.Drawing.Size(159, 37);
            this.btn_aldigimKitaplar.TabIndex = 9;
            this.btn_aldigimKitaplar.Text = "Üzerimdeki Kitaplar";
            this.btn_aldigimKitaplar.UseVisualStyleBackColor = false;
            this.btn_aldigimKitaplar.Click += new System.EventHandler(this.btn_aldigimKitaplar_Click);
            // 
            // btn_tumKitaplar
            // 
            this.btn_tumKitaplar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_tumKitaplar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_tumKitaplar.ForeColor = System.Drawing.Color.White;
            this.btn_tumKitaplar.Location = new System.Drawing.Point(635, 109);
            this.btn_tumKitaplar.Name = "btn_tumKitaplar";
            this.btn_tumKitaplar.Size = new System.Drawing.Size(130, 37);
            this.btn_tumKitaplar.TabIndex = 10;
            this.btn_tumKitaplar.Text = "Tüm Kitaplar";
            this.btn_tumKitaplar.UseVisualStyleBackColor = false;
            this.btn_tumKitaplar.Click += new System.EventHandler(this.btn_tumKitaplar_Click_1);
            // 
            // combobox_kritereGoreSec
            // 
            this.combobox_kritereGoreSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combobox_kritereGoreSec.FormattingEnabled = true;
            this.combobox_kritereGoreSec.Location = new System.Drawing.Point(394, 44);
            this.combobox_kritereGoreSec.Name = "combobox_kritereGoreSec";
            this.combobox_kritereGoreSec.Size = new System.Drawing.Size(232, 28);
            this.combobox_kritereGoreSec.TabIndex = 13;
            this.combobox_kritereGoreSec.SelectedIndexChanged += new System.EventHandler(this.combobox_kritereGoreSec_SelectedIndexChanged);
            // 
            // lbl_kriteregoresec
            // 
            this.lbl_kriteregoresec.AutoSize = true;
            this.lbl_kriteregoresec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kriteregoresec.Location = new System.Drawing.Point(312, 47);
            this.lbl_kriteregoresec.Name = "lbl_kriteregoresec";
            this.lbl_kriteregoresec.Size = new System.Drawing.Size(76, 20);
            this.lbl_kriteregoresec.TabIndex = 15;
            this.lbl_kriteregoresec.Text = "Kategori :";
            // 
            // lbl_kullaniciadi
            // 
            this.lbl_kullaniciadi.AutoSize = true;
            this.lbl_kullaniciadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kullaniciadi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_kullaniciadi.Location = new System.Drawing.Point(977, 19);
            this.lbl_kullaniciadi.Name = "lbl_kullaniciadi";
            this.lbl_kullaniciadi.Size = new System.Drawing.Size(0, 18);
            this.lbl_kullaniciadi.TabIndex = 16;
            this.lbl_kullaniciadi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KutuphaneBilgiSistemi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1148, 748);
            this.Controls.Add(this.lbl_kullaniciadi);
            this.Controls.Add(this.lbl_kriteregoresec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_arama);
            this.Controls.Add(this.combobox_kritereGoreSec);
            this.Controls.Add(this.combobox_ktriterSec);
            this.Controls.Add(this.txt_arama);
            this.Controls.Add(this.checkbox_kalmayanKitaplar);
            this.Controls.Add(this.btn_iadeSuresiGecenKitaplar);
            this.Controls.Add(this.btn_aldigimKitaplar);
            this.Controls.Add(this.btn_tumKitaplar);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "KutuphaneBilgiSistemi";
            this.Text = "Kütüphane Bilgi Sitemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KutuphaneBilgiSistemi_FormClosing);
            this.Load += new System.EventHandler(this.KutuphaneBilgiSistemi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_arama;
        private System.Windows.Forms.ComboBox combobox_ktriterSec;
        private System.Windows.Forms.TextBox txt_arama;
        private System.Windows.Forms.CheckBox checkbox_kalmayanKitaplar;
        private System.Windows.Forms.Button btn_tumKitaplar;
        private System.Windows.Forms.ComboBox combobox_kritereGoreSec;
        private System.Windows.Forms.Label lbl_kriteregoresec;
        private System.Windows.Forms.Label lbl_kullaniciadi;
        public System.Windows.Forms.Button btn_aldigimKitaplar;
        public System.Windows.Forms.Button btn_iadeSuresiGecenKitaplar;
    }
}