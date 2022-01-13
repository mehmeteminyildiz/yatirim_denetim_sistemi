using LiveCharts;
using LiveCharts.Wpf;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YatirimYonetimSistemi.FormsMusteri
{
    public partial class FormPortfoyum : Form
    {
        public string gelen_kullanici_adi;

        NpgsqlConnection baglanti =
            new NpgsqlConnection("server=localhost; port=5432; Database=db_proje; user ID=postgres;" +
            "password=1234");

        public FormPortfoyum(string kullanici_adi)
        {
            InitializeComponent();
            gelen_kullanici_adi = kullanici_adi;
            pozisyonBilgileriniAl(kullanici_adi);
        }

        private void pozisyonBilgileriniAl(string kullanici_adi)
        {
            // DB'den AÇIK POZİSYONLAR tablosundaki bilgileri al.
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT AP.*, Hi.ad from \"ACIK_POZISYONLAR\" AP, " +
                "\"HISSELER\" Hi WHERE musteri_id = (SELECT Mu.id from \"MUSTERILER\" Mu " +
                "WHERE Mu.kullanici_adi = @p1)" +
                "AND AP.hisse_id = Hi.id", baglanti);
            command.Parameters.AddWithValue("@p1", kullanici_adi);
            NpgsqlDataReader dr = command.ExecuteReader();
            // Pie Chart için: hisseler, fiyatlar, adetler
            List<string> hisseler = new List<string>();
            List<double> fiyatlar = new List<double>();
            List<int> adetler = new List<int>();
            List<Pozisyon> acik_pozisyonlar = new List<Pozisyon>();
            while (dr.Read())
            {
                hisseler.Add(Convert.ToString(dr[6])); // hisse adları
                fiyatlar.Add(Convert.ToDouble(dr[5])); // fiyat
                adetler.Add(Convert.ToInt32(dr[4])); // adet

                // Açık Pozisyonlar için:
                Pozisyon p = new Pozisyon(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1])
                    , Convert.ToInt32(dr[2]), Convert.ToInt32(dr[4]), Convert.ToDouble(dr[3])
                    , Convert.ToDouble(dr[5]), Convert.ToString(dr[6]));

                acik_pozisyonlar.Add(p);


            }

            showPieChart(hisseler, fiyatlar, adetler); // açık pozisyon bilgilerini pieChart'a yansıtıyoruz.
            gridViewDoldur(acik_pozisyonlar); // gridView'i dolduruyoruz gerekli bilgilerle.

            /*List<Pozisyon> acik_pozisyonlar = new List<Pozisyon>();
            Pozisyon p1 = new Pozisyon(1, 1, 1, 15, 80, 90, "ASELS");
            Pozisyon p2 = new Pozisyon(18, 3, 4, 10, 40, 50, "BIMAS");
            Pozisyon p3 = new Pozisyon(32, 3, 5, 99, 4, 5, "ARCLK");
            Pozisyon p4 = new Pozisyon(28, 3, 6, 88, 2, 2.5F, "KOCHOL");
            Pozisyon p5 = new Pozisyon(96, 3, 7, 77, 40, 50.8F, "EREGL");

            acik_pozisyonlar.Add(p1);
            acik_pozisyonlar.Add(p2);
            acik_pozisyonlar.Add(p3);
            acik_pozisyonlar.Add(p4);
            acik_pozisyonlar.Add(p5);

            List<string> hisseler = new List<string>();
            List<int> fiyatlar = new List<int>();
            List<int> adetler = new List<int>();

            hisseler.Add("BIMAS");
            hisseler.Add("ASELS");
            hisseler.Add("EREGL");
            hisseler.Add("TL");

            fiyatlar.Add(15);
            fiyatlar.Add(12);
            fiyatlar.Add(18);
            fiyatlar.Add(10);

            adetler.Add(55);
            adetler.Add(10);
            adetler.Add(80);
            adetler.Add(80);*/




        }

        private void showPieChart(List<string> hisseler, List<double> fiyatlar, List<int> adetler)
        {
            for (int i = 0; i < hisseler.Count; i++)
            {
                chart1.Series["s1"].Points.AddXY(hisseler[i], fiyatlar[i] * adetler[i]);
            }
            chart1.Series["s1"].LabelBackColor = Color.Black;
            chart1.Series["s1"].LabelForeColor = Color.White;
        }
        private void gridViewDoldur(List<Pozisyon> pozisyonlar)
        {
            // gridView'i açık olan pozisyonlar ile dolduruyoruz
            dataGridViewPozisyonlar.ColumnCount = 6;
            dataGridViewPozisyonlar.Columns[0].Name = "ID";
            dataGridViewPozisyonlar.Columns[1].Name = "Hisse";
            dataGridViewPozisyonlar.Columns[2].Name = "Adet";
            dataGridViewPozisyonlar.Columns[3].Name = "Maliyet";
            dataGridViewPozisyonlar.Columns[4].Name = "Fiyat";
            dataGridViewPozisyonlar.Columns[5].Name = "Kazanc";

            dataGridViewPozisyonlar.Rows.Add(pozisyonlar.Count);

            for (int i = 0; i < pozisyonlar.Count; i++)
            {
                dataGridViewPozisyonlar.Rows[i].Cells[0].Value = pozisyonlar[i].POZISYON_ID;
                dataGridViewPozisyonlar.Rows[i].Cells[1].Value = pozisyonlar[i].HISSE_ADI;
                dataGridViewPozisyonlar.Rows[i].Cells[2].Value = pozisyonlar[i].ADET;
                dataGridViewPozisyonlar.Rows[i].Cells[3].Value = pozisyonlar[i].MALIYET;
                dataGridViewPozisyonlar.Rows[i].Cells[4].Value = pozisyonlar[i].FIYAT;
                dataGridViewPozisyonlar.Rows[i].Cells[5].Value = pozisyonlar[i].ADET * (pozisyonlar[i].FIYAT - pozisyonlar[i].MALIYET);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int guncellenecek_id = Convert.ToInt32(tbId.Text);
                islemiGuncelle(guncellenecek_id);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorun var!");
            }


        }

        private void islemiGuncelle(int guncellenecek_id)
        {
            Console.WriteLine("güncellenecek_id : " + guncellenecek_id);
        }

        private void btnIslemiKapat_Click(object sender, EventArgs e)
        {
            try
            {
                int kapatilacak_id = Convert.ToInt32(tbId.Text);
                islemiKapat(kapatilacak_id);

            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorun var!");

            }
            
        }

        private void islemiKapat(int kapatilacak_id)
        {
            Console.WriteLine("kapatilacak_id : " + kapatilacak_id);

        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            // id, hisse adı, adet, maliyet, fiyat
            try
            {
                string hisse_adi = tbHisseAdi.Text;
                int adet = Convert.ToInt32(tbAdet.Text);
                double maliyet = Convert.ToDouble(tbMaliyet.Text);
                islemEkle(hisse_adi, adet, maliyet);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorun var");
            }
            
        }

        private void islemEkle(string hisse_adi, int adet, double maliyet)
        {
            Console.WriteLine("Hisse Adı: " + hisse_adi + "\nAdet: " + adet + "\nMaliyet: " + maliyet);
            // Burada DB işlemi yapılır. Ardından gridview kısmına da eklenir:


            // GridView'e eklenmesi:
            int index = dataGridViewPozisyonlar.Rows.Add();

            dataGridViewPozisyonlar.Rows[index].Cells[0].Value = "-";
            dataGridViewPozisyonlar.Rows[index].Cells[1].Value = hisse_adi;
            dataGridViewPozisyonlar.Rows[index].Cells[2].Value = adet;
            dataGridViewPozisyonlar.Rows[index].Cells[3].Value = maliyet;
            dataGridViewPozisyonlar.Rows[index].Cells[4].Value = maliyet;
            dataGridViewPozisyonlar.Rows[index].Cells[5].Value = 0;





        }

        private void FormPortfoyum_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewPozisyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboTest.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Hisse"].Value.ToString();
                dataGridViewPozisyonlar.CurrentRow.Selected = true;
                tbId.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                tbHisseAdi.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Hisse"].Value.ToString();
                tbAdet.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Adet"].Value.ToString();
                tbMaliyet.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Maliyet"].Value.ToString();
                tbFiyat.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Geçersiz seçim!");
            }
            

        }

        
    }
}
