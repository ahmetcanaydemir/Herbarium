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
    public partial class MainForm : ManageableForm
    {
        herbariumEntities entities = new herbariumEntities();
        public MainForm()
        {
            InitializeComponent();
            dataViewer.dtgDataView.DataBindingComplete += (se, ev) => tsToplam.Text = "Toplam:" + dataViewer.Table.Rows.Count;

            dataViewer.dtgDataView.SelectionChanged += (se, ev) => tsSecili.Text = "Seçili:" + dataViewer.dtgDataView.SelectedRows.Count;
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
        PlantForm plantForm = new PlantForm();
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            FillGrid();
            gridManager = new GridManager(GridManager.Table.Main);
            gridManager.Load(dataViewer.dtgDataView, false);
            if (this.FormBorderStyle == FormBorderStyle.None)
                tamEkranToolStripMenuItem.Text = "Tam Ekrandan Çık";
        }
        private void FillGrid()
        {
            dataViewer.dtgDataView.DataSource = new DataProcess().GetPlantsView();
        }
        

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new ReportForm(dataViewer.dtgDataView).ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new Taxonomy().ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            plantForm.Tablo = dataViewer.Table;
            plantForm.ShowDialog();
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
            new UserManagement().ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridManager.Save(dataViewer.dtgDataView);
            Environment.Exit(0)
;        }
        

        private void logKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LogView().ShowDialog();
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

        private void tamEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool tamEkranaGec = tamEkranToolStripMenuItem.Text == "Tam Ekrana Geç";
            this.WindowState = tamEkranaGec ? FormWindowState.Normal : FormWindowState.Maximized;
            this.FormBorderStyle = tamEkranaGec ? FormBorderStyle.None : FormBorderStyle.Sizable;
            if(tamEkranaGec)
                this.Bounds = Screen.PrimaryScreen.Bounds;
            tamEkranToolStripMenuItem.Text = tamEkranaGec ? "Tam Ekrandan Çık" : "Tam Ekrana Geç";
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Info().Show();
        }
    }
}
