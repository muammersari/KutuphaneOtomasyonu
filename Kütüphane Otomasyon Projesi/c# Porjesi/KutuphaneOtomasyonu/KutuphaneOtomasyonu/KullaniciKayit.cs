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
    public partial class KullaniciKayit : Form
    {
        public KullaniciKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=---;Initial catalog=KutuphaneOtomasyon;Integrated Security=True");

        private void Btn_KayitOl_Click(object sender, EventArgs e)
        {

            if (comboBox_unvan.Text.Length > 0) // unvan seçilmiş mi kontrol ediyoruz
            {
                if (txt_email.Text.Length > 0 && txt_okulNo.Text.Length > 0 && txt_kullaniciIsim.Text.Length > 0 && txt_kullaniciSoyisim.Text.Length > 0 && txt_kullaniciSifre.Text.Length > 0) // diğer tüm bilgileri girilmiş mi kontrol ediyoruz
                {
                    if (txt_kullaniciSifre.Text.Trim() == txt_kullaniciSifreTekrar.Text.Trim()) // şifre tekrarı doğru mu kontrol ediyoruz
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("select count(*) from Uye_tbl where kullaniciEmail = '" + txt_email.Text.ToString() + "' or kullaniciOkulNo = '" + txt_okulNo.Text + "'", baglanti); // girilen kullanıcı veritabanındda var mı kontrol ettik
                        int kullanici = Convert.ToInt32(komut.ExecuteScalar());
                        if (kullanici > 0) // veritabanında aynı email adresi veya eynı okul no ile kayıt var mı kontrol ediyoruz. var ise uyarı mesajı veriyoruz. yok ise kayıt yapıyoruz
                        {
                            lbl_kayitUyari.Text = "Bu Mail Adresi veya Okul Numarası Veritabanında Kayıtlı.\nDaha Farklı Bir Email veya Okul Numarası Giriniz !";
                        }
                        else //Veritabanında kullanıcı kayıtlı değilse kullanıcıyı kaydediyoruz.
                        {
                            Random rastgele = new Random(); // burada rastgele 6 haneli string üretiyoruz
                            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz";
                            string rastgeleString = "";
                            for (int i = 0; i < 6; i++)
                            {
                                rastgeleString += harfler[rastgele.Next(harfler.Length)];
                            }

                            SHA256 sha = SHA256.Create(); // Burada kullanıcı şifresini hash koduna çevirdik ve veri tabanına hash kodunu kaydettik.
                            byte[] degerBytes = Encoding.UTF8.GetBytes((rastgeleString + txt_kullaniciSifre.Text));
                            byte[] shaBytes = sha.ComputeHash(degerBytes);
                            StringBuilder result = new StringBuilder();
                            foreach (byte item in shaBytes)
                            {
                                result.Append(item.ToString("x2"));

                            }
                            //burada veritabanına kullanıcı bilgilerini kayıt ettik
                            SqlCommand uyeEkle = new SqlCommand("insert into Uye_tbl(kullaniciEmail,kullaniciOkulNo,kullaniciIsim,kullaniciSoyisim,kullaniciSifre,rastgeleString,kullaniciUnvan,statu) values('" + txt_email.Text + "','" + txt_okulNo.Text + "', '" + txt_kullaniciIsim.Text + "','" + txt_kullaniciSoyisim.Text + "','" + result.ToString() + "', '" + rastgeleString + "' ,'" + comboBox_unvan.Text + "',3)", baglanti);
                            uyeEkle.ExecuteNonQuery();
                            baglanti.Close();
                            if (comboBox_unvan.Text == "Öğretmen")
                            {
                                if (Application.OpenForms["AdminPaneli"] != null)// admin paneli açıksa
                                {
                                    AdminPaneli admin = (AdminPaneli)Application.OpenForms["AdminPaneli"];
                                    admin.btn_yenile.PerformClick(); // Burada kitap alındığında admin panelindeki alınan kitaplar butonuna tıklatıyoruz ve listeyi otomatik güncelleniyor
                                }
                            }
                            this.Close(); // kayit sayfasını kapat

                        }
                        baglanti.Close();
                    }
                    else lbl_kayitUyari.Text = "Şifrenizi Tekrar Ederken Yanlış Girdiniz !"; // şifre tekrarı yanlışsa mesaj veriyoruz
                }
                else lbl_kayitUyari.Text = "Kullanıcı Bilgilerinizde Eksik Var"; // bilgiler eksikse mesaj veriyoruz
            }
            else lbl_kayitUyari.Text = "Lütfen Unvan Seçiniz"; // unvan seçilmemişse mesaj veriyoruz


        }
    }
}
