using Herbarium.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.Class
{
    class Searching
    {
        private SearchToolbar AramaKutusu;
        private System.Windows.Forms.Timer timer;
        private DataViewer VeriTablosu;
        private DateTime SonTusaBasmaZamani;
        private List<char> Barkod;
        public Dictionary<int, bool> Bulunanlar;
        public string BarkodYazisi;




        public Searching(DataViewer tablo)
        {
            this.AramaKutusu = new SearchToolbar();
            VeriTablosu = tablo;

            AramaKutusu.textBox_search.TextChanged += TextBoxSearch_TextChanged;
            AramaKutusu.Search += AramaKutusu_Search;

            TimerAyarla();
        }

        public Searching()
        {
            SonTusaBasmaZamani = new DateTime(0);
            Barkod = new List<char>(30);
        }

        public void Tusa_Tiklama(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //BarkodYazisi = string.Empty;
            //if (!Settings.Default.BarkodAramasi) return;

            //Bulunanlar = new Dictionary<int, bool>();
            //TimeSpan elapsed = (DateTime.Now - SonTusaBasmaZamani);
            //if (elapsed.TotalMilliseconds > (int)Settings.Default.BarkodMiliSaniye)
            //    Barkod.Clear();

            //Barkod.Add(e.KeyChar);
            //SonTusaBasmaZamani = DateTime.Now;

            //if (Barkod.Count < 10) return;
            //for (int i = Barkod.Count - 1; i >= 0; i--)
            //{
            //    if (!int.TryParse(Barkod[i].ToString(), out int _))
            //        Barkod.RemoveAt(i);
            //}

            ////string msg = new String(Barkod.ToArray()).Trim();
            //////msg = "0000001";
            ////if (msg.Length < (int)Settings.Default.BarkodMinimumKarakter) return;
            ////BarkodYazisi = msg;


            ////Veritabani.ParametreEkle("@barkod", msg);
            ////DataTable dt = Veritabani.DtVeriCek("SELECT id,kitapDurum FROM kitaplar WHERE barkod=@barkod");

            ////foreach (DataRow satir in dt.Rows)
            ////{
            ////    Bulunanlar.Add(Convert.ToInt32(satir["id"]), satir["kitapDurum"].ToString() == "2");
            ////}

            //Barkod.Clear();
        }


        private void TimerAyarla()
        {
            timer = new System.Windows.Forms.Timer()
            {
                Interval = 350,
                Enabled = true
            };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            TimerArama();
        }

        private void TimerArama()
        {
            if (VeriTablosu.dtgDataView.DataSource == null) return;
            if (AramaKutusu?.textBox_search?.Text is null || string.IsNullOrEmpty(AramaKutusu?.textBox_search?.Text))
            {
                //  VeriTablosu.FiltreTemizle();
                AramaKutusu.button_search_Click(this, AramaToolBarSearchEventArgs.Empty);
               // if (!string.IsNullOrEmpty(VeriTablosu.Table.DefaultView.RowFilter))
                 //   VeriTablosu.Table.DefaultView.RowFilter = null;
            }
            //else if (Properties.Settings.Default.AramaEnterOlmadan)
            //{
            else    AramaKutusu.button_search_Click(this, AramaToolBarSearchEventArgs.Empty);
            //}
        }

        private void AramaKutusu_Search(object sender, AramaToolBarSearchEventArgs e)
        {
            //    VeriTablosu.FiltreTemizle();

            AramaKutusu.textBox_search.BackColor = System.Drawing.Color.Yellow;
            if (e.ValueToSearch == string.Empty)
            {
                VeriTablosu.Table.DefaultView.RowFilter = null;
                AramaKutusu.textBox_search.BackColor = System.Drawing.Color.White;
                return;
            }

            var filtre = new StringBuilder();

            var aramaMetni = e.ValueToSearch.Replace("'", "''");

            VeriTablosu.Table.CaseSensitive = e.CaseSensitive;

            if (e.ColumnToSearch == string.Empty)
            {
                foreach (DataGridViewColumn sutun in VeriTablosu.dtgDataView.Columns)
                {
                    if (sutun.Visible)
                        filtre.Append(FiltreStringi(aramaMetni, sutun.HeaderText, e.WholeWord));
                }
            }
            else
            {
                filtre.Append(FiltreStringi(aramaMetni, e.ColumnToSearch, e.WholeWord));
            }

            VeriTablosu.Table.DefaultView.RowFilter = filtre.ToString().Substring(0, filtre.Length - 4);
            //if (Properties.Settings.Default.AramaMetniSec && !Properties.Settings.Default.AramaEnterOlmadan)
            //{
            //    AramaKutusu.textBox_search.Select(0, AramaKutusu.textBox_search.Text.Length);
            //    AramaKutusu.Focus();
            //}
        }

        private string FiltreStringi(string aramaMetni, string sutunBasligi, bool tamKelimeMi)
        {
            if (sutunBasligi == "Seçim") return string.Empty;
            string filtre = string.Empty;
            filtre += $"CONVERT([{sutunBasligi}], System.String) Like '%{aramaMetni}%'";
            if (tamKelimeMi)
                filtre += $" OR CONVERT([{sutunBasligi}], System.String) Like '%{aramaMetni}' OR CONVERT([{sutunBasligi}], System.String) Like '{aramaMetni}%' OR CONVERT([{sutunBasligi}], System.String) Like '{aramaMetni}'";
            filtre += " OR ";
            return filtre;
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
              timer.Start();
        }

        public SearchToolbar getAramaKutusu()
        {
            return AramaKutusu;
        }
    }
}
