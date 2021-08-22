using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=---;Initial catalog=KutuphaneOtomasyon;Integrated Security=True");
        int timer = 0;
        int yanlisGirisSayisi = 0;

        private void btn_girisYap_Click(object sender, EventArgs e)
        {
            if (txt_kullaniciAdiGiris.Text.Length > 0)
            {
                if (txt_kullaniciSifreGiris.Text.Length > 0)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("select count(*) from Uye_tbl where kullaniciEmail='" + txt_kullaniciAdiGiris.Text + "' or kullaniciOkulNo='" + txt_kullaniciAdiGiris.Text + "'", baglanti);
                    if (Convert.ToInt32(komut.ExecuteScalar().ToString()) > 0) // bu isimde kullanıcı veritabanında var mı kontrol ediyoruz. var sa kişiye ait rastgele oluşturulan strig i çekiyoruz
                    {
                        var rastgelestring = "";
                        SqlCommand gelenstring = new SqlCommand("select rastgeleString from Uye_tbl where kullaniciEmail='" + txt_kullaniciAdiGiris.Text + "' or kullaniciOkulNo='" + txt_kullaniciAdiGiris.Text + "'", baglanti);
                        rastgelestring = gelenstring.ExecuteScalar().ToString(); // kullanıya kayıtlı olan rastgele string veriyi veritabanından çekiyoruz ki girdiği şifre ile birleştirip sha ile kodlayıp veritabanındaki şifre ile karşılaştıralım
                        SHA256 sha = SHA256.Create(); // gelen string i ve girilen şifreyi birleştirip sha256  ile şifreliyoruz
                        byte[] degerBytes = Encoding.UTF8.GetBytes((rastgelestring + txt_kullaniciSifreGiris.Text));
                        byte[] shaBytes = sha.ComputeHash(degerBytes);
                        StringBuilder result = new StringBuilder();
                        foreach (byte item in shaBytes)
                        {
                            result.Append(item.ToString("x2"));

                        }
                        // girilen kullanıcı email veya kullanıcı okul numarası ve şifresi veri tabanında var mı kontrol ediyoruz
                        SqlCommand komutGiris = new SqlCommand("select count(*) from Uye_tbl where (kullaniciEmail ='" + txt_kullaniciAdiGiris.Text + "' or kullaniciOkulNo ='" + txt_kullaniciAdiGiris.Text + "') and kullaniciSifre ='" + result.ToString() + "'", baglanti);
                        int kullanici = Convert.ToInt32(komutGiris.ExecuteScalar());
                        if (kullanici > 0) // kullanıcı ismi ve şifresi doğru ise giriş işlemi gerçekleşiyor
                        {
                            SqlCommand komutKullaniciBilgileri = new SqlCommand("select * from Uye_tbl where (kullaniciEmail ='" + txt_kullaniciAdiGiris.Text + "' or kullaniciOkulNo ='" + txt_kullaniciAdiGiris.Text + "') and kullaniciSifre ='" + result.ToString() + "'", baglanti); // kullanıcının bilgilerini alıyoruz
                            SqlDataReader read = komutKullaniciBilgileri.ExecuteReader();
                            while (read.Read())
                            {
                                if (txt_kullaniciAdiGiris.Text == "admin") // admin girişi yapıldı ise admin sayfası açılacak
                                {
                                    AdminPaneli admin = new AdminPaneli();
                                    if (Application.OpenForms["KutuphaneBilgiSistemi"] != null) // admin girişi yapılırken kullanıcıgirisi daha önce yapıldı ise giriş sayfası kapatılıyor.
                                    {
                                        this.Hide(); // giriş sayfası gizleniyor
                                        admin.Show(); // admin sayfası açılıyor
                                    }
                                    else // admin girişi açılırken kullanici girişi daha  önce açılmamışsa giriş sayfası açık bırakılıyor.
                                    {
                                        admin.Show(); // admin sayfası açılıyor
                                    }
                                }
                                else
                                {
                                    KutuphaneBilgiSistemi kutuphaneBilgiSistemi = new KutuphaneBilgiSistemi();
                                    kutuphaneBilgiSistemi.kullaniciAdi = read["kullaniciEmail"].ToString(); // kullanıcı bilgilerini anasayfaya gönderiyoruz
                                    kutuphaneBilgiSistemi.Unvan = read["kullaniciUnvan"].ToString();
                                    kutuphaneBilgiSistemi.statu = read["statu"].ToString();
                                    if (Application.OpenForms["AdminPaneli"] != null)// kullanici girişi yapılırken admin girişi daha önce yapılmışsa  giriş sayfası açık bırakılıyor
                                    {
                                        this.Hide(); //giriş sayfası gizleniyor
                                        kutuphaneBilgiSistemi.Show(); // kütüphanebilgisistemi sayfasını aç
                                    }
                                    else // kullanıcı girişi yapılırken admin girişi dana önce yapılmamışsa sadece kullanıcı sayfası açılıyor
                                    {
                                        kutuphaneBilgiSistemi.Show(); // kütüphanebilgisistemi sayfasını aç
                                    }
                                }
                            }
                            read.Close();
                            baglanti.Close();
                        }
                        else
                        {
                            lbl_girisUyari.Text = "Kullanıcı Bilgileriniz Yanlış !";
                            yanlisGirisSayisi++;
                            if (yanlisGirisSayisi >= 3)
                            { // burada kullanıcı şifresini 3 kere yanlış girdiğinde şifre giriş ekranını kapatıyoruz. 30 saniye sonra tekrar girmesini istiyoruz.
                                lbl_girisUyari.Text = "Şifrenizi '" + yanlisGirisSayisi + "' kere yanlış girdiniz !\nLütfen 30 saniye bekleyip tekrar deneyiniz";
                                txt_kullaniciSifreGiris.Enabled = false;
                                timer1.Start();
                            }
                            timer1.Start();
                        }
                    }
                    else
                    {
                        lbl_girisUyari.Text = "Bu isimde bir kullanıcı bulunamadı";
                        timer1.Start();
                    }
                    baglanti.Close();
                }
                else
                {
                    lbl_girisUyari.Text = "Kullanıcı Adınızı Giriniz !";
                    timer1.Start();
                }
            }
            else
            {
                lbl_girisUyari.Text = "Şifrenizi Giriniz !";
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) // burada kullanıcı yanlış işlem yaptırdığında timer süresi yani 30 süre boyunca mesajı gösteriyoruz. 30 süre sonra mesaj görünmez oluyor.
        {
            timer1.Interval = 1000; // her bir saniye de  bir işlem yapması için
            timer++;
            if (yanlisGirisSayisi >= 3) // burda kullanıcı şifresini 3 kereden fazla yaznlı girdi ise 30 saniye boyunca şifre alanını kapatıyoruz ve mesaj veriyoruz 
            {
                if (timer == 30)
                {
                    txt_kullaniciSifreGiris.Enabled = true;
                    lbl_girisUyari.Text = "";
                    timer1.Stop();
                    timer = 0;
                }
            }
            else // kullanıcı 3 den az yanlış yaparsa sadece 5 saniye uyarı mesajı veriyoruz
            {
                if (timer == 5)
                {
                    lbl_girisUyari.Text = "";
                    timer1.Stop();
                    timer = 0;
                }
            }

        }

        private void label2_Click(object sender, EventArgs e) // hesap oluştur alanına tıklşandığında kayıt sayfasını açıyoruz
        {
            baglanti.Close();
            this.Hide(); // giriş sayfasını gizle
            KullaniciKayit kullaniciKayit = new KullaniciKayit();
            kullaniciKayit.ShowDialog(); // kayıt olma sayfasını aç
            this.Show(); // giriş sayfasını aç
        }


    }
}
