namespace Herbarium.Forms
{
    partial class PlantForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantForm));
            this.pnlUst = new System.Windows.Forms.Panel();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblFamily = new System.Windows.Forms.Label();
            this.lblSpeciesName = new System.Windows.Forms.Label();
            this.lblGenus = new System.Windows.Forms.Label();
            this.pboxResim = new System.Windows.Forms.PictureBox();
            this.cMenuImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.değiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtKod = new System.Windows.Forms.TextBox();
            this.pnlBildirim = new System.Windows.Forms.Panel();
            this.lblDurum = new System.Windows.Forms.Label();
            this.btnKEKaydet = new System.Windows.Forms.Button();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.bilgiKutusu = new System.Windows.Forms.ToolTip(this.components);
            this.txtCoord = new Herbarium.CueTextBox();
            this.txtCollector = new Herbarium.CueTextBox();
            this.txtDiagnose = new Herbarium.CueTextBox();
            this.pboxHarita = new System.Windows.Forms.PictureBox();
            this.pnlAna = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.chkSwitch = new Herbarium.UserControls.CustomControls.CheckBoxSwitch();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLocalName = new Herbarium.CueTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtHabitat = new Herbarium.CueTextBox();
            this.cmbIlce = new Kutuphane.CueComboBox();
            this.cmbIl = new Kutuphane.CueComboBox();
            this.txtTypeExample = new Herbarium.CueTextBox();
            this.cmbSpecies = new Kutuphane.CueComboBox();
            this.cmbGenus = new Kutuphane.CueComboBox();
            this.cmbFamily = new Kutuphane.CueComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.rchDetails = new System.Windows.Forms.RichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.nmMaks = new System.Windows.Forms.NumericUpDown();
            this.nmMin = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.txtlocalite = new Herbarium.CueTextBox();
            this.txtGrids = new Herbarium.CueTextBox();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbYes = new System.Windows.Forms.RadioButton();
            this.txtVaryete = new Herbarium.CueTextBox();
            this.txtSubsp = new Herbarium.CueTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).BeginInit();
            this.cMenuImage.SuspendLayout();
            this.pnlBildirim.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHarita)).BeginInit();
            this.pnlAna.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMin)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlUst.Controls.Add(this.lblPhoto);
            this.pnlUst.Controls.Add(this.lblFamily);
            this.pnlUst.Controls.Add(this.lblSpeciesName);
            this.pnlUst.Controls.Add(this.lblGenus);
            this.pnlUst.Controls.Add(this.pboxResim);
            this.pnlUst.Controls.Add(this.txtKod);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(825, 116);
            this.pnlUst.TabIndex = 2;
            // 
            // lblPhoto
            // 
            this.lblPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPhoto.CausesValidation = false;
            this.lblPhoto.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Italic);
            this.lblPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.errorProvider.SetIconAlignment(this.lblPhoto, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.lblPhoto.Location = new System.Drawing.Point(12, 10);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(80, 80);
            this.lblPhoto.TabIndex = 142;
            this.lblPhoto.Text = "fotoğraf için tıklayın veya sürükleyip bırakın";
            this.lblPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPhoto.Click += new System.EventHandler(this.lblPhoto_Click);
            // 
            // lblFamily
            // 
            this.lblFamily.AutoEllipsis = true;
            this.lblFamily.AutoSize = true;
            this.lblFamily.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFamily.ForeColor = System.Drawing.Color.Black;
            this.lblFamily.Location = new System.Drawing.Point(113, 10);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(0, 15);
            this.lblFamily.TabIndex = 109;
            this.lblFamily.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpeciesName
            // 
            this.lblSpeciesName.AutoEllipsis = true;
            this.lblSpeciesName.AutoSize = true;
            this.lblSpeciesName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSpeciesName.ForeColor = System.Drawing.Color.Black;
            this.lblSpeciesName.Location = new System.Drawing.Point(113, 54);
            this.lblSpeciesName.Name = "lblSpeciesName";
            this.lblSpeciesName.Size = new System.Drawing.Size(94, 25);
            this.lblSpeciesName.TabIndex = 108;
            this.lblSpeciesName.Text = "Yeni Bitki";
            this.lblSpeciesName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGenus
            // 
            this.lblGenus.AutoEllipsis = true;
            this.lblGenus.AutoSize = true;
            this.lblGenus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGenus.ForeColor = System.Drawing.Color.Black;
            this.lblGenus.Location = new System.Drawing.Point(113, 32);
            this.lblGenus.Name = "lblGenus";
            this.lblGenus.Size = new System.Drawing.Size(0, 15);
            this.lblGenus.TabIndex = 110;
            this.lblGenus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pboxResim
            // 
            this.pboxResim.BackColor = System.Drawing.Color.Transparent;
            this.pboxResim.ContextMenuStrip = this.cMenuImage;
            this.pboxResim.Image = global::Herbarium.Properties.Resources.SearchToolBar_ButtonClose;
            this.pboxResim.Location = new System.Drawing.Point(12, 10);
            this.pboxResim.Name = "pboxResim";
            this.pboxResim.Size = new System.Drawing.Size(80, 80);
            this.pboxResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxResim.TabIndex = 81;
            this.pboxResim.TabStop = false;
            this.bilgiKutusu.SetToolTip(this.pboxResim, "Resmi görüntülemek için çift tıklayın");
            this.pboxResim.DoubleClick += new System.EventHandler(this.pboxResim_DoubleClick);
            // 
            // cMenuImage
            // 
            this.cMenuImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.değiştirToolStripMenuItem,
            this.silToolStripMenuItem});
            this.cMenuImage.Name = "cMenuImage";
            this.cMenuImage.Size = new System.Drawing.Size(115, 48);
            // 
            // değiştirToolStripMenuItem
            // 
            this.değiştirToolStripMenuItem.Name = "değiştirToolStripMenuItem";
            this.değiştirToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.değiştirToolStripMenuItem.Text = "Değiştir";
            this.değiştirToolStripMenuItem.Click += new System.EventHandler(this.değiştirToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // txtKod
            // 
            this.txtKod.BackColor = System.Drawing.SystemColors.Control;
            this.txtKod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKod.Enabled = false;
            this.txtKod.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtKod.ForeColor = System.Drawing.Color.Navy;
            this.txtKod.Location = new System.Drawing.Point(118, 86);
            this.txtKod.MaxLength = 50;
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(695, 26);
            this.txtKod.TabIndex = 1;
            this.txtKod.Text = "0000000";
            this.bilgiKutusu.SetToolTip(this.txtKod, "Var olmayan bir kod ile değiştirebilirsiniz");
            this.txtKod.TextChanged += new System.EventHandler(this.txtKod_TextChanged);
            // 
            // pnlBildirim
            // 
            this.pnlBildirim.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlBildirim.Controls.Add(this.lblDurum);
            this.pnlBildirim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBildirim.Location = new System.Drawing.Point(0, 41);
            this.pnlBildirim.Name = "pnlBildirim";
            this.pnlBildirim.Size = new System.Drawing.Size(825, 24);
            this.pnlBildirim.TabIndex = 84;
            this.pnlBildirim.Visible = false;
            // 
            // lblDurum
            // 
            this.lblDurum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurum.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lblDurum.Location = new System.Drawing.Point(0, 0);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(825, 24);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKEKaydet
            // 
            this.btnKEKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKEKaydet.FlatAppearance.BorderSize = 0;
            this.btnKEKaydet.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnKEKaydet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKEKaydet.Location = new System.Drawing.Point(671, 6);
            this.btnKEKaydet.Name = "btnKEKaydet";
            this.btnKEKaydet.Size = new System.Drawing.Size(131, 31);
            this.btnKEKaydet.TabIndex = 0;
            this.btnKEKaydet.Text = " Bitki Ekle";
            this.btnKEKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKEKaydet.UseVisualStyleBackColor = true;
            this.btnKEKaydet.Click += new System.EventHandler(this.btnKEKaydet_Click);
            // 
            // pnlAlt
            // 
            this.pnlAlt.Controls.Add(this.pnlBildirim);
            this.pnlAlt.Controls.Add(this.btnKEKaydet);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 816);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(825, 65);
            this.pnlAlt.TabIndex = 116;
            // 
            // txtCoord
            // 
            this.txtCoord.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCoord.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCoord.CueText = "Sayısal veya dereceli olarak koordinat bilgisi girin";
            this.txtCoord.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCoord.Location = new System.Drawing.Point(193, 503);
            this.txtCoord.Name = "txtCoord";
            this.txtCoord.Size = new System.Drawing.Size(412, 27);
            this.txtCoord.TabIndex = 18;
            this.txtCoord.Validating += new System.ComponentModel.CancelEventHandler(this.txtCoord_Validating);
            // 
            // txtCollector
            // 
            this.txtCollector.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCollector.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCollector.CueText = null;
            this.txtCollector.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCollector.Location = new System.Drawing.Point(195, 541);
            this.txtCollector.Name = "txtCollector";
            this.txtCollector.Size = new System.Drawing.Size(412, 27);
            this.txtCollector.TabIndex = 20;
            this.bilgiKutusu.SetToolTip(this.txtCollector, "Aşağıdaki tiplerde giriş yapabilirsiniz:\r\n21° 16\' 674S, 27° 30\' 318E\r\n21 16 674S," +
        " 27 30 318E\r\n9.182, -39.140625\r\n9.182 / -39.140625\r\n9.182,-39.140625\r\n9.182 -39." +
        "140625");
            // 
            // txtDiagnose
            // 
            this.txtDiagnose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDiagnose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDiagnose.CueText = null;
            this.txtDiagnose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDiagnose.Location = new System.Drawing.Point(195, 571);
            this.txtDiagnose.Name = "txtDiagnose";
            this.txtDiagnose.Size = new System.Drawing.Size(412, 27);
            this.txtDiagnose.TabIndex = 21;
            this.bilgiKutusu.SetToolTip(this.txtDiagnose, "Aşağıdaki tiplerde giriş yapabilirsiniz:\r\n21° 16\' 674S, 27° 30\' 318E\r\n21 16 674S," +
        " 27 30 318E\r\n9.182, -39.140625\r\n9.182 / -39.140625\r\n9.182,-39.140625\r\n9.182 -39." +
        "140625");
            // 
            // pboxHarita
            // 
            this.pboxHarita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxHarita.Image = ((System.Drawing.Image)(resources.GetObject("pboxHarita.Image")));
            this.pboxHarita.Location = new System.Drawing.Point(578, 504);
            this.pboxHarita.Name = "pboxHarita";
            this.pboxHarita.Size = new System.Drawing.Size(24, 24);
            this.pboxHarita.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboxHarita.TabIndex = 263;
            this.pboxHarita.TabStop = false;
            this.bilgiKutusu.SetToolTip(this.pboxHarita, "Haritada göster");
            this.pboxHarita.Click += new System.EventHandler(this.pboxHarita_Click);
            // 
            // pnlAna
            // 
            this.pnlAna.Controls.Add(this.tabControl1);
            this.pnlAna.Controls.Add(this.panel1);
            this.pnlAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAna.Location = new System.Drawing.Point(0, 116);
            this.pnlAna.Name = "pnlAna";
            this.pnlAna.Size = new System.Drawing.Size(825, 700);
            this.pnlAna.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(825, 656);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panelContainer);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 647);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.pboxHarita);
            this.panelContainer.Controls.Add(this.label28);
            this.panelContainer.Controls.Add(this.label27);
            this.panelContainer.Controls.Add(this.chkSwitch);
            this.panelContainer.Controls.Add(this.txtCoord);
            this.panelContainer.Controls.Add(this.label14);
            this.panelContainer.Controls.Add(this.txtLocalName);
            this.panelContainer.Controls.Add(this.label4);
            this.panelContainer.Controls.Add(this.button2);
            this.panelContainer.Controls.Add(this.txtHabitat);
            this.panelContainer.Controls.Add(this.cmbIlce);
            this.panelContainer.Controls.Add(this.cmbIl);
            this.panelContainer.Controls.Add(this.txtTypeExample);
            this.panelContainer.Controls.Add(this.cmbSpecies);
            this.panelContainer.Controls.Add(this.cmbGenus);
            this.panelContainer.Controls.Add(this.cmbFamily);
            this.panelContainer.Controls.Add(this.label26);
            this.panelContainer.Controls.Add(this.txtCollector);
            this.panelContainer.Controls.Add(this.label25);
            this.panelContainer.Controls.Add(this.label24);
            this.panelContainer.Controls.Add(this.rchDetails);
            this.panelContainer.Controls.Add(this.label23);
            this.panelContainer.Controls.Add(this.txtDiagnose);
            this.panelContainer.Controls.Add(this.label16);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.label22);
            this.panelContainer.Controls.Add(this.nmMaks);
            this.panelContainer.Controls.Add(this.nmMin);
            this.panelContainer.Controls.Add(this.label17);
            this.panelContainer.Controls.Add(this.label18);
            this.panelContainer.Controls.Add(this.dtPicker);
            this.panelContainer.Controls.Add(this.txtlocalite);
            this.panelContainer.Controls.Add(this.txtGrids);
            this.panelContainer.Controls.Add(this.rdbNo);
            this.panelContainer.Controls.Add(this.rdbYes);
            this.panelContainer.Controls.Add(this.txtVaryete);
            this.panelContainer.Controls.Add(this.txtSubsp);
            this.panelContainer.Controls.Add(this.label15);
            this.panelContainer.Controls.Add(this.label13);
            this.panelContainer.Controls.Add(this.label12);
            this.panelContainer.Controls.Add(this.label11);
            this.panelContainer.Controls.Add(this.label10);
            this.panelContainer.Controls.Add(this.label9);
            this.panelContainer.Controls.Add(this.label8);
            this.panelContainer.Controls.Add(this.label6);
            this.panelContainer.Controls.Add(this.label7);
            this.panelContainer.Controls.Add(this.label5);
            this.panelContainer.Controls.Add(this.label1);
            this.panelContainer.Location = new System.Drawing.Point(29, 1);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(769, 656);
            this.panelContainer.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label28.Location = new System.Drawing.Point(722, 508);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 262;
            this.label28.Text = "derece";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label28.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label27.Location = new System.Drawing.Point(631, 508);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(38, 13);
            this.label27.TabIndex = 259;
            this.label27.Text = "sayısal";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label27.Visible = false;
            // 
            // chkSwitch
            // 
            this.chkSwitch.Enabled = false;
            this.chkSwitch.Location = new System.Drawing.Point(674, 503);
            this.chkSwitch.Name = "chkSwitch";
            this.chkSwitch.Padding = new System.Windows.Forms.Padding(6);
            this.chkSwitch.Size = new System.Drawing.Size(42, 24);
            this.chkSwitch.TabIndex = 19;
            this.chkSwitch.Text = "checkBoxSwitch1";
            this.chkSwitch.UseVisualStyleBackColor = true;
            this.chkSwitch.Visible = false;
            this.chkSwitch.CheckedChanged += new System.EventHandler(this.chkSwitch_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label14.Location = new System.Drawing.Point(125, 505);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 21);
            this.label14.TabIndex = 260;
            this.label14.Text = "Konum";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocalName
            // 
            this.txtLocalName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLocalName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLocalName.CueText = null;
            this.txtLocalName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLocalName.Location = new System.Drawing.Point(195, 177);
            this.txtLocalName.Name = "txtLocalName";
            this.txtLocalName.Size = new System.Drawing.Size(412, 27);
            this.txtLocalName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(102, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 257;
            this.label4.Text = "Türkçe Adı";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(623, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 10;
            this.button2.Text = "SEÇ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtHabitat
            // 
            this.txtHabitat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtHabitat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHabitat.CueText = null;
            this.txtHabitat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtHabitat.Location = new System.Drawing.Point(195, 404);
            this.txtHabitat.Name = "txtHabitat";
            this.txtHabitat.Size = new System.Drawing.Size(412, 27);
            this.txtHabitat.TabIndex = 14;
            this.txtHabitat.TextChanged += new System.EventHandler(this.txtHabitat_TextChanged);
            // 
            // cmbIlce
            // 
            this.cmbIlce.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIlce.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIlce.CueText = null;
            this.cmbIlce.Enabled = false;
            this.cmbIlce.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbIlce.FormattingEnabled = true;
            this.cmbIlce.Location = new System.Drawing.Point(195, 344);
            this.cmbIlce.Name = "cmbIlce";
            this.cmbIlce.Size = new System.Drawing.Size(412, 28);
            this.cmbIlce.TabIndex = 12;
            // 
            // cmbIl
            // 
            this.cmbIl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIl.CueText = null;
            this.cmbIl.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbIl.FormattingEnabled = true;
            this.cmbIl.Location = new System.Drawing.Point(195, 314);
            this.cmbIl.Name = "cmbIl";
            this.cmbIl.Size = new System.Drawing.Size(412, 28);
            this.cmbIl.TabIndex = 11;
            this.cmbIl.SelectedIndexChanged += new System.EventHandler(this.cmbIl_SelectedIndexChanged);
            // 
            // txtTypeExample
            // 
            this.txtTypeExample.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTypeExample.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTypeExample.CueText = null;
            this.txtTypeExample.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTypeExample.Location = new System.Drawing.Point(195, 210);
            this.txtTypeExample.Name = "txtTypeExample";
            this.txtTypeExample.Size = new System.Drawing.Size(412, 27);
            this.txtTypeExample.TabIndex = 6;
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSpecies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSpecies.CueText = null;
            this.cmbSpecies.Enabled = false;
            this.cmbSpecies.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpecies.FormattingEnabled = true;
            this.cmbSpecies.Location = new System.Drawing.Point(195, 70);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(412, 28);
            this.cmbSpecies.TabIndex = 2;
            this.cmbSpecies.SelectedIndexChanged += new System.EventHandler(this.cmbSpecies_Leave);
            this.cmbSpecies.Leave += new System.EventHandler(this.cmbSpecies_Leave);
            // 
            // cmbGenus
            // 
            this.cmbGenus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGenus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGenus.CueText = null;
            this.cmbGenus.Enabled = false;
            this.cmbGenus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGenus.FormattingEnabled = true;
            this.cmbGenus.Location = new System.Drawing.Point(195, 39);
            this.cmbGenus.Name = "cmbGenus";
            this.cmbGenus.Size = new System.Drawing.Size(412, 28);
            this.cmbGenus.TabIndex = 1;
            this.cmbGenus.SelectedIndexChanged += new System.EventHandler(this.cmbGenus_Leave);
            this.cmbGenus.Leave += new System.EventHandler(this.cmbGenus_Leave);
            // 
            // cmbFamily
            // 
            this.cmbFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFamily.CueText = null;
            this.cmbFamily.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFamily.FormattingEnabled = true;
            this.cmbFamily.Location = new System.Drawing.Point(195, 9);
            this.cmbFamily.Name = "cmbFamily";
            this.cmbFamily.Size = new System.Drawing.Size(412, 28);
            this.cmbFamily.TabIndex = 0;
            this.cmbFamily.SelectedIndexChanged += new System.EventHandler(this.cmbFamily_Leave);
            this.cmbFamily.Leave += new System.EventHandler(this.cmbFamily_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label26.Location = new System.Drawing.Point(537, 442);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 13);
            this.label26.TabIndex = 245;
            this.label26.Text = "m ";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label25.Location = new System.Drawing.Point(2, 543);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(190, 21);
            this.label25.TabIndex = 243;
            this.label25.Text = "Toplayıcı / Toplayıcı No";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label24.Location = new System.Drawing.Point(172, 316);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 21);
            this.label24.TabIndex = 242;
            this.label24.Text = "İl";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rchDetails
            // 
            this.rchDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rchDetails.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rchDetails.Location = new System.Drawing.Point(193, 601);
            this.rchDetails.Name = "rchDetails";
            this.rchDetails.Size = new System.Drawing.Size(414, 46);
            this.rchDetails.TabIndex = 22;
            this.rchDetails.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label23.Location = new System.Drawing.Point(111, 603);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 21);
            this.label23.TabIndex = 241;
            this.label23.Text = "Açıklama";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label16.Location = new System.Drawing.Point(94, 573);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 21);
            this.label16.TabIndex = 239;
            this.label16.Text = "Teşhis Eden";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(150, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 238;
            this.label3.Text = "Cins";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label22.Location = new System.Drawing.Point(122, 12);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 21);
            this.label22.TabIndex = 236;
            this.label22.Text = "Familya";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmMaks
            // 
            this.nmMaks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nmMaks.Location = new System.Drawing.Point(431, 437);
            this.nmMaks.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmMaks.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nmMaks.Name = "nmMaks";
            this.nmMaks.Size = new System.Drawing.Size(100, 27);
            this.nmMaks.TabIndex = 16;
            // 
            // nmMin
            // 
            this.nmMin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nmMin.Location = new System.Drawing.Point(248, 437);
            this.nmMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmMin.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nmMin.Name = "nmMin";
            this.nmMin.Size = new System.Drawing.Size(100, 27);
            this.nmMin.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label17.Location = new System.Drawing.Point(350, 442);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 233;
            this.label17.Text = "m -  maksimum:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label18.Location = new System.Drawing.Point(193, 442);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 232;
            this.label18.Text = "minimum:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtPicker
            // 
            this.dtPicker.CustomFormat = "dd.MM.yyyy";
            this.dtPicker.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(193, 470);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(412, 27);
            this.dtPicker.TabIndex = 17;
            // 
            // txtlocalite
            // 
            this.txtlocalite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtlocalite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtlocalite.CueText = null;
            this.txtlocalite.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtlocalite.Location = new System.Drawing.Point(195, 374);
            this.txtlocalite.Name = "txtlocalite";
            this.txtlocalite.Size = new System.Drawing.Size(412, 27);
            this.txtlocalite.TabIndex = 13;
            // 
            // txtGrids
            // 
            this.txtGrids.CueText = "Boşluk bırakmadan virgül ile ayırarak girin veya haritadan seçin";
            this.txtGrids.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGrids.Location = new System.Drawing.Point(195, 284);
            this.txtGrids.Name = "txtGrids";
            this.txtGrids.Size = new System.Drawing.Size(412, 27);
            this.txtGrids.TabIndex = 9;
            this.txtGrids.Validating += new System.ComponentModel.CancelEventHandler(this.txtGrids_Validating);
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Checked = true;
            this.rdbNo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rdbNo.Location = new System.Drawing.Point(195, 242);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(62, 24);
            this.rdbNo.TabIndex = 7;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "Hayır";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // rdbYes
            // 
            this.rdbYes.AutoSize = true;
            this.rdbYes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rdbYes.Location = new System.Drawing.Point(263, 242);
            this.rdbYes.Name = "rdbYes";
            this.rdbYes.Size = new System.Drawing.Size(55, 24);
            this.rdbYes.TabIndex = 8;
            this.rdbYes.TabStop = true;
            this.rdbYes.Text = "Evet";
            this.rdbYes.UseVisualStyleBackColor = true;
            // 
            // txtVaryete
            // 
            this.txtVaryete.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtVaryete.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtVaryete.CueText = null;
            this.txtVaryete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtVaryete.Location = new System.Drawing.Point(195, 144);
            this.txtVaryete.Name = "txtVaryete";
            this.txtVaryete.Size = new System.Drawing.Size(412, 27);
            this.txtVaryete.TabIndex = 4;
            this.txtVaryete.TextChanged += new System.EventHandler(this.txtVaryete_TextChanged);
            // 
            // txtSubsp
            // 
            this.txtSubsp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSubsp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSubsp.CueText = null;
            this.txtSubsp.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSubsp.Location = new System.Drawing.Point(195, 114);
            this.txtSubsp.Name = "txtSubsp";
            this.txtSubsp.Size = new System.Drawing.Size(412, 27);
            this.txtSubsp.TabIndex = 3;
            this.txtSubsp.TextChanged += new System.EventHandler(this.txtSubsp_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label15.Location = new System.Drawing.Point(115, 241);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 21);
            this.label15.TabIndex = 231;
            this.label15.Text = "Endemik";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label13.Location = new System.Drawing.Point(142, 474);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 21);
            this.label13.TabIndex = 229;
            this.label13.Text = "Tarih";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label12.Location = new System.Drawing.Point(109, 438);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 21);
            this.label12.TabIndex = 228;
            this.label12.Text = "Yükseklik";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label11.Location = new System.Drawing.Point(125, 406);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 21);
            this.label11.TabIndex = 227;
            this.label11.Text = "Habitat";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label10.Location = new System.Drawing.Point(121, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 21);
            this.label10.TabIndex = 226;
            this.label10.Text = "Lokalite";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label9.Location = new System.Drawing.Point(123, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 21);
            this.label9.TabIndex = 225;
            this.label9.Text = "Varyete";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label8.Location = new System.Drawing.Point(155, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 21);
            this.label8.TabIndex = 224;
            this.label8.Text = "İlçe";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(148, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 21);
            this.label6.TabIndex = 222;
            this.label6.Text = "Kare";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label7.Location = new System.Drawing.Point(102, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 221;
            this.label7.Text = "Tip Örneği";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label5.Location = new System.Drawing.Point(132, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 21);
            this.label5.TabIndex = 220;
            this.label5.Text = "Alt Tür";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(158, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 21);
            this.label1.TabIndex = 218;
            this.label1.Text = "Tür";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 44);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(338, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(149, 27);
            this.panel2.TabIndex = 0;
            this.panel2.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(71, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "İşlemler";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Düzen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PlantForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 881);
            this.Controls.Add(this.pnlAna);
            this.Controls.Add(this.pnlUst);
            this.Controls.Add(this.pnlAlt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitki Düzenle";
            this.Load += new System.EventHandler(this.PlantForm_Load);
            this.SizeChanged += new System.EventHandler(this.PlantForm_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PlantForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PlantForm_DragEnter);
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxResim)).EndInit();
            this.cMenuImage.ResumeLayout(false);
            this.pnlBildirim.ResumeLayout(false);
            this.pnlAlt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxHarita)).EndInit();
            this.pnlAna.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.Label lblSpeciesName;
        private System.Windows.Forms.Label lblGenus;
        private System.Windows.Forms.PictureBox pboxResim;
        private System.Windows.Forms.ToolTip bilgiKutusu;
        private System.Windows.Forms.Panel pnlBildirim;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Button btnKEKaydet;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel pnlAna;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip cMenuImage;
        private System.Windows.Forms.ToolStripMenuItem değiştirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button button2;
        private CueTextBox txtHabitat;
        private Kutuphane.CueComboBox cmbIlce;
        private Kutuphane.CueComboBox cmbIl;
        private CueTextBox txtTypeExample;
        private Kutuphane.CueComboBox cmbSpecies;
        private Kutuphane.CueComboBox cmbGenus;
        private Kutuphane.CueComboBox cmbFamily;
        private System.Windows.Forms.Label label26;
        private CueTextBox txtCollector;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RichTextBox rchDetails;
        private System.Windows.Forms.Label label23;
        private CueTextBox txtDiagnose;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nmMaks;
        private System.Windows.Forms.NumericUpDown nmMin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private CueTextBox txtlocalite;
        private CueTextBox txtGrids;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbYes;
        private CueTextBox txtVaryete;
        private CueTextBox txtSubsp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private UserControls.CustomControls.CheckBoxSwitch chkSwitch;
        private CueTextBox txtCoord;
        private System.Windows.Forms.Label label14;
        private CueTextBox txtLocalName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtKod;
        private System.Windows.Forms.PictureBox pboxHarita;
    }
}