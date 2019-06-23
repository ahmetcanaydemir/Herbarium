using Herbarium.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.Forms
{
    public partial class Barcode : Form
    {
        private string[] _barkodlar;
        public Barcode()
        {
            InitializeComponent();
        }

        public Barcode(string[] v)
        {
            InitializeComponent();
            _barkodlar = v;
            Array.Reverse(_barkodlar, 0, _barkodlar.Length);
            nmBarkodAdet.Value = _barkodlar.Length;
            nmBarkodAdet.Enabled = false;
        }

        private void Barcode_Load(object sender, EventArgs e)
        {
          //  if (!Sabit.Kullanici.YetkisiVarMi(Yetki.BarkodYazdir))
          //      this.Close();
            BarkodAyarlariniGetir();
        }

        private void BarkodAyarlariniGetir()
        {
            bA_ustKenarBosluk.Value = Settings.Default.UstKenarBosluk;
            bA_satirBosluk.Value = Settings.Default.SatirAraBosluk;
            bA_sutunBosluk.Value = Settings.Default.SutunAraBosluk;
            bA_sutunAdet.Value = Settings.Default.SutunAdet;
            bA_satirAdet.Value = Settings.Default.SatirAdet;
            bA_sayfaYukseklik.Value = Settings.Default.SayfaYukseklik;
            bA_sayfaGenislik.Value = Settings.Default.SayfaGenislik;
            bA_etiketGenislik.Value = Settings.Default.EtiketGenislik;
            bA_etiketYukseklik.Value = Settings.Default.EtiketYukseklik;
            bA_olcek.Value = Settings.Default.BarkodOlcek;
            bA_yazilanSonBarkod.Value = Settings.Default.SonBarkod;
        }
        private void BarkodAyarlariniKaydet()
        {
            Settings.Default.UstKenarBosluk = bA_ustKenarBosluk.Value;
            Settings.Default.SatirAraBosluk = bA_satirBosluk.Value;
            Settings.Default.SutunAraBosluk = bA_sutunBosluk.Value;
            Settings.Default.SutunAdet = bA_sutunAdet.Value;
            Settings.Default.SatirAdet = bA_satirAdet.Value;
            Settings.Default.SayfaYukseklik = bA_sayfaYukseklik.Value;
            Settings.Default.SayfaGenislik = bA_sayfaGenislik.Value;
            Settings.Default.EtiketGenislik = bA_etiketGenislik.Value;
            Settings.Default.EtiketYukseklik = bA_etiketYukseklik.Value;
            Settings.Default.BarkodOlcek = bA_olcek.Value;
            Settings.Default.SonBarkod = bA_yazilanSonBarkod.Value;
            Settings.Default.Save();
        }

        private void btnDegisiklikleriKaydet_Click(object sender, EventArgs e)
        {
            BarkodAyarlariniKaydet();
            ShowMessage.Success("Değişiklikler kayıt edildi");
        }
        int _sonBarkod; int _yazilan;

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            BarkodAyarlariniKaydet();
            _sonBarkod = Convert.ToInt32(Settings.Default.SonBarkod);
            _yazilan = 0;

            dialogYazdirmaOnizleme.Document = prntDoc;
            dialogYazdirmaOnizleme.PrintPreviewControl.Zoom = 1;
            dialogYazdirmaOnizleme.Width = 900;
            dialogYazdirmaOnizleme.Height = 700;

            ToolStripButton b = new ToolStripButton();
          //  b.Image = Properties.Resources.yazici;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += B_Click;
            ((ToolStrip)(dialogYazdirmaOnizleme.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(dialogYazdirmaOnizleme.Controls[1])).Items.Insert(0, b);
            dialogYazdirmaOnizleme.ShowDialog();
            BarkodAyarlariniGetir();
        }

        private void B_Click(object sender, EventArgs e)
        {
            try
            {
                _sonBarkod = Convert.ToInt32(Settings.Default.SonBarkod);
                _yazilan = 0;
                dialogYazdirma.Document = prntDoc;
                if (dialogYazdirma.ShowDialog() == DialogResult.OK)
                {
                    dialogYazdirma.Document.Print();
                    if (_barkodlar == null)
                    {
                        Settings.Default.SonBarkod = _sonBarkod;
                        Settings.Default.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }

        private void prntDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            Ean13 barcode = new Ean13();

            int adet = Convert.ToInt32(nmBarkodAdet.Value);
            int xx = (int)bA_SolKenarBosluk.Value;
            int yy = (int)bA_ustKenarBosluk.Value;
            int satir = 1;

            for (int i = 1; i <= bA_satirAdet.Value * bA_sutunAdet.Value; i++)
            {
                if (_yazilan >= adet || satir > bA_satirAdet.Value)
                    return;
                else
                {
                    _sonBarkod++;
                }

                barcode.ChecksumDigit = "0";
                if (_barkodlar == null || _barkodlar.Length == 0)
                {
                    barcode.CountryCode = "000";
                    barcode.ManufacturerCode = "0000";
                    barcode.ProductCode = _sonBarkod.ToString().PadLeft(5, '0');
                }
                else
                {
                    barcode.CountryCode = _barkodlar[i - 1].Substring(0, 3);
                    barcode.ManufacturerCode = _barkodlar[i - 1].Substring(3, 4);
                    barcode.ProductCode = _barkodlar[i - 1].Substring(7, 5);
                }

                barcode.Scale = (float)(bA_olcek.Value * 0.01m);
                barcode.Width = (float)bA_etiketGenislik.Value;
                barcode.Height = (float)bA_etiketYukseklik.Value;
                barcode.DrawEan13Barcode(e.Graphics, new PointF(xx, yy));
                xx += (int)bA_sutunBosluk.Value + (int)bA_etiketGenislik.Value;
                if (i % (int)bA_sutunAdet.Value == 0)
                {
                    xx = (int)bA_SolKenarBosluk.Value;
                    yy += (int)bA_etiketYukseklik.Value + (int)bA_satirBosluk.Value;
                    satir++;
                }
                _yazilan++;
            }
            e.HasMorePages = _yazilan < adet;
        }
    }
}
