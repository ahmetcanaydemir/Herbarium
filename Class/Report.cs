using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.Class
{
    class Report
    {
        private PrintPreviewDialog _printPreview = new PrintPreviewDialog();
        private PrintDialog _printDialog = new PrintDialog();
        private PrintDocument _printDocument = new PrintDocument();
        private DataGridView dtg;
        private bool selectedOnly = false;

        
        public Report(DataGridView gelenDtg,bool selectedOnly)
        {
            this.selectedOnly = selectedOnly;
            dtg = DataGridViewKopyala(gelenDtg);

            List<DataGridViewColumn> silinecekSutunlar = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn sutun in dtg.Columns)
            {
                if (!sutun.Visible) silinecekSutunlar.Add(sutun);
            }
            foreach (DataGridViewColumn sutun in silinecekSutunlar)
            {
                dtg.Columns.Remove(sutun);
            }


        }
        private DataGridView DataGridViewKopyala(DataGridView kopyalanacakDtg)
        {
            DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in kopyalanacakDtg.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();


                foreach (DataGridViewRow satir in kopyalanacakDtg.Rows)
                {
                    if (selectedOnly && !satir.Selected) continue;
                    row = (DataGridViewRow)satir.Clone();
                    foreach (DataGridViewColumn sutun in kopyalanacakDtg.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
                    {
                        row.Cells[sutun.DisplayIndex].Value = satir.Cells[sutun.HeaderText].Value;
                    }
                    dgv_copy.Rows.Add(row);
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();

            }
            catch (Exception ex)
            {
                ShowMessage.Error("Veri tablosu kopyalanamadı.\n" + ex.Message);
            }
            return dgv_copy;
        }
        public DataTable DataTableOlustur(DataGridView dgv)
        {
            var dt = new DataTable();
            int visibleColumnCount = 0;
            foreach (DataGridViewColumn column in dgv.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
            {
                if (column.Visible)
                {
                    dt.Columns.Add(column.HeaderText);
                    visibleColumnCount++;
                }
            }

            object[] cellValues = new object[visibleColumnCount];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                int sayac = 0;
                foreach (DataGridViewColumn sutun in dtg.Columns.OfType<DataGridViewColumn>()
                    .OrderBy(x => x.DisplayIndex))
                {
                    cellValues[sayac] = row.Cells[sutun.Index].Value.ToString();
                    sayac++;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
        public void Yazdir()
        {
            _printDocument.PrintPage += _printDocument_PrintPage;
            _printDocument.BeginPrint += _printDocument_BeginPrint;
            _printPreview.Document = _printDocument;
            _printPreview.ShowDialog();
        }

        public void ExceleCikar()
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Dosyaları (*.xls)|*.xls",
                    DefaultExt = "xls",
                    RestoreDirectory = true,
                    Title = "Excele aktar",
                    FileName = "Rapor-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss"),

                    AddExtension = true
                };
                DialogResult dialogSonucu = saveFileDialog.ShowDialog();
                IWorkbook calismaKitabi = new HSSFWorkbook();
                ISheet sayfa = calismaKitabi.CreateSheet();
                IRow baslikSatiri = sayfa.CreateRow(0);


                var font = calismaKitabi.CreateFont();
                font.FontHeightInPoints = 11;
                font.FontName = "Calibri";
                font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

                foreach (DataGridViewColumn sutun in dtg.Columns)
                {
                    var baslikHucresi = baslikSatiri.CreateCell(sutun.DisplayIndex);
                    baslikHucresi.SetCellValue(sutun.HeaderText);
                    baslikHucresi.CellStyle = calismaKitabi.CreateCellStyle();
                    baslikHucresi.CellStyle.SetFont(font);
                }
                int satirSayaci = 1;
                foreach (DataGridViewRow satir in dtg.Rows)
                {
                    IRow veriSatiri = sayfa.CreateRow(satirSayaci);
                    foreach (DataGridViewColumn sutun in dtg.Columns)
                    {
                        veriSatiri.CreateCell(sutun.DisplayIndex).SetCellValue(satir.Cells[sutun.Index].Value.ToString());
                    }
                    satirSayaci++;
                }
                for (int i = 0; i <= sayfa.GetRow(0).LastCellNum; i++)
                {
                    sayfa.AutoSizeColumn(i);
                    GC.Collect();
                }


                calismaKitabi.Write(ms);
                ms.Flush();
                ms.Position = 0;



                if (dialogSonucu == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    ms.WriteTo(fs);
                    fs.Close();
                    ms.Close();
                }
            }
            catch (Exception ex)
            {
                ShowMessage.Error("HATA: " + ex.Message);
            }
        }

        public void XmlDosyasi()
        {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML Dosyası|*.xml";

            dialog.FileName = "Rapor-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            DataTable dT = DataTableOlustur(dtg);
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);
            dS.WriteXml(File.OpenWrite(dialog.FileName));

        }

        public void HtmlDosyasi()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Html Dosyası|*.html";
            dialog.FileName = "Rapor-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            DataTable dt = DataTableOlustur(dtg);
            StringBuilder builder = new StringBuilder();
            builder.Append("<table border=1>");
            //add header row
            builder.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
                builder.Append("<td><b>" + dt.Columns[i].ColumnName + "</b></td>");
            builder.Append("</tr>");
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                builder.Append("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                    builder.Append("<td>" + dt.Rows[i][j] + "</td>");
                builder.Append("</tr>");
            }
            builder.Append("</table>");

            System.IO.File.WriteAllText(dialog.FileName, builder.ToString(), Encoding.UTF8);
        }

        public void CsvDosyasi()
        {
            string json = JsonConvert.SerializeObject(DataTableOlustur(dtg), Formatting.Indented);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Csv Dosyası|*.csv";
            dialog.FileName = "Rapor-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            StringBuilder sb = new StringBuilder();
            DataTable dt = DataTableOlustur(dtg);

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                    string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(dialog.FileName, sb.ToString(), Encoding.UTF8);
        }
        public void JsonDosyasi()
        {
            string json = JsonConvert.SerializeObject(DataTableOlustur(dtg), Formatting.Indented);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Json Dosyası|*.json";
            dialog.FileName = "Rapor-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            System.IO.File.WriteAllText(dialog.FileName, json);
        }
       
        public void TxtDosyasi()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Metin Dosyası|*.txt";
            dialog.FileName = "Rapor-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            StringBuilder builder = new StringBuilder();
            int rowcount = dtg.Rows.Count;
            int columncount = dtg.Columns.Count;
            List<string> headerCols = new List<string>();
            for (int j = 0; j < columncount - 1; j++)
            {
                headerCols.Add(dtg.Columns[j].HeaderText);
            }
            builder.AppendLine(string.Join("\t", headerCols));
            for (int i = 0; i < rowcount - 1; i++)
            {
                List<string> cols = new List<string>();
                for (int j = 0; j < columncount - 1; j++)
                {
                    cols.Add(dtg.Rows[i].Cells[j].Value.ToString());
                }
                builder.AppendLine(string.Join("\t", cols.ToArray()));
            }
            System.IO.File.WriteAllText(dialog.FileName, builder.ToString(), Encoding.UTF8);
        }
        #region Yazdir
        #region Yazdir Degiskenleri
        private int _indexC = 0;
        private string _kadi = "test";
        private string _kurumAdi;
        private string _sorumluAdi;

        private StringFormat _yaziFormati;
        private ArrayList _solSutunKonumlari = new ArrayList();
        private ArrayList _sutunGenislikleri = new ArrayList();
        private int _hucreYuksekligi;
        private int _toplamGenislik;
        private int _satirSayaci;
        private bool _ilkSayfa;
        private bool _yeniSayfa;
        private int _ustKisimYuksekligi;
        private int _sayfasayisi;
        #endregion
        private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                _yaziFormati = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                };

                _solSutunKonumlari.Clear();
                _sutunGenislikleri.Clear();
                _satirSayaci = _hucreYuksekligi = 0;
                _yeniSayfa = _ilkSayfa = true;

                _toplamGenislik = 0;
                foreach (DataGridViewColumn dgvGridCol in dtg.Columns)
                {
                    _toplamGenislik += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                var solBosluk = e.MarginBounds.Left - 55;
                var ustBosluk = e.MarginBounds.Top;
                var yazdirilacakSayfaVar = false;

                if (_ilkSayfa)
                {
                    _sayfasayisi = 1;


                    foreach (DataGridViewColumn sutun in dtg.Columns)
                    {
                        var geciciGenislik = (int)Math.Floor((double)((double)sutun.Width /
                                                                       (double)_toplamGenislik * (double)_toplamGenislik *
                                                                       ((double)e.MarginBounds.Width / (double)_toplamGenislik)));

                        _ustKisimYuksekligi = (int)(e.Graphics.MeasureString(sutun.HeaderText,
                                    sutun.InheritedStyle.Font, geciciGenislik).Height) + 20;

                        _solSutunKonumlari.Add(solBosluk + 5);
                        _sutunGenislikleri.Add(geciciGenislik + 5);
                        solBosluk += geciciGenislik + 5;
                    }
                }
                while (_satirSayaci < dtg.Rows.Count)
                {
                    DataGridViewRow simdikiSatir = dtg.Rows[_satirSayaci];

                    _hucreYuksekligi = simdikiSatir.Height + 10;
                    int sayac = 0;
                    if (ustBosluk + _hucreYuksekligi >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        _sayfasayisi++;
                        _ilkSayfa = false;
                        yazdirilacakSayfaVar = _yeniSayfa = true;
                        break;
                    }

                    if (_yeniSayfa)
                    {
                        #region Baslik

                        e.Graphics.DrawString(_kurumAdi, new Font("Arial", 10, FontStyle.Bold),
                            Brushes.Black, (e.MarginBounds.Left + e.MarginBounds.Left + (e.MarginBounds.Width -
                                                                                         e.Graphics.MeasureString(_kurumAdi, new Font(dtg.Font,
                                                                                             FontStyle.Bold), e.MarginBounds.Width).Width)) / 2, e.MarginBounds.Top - 30);

                        string rapor = "RAPOR";
                        e.Graphics.DrawString(rapor, new Font("Arial", 10, FontStyle.Bold),
                            Brushes.Black, (e.MarginBounds.Left + e.MarginBounds.Left + (e.MarginBounds.Width -
                                                                                         e.Graphics.MeasureString(rapor, new Font(dtg.Font,
                                                                                             FontStyle.Bold), e.MarginBounds.Width).Width)) / 2, e.MarginBounds.Top - 15);

                        string sayfa = _sayfasayisi + ". Sayfa";
                        e.Graphics.DrawString(sayfa, new Font("Arial", 10, FontStyle.Bold),
                            Brushes.Black, (e.MarginBounds.Left + e.MarginBounds.Width -
                                            e.Graphics.MeasureString(sayfa, new Font(dtg.Font,
                                                FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top + 15);

                        string strDate = "Raporlama Tarihi: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                        e.Graphics.DrawString(strDate, new Font("Arial", 9, FontStyle.Bold),
                            Brushes.Black, e.MarginBounds.Left - 55, e.MarginBounds.Top + 15);

                        string raporlayan = "Raporlayan Kullanıcı: " ;

                        e.Graphics.DrawString(raporlayan, new Font("Arial", 9, FontStyle.Bold),
                            Brushes.Black, e.MarginBounds.Left - 55, e.MarginBounds.Top + 30);
                        string sorumluadi = "";
                        if (!string.IsNullOrEmpty(sorumluadi))
                            _sorumluAdi = sorumluadi;
                        string sorumlu = "Sorumlu: " + _sorumluAdi;
                        e.Graphics.DrawString(sorumlu, new Font("Arial", 9, FontStyle.Bold),
                            Brushes.Black, e.MarginBounds.Left - 55, e.MarginBounds.Top + 45);

                        #endregion

                        #region SutunBasliklari
                        ustBosluk = e.MarginBounds.Top + 70;
                        foreach (DataGridViewColumn sutun in dtg.Columns)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)_solSutunKonumlari[sayac], ustBosluk,
                                    (int)_sutunGenislikleri[sayac], _ustKisimYuksekligi));

                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)_solSutunKonumlari[sayac], ustBosluk,
                                    (int)_sutunGenislikleri[sayac], _ustKisimYuksekligi));

                            e.Graphics.DrawString(sutun.HeaderText, new Font(new Font(dtg.Font,
                                    FontStyle.Bold), FontStyle.Bold),
                                new SolidBrush(sutun.InheritedStyle.ForeColor),
                                new RectangleF((int)_solSutunKonumlari[sayac], ustBosluk,
                                    (int)_sutunGenislikleri[sayac], _ustKisimYuksekligi), _yaziFormati);
                            sayac++;
                        }
                        _yeniSayfa = false;
                        ustBosluk += _ustKisimYuksekligi;
                    }

                    #endregion
                    sayac = 0;

                    #region SutunIcerikleri         
                    foreach (DataGridViewColumn sutun in dtg.Columns)
                    {
                        DataGridViewCell hucre = dtg.Rows[simdikiSatir.Index].Cells[sutun.Index];
                        if (hucre.Value != null)
                        {
                            if (DateTime.TryParse(hucre.Value.ToString(), out DateTime temp))
                            {
                                e.Graphics.DrawString(Convert.ToDateTime(hucre.Value.ToString()).ToShortDateString(), hucre.InheritedStyle.Font,
                                    new SolidBrush(hucre.InheritedStyle.ForeColor),
                                    new RectangleF((int)_solSutunKonumlari[sayac], (float)ustBosluk,
                                        (int)_sutunGenislikleri[sayac], (float)_hucreYuksekligi), _yaziFormati);
                            }
                            else
                            {
                                e.Graphics.DrawString(hucre.Value.ToString(), hucre.InheritedStyle.Font,
                                    new SolidBrush(hucre.InheritedStyle.ForeColor),
                                    new RectangleF((int)_solSutunKonumlari[sayac], (float)ustBosluk,
                                        (int)_sutunGenislikleri[sayac], (float)_hucreYuksekligi), _yaziFormati);
                            }
                        }
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)_solSutunKonumlari[sayac],
                            ustBosluk, (int)_sutunGenislikleri[sayac], _hucreYuksekligi));

                        sayac++;
                    }
                    #endregion
                    _satirSayaci++;
                    ustBosluk += _hucreYuksekligi;
                }

                e.HasMorePages = yazdirilacakSayfaVar;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
