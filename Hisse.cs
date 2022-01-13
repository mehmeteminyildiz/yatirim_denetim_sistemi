using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatirimYonetimSistemi
{
    class Hisse
    {
        int id;
        string ad;
        double fiyat;

        public Hisse(int id, string ad, double fiyat)
        {
            Console.WriteLine("Hisse constructor çalıştı");
            ID = id;
            AD = ad;
            FIYAT = fiyat;

        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string AD
        {
            get { return ad; }
            set { ad = value; }
        }

        public double FIYAT
        {
            get { return fiyat; }
            set { fiyat = value; }
        }


    }
}
