using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatirimYonetimSistemi
{
    class Pozisyon
    {
        int pozisyon_id, musteri_id, hisse_id, adet;
        double maliyet, fiyat;
        string hisse_adi;

        public Pozisyon(int pozisyon_id, int musteri_id, int hisse_id, int adet,
            double maliyet, double fiyat, string hisse_adi)
        {
            POZISYON_ID = pozisyon_id;
            MUSTERI_ID = musteri_id;
            HISSE_ID = hisse_id;
            ADET = adet;
            MALIYET = maliyet;
            FIYAT = fiyat;
            HISSE_ADI = hisse_adi;
        }

        public int POZISYON_ID { get => pozisyon_id; set => pozisyon_id = value; }
        public int MUSTERI_ID { get => musteri_id; set => musteri_id = value; }
        public int HISSE_ID { get => hisse_id; set => hisse_id = value; }
        public int ADET { get => adet; set => adet = value; }
        public double MALIYET { get => maliyet; set => maliyet = value; }
        public double FIYAT { get => fiyat; set => fiyat = value; }
        public string HISSE_ADI { get => hisse_adi; set => hisse_adi = value; }

    }
}
