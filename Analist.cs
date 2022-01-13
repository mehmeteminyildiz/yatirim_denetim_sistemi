using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatirimYonetimSistemi
{
    class Analist
    {
        int id;
        string kullanici_adi, ad_soyad, baslama_tarihi, parola;


        public Analist(int id, string kullanici_adi, string ad_soyad,
            string baslama_tarihi, string parola)
        {
            Console.WriteLine("ANALİST constructor çalıştı");
            ID = id;
            KULLANICI_ADI = kullanici_adi;
            AD_SOYAD = ad_soyad;
            BASLAMA_TARIHI = baslama_tarihi;
            PAROLA = parola;

        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string KULLANICI_ADI
        {
            get { return kullanici_adi; }
            set { kullanici_adi = value; }
        }

        public string AD_SOYAD
        {
            get { return ad_soyad; }
            set { ad_soyad = value; }
        }

        public string BASLAMA_TARIHI
        {
            get { return baslama_tarihi; }
            set { baslama_tarihi = value; }
        }

        public string PAROLA
        {
            get { return parola; }
            set { parola = value; }
        }
    }
}
