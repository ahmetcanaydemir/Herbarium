using EasyTabs;
using Herbarium.Class;
using Herbarium.Forms;
using Herbarium.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium
{
    public partial class MainForm : Form
    {
        herbariumEntities entities = new herbariumEntities();
        //ManageableForm manageable;
        public DataTable Table => dataViewer.Table;
        public MainForm()
        {
            InitializeComponent();
            
            dataViewer.dtgDataView.DataBindingComplete += (se, ev) =>
            {
                tsToplam.Text = "Toplam:" + dataViewer.dtgDataView.Rows.Count;
                gridManager = new GridManager(GridManager.Table.Main);
                gridManager.Load(dataViewer.dtgDataView, false);
            };
           // manageable = new ManageableForm(this);
            dataViewer.dtgDataView.SelectionChanged += (se, ev) => tsSecili.Text = "Seçili:" + dataViewer.dtgDataView.SelectedRows.Count;
            tsKullanici.Text = "Aktif Kullanıcı: "+UserBLL.ActiveUser.name;
            tsKullanici.Click += (se, ev) => new UserManagement().ShowDialog();
            dataViewer.dtgDataView.CellFormatting += (se, ev) =>
            {
                return;
                var grid = (DataGridView)se;
                if (grid.Columns[ev.ColumnIndex].Name == "Sinonim"|| grid.Columns[ev.ColumnIndex].Name == "Endemik")
                {
                    ev.Value = (bool)ev.Value ? "Evet" : "Hayır";
                    ev.FormattingApplied = true;
                }
            };
        }

       

        GridManager gridManager;
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            FillGrid();
            
            
        }
        private void FillGrid()
        {
            BackgroundWorker bg = new BackgroundWorker();
            tsProgressBar.Visible = true;
            lblLoading.Visible = true;
            bg.DoWork += (se, ev) =>
            {
                DataTable dt = new DataProcess().GetPlantsView();
                ev.Result = dt;
            };
            bg.RunWorkerCompleted += (se, ev) => {

                dataViewer.dtgDataView.DataSource = (DataTable)ev.Result;
                tsProgressBar.Visible = false;
                lblLoading.Visible = false;
            };

            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }
        

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new ReportForm(dataViewer.dtgDataView).ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (var item in Login.tabbedApp.Tabs)
            {
                if (item.Caption == "Taksonomi Düzenle")
                {
                    Login.tabbedApp.SelectedTab = item;
                    return;
                }
            }
            var form = new Taxonomy();
            form.Text = "Taksonomi Düzenle";
            Login.tabbedApp.Tabs.Add(new EasyTabs.TitleBarTab(Login.tabbedApp)
            {
                Content = form
            });
            Login.tabbedApp.SelectedTabIndex = Login.tabbedApp.Tabs.Count - 1;
       
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataViewer.PlantNew();
           
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataViewer.PlantUpdate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataViewer.PlantRemove();
        }

        private void barkodToolStripMenuItem_Click(object sender, EventArgs e) =>
           new Barcode().ShowDialog();

        private void kullanıcıAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Login.tabbedApp.Tabs)
            {
                if (item.Caption == "Kullanıcı Yönetimi")
                {
                    Login.tabbedApp.SelectedTab = item;
                    return;
                }
            }
            var form = new UserManagement();
            form.Text = "Kullanıcı Yönetimi";
            Login.tabbedApp.Tabs.Add(new EasyTabs.TitleBarTab(Login.tabbedApp)
            {
                Content = form
            });
            Login.tabbedApp.SelectedTabIndex = Login.tabbedApp.Tabs.Count - 1;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason != CloseReason.WindowsShutDown && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
            }
            
        }
        internal void Kapat()
        {
            gridManager.Save(dataViewer.dtgDataView);
        }

        private void logKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Login.tabbedApp.Tabs)
            {
                if (item.Caption == "Log Görüntüle")
                {
                    Login.tabbedApp.SelectedTab = item;
                    return;
                }
            }
            var form = new LogView();
            form.Text = "Log Görüntüle";
            Login.tabbedApp.Tabs.Add(new EasyTabs.TitleBarTab(Login.tabbedApp)
            {
                Content = form
            });
            Login.tabbedApp.SelectedTabIndex = Login.tabbedApp.Tabs.Count - 1;
        }

        private void seçiliOlanlarıRaporlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataViewer.ListReport(true);
        }

        private void tümünüRaporlaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataViewer.ListReport(false);
        }

        private void fotoğrafıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataViewer.ShowPhoto();
        }
        

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Info().Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void oturumuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.tabbedApp.Close();
        }

        private void haritadaGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataViewer.ShowMap();
        }
    }
}
