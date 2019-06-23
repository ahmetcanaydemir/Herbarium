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
    public partial class LogView : UserControls.ManageableForm
    {
        public LogView()
        {
            InitializeComponent();
            dataViewer.dtgDataView.CellEnter += DtgDataView_CellEnter;
        }
        herbariumEntities entities = new herbariumEntities();
        private void DtgDataView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
           log kayit =  entities.log.Find(Convert.ToInt32(dataViewer.dtgDataView.CurrentRow.Cells["ID"].Value));
            rchAciklama.Text = kayit.details;
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            dataViewer.dtgDataView.DataSource = new Class.DataProcess().GetLogsView();
     
        }

        private void LogView_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
