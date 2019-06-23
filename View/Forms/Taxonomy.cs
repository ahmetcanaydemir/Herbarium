using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.Forms
{
    public partial class Taxonomy : UserControls.ManageableForm
    {
        herbariumEntities entities = new herbariumEntities();
        enum Types
        {
            Major,
            Family,
            Genus,
            Species,
            Synonym
        }
        class DataObj{
            public int Id = -1;
            public string Name=string.Empty;
        }
        Dictionary<Types,DataObj> Selections = new Dictionary<Types, DataObj>()
        {
            {Types.Major,new DataObj()},{Types.Family,new DataObj()},{Types.Genus,new DataObj()},{Types.Species,new DataObj()},{Types.Synonym,new DataObj() }
        };
        public Taxonomy()
        {
            InitializeComponent();
            InitializeGrid();
        }
        DataGridView GridView;
        void InitializeGrid()
        {
            GridView = dataViewer.dtgDataView;
            GridView.AllowUserToAddRows = true;
            GridView.AllowUserToDeleteRows = true;
            GridView.RowHeadersVisible = true;
            GridView.ShowEditingIcon = true;
            GridView.ReadOnly = false;
            GridView.VirtualMode = false;
            GridView.AllowUserToResizeRows = false;
            GridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GridView.CellEnter += GridView_CellEnter;
            GridView.CellEndEdit += GridView_CellEndEdit;
        }
        


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var cRow = GridView.CurrentRow;
            if (!GridView.Columns.Contains("Id") || cRow.Cells["Id"].Value is DBNull)
            {
                return;
            }

            int id = Convert.ToInt32(cRow.Cells[0].Value);
            RemoveRow(id);
            GridView.Rows.Remove(cRow);
        }
        private void GridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if (GridView.CurrentCell is null || GridView.CurrentCell.Value is null || string.IsNullOrEmpty(GridView.CurrentCell.Value.ToString().Trim()) || NameAlreadyExists(GridView.CurrentCell.Value.ToString().Trim()))
            {
                GridView.CancelEdit();
                return;
            }

            string newName = GridView.CurrentCell.Value.ToString().Trim();
            if (!GridView.Columns.Contains("Id") || GridView.CurrentRow.Cells["Id"].Value is DBNull)
            {
                GridView.CurrentRow.Cells["Id"].Value = AddNewRowToTable(newName);
            }
            else
            {
                UpdateRow(Convert.ToInt32(GridView.CurrentRow.Cells["Id"].Value), newName);
            }

            GridView.EndEdit();
        }
        private void RemoveRow(int id)
        {
            switch ((Types)tabControl1.SelectedIndex)
            {
                case Types.Family:
                    var result = entities.family.Find(id);
                    if (result != null)
                    {
                        entities.family.Remove(result);
                    }
                    break;
                case Types.Genus:
                    var result2 = entities.genus.Find(id);
                    if (result2 != null)
                    {
                        entities.genus.Remove(result2);
                    }
                    break;
                case Types.Species:
                    var result3 = entities.species.Find(id);
                    if (result3 != null)
                    {
                        entities.species.Remove(result3);
                    }
                    break;
                case Types.Synonym:
                    var result4 = entities.synonym.Find(id);
                    if (result4 != null)
                    {
                        entities.synonym.Remove(result4);
                    }
                    break;
                default:
                    var result5 = entities.major.Find(id);
                    if (result5 != null)
                    {
                        entities.major.Remove(result5);
                    }
                    break;
            }

            entities.SaveChanges();
        }
        private void UpdateRow(int id,string name)
        {
            switch ((Types)tabControl1.SelectedIndex)
            {
                case Types.Family:
                    var result = entities.family.Find(id);
                    if (result != null)
                    {
                        result.name = name;
                    }
                    break;
                case Types.Genus:
                    var result2 = entities.genus.Find(id);
                    if (result2 != null)
                    {
                        result2.name = name;
                    }
                    break;
                case Types.Species:
                    var result3 = entities.species.Find(id);
                    if (result3 != null)
                    {
                        result3.name = name;
                    }
                    break;
                case Types.Synonym:
                    var result4 = entities.synonym.Find(id);
                    if (result4 != null)
                    {
                        result4.name = name;
                    }
                    break;
                default:
                    var result5 = entities.major.Find(id);
                    if (result5 != null)
                    {
                        result5.name = name;
                    }
                    break;
            }

            entities.SaveChanges();
        }

        private int AddNewRowToTable(string name)
        {
            int id = -1;
            switch ((Types)tabControl1.SelectedIndex)
            {
                case Types.Family:
                    family obj = new family { name = name,majorid = Selections[Types.Major].Id };
                    entities.family.Add(obj);
                    id = obj.id;
                    break;
                case Types.Genus:
                    genus obj2 = new genus { name = name, familyid = Selections[Types.Family].Id };
                    entities.genus.Add(obj2);
                    id = obj2.id;
                    break;
                case Types.Species:
                    species obj3 = new species { name = name, genusid = Selections[Types.Genus].Id };
                    entities.species.Add(obj3);
                    id = obj3.id;
                    break;
                case Types.Synonym:
                    synonym obj4 = new synonym { name = name,speciesid= Selections[Types.Species].Id };
                    entities.synonym.Add(obj4);
                    id = obj4.id;
                    break;
                default:
                    major obj5 = new major { name = name };
                    entities.major.Add(obj5);
                    id = obj5.id;
                    break;
            }
            entities.SaveChanges();

            return id;
        }

        private void GridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(GridView.Rows[e.RowIndex]==null|| GridView.Rows[e.RowIndex].Cells[0].Value is DBNull)
            {
                Selections[(Types)tabControl1.SelectedIndex]= new DataObj();
                return;
            }
           
                Selections[(Types)tabControl1.SelectedIndex].Id = Convert.ToInt32(GridView.CurrentRow.Cells?[0].Value);
            Selections[(Types)tabControl1.SelectedIndex].Name = GridView.CurrentRow.Cells?[1].Value.ToString();
            PrintBreadCrumbs();
        }
        private void PrintBreadCrumbs()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Selections.Count; i++)
            {
                if (i > tabControl1.SelectedIndex)
                {
                    Selections[(Types)i] = new DataObj();
                    continue;
                }
                sb.Append(" / "+Selections[(Types)i].Name );
            }
            rchBreadCrumb.Text = sb.ToString().Substring(3);
            rchBreadCrumb.SelectAll();
            rchBreadCrumb.SelectionColor = Color.Black;
            rchBreadCrumb.Select(rchBreadCrumb.Text.LastIndexOf(Selections[(Types)tabControl1.SelectedIndex].Name), Selections[(Types)tabControl1.SelectedIndex].Name.Length);
            rchBreadCrumb.SelectionColor = Color.Red;
        }

        private void Taxonomy_Load(object sender, EventArgs e)
        {

            AddDataViewToCurrentTab();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0 && Selections[(Types)tabControl1.SelectedIndex].Id == -1)
            {
                CheckTabAccessible();
              
            }
            AddDataViewToCurrentTab();
        }

        private bool NameAlreadyExists(string name)
        {
            var count = 1;
            switch ((Types)tabControl1.SelectedIndex)
            {
                case Types.Family:
                    count = entities.family.Where(x => x.name == name).Count();
                    break;
                case Types.Genus:
                    count = entities.genus.Where(x => x.name == name).Count();
                    break;
                case Types.Species:
                    count = entities.species.Where(x => x.name == name).Count();
                    break;
                case Types.Synonym:
                    count = entities.synonym.Where(x => x.name == name).Count();
                    break;
                default:
                    count = entities.major.Where(x => x.name == name).Count();
                    break;
            }

            return count > 0;
        }

        private void AddDataViewToCurrentTab()
        {
            var list = entities.major.Select(x => new { x.id, x.name }).ToList();

            switch ((Types)tabControl1.SelectedIndex)
            {
                case Types.Family:
                    int id = Selections[Types.Major].Id;
                    list = entities.family.Where(x=>x.majorid ==id).Select(x => new { x.id, x.name }).ToList();
                    break;
                case Types.Genus:
                    id = Selections[Types.Family].Id;
                    list = entities.genus.Where(x => x.familyid == id).Select(x => new { x.id, x.name }).ToList();
                    break;
                case Types.Species:
                    id = Selections[Types.Genus].Id;
                    list = entities.species.Where(x => x.genusid == id).Select(x => new { x.id, x.name }).ToList();
                    break;
                case Types.Synonym:
                    id = Selections[Types.Species].Id;
                    list = entities.synonym.Where(x => x.speciesid == id).Select(x => new { x.id, x.name }).ToList();
                    break;
                default:
                    break;
            }
            BindingSource bs = new BindingSource();
            var dt = new Class.DataProcess().GetDataTableFromList(list);
            bs.DataSource = dt;
            GridView.DataSource = bindingNavigator1.BindingSource = bs;

            GridView.Columns["id"].Visible = false;
            GridView.Columns["name"].HeaderText = "Ad";
            tabControl1.SelectedTab.Controls.Clear();
            tabControl1.SelectedTab.Controls.Add(pnlContainer);
        }

        private void CheckTabAccessible()
        {
            int i = 0;
            foreach (var item in Selections.Values)
            {
                if (item.Id == -1) break;
                i++;
            }
            tabControl1.SelectedIndex = i;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedCells.Count < 2) return;
            DialogResult dialog = MessageBox.Show(GridView.SelectedCells.Count + " adet veri ve alt verilerini " + GridView.CurrentRow.Cells[1].Value.ToString() + " altında birleştirmek istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) ;
            if (dialog != DialogResult.Yes) return;
            int rowId = -1;
            int mergeId = Convert.ToInt32(GridView.CurrentRow.Cells[0].Value);

            for (int i = 0; i < GridView.SelectedCells.Count; i++)
            {
                int rowIndex = GridView.SelectedCells[i].RowIndex;
                rowId = Convert.ToInt32(GridView.Rows[rowIndex].Cells[0].Value);
                if (rowId == mergeId) continue;

                switch ((Types)tabControl1.SelectedIndex)
                {
                    case Types.Major:
                        foreach (var obj in entities.family.Where(x => x.majorid == rowId))
                        {
                            obj.majorid = mergeId;
                        }
                        break;
                    case Types.Family:
                        foreach (var obj in entities.genus.Where(x => x.familyid == rowId))
                        {
                            obj.familyid = mergeId;
                        }

                        break;
                    case Types.Genus:
                        foreach (var obj in entities.species.Where(x => x.genusid == rowId))
                        {
                            obj.genusid = mergeId;
                        }

                        break;
                    case Types.Species:
                        foreach (var obj in entities.synonym.Where(x => x.speciesid == rowId))
                        {
                            obj.speciesid = mergeId;
                        }
                        break;
                    case Types.Synonym:
                        
                        break;
                    default:
                        break;
                }
                entities.SaveChanges();

                RemoveRow(rowId);
                MessageBox.Show("Birleştirme işlemi başarılı!");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
    }
}
