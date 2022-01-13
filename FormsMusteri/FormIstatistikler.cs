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
using System.Windows.Forms.DataVisualization.Charting;

namespace YatirimYonetimSistemi.FormsMusteri
{
    public partial class FormIstatistikler : Form
    {
        string gelen_kullanici_adi;
        public FormIstatistikler(string kullanici_adi)
        {
            InitializeComponent();
            gelen_kullanici_adi = kullanici_adi;
        }
        NpgsqlConnection baglanti =
            new NpgsqlConnection("server=localhost; port=5432; Database=db_proje; user ID=postgres;" +
            "password=1234");

        private void FormIstatistikler_Load(object sender, EventArgs e)
        {

            portfoyDurumunuYansit(gelen_kullanici_adi);


            
        }

        private void portfoyDurumunuYansit(string kullanici_adi)
        {
            // DB'den portföy bilgisini çekelim aylara göre. Ve o verileri yansıtalım.
            // gerekenler: ay, para     göndereceğimiz veri: kullanici_adi
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT Po.* from \"PORTFOY_DURUMU\" Po " +
                "WHERE Po.musteri_id = (SELECT id from \"MUSTERILER\" Mu " +
                "WHERE Mu.kullanici_adi=@p1) ORDER BY Po.ay", baglanti);
            command.Parameters.AddWithValue("@p1", kullanici_adi);

            NpgsqlDataReader dr = command.ExecuteReader();
            List<string> aylar = new List<string>();
            List<double> para = new List<double>();

            while (dr.Read())
            { // 2: ay  3: para
                Console.WriteLine("Ay: {0}    Para: {1}", dr[2],dr[3] );
                aylar.Add(Convert.ToString(dr[2]));
                para.Add(Convert.ToDouble(dr[3]));
            }

            for (int i = 0; i < aylar.Count; i++)
            {
                chart1.Series["Portfoy"].Points.AddXY(aylar[i], para[i]);
            }

            baglanti.Close();

        }


    }
}
