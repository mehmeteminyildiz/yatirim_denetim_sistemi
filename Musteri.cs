using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatirimYonetimSistemi
{
    class Musteri
    {
        
        public int id;
        public string kullanici_adi, ad_soyad, hesap_no, acilis_tarihi, tc_no, dogum_yeri, dogum_tarihi, parola;

        public Musteri(int id, string kullanici_adi, string ad_soyad, string hesap_no,
            string acilis_tarihi, string tc_no, string dogum_yeri, string dogum_tarihi, string parola)
        {
            Console.WriteLine("constructor çalıştı");
            ID = id;
            KULLANICI_ADI = kullanici_adi;
            AD_SOYAD = ad_soyad;
            HESAP_NO = hesap_no;
            ACILIS_TARIHI = acilis_tarihi;
            TC_NO = tc_no;
            DOGUM_YERI = dogum_yeri;
            DOGUM_TARIHI = dogum_tarihi;
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

        public string HESAP_NO
        {
            get { return hesap_no; }
            set { hesap_no = value; }
        }

        public string ACILIS_TARIHI
        {
            get { return acilis_tarihi; }
            set { acilis_tarihi = value; }
        }

        public string TC_NO
        {
            get { return tc_no; }
            set { tc_no = value; }
        }

        public string DOGUM_YERI
        {
            get { return dogum_yeri; }
            set { dogum_yeri = value; }
        }

        public string DOGUM_TARIHI
        {
            get { return dogum_tarihi; }
            set { dogum_tarihi = value; }
        }

        public string PAROLA
        {
            get { return parola; }
            set { parola = value; }
        }

    }
}
