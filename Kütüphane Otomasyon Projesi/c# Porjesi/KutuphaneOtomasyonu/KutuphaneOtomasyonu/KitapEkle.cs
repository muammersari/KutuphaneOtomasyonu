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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=---;Initial catalog=KutuphaneOtomasyon;Integrated Security=True");
        private void btn_kitapEkle_Click(object sender, EventArgs e)
        {
            if (txt_kitapAdi.Text.Length > 0 && txt_kitapSayfasi.Text.Length > 0 && txt_kitapYili.Text.Length > 0 && txt_kitapAdet.Text.Length > 0 && comboBox_TurList.Text.Length > 0 && comboBox_YazarList.Text.Length > 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select count(kitapAdi) from Kitap_tbl where kitapAdi = '" + txt_kitapAdi.Text.ToString() + "'", baglanti); // girilen kitap veritabanındda var mı kontrol ettik
                int kitap = Convert.ToInt32(komut.ExecuteScalar());
                if (kitap > 0) // veritabanında aynı isimde kayıtlı kitap var ise kayıt yapmıyoruz ve uyarı esajı veriyoruz
                {
                    lbl_kitapEkleUyari.Text = "Bu kitap Veritabanında Kayıtlı.\n Lütfen Daha Farklı Bir Kitap İsmi Giriniz !";
                }
                else
                {//kitaplar bilgileri veritabanına kaydediliyor
                    SqlCommand kitapEkle = new SqlCommand("insert into Kitap_tbl(kitapAdi,kitapSayfaSayisi,kitapYili,kitapAdet,kalanAdet) values('" + txt_kitapAdi.Text + "', '" + Convert.ToInt32(txt_kitapSayfasi.Text) + "','" + Convert.ToInt32(txt_kitapYili.Text) + "','" + Convert.ToInt32(txt_kitapAdet.Text) + "','" + Convert.ToInt32(txt_kitapAdet.Text) + "')", baglanti);
                    kitapEkle.ExecuteNonQuery();
                    SqlCommand kitapId = new SqlCommand("select MAX(kitapId) from Kitap_tbl", baglanti); // burada en son eklenen kitabın Id bilgisi alınıyor ki diğer tablolara ekleme yaparken kitapId sini kullanabilelim
                    int kitap_id = Convert.ToInt32(kitapId.ExecuteScalar());

                    SqlCommand yazarIdkomut = new SqlCommand("select yazarId from Yazar_tbl where yazarAdiSoyadi='" + comboBox_YazarList.Text.ToString() + "'", baglanti);
                    int yazarId = Convert.ToInt32(yazarIdkomut.ExecuteScalar()); // burada eklenen yazarın yazarıd si bulunuyor

                    SqlCommand turIdkomut = new SqlCommand("select turId from Tur_tbl where turAdi='" + comboBox_TurList.Text.ToString() + "'", baglanti);
                    int turId = Convert.ToInt32(turIdkomut.ExecuteScalar()); // burada eklenen tur un turId si bulunuyor

                    SqlCommand yazarTurIdEkle = new SqlCommand("update Kitap_tbl set yazarId='" + yazarId + "', turId ='" + turId + "' where kitapId ='" + kitap_id + "'", baglanti);
                    yazarTurIdEkle.ExecuteNonQuery();// burada kitaba yazar ve tur id si ekleniyor
                    baglanti.Close();
                    this.Close();

                }
                baglanti.Close();
            }
            else lbl_kitapEkleUyari.Text = "Kitap bilgilerinde eksik var. Lütfen eksiksiz Doldurunuz !";
        }

        private void btn_yazarEkle_Click(object sender, EventArgs e) // Burada veritabanında istenilen yazar yoksa veritabanına kaydediyoruz
        {
            if (txt_yazarAdi.Text.Length > 0)
            {
                baglanti.Open();
                SqlCommand kontrol = new SqlCommand("select count(*) from Yazar_tbl where yazarAdiSoyadi='" + txt_yazarAdi.Text + "'", baglanti); // yazar veritabanında var mı kontrol ediyoruz. varsa eklettirmiyoruz.
                int gelenkontrolDegeri = Convert.ToInt32(kontrol.ExecuteScalar());
                if (gelenkontrolDegeri == 0) // yazar yoksa eklettiriyoruz
                {
                    SqlCommand yazarEkle = new SqlCommand("insert into Yazar_tbl(yazarAdiSoyadi) values('" + txt_yazarAdi.Text + "')", baglanti);
                    yazarEkle.ExecuteNonQuery();
                    txt_yazarAdi.Text = "";
                }
                else MessageBox.Show("Bu yazar veri tabanında ekli.");
                baglanti.Close();
            }
        }

        private void btn_turEkle_Click(object sender, EventArgs e)  // tur veritabanında var mı kontrol ediyoruz. varsa eklettirmiyoruz.
        {
            if (txt_turAdi.Text.Length > 0)
            {
                baglanti.Open();
                SqlCommand kontrol = new SqlCommand("select count(*) from Tur_tbl where turAdi='" + txt_turAdi.Text + "'", baglanti);
                int gelenkontrolDegeri = Convert.ToInt32(kontrol.ExecuteScalar());
                if (gelenkontrolDegeri == 0)// tur yoksa eklettiriyoruz
                {
                    SqlCommand turEkle = new SqlCommand("insert into Tur_tbl(turAdi) values('" + txt_turAdi.Text + "')", baglanti);
                    turEkle.ExecuteNonQuery();
                    txt_turAdi.Text = "";
                }
                else MessageBox.Show("Bu tür veritabanında ekli");
                baglanti.Close();
                if (Application.OpenForms["KutuphaneBilgiSistemi"] != null)// KutuphaneBilgiSistemi açıksa
                {
                    KutuphaneBilgiSistemi kutuphaneBilgiSistemi = (KutuphaneBilgiSistemi)Application.OpenForms["KutuphaneBilgiSistemi"];
                    kutuphaneBilgiSistemi.turListesiYukle(); // KutuphaneBilgiSistemi sayfasındaki tür listesi combobox unu güncelliyotuz 
                }
            }
        }

        private void comboBox_YazarList_Click(object sender, EventArgs e) // yazarlar combobox una her tıkladığımızda veriabanından güncel yazar listesini çekiyoruz
        {
            comboBox_YazarList.Items.Clear();
            baglanti.Open();
            SqlCommand yazarlar = new SqlCommand("select yazarAdiSoyadi from Yazar_tbl", baglanti);
            SqlDataReader read = yazarlar.ExecuteReader();
            while (read.Read())
            {
                comboBox_YazarList.Items.Add(read["yazarAdiSoyadi"]);
            }
            read.Close();
            baglanti.Close();
        }

        private void comboBox_TurList_Click(object sender, EventArgs e) // tur combobox una her tıkladığımızda veritabanından güncel tur listesini çekiyoruz
        {
            comboBox_TurList.Items.Clear();
            baglanti.Open();
            SqlCommand yazarlar = new SqlCommand("select turAdi from Tur_tbl", baglanti);
            SqlDataReader read = yazarlar.ExecuteReader();
            while (read.Read())
            {
                comboBox_TurList.Items.Add(read["turAdi"]);
            }
            read.Close();
            baglanti.Close();
        }
    }
}
