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
    public partial class FormProfil : Form
    {
        string analist_adi;
        public FormProfil(string gelen_analist_adi)
        {
            InitializeComponent();
            analist_adi = gelen_analist_adi;
        }
        NpgsqlConnection baglanti =
            new NpgsqlConnection("server=localhost; port=5432; Database=db_proje; user ID=postgres;" +
            "password=1234");
        private void FormProfil_Load(object sender, EventArgs e)
        {
            analist_bilgilerini_getir(analist_adi);

        }

        private void analist_bilgilerini_getir(string analist_adi)
        { // DB'den analist_adi değeri kullanılarak analist'in bilgileri getirilir.

            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * from \"ANALISTLER\" WHERE kullanici_adi=@p1", baglanti);
            command.Parameters.AddWithValue("@p1", analist_adi);

            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string ad_soyad = Convert.ToString(dr[2]);
                string baslama_tarihi = Convert.ToString(dr[3]);
                bilgileriYerlestir(analist_adi, ad_soyad, baslama_tarihi);

            }


        }

        private void bilgileriYerlestir(string analist_adi, string ad_soyad, string baslama_tarihi)
        {
            // DB'den alınan analist bilgisi arayüze yansıtılır.
            lblAnalistKullaniciAdi.Text = analist_adi;
            lblAnalistAdSoyad.Text = ad_soyad;
            lblAnalistBaslamaTarihi.Text = baslama_tarihi;
        }
    }
}
