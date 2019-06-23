using Herbarium.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Herbarium.Forms
{
    public partial class ReportForm : Form
    {
        DataGridView _dtg;
        bool _selectedOnly = false;
        public ReportForm(DataGridView dtg)
        {
            _dtg = dtg;
            InitializeComponent();
        }
        public ReportForm(DataGridView dtg, bool selectedOnly)
        {
            _dtg = dtg;
            _selectedOnly = selectedOnly;
            InitializeComponent();
        }

        private void btnRaporla_Click(object sender, EventArgs e)
        {
            RadioButton radioBtn = groupBox1.Controls.OfType<RadioButton>()
                                       .Where(x => x.Checked).FirstOrDefault();
            Report form = new Report(_dtg,_selectedOnly);

            switch (radioBtn.Name)
            {
                case nameof(rdbYazdir):
                    form.Yazdir();
                    break;
                case nameof(rdbExcel):
                    form.ExceleCikar();
                    break;
                case nameof(rdbHtml):
                    form.HtmlDosyasi();
                    break;
                case nameof(rdbMetin):
                    form.TxtDosyasi();
                    break;
                case nameof(rdbJson):
                    form.JsonDosyasi();
                    break;
                case nameof(rdbXml):
                    form.XmlDosyasi();
                    break;
                case nameof(rdbCsv):
                    form.CsvDosyasi();
                    break;
            }
            var list = Log.DataTableToList(form.DataTableOlustur(_dtg));
           
            Log.Debug( "["+radioBtn.Name.Replace("rdb","")+" Raporu]: "+_dtg.Rows.Count+" kayıt", $"[{(_selectedOnly?"Sadece seçilenler":"Tümü")}] tipli {_dtg.Rows.Count} adet satıra ve {_dtg.Columns.Count} sütuna sahip tablonun raporu {UserBLL.ActiveUser.name} tarafından {DateTime.Now.ToString()} tarihinda alındı.\nRaporu alınan tablo:\n" + Newtonsoft.Json.JsonConvert.SerializeObject(list,Newtonsoft.Json.Formatting.Indented));

        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (UserBLL.YekisiYok("Raporla"))
            {
                this.Close();
            }
        }
    }
}
