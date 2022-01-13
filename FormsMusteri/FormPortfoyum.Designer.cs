
namespace YatirimYonetimSistemi.FormsMusteri
{
    partial class FormPortfoyum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.tbAdet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFiyat = new System.Windows.Forms.TextBox();
            this.tbMaliyet = new System.Windows.Forms.TextBox();
            this.btnIslemiKapat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHisseAdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.dataGridViewPozisyonlar = new System.Windows.Forms.DataGridView();
            this.buttonEkle = new System.Windows.Forms.Button();
            this.comboTest = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPozisyonlar)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 1);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(390, 309);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Orange;
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(408, 250);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(130, 60);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // tbAdet
            // 
            this.tbAdet.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbAdet.Location = new System.Drawing.Point(565, 110);
            this.tbAdet.Name = "tbAdet";
            this.tbAdet.Size = new System.Drawing.Size(287, 31);
            this.tbAdet.TabIndex = 3;
            this.tbAdet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(438, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Adet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(438, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Maliyet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(438, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fiyat";
            // 
            // tbFiyat
            // 
            this.tbFiyat.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbFiyat.Location = new System.Drawing.Point(565, 196);
            this.tbFiyat.Name = "tbFiyat";
            this.tbFiyat.Size = new System.Drawing.Size(287, 31);
            this.tbFiyat.TabIndex = 9;
            this.tbFiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMaliyet
            // 
            this.tbMaliyet.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbMaliyet.Location = new System.Drawing.Point(565, 153);
            this.tbMaliyet.Name = "tbMaliyet";
            this.tbMaliyet.Size = new System.Drawing.Size(287, 31);
            this.tbMaliyet.TabIndex = 10;
            this.tbMaliyet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnIslemiKapat
            // 
            this.btnIslemiKapat.BackColor = System.Drawing.Color.Crimson;
            this.btnIslemiKapat.FlatAppearance.BorderSize = 0;
            this.btnIslemiKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIslemiKapat.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIslemiKapat.ForeColor = System.Drawing.Color.White;
            this.btnIslemiKapat.Location = new System.Drawing.Point(565, 250);
            this.btnIslemiKapat.Name = "btnIslemiKapat";
            this.btnIslemiKapat.Size = new System.Drawing.Size(130, 60);
            this.btnIslemiKapat.TabIndex = 11;
            this.btnIslemiKapat.Text = "İşlemi Kapat";
            this.btnIslemiKapat.UseVisualStyleBackColor = false;
            this.btnIslemiKapat.Click += new System.EventHandler(this.btnIslemiKapat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(438, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Hisse";
            // 
            // tbHisseAdi
            // 
            this.tbHisseAdi.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbHisseAdi.Location = new System.Drawing.Point(565, 67);
            this.tbHisseAdi.Name = "tbHisseAdi";
            this.tbHisseAdi.Size = new System.Drawing.Size(287, 31);
            this.tbHisseAdi.TabIndex = 12;
            this.tbHisseAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(438, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID";
            // 
            // tbId
            // 
            this.tbId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbId.ForeColor = System.Drawing.Color.Black;
            this.tbId.Location = new System.Drawing.Point(565, 24);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(287, 31);
            this.tbId.TabIndex = 15;
            this.tbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewPozisyonlar
            // 
            this.dataGridViewPozisyonlar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPozisyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPozisyonlar.Location = new System.Drawing.Point(12, 316);
            this.dataGridViewPozisyonlar.MultiSelect = false;
            this.dataGridViewPozisyonlar.Name = "dataGridViewPozisyonlar";
            this.dataGridViewPozisyonlar.ReadOnly = true;
            this.dataGridViewPozisyonlar.RowHeadersWidth = 51;
            this.dataGridViewPozisyonlar.RowTemplate.Height = 24;
            this.dataGridViewPozisyonlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPozisyonlar.Size = new System.Drawing.Size(1005, 274);
            this.dataGridViewPozisyonlar.TabIndex = 16;
            this.dataGridViewPozisyonlar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPozisyonlar_CellClick);
            // 
            // buttonEkle
            // 
            this.buttonEkle.BackColor = System.Drawing.Color.Teal;
            this.buttonEkle.FlatAppearance.BorderSize = 0;
            this.buttonEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEkle.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonEkle.ForeColor = System.Drawing.Color.White;
            this.buttonEkle.Location = new System.Drawing.Point(722, 250);
            this.buttonEkle.Name = "buttonEkle";
            this.buttonEkle.Size = new System.Drawing.Size(130, 60);
            this.buttonEkle.TabIndex = 17;
            this.buttonEkle.Text = "İşlem Ekle";
            this.buttonEkle.UseVisualStyleBackColor = false;
            this.buttonEkle.Click += new System.EventHandler(this.buttonEkle_Click);
            // 
            // comboTest
            // 
            this.comboTest.FormattingEnabled = true;
            this.comboTest.Location = new System.Drawing.Point(885, 93);
            this.comboTest.Name = "comboTest";
            this.comboTest.Size = new System.Drawing.Size(121, 24);
            this.comboTest.TabIndex = 18;
            // 
            // FormPortfoyum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1029, 602);
            this.Controls.Add(this.comboTest);
            this.Controls.Add(this.buttonEkle);
            this.Controls.Add(this.dataGridViewPozisyonlar);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbHisseAdi);
            this.Controls.Add(this.btnIslemiKapat);
            this.Controls.Add(this.tbMaliyet);
            this.Controls.Add(this.tbFiyat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAdet);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.chart1);
            this.Name = "FormPortfoyum";
            this.Text = "Portföyüm";
            this.Load += new System.EventHandler(this.FormPortfoyum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPozisyonlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.TextBox tbAdet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFiyat;
        private System.Windows.Forms.TextBox tbMaliyet;
        private System.Windows.Forms.Button btnIslemiKapat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHisseAdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.DataGridView dataGridViewPozisyonlar;
        private System.Windows.Forms.Button buttonEkle;
        private System.Windows.Forms.ComboBox comboTest;
    }
}