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

namespace YatirimYonetimSistemi.FormsAnalist
{
    public partial class FormAnaliz : Form
    {
        string gelen_kullanici_adi;
        public FormAnaliz(string kullanici_adi)
        {
            InitializeComponent();
            gelen_kullanici_adi = kullanici_adi;

        }
        NpgsqlConnection baglanti =
            new NpgsqlConnection("server=localhost; port=5432; Database=db_proje; user ID=postgres;" +
            "password=1234");
        private void FormAnaliz_Load(object sender, EventArgs e)
        {
            hisseAdlariniGetir();
            onerileriGetir();


        }

        private void hisseAdlariniGetir()
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("select ad from \"HISSELER\"", baglanti);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                comboBoxHisseler.Items.Add(dr[0]);
            }

            baglanti.Close();

        }

        private void onerileriGetir()
        {   // öneriler tablosundaki tüm önerileri getirir.
            dataGridViewAnalistOneriler.ColumnCount = 3;
            dataGridViewAnalistOneriler.Columns[0].Name = "Hisse";
            dataGridViewAnalistOneriler.Columns[1].Name = "Tavsiye";
            dataGridViewAnalistOneriler.Columns[2].Name = "Analist";

            baglanti.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT Hi.ad, O.al_sat, An.ad_soyad from \"ONERILER\" O," +
                "\"ANALISTLER\" An, \"HISSELER\"Hi WHERE O.analist_id = An.id AND O.hisse_id = Hi.id", baglanti);
            // ihtiyacım olanlar --> 1: hisse_adı     2: al_sat   3: analist_adi
            NpgsqlDataReader dr = command.ExecuteReader();
            List<string> hisseler = new List<string>();
            List<string> tavsiyeler = new List<string>();
            List<string> analistler = new List<string>();
            while (dr.Read())
            {
                hisseler.Add(Convert.ToString(dr[0]));
                tavsiyeler.Add(Convert.ToString(dr[1]));
                analistler.Add(Convert.ToString(dr[2]));


                //Console.WriteLine("{0}   {1}   {2}", dr[0], dr[1], dr[2]);
            }
            baglanti.Close();

            onerileriYerlestir(hisseler, tavsiyeler, analistler);
        }
        private void onerileriYerlestir(List<string> hisseler, List<string> tavsiyeler, List<string> analistler)
        {


            dataGridViewAnalistOneriler.Rows.Add(hisseler.Count);

            for (int i = 0; i < hisseler.Count; i++)
            {
                dataGridViewAnalistOneriler.Rows[i].Cells[0].Value = hisseler[i];
                dataGridViewAnalistOneriler.Rows[i].Cells[1].Value = tavsiyeler[i];
                dataGridViewAnalistOneriler.Rows[i].Cells[2].Value = analistler[i];
            }


        }

        private void btnOneriEkle_Click(object sender, EventArgs e)
        {
            // hisse_adi, analist_adi, al_sat
            try
            {
                string hisse_adi = comboBoxHisseler.Text;
                string analist_adi = gelen_kullanici_adi;
                string al_sat = comboBoxAlSat.Text;
                if (hisse_adi.Trim().Equals("") || al_sat.Trim().Equals(""))
                {
                    MessageBox.Show("Eksik Bilgi Girdiniz");
                }

                else
                {
                    baglanti.Open();
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"ONERILER\" (hisse_id, analist_id, al_sat)" +
                        " VALUES ((SELECT Hi.id from \"HISSELER\" Hi WHERE Hi.ad=@p2)," +
                        "(SELECT id FROM \"ANALISTLER\" WHERE kullanici_adi=@p1), @p3);", baglanti);
                    command.Parameters.AddWithValue("@p1", analist_adi);
                    command.Parameters.AddWithValue("@p2", hisse_adi);
                    command.Parameters.AddWithValue("@p3", al_sat);

                    command.ExecuteNonQuery();
                    baglanti.Close();

                    oneriEkle(hisse_adi, analist_adi, al_sat);
                }

                

                
                
                
            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorun var");
            }
        }

        private void oneriEkle(string hisse_adi, string analist_adi, string al_sat)
        {
            // GridView'e eklenmesi:
            int index = dataGridViewAnalistOneriler.Rows.Add();

            dataGridViewAnalistOneriler.Rows[index].Cells[0].Value = hisse_adi;
            dataGridViewAnalistOneriler.Rows[index].Cells[1].Value = al_sat;
            dataGridViewAnalistOneriler.Rows[index].Cells[2].Value = analist_adi;
        }
    }
}
