using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herbarium.Forms;
using Herbarium.Class;

namespace Herbarium
{
    public partial class DataViewer : UserControl
    {
        int _seciliSutun;
        private string _tabloAdi;
       public SearchToolbar searchToolbar;

        public DataViewer()
        {
            InitializeComponent();
           

            searchToolbar = new Class.Searching(this).getAramaKutusu();
            this.Controls.Add(searchToolbar);
            dtgDataView.ColumnHeaderMouseClick += DtgDataView_ColumnHeaderMouseClick;
            dtgDataView.CellMouseClick += DtgDataView_CellMouseClick;
            dtgDataView.CellDoubleClick += DtgDataView_CellDoubleClick;
            dtgDataView.DataBindingComplete += DtgDataView_DataBindingComplete;
        }

        private void DtgDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {/*
            if (TabloGridView.DataSource is null || TabloGridView.Rows.Count == 0) return;
            if (this.ParentForm?.Name == "AnaForm")
            {// DataGridAyarYoneticisi.DgDurumlariYerlestir(TabloGridView, "Tablo_" + _tabloAdi + ".json", false);
                DataGridAyarYoneticisi.DgDurumlariYerlestir(TabloGridView, "Tablo_" + _tabloAdi + ".json", false);
            }*/
        }

        private void DtgDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                MenuGuncelle_Click(this, EventArgs.Empty);
            }
        }

        private void DtgDataView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex == -1 || this.ParentForm?.Name != "MainForm") return;

            ContextMenuStrip baslikMenu = new ContextMenuStrip();
            var menuGuncelle = new ToolStripMenuItem("Görüntüle ve Güncelle");
            menuGuncelle.Click += MenuGuncelle_Click;
            var menuBarkodYazdir = new ToolStripMenuItem("Barkod yazdır");
            menuBarkodYazdir.Click += MenuBarkodYazdir_Click;
            var menuYeniKayit = new ToolStripMenuItem("Yeni kayıt");
            menuYeniKayit.Click += MenuYeniKayit_Click;
            var menuSil = new ToolStripMenuItem("Sil");
            menuSil.Click += MenuSil_Click;
            var menuRaporla = new ToolStripMenuItem("Tümünü raporla");
            menuRaporla.Click += (se, ev) => { ListReport(false); };
            var menuSeciliRaporla = new ToolStripMenuItem("Seçili olanları raporla");
            menuSeciliRaporla.Click += (se, ev) => { ListReport(true); };
            var menuFotograf = new ToolStripMenuItem("Fotoğrafı görüntüle");
            menuFotograf.Click += (se, ev) => {
                ShowPhoto();
            };
            var menuHarita = new ToolStripMenuItem("Haritada görüntüle");
            menuHarita.Click += (se, ev) => ShowMap();

            baslikMenu.Items.AddRange(new ToolStripItem[] { menuGuncelle, new ToolStripSeparator(), menuBarkodYazdir, new ToolStripSeparator(), menuYeniKayit, menuSil,new ToolStripSeparator(),menuRaporla,menuSeciliRaporla,new ToolStripSeparator(),menuFotograf,menuHarita });
            if (this.ParentForm.Name == "MainForm")
            {

            }
            else
            {
                baslikMenu.Items.Clear();
            }

            if (!dtgDataView.Rows[e.RowIndex].Selected)
            {
                dtgDataView.ClearSelection();
                dtgDataView.Rows[e.RowIndex].Selected = true;
            }
            baslikMenu.Show(Cursor.Position);
        }

        public void ShowMap()
        {
            var plant = new herbariumEntities().plant.Find(Convert.ToInt32(dtgDataView.CurrentRow.Cells[0].Value));
            if(plant != null && !string.IsNullOrEmpty(plant.coordinates))
            {
                foreach (var item in Login.tabbedApp.Tabs)
                {
                    if (item.Caption == "Harita " + plant.coordinates)
                    {
                        Login.tabbedApp.SelectedTab = item;
                        return;
                    }
                }
                var form = new Harita($"https://www.google.com/maps/search/{plant.coordinates}/");  
                form.Text = "Harita " + plant.coordinates;
                Login.tabbedApp.Tabs.Add(new EasyTabs.TitleBarTab(Login.tabbedApp)
                {
                    Content = form
                });
                Login.tabbedApp.SelectedTabIndex = Login.tabbedApp.Tabs.Count - 1;
            }
        }

        public void ShowPhoto()
        {
            var bll = new Class.BIL.PlantBLL();
            var photo = bll.getPhoto(new herbariumEntities().plant.Find(Convert.ToInt32(dtgDataView.CurrentRow.Cells[0].Value)));
            if (photo != null)
                bll.openImage(photo);
        }

        private void MenuSil_Click(object sender, EventArgs e)
        {
            
                PlantRemove();
        }


        private void MenuYeniKayit_Click(object sender, EventArgs e)
        {
            if (this.ParentForm?.Name != "MainForm") return;
            PlantNew();
            //form.ShowDialog();
        }

        private void MenuBarkodYazdir_Click(object sender, EventArgs e)
        {
            List<string> barkodlar = new List<string>();
            foreach (DataGridViewRow satir in dtgDataView.SelectedRows)
            {
                        if (satir.Cells["Barkod"].Value.ToString().Length == 13)
                {
                    barkodlar.Add(satir.Cells["Barkod"].Value.ToString());
                }
            }
            if (barkodlar.Count == 0)
            {
                //Sabit.MesajGoster("Yazdırılacak barkodlar 13 haneden oluşmalıdır!", Sabit.MesajTipi.Uyari);
                return;
            }
           new Forms.Barcode(barkodlar.ToArray()).ShowDialog();
            
        }

        private void MenuGuncelle_Click(object sender, EventArgs e)
        {
            PlantUpdate();
        }
        public void PlantNew()
        {
            foreach (var item in Login.tabbedApp.Tabs)
            {
                if (item.Caption == "Bitki Ekle")
                {
                    Login.tabbedApp.SelectedTab = item;
                    return;
                }
            }
            var form = new PlantForm();
            form.Tablo = Table;
            form.Text = "Bitki Ekle";
            Login.tabbedApp.Tabs.Add(new EasyTabs.TitleBarTab(Login.tabbedApp)
            {
                Content = form
            });
            Login.tabbedApp.SelectedTabIndex = Login.tabbedApp.Tabs.Count - 1;

        }
        public void PlantUpdate()
        {
            if (this.ParentForm?.Name != "MainForm") return;
            List<int> idler = new List<int>();
            foreach (DataGridViewRow dr in dtgDataView.SelectedRows)
                idler.Add(Convert.ToInt32(dr.Cells[0].Value));

            if (idler.Count <= 0) return;
            PlantForm form = new PlantForm(idler[0], Table);
            form.Text = form.HerbNo;
            foreach (var item in Login.tabbedApp.Tabs)
            {
                if (item.Caption == form.Text)
                {
                    Login.tabbedApp.SelectedTab = item;
                    Login.tabbedApp.SelectedTab.Content.Close();
                    break;
                }
            }
            Login.tabbedApp.Tabs.Add(new EasyTabs.TitleBarTab(Login.tabbedApp)
            {
                Content = form
        });
            Login.tabbedApp.SelectedTabIndex = Login.tabbedApp.Tabs.Count - 1;
          //  Login.tabbedApp.SelectedTabIndex = 0;
            //PlantForm form = new Forms.PlantForm(idler[0],Table);
            //form.ShowDialog();
        }
        public void PlantRemove()
        {
            if (UserBLL.YekisiYok("Bitki Sil"))
            {
                return;
            }
                if (this.ParentForm?.Name != "MainForm") return;

            herbariumEntities entity = new herbariumEntities();
            List<plant> plants = new List<plant>();
            List<DataGridViewRow> toBeDeleted = new List<DataGridViewRow>();

            if (dtgDataView.SelectedRows.Count > 0 && MessageBox.Show(dtgDataView.SelectedRows.Count + " adet bitki kaydını silmek istediğinize emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (DataGridViewRow dr in dtgDataView.SelectedRows)
                {
                    plant silinecek = entity.plant.Find(Convert.ToInt32(dr.Cells[0].Value));
                    silinecek.grid.Clear();
                    plants.Add(silinecek);
                    DataRow row = (dr.DataBoundItem as DataRowView).Row;
                    Log.Debug("[Silinen Bitki]: " + silinecek.herbno, $"{silinecek.herbno} kodlu {DateTime.Now.ToString()} tarihinde  {UserBLL.ActiveUser.name} tarafından {row["Tür"]} silindi.\nSilinen bitkinin detayları:\n" + Log.PlantRowToJson(row) );
                    toBeDeleted.Add(dr);
                }
                entity.plant.RemoveRange(plants);
                entity.SaveChanges();
                ShowMessage.Success("Silme işlemi başarılı");

                foreach (DataGridViewRow row in toBeDeleted)
                    dtgDataView.Rows.Remove(row);
            }
        }
        public void ListReport(bool onylSelected)
        {
            new ReportForm(dtgDataView,onylSelected).ShowDialog();
        }

        private void DtgDataView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button != MouseButtons.Right) return;

            ContextMenuStrip baslikMenu = new ContextMenuStrip();

            var menuSutunGenislik = new ToolStripMenuItem("Sütun genişliğini ayarla");
            _seciliSutun = e.ColumnIndex;
            menuSutunGenislik.Click += (s,ev) => dtgDataView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); 

            var menuTumSutunGenislik = new ToolStripMenuItem("Tüm sütun genişliklerini ayarla");
            menuTumSutunGenislik.Click += (s, ev) => dtgDataView.AutoResizeColumn(_seciliSutun, DataGridViewAutoSizeColumnMode.AllCells);

            baslikMenu.Items.AddRange(new ToolStripItem[] { menuSutunGenislik, menuTumSutunGenislik, new ToolStripSeparator() });

            foreach (DataGridViewColumn sutun in dtgDataView.Columns)
            {
                var eleman = new ToolStripMenuItem();
                eleman.Click += Eleman_Click;
                eleman.Checked = sutun.Visible;
                eleman.Text = sutun.HeaderText.ToString();
                eleman.Name = sutun.Index.ToString();
                baslikMenu.Items.Add(eleman);
            }
            baslikMenu.Items.Add(new ToolStripSeparator());

            var menuSutunVarsayilan = new ToolStripMenuItem("Sütunları varsayılana sıfırla");
           // menuSutunVarsayilan.Click += MenuSutunVarsayilan_Click;
            baslikMenu.Items.Add(menuSutunVarsayilan);
            baslikMenu.Show(Cursor.Position);
        }

        private void Eleman_Click(object sender, EventArgs e)
        {
            var eleman = sender as ToolStripMenuItem;
            int index = Convert.ToInt32(eleman.Name);

            dtgDataView.Columns[index].Visible = eleman.Checked = !(eleman.Checked);

            searchToolbar.SetColumns(dtgDataView.Columns);

            int gorunurSutunSayisi = 0; // Yapılan işlem sonucunda hiçbir sütun görünmüyor ise işlemi geri alır.
            foreach (DataGridViewColumn sutun in dtgDataView.Columns)
            {
                if (sutun.Visible) gorunurSutunSayisi++;
            }
            if (gorunurSutunSayisi < 1) dtgDataView.Columns[index].Visible = eleman.Checked = !(eleman.Checked);

           // DataGridAyarYoneticisi.DgDurumlariDegistir(TabloGridView, "Tablo_" + _tabloAdi + ".json");
         }

        public class OzelGridView : DataGridView  //Datagridview'i hızlandırıyor
        {
            public OzelGridView() => DoubleBuffered = true;
        }
        public OzelGridView GridView { get => dtgDataView; set => dtgDataView = value; }
        public DataTable Table
        {
            get => (DataTable)dtgDataView.DataSource;
            set
            {
                dtgDataView.DataSource = value;
            }
        }

        private void dtgDataView_DataSourceChanged(object sender, EventArgs e)
        {
            searchToolbar.SetColumns(dtgDataView.Columns);
            searchToolbar.textBox_search.Text = string.Empty;
            searchToolbar.textBox_search_Leave(this, EventArgs.Empty);
        }

        private void dtgDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
