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
using ExcelApp = Microsoft.Office.Interop.Excel;


namespace KutuphaneOtomasyonu
{
    public partial class excelkaydetme : Form
    {
        public excelkaydetme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=---;Initial catalog=KutuphaneOtomasyon;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void excelkaydetme_Load(object sender, EventArgs e)
        {
            string DosyaYolu;
            string DosyaAdi;
            DataTable dt;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "excelkitap | *.xls; *.xlsx; *.xlsm";
            if (file.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = file.FileName;// seçilen dosyanın tüm yolunu verir
                DosyaAdi = file.SafeFileName;// seçilen dosyanın adını verir.
                ExcelApp.Application excelApp = new ExcelApp.Application();
                if (excelApp == null)
                { //Excel Yüklümü Kontrolü Yapılmaktadır.
                    MessageBox.Show("Excel yüklü değil.");
                    return;
                }
                //Excel Dosyası Açılıyor.
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DosyaYolu);
                //Excel Dosyasının Sayfası Seçilir.
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                //Excel Dosyasının ne kadar satır ve sütun kaplıyorsa tüm alanları alır.
                ExcelApp.Range excelRange = excelSheet.UsedRange;
                int satirSayisi = excelRange.Rows.Count; //Sayfanın satır sayısını alır.
                int sutunSayisi = excelRange.Columns.Count;//Sayfanın sütun sayısını alır.
                dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Dosya Seçilemedi.");
            }
        }

        public DataTable ToDataTable(ExcelApp.Range range, int rows, int cols)
        {
            baglanti.Open();
            MessageBox.Show(rows.ToString());
            DataTable table = new DataTable();
            for (int i = 2; i <= rows; i++)
            {
                SqlCommand komut1 = new SqlCommand("select count(*) from Kitap_tbl where kitapAdi ='" + range.Cells[i, 1].Value + "'", baglanti);
                if (Convert.ToInt32(komut1.ExecuteScalar()) == 0)
                {
                    SqlCommand kitapEkle = new SqlCommand("insert into Kitap_tbl(kitapAdi,kitapSayfaSayisi,kitapYili,kitapAdet,kalanAdet,turId,YazarId) values('" + range.Cells[i, 1].Value + "', '" + Convert.ToInt32(range.Cells[i, 2].Value) + "','" + Convert.ToInt32(range.Cells[i, 3].Value) + "','" + Convert.ToInt32(range.Cells[i, 4].Value) + "','" + Convert.ToInt32(range.Cells[i, 4].Value) + "','" + Convert.ToInt32(range.Cells[i, 5].Value) + "','" + Convert.ToInt32(range.Cells[i, 6].Value) + "')", baglanti);
                    kitapEkle.ExecuteNonQuery();
                }
             
            }
            baglanti.Close();
            return table;
        }
    }
}
