namespace Herbarium.Forms
{
    partial class UserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement));
            this.dataViewer1 = new Herbarium.DataViewer();
            this.chkVarsayilan = new System.Windows.Forms.CheckBox();
            this.txtSifre = new System.Windows.Forms.MaskedTextBox();
            this.btnKullaniciOlustur = new System.Windows.Forms.Button();
            this.btnKullaniciSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.trvYetkiler = new System.Windows.Forms.TreeView();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataViewer1
            // 
            this.dataViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataViewer1.Location = new System.Drawing.Point(0, 0);
            this.dataViewer1.Name = "dataViewer1";
            this.dataViewer1.Size = new System.Drawing.Size(633, 134);
            this.dataViewer1.TabIndex = 0;
            this.dataViewer1.Table = null;
            // 
            // chkVarsayilan
            // 
            this.chkVarsayilan.AutoSize = true;
            this.chkVarsayilan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkVarsayilan.Location = new System.Drawing.Point(150, 406);
            this.chkVarsayilan.Name = "chkVarsayilan";
            this.chkVarsayilan.Size = new System.Drawing.Size(239, 21);
            this.chkVarsayilan.TabIndex = 204;
            this.chkVarsayilan.Text = "Bu hesap için varsayılan kullanıcı";
            this.chkVarsayilan.UseVisualStyleBackColor = true;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(151, 167);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '•';
            this.txtSifre.Size = new System.Drawing.Size(324, 20);
            this.txtSifre.TabIndex = 196;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // btnKullaniciOlustur
            // 
            this.btnKullaniciOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKullaniciOlustur.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnKullaniciOlustur.FlatAppearance.BorderSize = 0;
            this.btnKullaniciOlustur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciOlustur.Font = new System.Drawing.Font("Arial", 9F);
            this.btnKullaniciOlustur.ForeColor = System.Drawing.Color.White;
            this.btnKullaniciOlustur.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciOlustur.Image")));
            this.btnKullaniciOlustur.Location = new System.Drawing.Point(166, 442);
            this.btnKullaniciOlustur.Name = "btnKullaniciOlustur";
            this.btnKullaniciOlustur.Size = new System.Drawing.Size(165, 38);
            this.btnKullaniciOlustur.TabIndex = 198;
            this.btnKullaniciOlustur.Text = "Yeni Kullanıcı Oluştur";
            this.btnKullaniciOlustur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKullaniciOlustur.UseVisualStyleBackColor = false;
            this.btnKullaniciOlustur.Click += new System.EventHandler(this.btnKullaniciOlustur_Click);
            // 
            // btnKullaniciSil
            // 
            this.btnKullaniciSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKullaniciSil.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnKullaniciSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKullaniciSil.Enabled = false;
            this.btnKullaniciSil.FlatAppearance.BorderSize = 0;
            this.btnKullaniciSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciSil.Font = new System.Drawing.Font("Arial", 9F);
            this.btnKullaniciSil.ForeColor = System.Drawing.Color.White;
            this.btnKullaniciSil.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciSil.Image")));
            this.btnKullaniciSil.Location = new System.Drawing.Point(12, 442);
            this.btnKullaniciSil.Name = "btnKullaniciSil";
            this.btnKullaniciSil.Size = new System.Drawing.Size(148, 38);
            this.btnKullaniciSil.TabIndex = 200;
            this.btnKullaniciSil.Text = "Seçili Kullanıcıyı Sil";
            this.btnKullaniciSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKullaniciSil.UseVisualStyleBackColor = false;
            this.btnKullaniciSil.Click += new System.EventHandler(this.btnKullaniciSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuncelle.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Arial", 9F);
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.Image")));
            this.btnGuncelle.Location = new System.Drawing.Point(409, 442);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(211, 38);
            this.btnGuncelle.TabIndex = 199;
            this.btnGuncelle.Text = "Seçili Kullanıcıyı Güncelle";
            this.btnGuncelle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // trvYetkiler
            // 
            this.trvYetkiler.CheckBoxes = true;
            this.trvYetkiler.Font = new System.Drawing.Font("Arial", 9F);
            this.trvYetkiler.Location = new System.Drawing.Point(151, 193);
            this.trvYetkiler.Name = "trvYetkiler";
            this.trvYetkiler.Size = new System.Drawing.Size(324, 202);
            this.trvYetkiler.TabIndex = 197;
            this.trvYetkiler.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvYetkiler_AfterCheck);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKullaniciAdi.Location = new System.Drawing.Point(151, 140);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(324, 21);
            this.txtKullaniciAdi.TabIndex = 195;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(96, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 203;
            this.label2.Text = "yetkiler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(112, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 202;
            this.label1.Text = "şifre";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label54.Location = new System.Drawing.Point(71, 142);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(74, 15);
            this.label54.TabIndex = 201;
            this.label54.Text = "kullanıcı adı";
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 495);
            this.Controls.Add(this.chkVarsayilan);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.btnKullaniciOlustur);
            this.Controls.Add(this.btnKullaniciSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.trvYetkiler);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.dataViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserManagement";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataViewer dataViewer1;
        private System.Windows.Forms.CheckBox chkVarsayilan;
        private System.Windows.Forms.MaskedTextBox txtSifre;
        private System.Windows.Forms.Button btnKullaniciOlustur;
        private System.Windows.Forms.Button btnKullaniciSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.TreeView trvYetkiler;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label54;
    }
}