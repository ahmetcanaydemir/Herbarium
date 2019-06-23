using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.Class
{
    class GridManager
    {
     public enum Table
        {
            Main,
            Taxonomy,
            User
        }
        DataGridDurum durum;
        Table table;
        public GridManager(Table table)
        {
            durum = new DataGridDurum();
        }

        private DataGridDurum DosyadanDgOku()
        {
            if (!Directory.Exists(Constants.AppDataKonum + "Durum"))
                Directory.CreateDirectory(Constants.AppDataKonum + "Durum");
            var dosya = Constants.AppDataKonum + "Durum\\" + table.ToString() + ".json";
            
            var tamDosyaAdi = table.ToString() + ".json";
            return JsonListeye(tamDosyaAdi, File.ReadAllText(dosya));

        }
        private DataGridDurum JsonListeye(string dosyaAdi, string json)
        {
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
            DataGridDurum dgDurum = new DataGridDurum() { Ad = dosyaAdi, Sutunlar = new List<DataGridSutunDurum>() }; try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DataGridSutunDurum sutunDurum = new DataGridSutunDurum
                    {
                        Ad = dr[0].ToString(),
                        DisplayIndex = int.Parse(dr[2].ToString()),
                        Width = int.Parse(dr[1].ToString()),
                        Visible = Convert.ToBoolean(dr[3]),

                    };
                    if (dr[4].ToString() == "False")
                        sutunDurum.SiralamaYonu = SortOrder.None;
                    else
                        sutunDurum.SiralamaYonu = dr[4].ToString() == "Descending" ? SortOrder.Descending : SortOrder.Ascending;

                    dgDurum.Sutunlar.Add(sutunDurum);
                }
                return dgDurum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        public void DgDurumlariDegistir(DataGridView dg)
        {
                List<DataGridSutunDurum> sutunlar = new List<DataGridSutunDurum>();
                foreach (DataGridViewColumn dgSutun in dg.Columns)
                {
                    var baslik = dgSutun.HeaderText;
                    DataGridSutunDurum sutun = new DataGridSutunDurum();
                    sutun.Ad = baslik;
                    sutun.Visible = dgSutun.Visible;
                    sutun.DisplayIndex = dgSutun.DisplayIndex;
                    sutun.Width = dgSutun.Width;
                    sutun.SiralamaYonu = dg.SortedColumn?.Name == dgSutun.Name ? dg.SortOrder : SortOrder.None;
                    sutunlar.Add(sutun);
                }
                durum.Sutunlar = sutunlar;
        }


        public void Load(DataGridView dg,bool sifirla)
        {
            //if (sifirla) Sifirla(dosyaAdi);
            var dosya = Constants.AppDataKonum + "Durum\\" + table.ToString() + ".json";
            //int index = DosyaVarMi(dosyaAdi);
            int index = 1;
            if (File.Exists(dosya))
            {
                DataGridViewColumn siralamaSutunu = null;
                ListSortDirection sd = ListSortDirection.Ascending;
                var durum = DosyadanDgOku();
                if (durum.Sutunlar.Count > dg.Columns.Count) return;
                foreach (DataGridViewColumn dgSutun in dg.Columns)
                {
                    var baslik = dgSutun.HeaderText;
                    foreach (var sutun in durum.Sutunlar)
                    {
                        if (sutun.Ad != baslik) continue;
                        dgSutun.Visible = sutun.Visible;
                        dgSutun.Width = sutun.Width;
                        dgSutun.DisplayIndex = sutun.DisplayIndex;
                        if (sutun.SiralamaYonu != SortOrder.None)
                        {
                            sd = sutun.SiralamaYonu == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                            siralamaSutunu = dgSutun;
                        }
                    }
                }
            }
        }
        public void Save(DataGridView dg)
        {
                DgDurumlariDegistir(dg);
            var dosyaAdi = Constants.AppDataKonum + "Durum\\" + table.ToString() + ".json";
            if(!Directory.Exists(Constants.AppDataKonum + "Durum"))
                Directory.CreateDirectory(Constants.AppDataKonum + "Durum");
            DataTable dt = new DataTable();
                dt.Columns.Add("isim");
                dt.Columns.Add("genislik");
                dt.Columns.Add("konum");
                dt.Columns.Add("gorunurluk");
                dt.Columns.Add("sirali");
                foreach (var sutun in durum.Sutunlar)
                {
                    DataRow dr = dt.NewRow();
                    dr["isim"] = sutun.Ad;
                    dr["genislik"] = sutun.Width;
                    dr["konum"] = sutun.DisplayIndex;
                    dr["gorunurluk"] = sutun.Visible;
                    dr["sirali"] = sutun.SiralamaYonu.ToString() != "None" ? sutun.SiralamaYonu.ToString() : "False";
                    dt.Rows.Add(dr);
                }
                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                File.WriteAllText(dosyaAdi, json, Encoding.UTF8);
            
        }
    }
    class DataGridDurum
    {
        public string Ad;
        public List<DataGridSutunDurum> Sutunlar;
    }

    internal class DataGridSutunDurum
    {
        public string Ad;
        public int Width;
        public int DisplayIndex;
        public bool Visible;
        public SortOrder SiralamaYonu;
    }
}
