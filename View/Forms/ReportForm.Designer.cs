namespace Herbarium.Forms
{
    partial class ReportForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbCsv = new System.Windows.Forms.RadioButton();
            this.rdbHtml = new System.Windows.Forms.RadioButton();
            this.rdbXml = new System.Windows.Forms.RadioButton();
            this.rdbJson = new System.Windows.Forms.RadioButton();
            this.rdbMetin = new System.Windows.Forms.RadioButton();
            this.rdbExcel = new System.Windows.Forms.RadioButton();
            this.rdbYazdir = new System.Windows.Forms.RadioButton();
            this.btnRaporla = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbCsv);
            this.groupBox1.Controls.Add(this.rdbHtml);
            this.groupBox1.Controls.Add(this.rdbXml);
            this.groupBox1.Controls.Add(this.rdbJson);
            this.groupBox1.Controls.Add(this.rdbMetin);
            this.groupBox1.Controls.Add(this.rdbExcel);
            this.groupBox1.Controls.Add(this.rdbYazdir);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rapor Formatı";
            // 
            // rdbCsv
            // 
            this.rdbCsv.AutoSize = true;
            this.rdbCsv.Location = new System.Drawing.Point(6, 157);
            this.rdbCsv.Name = "rdbCsv";
            this.rdbCsv.Size = new System.Drawing.Size(119, 17);
            this.rdbCsv.TabIndex = 5;
            this.rdbCsv.Text = "CSV Dosyası (*.csv)";
            this.rdbCsv.UseVisualStyleBackColor = true;
            // 
            // rdbHtml
            // 
            this.rdbHtml.AutoSize = true;
            this.rdbHtml.Location = new System.Drawing.Point(6, 65);
            this.rdbHtml.Name = "rdbHtml";
            this.rdbHtml.Size = new System.Drawing.Size(130, 17);
            this.rdbHtml.TabIndex = 2;
            this.rdbHtml.Text = "HTML Dosyası (*.html)";
            this.rdbHtml.UseVisualStyleBackColor = true;
            // 
            // rdbXml
            // 
            this.rdbXml.AutoSize = true;
            this.rdbXml.Location = new System.Drawing.Point(6, 134);
            this.rdbXml.Name = "rdbXml";
            this.rdbXml.Size = new System.Drawing.Size(118, 17);
            this.rdbXml.TabIndex = 4;
            this.rdbXml.Text = "XML Dosyası (*.xml)";
            this.rdbXml.UseVisualStyleBackColor = true;
            // 
            // rdbJson
            // 
            this.rdbJson.AutoSize = true;
            this.rdbJson.Location = new System.Drawing.Point(6, 111);
            this.rdbJson.Name = "rdbJson";
            this.rdbJson.Size = new System.Drawing.Size(126, 17);
            this.rdbJson.TabIndex = 3;
            this.rdbJson.Text = "JSON dosyası (*.json)";
            this.rdbJson.UseVisualStyleBackColor = true;
            // 
            // rdbMetin
            // 
            this.rdbMetin.AutoSize = true;
            this.rdbMetin.Location = new System.Drawing.Point(6, 88);
            this.rdbMetin.Name = "rdbMetin";
            this.rdbMetin.Size = new System.Drawing.Size(116, 17);
            this.rdbMetin.TabIndex = 3;
            this.rdbMetin.Text = "Metin dosyası (*.txt)";
            this.rdbMetin.UseVisualStyleBackColor = true;
            // 
            // rdbExcel
            // 
            this.rdbExcel.AutoSize = true;
            this.rdbExcel.Location = new System.Drawing.Point(6, 42);
            this.rdbExcel.Name = "rdbExcel";
            this.rdbExcel.Size = new System.Drawing.Size(117, 17);
            this.rdbExcel.TabIndex = 1;
            this.rdbExcel.Text = "Excel dosyası (*.xls)";
            this.rdbExcel.UseVisualStyleBackColor = true;
            // 
            // rdbYazdir
            // 
            this.rdbYazdir.AutoSize = true;
            this.rdbYazdir.Checked = true;
            this.rdbYazdir.Location = new System.Drawing.Point(6, 19);
            this.rdbYazdir.Name = "rdbYazdir";
            this.rdbYazdir.Size = new System.Drawing.Size(54, 17);
            this.rdbYazdir.TabIndex = 0;
            this.rdbYazdir.TabStop = true;
            this.rdbYazdir.Text = "Yazdır";
            this.rdbYazdir.UseVisualStyleBackColor = true;
            // 
            // btnRaporla
            // 
            this.btnRaporla.Location = new System.Drawing.Point(274, 200);
            this.btnRaporla.Name = "btnRaporla";
            this.btnRaporla.Size = new System.Drawing.Size(75, 23);
            this.btnRaporla.TabIndex = 3;
            this.btnRaporla.Text = "Raporla";
            this.btnRaporla.UseVisualStyleBackColor = true;
            this.btnRaporla.Click += new System.EventHandler(this.btnRaporla_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 226);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRaporla);
            this.Name = "ReportForm";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbCsv;
        private System.Windows.Forms.RadioButton rdbHtml;
        private System.Windows.Forms.RadioButton rdbXml;
        private System.Windows.Forms.RadioButton rdbJson;
        private System.Windows.Forms.RadioButton rdbMetin;
        private System.Windows.Forms.RadioButton rdbExcel;
        private System.Windows.Forms.RadioButton rdbYazdir;
        private System.Windows.Forms.Button btnRaporla;
    }
}