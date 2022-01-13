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
    public partial class FormAnasayfaAnalist : Form
    {
        private Form activeForm;
        private Button currentButton;
        string gelen_analist_adi;
        public FormAnasayfaAnalist(string analist_adi)
        {
            InitializeComponent();
            btnCloseChildForm.Visible = false;
            gelen_analist_adi = analist_adi;
            gelenKullaniciAdiniYansit(analist_adi);

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


        private void btnAnalistAnaliz_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAnalist.FormAnaliz(gelen_analist_adi), sender, Color.FromArgb(44, 0, 126));
        }



        private void btnAnalistProfil_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAnalist.FormProfil(gelen_analist_adi), sender, Color.FromArgb(44, 0, 126));

        }

        private void btnAnalistClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnAnalistMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnAnalistMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panelTitleBarAnalist_MouseDown(object sender, MouseEventArgs e)
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
            this.panelDesktopPaneAnalist.Controls.Add(childForm);
            this.panelDesktopPaneAnalist.Tag = childForm;
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
                    //panelTitleBarAnalist.BackColor = color;
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

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Ana Sayfa";
            panelTitleBarAnalist.BackColor = Color.FromArgb(37, 8, 91);
            lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panelLogo.BackColor = Color.FromArgb(19, 0, 54);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktopPaneAnalist_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
