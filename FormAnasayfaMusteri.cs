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
using YatirimYonetimSistemi.FormsMusteri;

namespace YatirimYonetimSistemi
{
    public partial class FormAnasayfaMusteri : Form
    {
        private Form activeForm;
        private Button currentButton;
        public string gonderilecek_kullanici_adi;

        public FormAnasayfaMusteri(string kullanici_adi)
        {
            InitializeComponent();
            btnCloseChildForm.Visible = false;
            gelenKullaniciAdiniYansit(kullanici_adi);
            gonderilecek_kullanici_adi = kullanici_adi;

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void gelenKullaniciAdiniYansit(string kullanici_adi)
        {
            labelMusteriAdi.Text = kullanici_adi;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label1_Click(object sender, EventArgs e)
        {
            // Application.Exit();  // uygulamadan çıkmak için bunu kullanabiliriz.
        }

        private void btnMusteriClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMusteriMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;

            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMusteriMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void FormAnasayfaMusteri_Load(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

        private void OpenChildForm(Form childForm, object btnSender, Color color)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender, color);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void ActivateButton(object btnSender, Color color)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                { 
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Comic Sans MS", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //panelTitleBar.BackColor = color;
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(19, 0, 54);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnPortfoyum_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMusteri.FormPortfoyum(gonderilecek_kullanici_adi), sender, Color.FromArgb(44,0, 126));

        }

        private void btnOneriler_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMusteri.FormOneriler(), sender, Color.FromArgb(44, 0, 126));

        }

        private void btnIstatistikler_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMusteri.FormIstatistikler(gonderilecek_kullanici_adi), sender, Color.FromArgb(44,0,126));

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();

            }
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Ana Sayfa";
            panelTitleBar.BackColor = Color.FromArgb(37,8,91);
            lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panelLogo.BackColor = Color.FromArgb(19,0,54);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMusteri.FormProfil(gonderilecek_kullanici_adi), sender, Color.FromArgb(44, 0, 126));
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
