
namespace YatirimYonetimSistemi.FormsAnalist
{
    partial class FormAnaliz
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
            this.dataGridViewAnalistOneriler = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOneriEkle = new System.Windows.Forms.Button();
            this.comboBoxAlSat = new System.Windows.Forms.ComboBox();
            this.comboBoxHisseler = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalistOneriler)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAnalistOneriler
            // 
            this.dataGridViewAnalistOneriler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAnalistOneriler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.dataGridViewAnalistOneriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnalistOneriler.Location = new System.Drawing.Point(12, 65);
            this.dataGridViewAnalistOneriler.MultiSelect = false;
            this.dataGridViewAnalistOneriler.Name = "dataGridViewAnalistOneriler";
            this.dataGridViewAnalistOneriler.ReadOnly = true;
            this.dataGridViewAnalistOneriler.RowHeadersWidth = 51;
            this.dataGridViewAnalistOneriler.RowTemplate.Height = 24;
            this.dataGridViewAnalistOneriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAnalistOneriler.Size = new System.Drawing.Size(776, 525);
            this.dataGridViewAnalistOneriler.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hisse Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(347, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tavsiye:";
            // 
            // btnOneriEkle
            // 
            this.btnOneriEkle.BackColor = System.Drawing.Color.SpringGreen;
            this.btnOneriEkle.FlatAppearance.BorderSize = 0;
            this.btnOneriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOneriEkle.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOneriEkle.ForeColor = System.Drawing.Color.Black;
            this.btnOneriEkle.Location = new System.Drawing.Point(667, 10);
            this.btnOneriEkle.Name = "btnOneriEkle";
            this.btnOneriEkle.Size = new System.Drawing.Size(97, 35);
            this.btnOneriEkle.TabIndex = 18;
            this.btnOneriEkle.Text = "Ekle";
            this.btnOneriEkle.UseVisualStyleBackColor = false;
            this.btnOneriEkle.Click += new System.EventHandler(this.btnOneriEkle_Click);
            // 
            // comboBoxAlSat
            // 
            this.comboBoxAlSat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlSat.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxAlSat.FormattingEnabled = true;
            this.comboBoxAlSat.Items.AddRange(new object[] {
            "AL",
            "SAT"});
            this.comboBoxAlSat.Location = new System.Drawing.Point(442, 9);
            this.comboBoxAlSat.Name = "comboBoxAlSat";
            this.comboBoxAlSat.Size = new System.Drawing.Size(170, 36);
            this.comboBoxAlSat.TabIndex = 19;
            // 
            // comboBoxHisseler
            // 
            this.comboBoxHisseler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHisseler.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.comboBoxHisseler.FormattingEnabled = true;
            this.comboBoxHisseler.Location = new System.Drawing.Point(127, 9);
            this.comboBoxHisseler.Name = "comboBoxHisseler";
            this.comboBoxHisseler.Size = new System.Drawing.Size(170, 36);
            this.comboBoxHisseler.TabIndex = 20;
            // 
            // FormAnaliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.comboBoxHisseler);
            this.Controls.Add(this.comboBoxAlSat);
            this.Controls.Add(this.btnOneriEkle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAnalistOneriler);
            this.Name = "FormAnaliz";
            this.Text = "FormAnaliz";
            this.Load += new System.EventHandler(this.FormAnaliz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalistOneriler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAnalistOneriler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOneriEkle;
        private System.Windows.Forms.ComboBox comboBoxAlSat;
        private System.Windows.Forms.ComboBox comboBoxHisseler;
    }
}