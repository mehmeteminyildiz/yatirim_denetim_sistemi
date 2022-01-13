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
    public partial class FormProfil : Form
    {
        public FormProfil(string kullanici_adi)
        {
            InitializeComponent();
            kullaniciBilgileriniGetirByKullaniciAdi(kullanici_adi);
        }

        NpgsqlConnection baglanti =
            new NpgsqlConnection("server=localhost; port=5432; Database=db_proje; user ID=postgres;" +
            "password=1234");


        private void kullaniciBilgileriniGetirByKullaniciAdi(string kullanici_adi)
        {
            // DB'den veriler gelir.
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * from \"MUSTERILER\" WHERE kullanici_adi=@p1", baglanti);
            command.Parameters.AddWithValue("@p1", kullanici_adi);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                string kullanici_adimiz=Convert.ToString(dr[1]);
                string ad_soyad =Convert.ToString(dr[3]);
                string hesap_no =Convert.ToString(dr[4]);
                string acilis_tarihi =Convert.ToString(dr[5]);
                string tc_no =Convert.ToString(dr[6]);
                string dogum_yeri =Convert.ToString(dr[7]);
                string dogum_tarihi =Convert.ToString(dr[8]);
                Console.WriteLine("BİLGİ: {0}", dr[0]);

                Musteri musteri = new Musteri(0, kullanici_adimiz, ad_soyad, hesap_no,
                    acilis_tarihi, tc_no, dogum_yeri, dogum_tarihi, "gereksiz");
                verileriYerlestir(musteri);
            }

            baglanti.Close();

            // ---------------------
            
            
        }
        private void verileriYerlestir(Musteri musteri)
        {
            lbl_musteri_kullanici_adi.Text = musteri.KULLANICI_ADI;
            lbl_musteri_hesap_no.Text = musteri.HESAP_NO;
            lbl_musteri_acilis_tarihi.Text = musteri.ACILIS_TARIHI;
            lbl_musteri_tc_no.Text = musteri.TC_NO;
            lbl_musteri_ad_soyad.Text = musteri.AD_SOYAD;
            lbl_musteri_dogum_yeri.Text = musteri.DOGUM_YERI;
            lbl_musteri_dogum_tarihi.Text = musteri.DOGUM_TARIHI;
            Console.WriteLine("veriler yerleştirildi!");
        }

        private void FormProfil_Load(object sender, EventArgs e)
        {


        }
    }
}
