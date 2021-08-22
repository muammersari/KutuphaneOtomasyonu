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
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=---;Initial catalog=KutuphaneOtomasyon;Integrated Security=True"); //sql bağlantısını kurduk

        string tiklananButon = "";

        private void btn_kitapEkle_Click(object sender, EventArgs e)
        {
            KitapEkle kitapEkle = new KitapEkle(); // kitap ekle butonu basınca kitap ekleme sayfası açılıyor
            kitapEkle.ShowDialog();
        }

        private void btn_kitapSayisi_Click(object sender, EventArgs e) // burada kitap alma sayısı değiştirildi ise veritabanına yeni kitap sayılarını kaydettik
        {
            baglanti.Open();
            if (txt_ogrenciKitapSayisi.Text.Length > 0 && txt_ogretmenKitapSayisi.Text.Length > 0)
            {
                SqlCommand komut = new SqlCommand("update KitapAlmaSayisi_tbl set Ogrenci='" + txt_ogrenciKitapSayisi.Text + "', Ogretmen='" + txt_ogretmenKitapSayisi.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kitap Sayısı Adetleri Güncellendi");
            }
            else MessageBox.Show("Bilgileri Boş Giremezsiniz");
            baglanti.Close();
        }

        private void btn_iadeZamani_Click(object sender, EventArgs e)// burada iade zamanı değiştirildi ise veritabanına kaydettik
        {
            baglanti.Open();
            if (txt_ogrenciIadeZamani.Text.Length > 0 && txt_ogretmenIadeZamani.Text.Length > 0)
            {
                SqlCommand komut = new SqlCommand("update KitapSuresi_tbl set Ogrenci='" + Convert.ToInt32(txt_ogrenciIadeZamani.Text) + "', Ogretmen='" + Convert.ToInt32(txt_ogretmenIadeZamani.Text) + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kitap İade Süreleriniz Güncellendi");
            }
            else MessageBox.Show("Bilgileri Boş Giremezsiniz");
            baglanti.Close();
        }

        private void KutuphaneBilgiSistemi_Load(object sender, EventArgs e) // burada öğrenci ve öğretmenin kitap alım sayısını ve iade zamanlarını veritabanından ilgili textboxlara çektik ve yazdık
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KitapAlmaSayisi_tbl", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txt_ogrenciKitapSayisi.Text = read["Ogrenci"].ToString();
                txt_ogretmenKitapSayisi.Text = read["Ogretmen"].ToString();
            }
            read.Close();

            SqlCommand komut1 = new SqlCommand("select * from KitapSuresi_tbl", baglanti);
            SqlDataReader read1 = komut1.ExecuteReader();
            while (read1.Read())
            {
                txt_ogrenciIadeZamani.Text = read1["Ogrenci"].ToString();
                txt_ogretmenIadeZamani.Text = read1["Ogretmen"].ToString();
            }
            read1.Close();
            baglanti.Close();
            btn_yenile.PerformClick();
            btn_iadeBekleyenKitaplar.PerformClick(); // burada sayfa ilk açıldığında otomatik olarak iade edilmeyi bekleyen kitaplar butnuna bastırdık ki sayfa açılır açılmaz iade edilmeyi bekleyen kitaplar otomatik olarak listelensin
        }

        private void data_StatuOnayBekleyenler_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string kulEmail = data_StatuOnayBekleyenler.Rows[e.RowIndex].Cells[0].Value.ToString(); // tıklanan satırdaki kullaniciAdi ni aldık
            if (kulEmail != "")
            {
                if (MessageBox.Show("Kullanıcı Öğretmen Seviyesine Yükseltilsin mi?", "Rütbe Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //mesaj onaylandı ise kullanıcı rütbesi öğretmen olarak yükseltiliyor
                {
                    // MessageBoxtaki Evet'e tıklarsa buradaki kodlar çalışır.
                    baglanti.Open();
                    SqlCommand rutbeguncelle = new SqlCommand("update Uye_tbl set statu ='2' where kullaniciEmail ='" + kulEmail + "'", baglanti); // kullanıcı statusunü 2 yani öğretmen yaptık
                    rutbeguncelle.ExecuteNonQuery();
                    SqlCommand kullaniciBitisTarihiGuncelle = new SqlCommand("update UyeKitap_tbl set bitisTarihi='sınırsız' where UyeAdi ='" + kulEmail + "'", baglanti);
                    kullaniciBitisTarihiGuncelle.ExecuteNonQuery();
                    baglanti.Close();
                    data_StatuOnayBekleyenler.Rows.RemoveAt(data_StatuOnayBekleyenler.Rows[e.RowIndex].Index); // satatusu güncellenen veriyi tablodan sildik
                    if (Application.OpenForms["KutuphaneBilgiSistemi"] != null)// admin paneli açıksa
                    {
                        KutuphaneBilgiSistemi kutuphaneBilgiSistemi = (KutuphaneBilgiSistemi)Application.OpenForms["KutuphaneBilgiSistemi"];
                        if (kutuphaneBilgiSistemi.kullaniciAdi == kulEmail)
                        {
                            kutuphaneBilgiSistemi.btn_iadeSuresiGecenKitaplar.Visible = false; // burada statusu yükseltilen kişinin sayfası açıksa o kişinin kitap iade süre sınırı olmaığı için iade edilmeyen kitaplar alanını kapatıyoruz
                            kutuphaneBilgiSistemi.btn_aldigimKitaplar.PerformClick();
                        }
                    }
                }
            }

        }
        public void btn_alinanKitaplar_Click(object sender, EventArgs e) // burada veritabanında kayıtlı alınan kitaplar butonuna basıldığında kullanıcıların aldığı tüm kitaplar listede gösteriliyor
        {
            groupBox6.Text = "Alınan Kitaplar";
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select distinct Uye_tbl.kullaniciEmail as 'E-Mail', Kitap_tbl.kitapAdi as 'Kitap Adı', UyeKitap_tbl.baslangicTarihi as 'Alma Tarihi', UyeKitap_tbl.bitisTarihi as 'İada Tarihi', UyeKitap_tbl.iadeDurumu as 'İade Durumu' from Uye_tbl, UyeKitap_tbl, Kitap_tbl where Uye_tbl.kullaniciEmail = UyeKitap_tbl.uyeAdi and UyeKitap_tbl.kitapId = Kitap_tbl.kitapId and UyeKitap_tbl.iadeDurumu != 'iade edildi'", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            data_AlinanKitapveIade.DataSource = dt;
            tiklananButon = "Alınan Kitaplar"; // alınan kitaplar butonuna tıklandığını değişkene ekliyoruz
            baglanti.Close();
        }

        public void btn_iadeBekleyenKitaplar_Click(object sender, EventArgs e) // İade bekleyenler butonuna bastığımızda veritabanında iade onayı bekleyen kayıtlar listede gösterilecek
        {
            groupBox6.Text = "İade Onayı Bekleyen Kitaplar";
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select distinct Uye_tbl.kullaniciEmail as 'E-Mail', Kitap_tbl.kitapId as 'Kitap ID', Kitap_tbl.kitapAdi as 'Kitap Adı', UyeKitap_tbl.baslangicTarihi as 'Alma Tarihi', UyeKitap_tbl.bitisTarihi as 'İada Tarihi' from Uye_tbl, UyeKitap_tbl, Kitap_tbl where UyeKitap_tbl.iadeDurumu ='Onay Bekliyor' and Uye_tbl.kullaniciEmail = UyeKitap_tbl.uyeAdi and UyeKitap_tbl.kitapId = Kitap_tbl.kitapId", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            data_AlinanKitapveIade.DataSource = dt;
            tiklananButon = "İade Bekleyen"; // iade bekleyenler butonuna tıklandığını değişkene ekliyoruz
            baglanti.Close();
        }

        private void data_AlinanKitapveIade_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // burada iade bekleyeneler butonuna tıklanırsa iade işlemleri yapılacak
        {
            if (tiklananButon == "İade Bekleyen") // tabloya çift tıklandığında kitap iade onayı bekleyenler listesi mevcut ise iade işlemleri yapılacak. alınan kitaplar listesi mevcut ise hiç bir işlem yapılmayack
            {
                string kulAdi = data_AlinanKitapveIade.Rows[e.RowIndex].Cells[0].Value.ToString(); // tıklanan satırdaki kullaniciAdi ni aldık
                string kitapid = data_AlinanKitapveIade.Rows[e.RowIndex].Cells[1].Value.ToString(); // tıklanan satırdaki kitapId sini aldık

                if (kitapid != "" && kulAdi != "") // boş alana tıklanmamışsa  kitabın iade işlemi yapılıyor.
                {
                    if (MessageBox.Show("Kitabın iade edilmesini onaylıyor musunuz?", "Kitap İade Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //mesaj onaylandı ise kullanıcı rütbesi öğretmen olarak yükseltiliyor
                    {
                        // MessageBoxtaki Evet'e tıklarsa buradaki kodlar çalışır.
                        baglanti.Open();
                        SqlCommand rutbeguncelle = new SqlCommand("update UyeKitap_tbl set iadeDurumu ='iade edildi' where uyeAdi ='" + kulAdi + "' and kitapId ='" + kitapid + "' and iadeDurumu='onay bekliyor'", baglanti); //iade bekleyen kitabın iadesini onayladık
                        rutbeguncelle.ExecuteNonQuery();
                        data_AlinanKitapveIade.Rows.RemoveAt(data_AlinanKitapveIade.Rows[e.RowIndex].Index); // iadesi onaylanan satırı tablodan sildik
                        baglanti.Close();
                        kitapSayisiArttır(Convert.ToInt32(kitapid));

                        if (Application.OpenForms["KutuphaneBilgiSistemi"] != null)// admin paneli açıksa
                        {
                            KutuphaneBilgiSistemi kutuphaneBilgiSistemi = (KutuphaneBilgiSistemi)Application.OpenForms["KutuphaneBilgiSistemi"];
                            kutuphaneBilgiSistemi.btn_aldigimKitaplar.PerformClick(); // Burada kitap alındığında admin panelindeki alınan kitaplar butonuna tıklatıyoruz ve listeyi otomatik güncelleniyor
                        }
                    }
                }
            }
        }

        public void kitapSayisiArttır(int kitapid)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kitap_tbl set kalanAdet+=1 where kitapId = '" + kitapid + "'", baglanti);
            komut.ExecuteNonQuery(); // burada admin kitap iade onayını onayadığı zaman kitap stok sayısını 1 arttırıyoruz
            baglanti.Close();
        }

        public void btn_yenile_Click(object sender, EventArgs e) // burada butona basıldığında statu onayı bekleyen öğretmenler llistesi yenileniyor
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select kullaniciEmail as 'E-mail',kullaniciIsim as 'İsim',kullaniciSoyisim as 'Soyisim',kullaniciUnvan as Unvan,statu as Statu from Uye_tbl where kullaniciUnvan='Öğretmen' and statu='" + 3 + "'", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut2); // burada form her açıldığında statu durumu göncellenmeyi bekleyen yani öğretmen fakat öğrenci statüsünde olan kayıtlar listelenecek
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            data_StatuOnayBekleyenler.DataSource = dt;
            baglanti.Close();
        }

        private void AdminPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms["GirisYap"].Show(); // admin paneli kapandı ise giriş sayfasını aç
        }

        private void btn_tumKitaplar_Click(object sender, EventArgs e)// Burada Admin panelinde admin tüm kitapları görebilir. tüm kitaplar listeleniyor
        {
            groupBox6.Text = "Tüm Kitaplar";
            tiklananButon = "Tüm Kitaplar";// tıklanan butonun tüm kitaplar olduğunu tiklananbuton değişkenine yazıyoruz
            baglanti.Open();

            string sorgu = "select distinct Kitap_tbl.kitapId as 'Kitap ID', Kitap_tbl.kitapAdi as 'Kitap', Kitap_tbl.kitapSayfaSayisi as 'Sayfa', Kitap_tbl.kitapYili as Yıl, Kitap_tbl.kalanAdet as 'Kalan Adet', Yazar_tbl.yazarAdiSoyadi as 'Yazar', Tur_tbl.turAdi as Türü " +
            "from Tur_tbl, Yazar_tbl, Kitap_tbl " +
            "where Kitap_tbl.yazarId = Yazar_tbl.yazarId and Kitap_tbl.turId = Tur_tbl.turId";

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            data_AlinanKitapveIade.DataSource = dt;
            baglanti.Close();
        }
    }
}
