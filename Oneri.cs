using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatirimYonetimSistemi
{
    class Oneri
    {
        int id, hisse_id, analist_id;
        string al_sat;

        public Oneri(int id, int hisse_id, int analist_id, string al_sat)
        {
            Console.WriteLine("Oneri Constructor çalıştı!");
            ID = id;
            HISSE_ID = hisse_id;
            ANALIST_ID = analist_id;
            AL_SAT = al_sat;

        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int HISSE_ID
        {
            get { return hisse_id; }
            set { hisse_id = value; }
        }
        public int ANALIST_ID
        {
            get { return analist_id; }
            set { analist_id = value; }
        }

        public string AL_SAT
        {
            get { return al_sat; }
            set { al_sat = value; }
        }


    }
}
