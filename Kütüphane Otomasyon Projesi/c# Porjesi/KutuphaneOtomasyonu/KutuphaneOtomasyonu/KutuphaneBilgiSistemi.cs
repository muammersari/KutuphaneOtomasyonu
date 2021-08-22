using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class KutuphaneBilgiSistemi : Form
    {
        public KutuphaneBilgiSistemi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=---;Initial catalog=KutuphaneOtomasyon;Integrated Security=True");

        public string kullaniciAdi { get; set; }
        public string Unvan { get; set; }
        public string statu { get; set; }

        public string tiklananButon = "";

        DataTable dt;
        private void KutuphaneBilgiSistemi_Load(object sender, EventArgs e)
        {// from açıldığında otomatik olarak geciken kitapların listesi görünecek
            lbl_kullaniciadi.Text = "Hoşgeldiniz \n" + kullaniciAdi;
            baglanti.Close();
            btn_tumKitaplar.PerformClick();
            turListesiYukle(); //burda sayfa açıldığında combobox a tür listesi yükleniyor
            if (statu != "3") // burada kulanıcı öğretmen statsunde ise iade süresi butonunu kapatıyoruz. çünkü iade süsresi sınırı yok.
            {
                btn_iadeSuresiGecenKitaplar.Visible = false;
            }
        }
        public void turListesiYukle()
        {
            combobox_kritereGoreSec.Items.Clear(); // burada tüm kitap türlerini comboboxa çekiyoruz ki kullanıcı buradan seçme yapabilsin
            baglanti.Open();
            SqlCommand turler = new SqlCommand("select turAdi from Tur_tbl", baglanti);
            SqlDataReader read = turler.ExecuteReader();
            while (read.Read())
            {
                combobox_kritereGoreSec.Items.Add(read["turAdi"]);
            }
            read.Close();
            baglanti.Close();

        }
        private void btn_tumKitaplar_Click_1(object sender, EventArgs e) // tüm kitaplar butonuna basıldığında tüm kitaplar listeleniyor
        {
            groupBox1.Text = "Tüm Kitaplar";
            tiklananButon = "Tüm Kitaplar";// tıklanan butonun tüm kitaplar olduğunu tiklananbuton değişkenine yazıyoruz
            baglanti.Open();

            string sorgu = "select distinct Kitap_tbl.kitapId as 'Kitap ID', Kitap_tbl.kitapAdi as 'Kitap', Kitap_tbl.kitapSayfaSayisi as 'Sayfa', Kitap_tbl.kitapYili as Yıl, Kitap_tbl.kalanAdet as 'Kalan Adet', Yazar_tbl.yazarAdiSoyadi as 'Yazar', Tur_tbl.turAdi as Türü " +
            "from Tur_tbl, Yazar_tbl, Kitap_tbl " +
            "where Kitap_tbl.yazarId = Yazar_tbl.yazarId and Kitap_tbl.turId = Tur_tbl.turId";

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        public void btn_aldigimKitaplar_Click(object sender, EventArgs e) // aldığım kitaplar butonuna basıldığında çalışan metod
        {
            tiklananButon = "Aldığım Kitaplar";// tıklanan butonun aldığım kitaplar butonu olduğunu tıklananbuton değişkenine kaydediyoruz
            groupBox1.Text = "Aldığım Kitaplar";
            baglanti.Open();

            string sorgu = "select distinct Kitap_tbl.kitapId as 'Kitap ID', Kitap_tbl.kitapAdi as 'Kitap', UyeKitap_tbl.baslangicTarihi as 'Alış Tarihi', UyeKitap_tbl.bitisTarihi as 'İade Tarihi', UyeKitap_tbl.iadeDurumu as 'İade Durumu' " +
            "from Kitap_tbl ,UyeKitap_tbl " +
            "where UyeKitap_tbl.uyeAdi = '" + kullaniciAdi.ToString() + "' and UyeKitap_tbl.kitapId = Kitap_tbl.kitapId and UyeKitap_tbl.iadeDurumu !='iade edildi'";

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut); // burada tabloya verileri aktarıyoruz
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        public void btn_iadeSuresiGecenKitaplar_Click(object sender, EventArgs e) // iade süresi geçen kitaplar butonuna basıldığında çalışan metod
        {
            dataGridView1.Columns.Clear();

            groupBox1.Text = "İade Süresi Geçen Kitaplar";
            tiklananButon = "İade Süresi Geçen Kitaplar"; // tıklanan buton iade süresi geçen kitaplar olarak tıklanan buton değerine kaydediliyor
            if (statu == "3")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select kitapId as 'Kitap ID', uyeAdi as 'Üye Adı', baslangicTarihi as 'Alış Tarihi', bitisTarihi as 'İade Tarihi', iadeDurumu as 'İade Durumu' from UyeKitap_tbl where bitisTarihi !='sınırsız' and iadeDurumu !='iade edildi' and DATEDIFF(day, convert(date,baslangicTarihi,104), convert(date,bitisTarihi,104)) <= 0", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);// burada tabloya verileri aktarıyoruz
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("İade Süresi Geçen Kitabınız Bulunmamaktadır");
            }


        }

        private void combobox_kritereGoreSec_SelectedIndexChanged(object sender, EventArgs e) //kategori seçildiğinde yapılacak işlemler
        {
            baglanti.Open();
            string sorgu = "";
            if (checkbox_kalmayanKitaplar.Checked == true && tiklananButon == "Tüm Kitaplar")// burada kalan 0 olan kitapları gösterme seçili ise kalan adeti 0 olan kitapları seçilen kategoriye göre listeliyoruz
            {
                sorgu = "select distinct Kitap_tbl.kitapId as 'kitap ID', Kitap_tbl.kitapAdi as 'Kitap', Kitap_tbl.kitapSayfaSayisi as Sayfa, Kitap_tbl.kitapYili as Yıl, Kitap_tbl.kalanAdet as 'Kalan Adet', Yazar_tbl.yazarAdiSoyadi as Yazar, Tur_tbl.turAdi as Türü " +
             "from Tur_tbl, Yazar_tbl, Kitap_tbl " +
             "where Kitap_tbl.yazarId = Yazar_tbl.yazarId and Kitap_tbl.turId = Tur_tbl.turId and Kitap_tbl.kalanAdet != 0 and Tur_tbl.turAdi='" + combobox_kritereGoreSec.SelectedItem.ToString() + "'";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                dt = new DataTable(); // burada dataadapter metodu veritabanından sorgumuza göre gelen verileri datagridview e atıyor
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (tiklananButon == "Tüm Kitaplar")// burada kalan 0 olan kitapları gösterme seçili değil ise sadece seçilen kategoriye göre listeliyoruz
            {
                sorgu = "select distinct Kitap_tbl.kitapId as 'kitap ID', Kitap_tbl.kitapAdi as 'Kitap', Kitap_tbl.kitapSayfaSayisi as Sayfa, Kitap_tbl.kitapYili as Yıl, Kitap_tbl.kalanAdet as 'Kalan Adet', Yazar_tbl.yazarAdiSoyadi as Yazar, Tur_tbl.turAdi as Türü " +
                "from Tur_tbl, Yazar_tbl, Kitap_tbl " +
                "where Kitap_tbl.yazarId = Yazar_tbl.yazarId and Kitap_tbl.turId = Tur_tbl.turId and Tur_tbl.turAdi='" + combobox_kritereGoreSec.SelectedItem.ToString() + "'";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);// burada tabloya verileri aktarıyoruz
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }


            baglanti.Close();
        }

        private void txt_arama_TextChanged(object sender, EventArgs e)
        {
            if (combobox_ktriterSec.Text == "Yazar Adı")// seçili olan kriter yazar adı ise ve tabloda veri var ise tabloda yazar adına göre arama yapıyoruz
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "Yazar Like '%" + txt_arama.Text.ToUpper() + "%'";
                dataGridView1.DataSource = dv;
            }
            else  //  seçili olan kriter kitap ismi ise ve tabloda veri var ise tabloda yazar adına göre arama yaptırıyoruz
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "Kitap Like '%" + txt_arama.Text.ToUpper() + "%'";
                dataGridView1.DataSource = dv;
            }
            //if (txt_arama.Text == "")
            //{
            //    btn_tumKitaplar.PerformClick(); // eğer arama alanı boş ise otomatik olarak tüm kitapları listeliyoruz
            //}
        }

        private void checkbox_kalmayanKitaplar_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "";
            if (checkbox_kalmayanKitaplar.Checked == true && tiklananButon == "Tüm Kitaplar") // kalmayan kitapları listeleme seçeneği seçili ise kalmayan kitapları göstermiyoruz
            {
                sorgu = "select distinct Kitap_tbl.kitapId  as 'kitap ID', Kitap_tbl.kitapAdi as 'Kitap', Kitap_tbl.kitapSayfaSayisi as Sayfa, Kitap_tbl.kitapYili as Yıl, Kitap_tbl.kalanAdet as 'Kalan Adet', Yazar_tbl.yazarAdiSoyadi as Yazar, Tur_tbl.turAdi as Türü " +
                "from Tur_tbl, Yazar_tbl, Kitap_tbl " +
                "where Kitap_tbl.yazarId = Yazar_tbl.yazarId and Kitap_tbl.turId = Tur_tbl.turId and Kitap_tbl.kalanAdet != 0";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (tiklananButon == "Tüm Kitaplar") //seçili değilse tüm kitapları gösteriyoruz
            {
                sorgu = "select distinct Kitap_tbl.kitapId as 'kitap ID', Kitap_tbl.kitapAdi as 'Kitap', Kitap_tbl.kitapSayfaSayisi as Sayfa, Kitap_tbl.kitapYili as Yıl, Kitap_tbl.kalanAdet as 'Kalan Adet', Yazar_tbl.yazarAdiSoyadi as Yazar, Tur_tbl.turAdi as Türü " +
               "from Tur_tbl, Yazar_tbl, Kitap_tbl " +
               "where Kitap_tbl.yazarId = Yazar_tbl.yazarId and Kitap_tbl.turId = Tur_tbl.turId";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tiklananButon == "Tüm Kitaplar") // tüm kitaplarda kullanıcı kitabı almak istediği satıra çift tıklayıp onayladıktan sonra kitabı alıyor
            {
                baglanti.Open();
                AdminPaneli adminPaneli = new AdminPaneli();
                string kitapId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // tıklanan satırdaki kitabın id sini aldık
                string kalanKitapSayisi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // tıklanan satırdaki kitabın id sini aldık
                if (Convert.ToInt32(kalanKitapSayisi) > 0) // burada tıklanan kitabın kalan sayısı 0 ise kitap yok mesajı veriyoruz
                {
                    SqlCommand kitap_daha_once_alinmis_mi = new SqlCommand("select count(*) from UyeKitap_tbl where uyeAdi ='" + kullaniciAdi + "' and kitapId = '" + kitapId + "' and iadeDurumu !='iade edildi'", baglanti); // burada kullanıcı da şu an bu kitap mevcutsa uyarı veriyoruz
                    if (Convert.ToInt32(kitap_daha_once_alinmis_mi.ExecuteScalar()) == 0)
                    {
                        if (statu == "2") // kullanıcı öğretmen ise
                        {
                            if (MessageBox.Show("Kitab almak istiyor musunuz?", "Kitap Alma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                // MessageBoxtaki Evet'e tıklarsa buradaki kodlar çalışır. 
                                SqlCommand kitapAl = new SqlCommand("insert into UyeKitap_tbl(uyeAdi,kitapId,baslangicTarihi,bitisTarihi,iadeDurumu) values('" + kullaniciAdi + "','" + kitapId + "','" + DateTime.Now.ToString() + "','sınırsız','iade edilmedi')", baglanti); // kullacını aldığı kitabı veritabanına kaydediyoruz
                                kitapAl.ExecuteNonQuery();
                                MessageBox.Show("Kitap Başarılı bir şekilde Alındı");
                                baglanti.Close();
                                kitapSayisiEksilt(Convert.ToInt32(kitapId));
                                btn_aldigimKitaplar.PerformClick();
                                if (Application.OpenForms["AdminPaneli"] != null)// admin paneli açıksa
                                {
                                    AdminPaneli admin = (AdminPaneli)Application.OpenForms["AdminPaneli"];
                                    admin.btn_alinanKitaplar.PerformClick(); // Burada kitap alındığında admin panelindeki alınan kitaplar butonuna tıklatıyoruz ve listeyi otomatik güncelleniyor
                                }
                              
                            }
                        }
                        else if (statu == "3") // kullanıcı öğrenci ise
                        {
                            SqlCommand komut1 = new SqlCommand("select count(*) from UyeKitap_tbl where uyeAdi ='" + kullaniciAdi + "' and iadeDurumu !='iade edildi'", baglanti); // kullanıcının üzerine kayıtlı kitap sayısını bulduk
                            int uzerineKayitliKitapSayisi = Convert.ToInt32(komut1.ExecuteScalar());
                            SqlCommand komut2 = new SqlCommand("select Ogrenci from KitapAlmaSayisi_tbl", baglanti); // öğrencinin kitap alma sınırı olduğu için öğrencinin en fazla kaç kitap alabileceğini veritabanından aldık
                            int ogrenciMaxAlabilecegiKitapSayisi = Convert.ToInt32(komut2.ExecuteScalar());
                            if (uzerineKayitliKitapSayisi >= ogrenciMaxAlabilecegiKitapSayisi) // öğrencinin üzerindeki kitap sayısı en fazla alabileceği kitap sayısından fazla ise uyarı mesajı verdirdik
                            {
                                MessageBox.Show("Üzerinize en fazla '" + ogrenciMaxAlabilecegiKitapSayisi.ToString() + "' kitap alabilirsiniz ! Üzerinizde şu an '" + uzerineKayitliKitapSayisi.ToString() + "' kayıtlı kitap var ");
                            }
                            else // öğrencinin üzerine kayıtlı 5 den az kitap varsa kitap almasını onaylıyoruz ve kitabu öğrenci üzerine kaydediyoruz
                            {
                                SqlCommand komut = new SqlCommand("select Ogrenci from KitapSuresi_tbl", baglanti);
                                int bitisZamani = Convert.ToInt32(komut.ExecuteScalar());
                                if (MessageBox.Show("Kitab almak istiyor musunuz?", "Kitap Alma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    // MessageBoxtaki Evet'e tıklarsa buradaki kodlar çalışır.
                                    SqlCommand kitapAl = new SqlCommand("insert into UyeKitap_tbl(uyeAdi,kitapId,baslangicTarihi,bitisTarihi,iadeDurumu) values('" + kullaniciAdi + "','" + kitapId + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.AddDays(bitisZamani).ToString() + "','iade edilmedi')", baglanti); // kullacını aldığı kitabı veritabanına kaydediyoruz
                                    kitapAl.ExecuteNonQuery();
                                    MessageBox.Show("Kitap Başarılı bir şekilde Alındı");
                                    baglanti.Close();
                                    kitapSayisiEksilt(Convert.ToInt32(kitapId));
                                    btn_aldigimKitaplar.PerformClick();
                                    if (Application.OpenForms["AdminPaneli"] != null)// admin paneli açıksa
                                    {
                                        AdminPaneli admin = (AdminPaneli)Application.OpenForms["AdminPaneli"];
                                        admin.btn_alinanKitaplar.PerformClick(); // Burada kitap alındığında admin panelindeki alınan kitaplar butonuna tıklatıyoruz ve listeyi otomatik güncelleniyor
                                    }
                                }
                            }
                        }
                    }
                    else MessageBox.Show("Bu kitab şu an sizde görünüyor. tekrar aynı kitabı iade etmeden  alamazsınız !");
                }
                else
                {
                    MessageBox.Show("Bu kitap bulunmamaktadır.");
                }
                baglanti.Close();
            }
            else // tıklanan buton tüm kitaplar değil ise aldığım kitaplar ise kullanıcı almış oludğu veya iade zamanı geçmiş kitap listesinde iade etmek istediği kitaba çift tıklayıp onayladıktan sonra kitap admin onayı için onay bekliyor olarak veritabanınde güncelleniyor
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "iade edilmedi")
                {
                    if (MessageBox.Show("Kitabı İade Etmek İstiyor musunuz?", "Kitap İade İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        baglanti.Open();
                        // MessageBoxtaki Evet'e tıklarsa buradaki kodlar çalışır.
                        string kitapId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // tıklanan satırdaki kitabın id sini aldık
                        SqlCommand komut = new SqlCommand("update UyeKitap_tbl set iadeDurumu ='onay Bekliyor' where uyeAdi='" + kullaniciAdi + "' and kitapId='" + kitapId + "' and iadeDurumu='iade edilmedi'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        if (Application.OpenForms["AdminPaneli"] != null)// admin paneli açıksa
                        {
                            AdminPaneli admin = (AdminPaneli)Application.OpenForms["AdminPaneli"];
                            admin.btn_iadeBekleyenKitaplar.PerformClick(); // Burada kitap iade edildiğinde admin panelindeki iade bekleyen kitaplar butonuna tıklatıyoruz ve listeyi otomatik güncelleniyor
                        }
                        MessageBox.Show("Kitap Başarılı bir şekilde iade edildi");
                        if (tiklananButon == "Aldığım Kitaplar")
                        {
                            baglanti.Close();
                            btn_aldigimKitaplar.PerformClick(); // burada işlemler bitince butona tıklattırıp aldğımız kitapları tekrar çekiyoruz
                        }
                        else if (tiklananButon == "İade Süresi Geçen Kitaplar")
                        {
                            baglanti.Close();
                            btn_iadeSuresiGecenKitaplar.PerformClick(); // burada işlemler bitince butona tıklattırıp iade edilmeyen kitapları tekrar çekiyoruz
                        }
                    }
                }
                else MessageBox.Show("Kitabınız iade onayı bekliyor");
            }
        }

        public void kitapSayisiEksilt(int kitapid)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kitap_tbl set kalanAdet-=1 where kitapId = '" + kitapid + "'", baglanti);
            komut.ExecuteNonQuery(); // burada kitap alındığı zaman kitap stok sayısını bir azalttıkk
            baglanti.Close();
        }

        private void KutuphaneBilgiSistemi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms["GirisYap"].Show(); // kutuphanebilgisistemi formu kapatıldığında giriş sayfasını açıyoruz
        }


    }
}

