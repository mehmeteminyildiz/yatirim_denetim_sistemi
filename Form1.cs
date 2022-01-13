using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YatirimYonetimSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        NpgsqlConnection baglanti = 
            new NpgsqlConnection("server=localhost; port=5432; Database=db_proje; user ID=postgres;" +
            "password=1234");

        private void musteriGirisi(string giren_kullanici_adi)
        {
            FormAnasayfaMusteri formAnasayfaMusteri = new FormAnasayfaMusteri(kullanici_adi: giren_kullanici_adi);
            //formAnasayfaMusteri.labelMusteriAdi.Text = kullanici_adi;
            formAnasayfaMusteri.Show();
            this.Hide();
        }

        private void analistGirisi(string kullanici_adi)
        {
            FormAnasayfaAnalist formAnasayfaAnalist = new FormAnasayfaAnalist(analist_adi: kullanici_adi);
            this.Hide();
            formAnasayfaAnalist.Show();
        }

        bool move;
        int mouse_x, mouse_y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

        }

       

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnMaximize_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAnalistGirisi_Click(object sender, EventArgs e)
        { // analist girişi
            string kullanici_adi = tbGirisKullaniciAdi.Text;
            string parola = tbGirisParole.Text;

            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) from \"ANALISTLER\" WHERE kullanici_adi=@p1 AND parola=@p2", baglanti);
            command.Parameters.AddWithValue("@p1", kullanici_adi);
            command.Parameters.AddWithValue("@p2", parola);

            NpgsqlDataReader dr = command.ExecuteReader();
            bool girisBasarili = false;

            while (dr.Read())
            {
                Console.WriteLine("COUNT: {0}", dr[0]); ;
                if (Convert.ToInt32(dr[0]) == 1)
                {
                    girisBasarili = true;
                    analistGirisi(kullanici_adi);
                }
                else
                {
                    girisBasarili = false;
                }
            }
            if (!girisBasarili)
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");

            }
            baglanti.Close();


        }

        private void btnMusteriGirisi_Click(object sender, EventArgs e)
        { // müşteri girişi

            string kullanici_adi = tbGirisKullaniciAdi.Text;
            string parola = tbGirisParole.Text;

            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) from \"MUSTERILER\" WHERE kullanici_adi=@p1 AND parola=@p2", baglanti);
            command.Parameters.AddWithValue("@p1", kullanici_adi);
            command.Parameters.AddWithValue("@p2", parola);

            NpgsqlDataReader dr = command.ExecuteReader();
            bool girisBasarili = false;
            
            while (dr.Read())
            {
                Console.WriteLine("COUNT: {0}", dr[0]); ;
                if (Convert.ToInt32(dr[0]) == 1)
                {
                    girisBasarili = true;
                    musteriGirisi(kullanici_adi);
                }
                else
                {
                    girisBasarili = false;
                }
            }
            if (!girisBasarili)
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");

            }
            baglanti.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }


        

    }
}
