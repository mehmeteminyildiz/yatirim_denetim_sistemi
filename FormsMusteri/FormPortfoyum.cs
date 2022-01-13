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
            hisseAdlariniGetir();
            buttonEkle.Enabled = false;

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
            baglanti.Close();

            showPieChart(hisseler, fiyatlar, adetler); // açık pozisyon bilgilerini pieChart'a yansıtıyoruz.
            gridViewDoldur(acik_pozisyonlar); // gridView'i dolduruyoruz gerekli bilgilerle.
        }

        private void hisseAdlariniGetir()
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("select ad from \"HISSELER\"", baglanti);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                comboHisseAdi.Items.Add(dr[0]);
            }

            baglanti.Close();

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

            if (pozisyonlar.Count > 0)
            {
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
            else
            {

            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                int guncellenecek_id = Convert.ToInt32(tbId.Text); // pozisyon_id değeri bu.
                NpgsqlCommand command = new NpgsqlCommand("UPDATE \"ACIK_POZISYONLAR\" " +
                    "SET maliyet=@p1, adet=@p2, fiyat=@p3 " +
                    "WHERE id=@p4", baglanti);
                command.Parameters.AddWithValue("@p1", Convert.ToDouble(tbMaliyet.Text));
                command.Parameters.AddWithValue("@p2", Convert.ToInt32(tbAdet.Text));
                command.Parameters.AddWithValue("@p3", Convert.ToDouble(tbFiyat.Text));
                command.Parameters.AddWithValue("@p4", guncellenecek_id);

                command.ExecuteNonQuery();

                inputlariTemizle();
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorun var!");
            }


        }


        private void btnIslemiKapat_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Bu işlemin detaylarını KAPALI_POZISYONLAR tablosuna ekleyelim.
                // 2. işlemi ACIK_POZISYONLAR tablosundan sil
                kapaliPozisyonlaraEkle();
                //acikPozisyonlardanSil();

            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorun var!");

            }
            
        }

        private void kapaliPozisyonlaraEkle()
        {
            string hisse_adi = comboHisseAdi.Text;
            int adet = Convert.ToInt32(tbAdet.Text);
            double maliyet = Convert.ToDouble(tbMaliyet.Text);

            baglanti.Open();
            // gerekli bilgiler: musteri_id, hisse_id, maliyet: , adet, fiyat
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"KAPALI_POZISYONLAR\" " +
                "(musteri_id, hisse_id, maliyet, adet, fiyat) " +
                "VALUES ((SELECT Mu.id from \"MUSTERILER\" Mu WHERE Mu.kullanici_adi=@p1)," +
                "(SELECT Hi.id from \"HISSELER\" Hi WHERE Hi.ad=@p2)," +
                "@p3, @p4, @p5)", baglanti);

            command.Parameters.AddWithValue("@p1", gelen_kullanici_adi);
            command.Parameters.AddWithValue("@p2", comboHisseAdi.Text);
            command.Parameters.AddWithValue("@p3", Convert.ToDouble(tbMaliyet.Text));
            command.Parameters.AddWithValue("@p4", Convert.ToInt32(tbAdet.Text));
            command.Parameters.AddWithValue("@p5", Convert.ToDouble(tbFiyat.Text));

            command.ExecuteNonQuery();

            baglanti.Close();

            acikPozisyonlardanSil();
        }

        private void acikPozisyonlardanSil()
        {
            int silinecekPozisyonId = Convert.ToInt32(tbId.Text);

            baglanti.Open();
            // gerekli bilgiler: musteri_id, hisse_id, maliyet: , adet, fiyat
            NpgsqlCommand command = new NpgsqlCommand("delete from \"ACIK_POZISYONLAR\" where id=@p1", baglanti);

            command.Parameters.AddWithValue("@p1", silinecekPozisyonId);

            command.ExecuteNonQuery();

            inputlariTemizle();
            baglanti.Close();
            foreach (DataGridViewRow item in this.dataGridViewPozisyonlar.SelectedRows)
            {
                dataGridViewPozisyonlar.Rows.RemoveAt(item.Index);
            }

            procedureCalistir();

        }

        private void procedureCalistir()
        {
            baglanti.Open();
            // gerekli bilgiler: musteri_id, hisse_id, maliyet: , adet, fiyat
            NpgsqlCommand command = new NpgsqlCommand("call islemkapandi();", baglanti);

            command.ExecuteNonQuery();

            baglanti.Close();
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            // id, hisse adı, adet, maliyet, fiyat
            btnGuncelle.Enabled = true;
            btnIslemiKapat.Enabled = true;
            buttonEkle.Enabled = false;
            try
            {
                string hisse_adi = comboHisseAdi.Text;
                int adet = Convert.ToInt32(tbAdet.Text);
                double maliyet = Convert.ToDouble(tbMaliyet.Text);

                baglanti.Open();
                // gerekli bilgiler: musteri_id, hisse_id, maliyet: , adet, fiyat
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"ACIK_POZISYONLAR\" " +
                    "(musteri_id, hisse_id, maliyet, adet, fiyat) " +
                    "VALUES ((SELECT Mu.id from \"MUSTERILER\" Mu where Mu.kullanici_adi=@p1), " +
                    "(SELECT Hi.id from \"HISSELER\" Hi where Hi.ad=@p2), " +
                    "@p3, @p4, @p5)", baglanti);
                command.Parameters.AddWithValue("@p1", gelen_kullanici_adi);
                command.Parameters.AddWithValue("@p2", comboHisseAdi.Text);
                command.Parameters.AddWithValue("@p3", Convert.ToDouble(tbMaliyet.Text));
                command.Parameters.AddWithValue("@p4", Convert.ToInt32(tbAdet.Text));
                command.Parameters.AddWithValue("@p5", Convert.ToDouble(tbFiyat.Text));

                command.ExecuteNonQuery();

                inputlariTemizle();
                baglanti.Close();




                // DB işlemi sonrası:
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
            
            // GridView'e eklenmesi:
            int index = dataGridViewPozisyonlar.Rows.Add();

            dataGridViewPozisyonlar.Rows[index].Cells[0].Value = "-";
            dataGridViewPozisyonlar.Rows[index].Cells[1].Value = hisse_adi;
            dataGridViewPozisyonlar.Rows[index].Cells[2].Value = adet;
            dataGridViewPozisyonlar.Rows[index].Cells[3].Value = maliyet;
            dataGridViewPozisyonlar.Rows[index].Cells[4].Value = maliyet;
            dataGridViewPozisyonlar.Rows[index].Cells[5].Value = 0;

            btnGuncelle.Enabled = true;
            btnIslemiKapat.Enabled = true;

            inputlariTemizle();





        }

        private void FormPortfoyum_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewPozisyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                inputlariTemizle();
                btnGuncelle.Enabled = true;
                btnIslemiKapat.Enabled = true;
                buttonEkle.Enabled = false;
                comboHisseAdi.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Hisse"].Value.ToString();
                dataGridViewPozisyonlar.CurrentRow.Selected = true;
                tbId.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                comboHisseAdi.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Hisse"].Value.ToString();
                tbAdet.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Adet"].Value.ToString();
                tbMaliyet.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Maliyet"].Value.ToString();
                tbFiyat.Text = dataGridViewPozisyonlar.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Geçersiz seçim!");
            }
            

        }

        private void btnYeniIslem_Click(object sender, EventArgs e)
        {
            inputlariTemizle();
            buttonEkle.Enabled = true ;
            btnGuncelle.Enabled = false;
            btnIslemiKapat.Enabled = false;
        }

        private void inputlariTemizle()
        {
            tbId.Text = "";
            tbAdet.Text = "";
            tbMaliyet.Text = "";
            tbFiyat.Text = "";

        }
    }
}
