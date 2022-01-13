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
    public partial class FormOneriler : Form
    {
        public FormOneriler()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti =
            new NpgsqlConnection("server=localhost; port=5432; Database=db_proje; user ID=postgres;" +
            "password=1234");

        private void FormOneriler_Load(object sender, EventArgs e)
        {
            onerileriAl();
        }

        private void onerileriAl()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Hisse";
            dataGridView1.Columns[1].Name = "Tavsiye";
            dataGridView1.Columns[2].Name = "Analist";

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



            // öneriler alınır...
            onerileriYerlestir(hisseler, tavsiyeler, analistler);
        }

        private void onerileriYerlestir(List<string> hisseler, List<string> tavsiyeler, List<string> analistler)
        {
            

            dataGridView1.Rows.Add(hisseler.Count);

            for (int i = 0; i < hisseler.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = hisseler[i];
                dataGridView1.Rows[i].Cells[1].Value = tavsiyeler[i];
                dataGridView1.Rows[i].Cells[2].Value = analistler[i];
            }

            
        }
    }
}
