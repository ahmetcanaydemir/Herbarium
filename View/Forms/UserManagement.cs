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

namespace Herbarium.Forms
{
    public partial class UserManagement : Form
    {
        UserBLL userBLL = new UserBLL();
        user Uye;
        public UserManagement()
        {
            InitializeComponent();
            dataViewer1.dtgDataView.CellEnter += DtgDataView_CellEnter;
        }
        public delegate void Function(TreeNode node);
        private void HandleAllNodes(TreeNodeCollection nodeCollection, Function function)
        {
            foreach (TreeNode trNode in nodeCollection)
            {
                function(trNode);
                if (trNode.Nodes.Count > 0)
                    HandleAllNodes(trNode.Nodes, function);
            }
        }
        private void UncheckTreeNode(TreeNode node)
        {
            node.Checked = false;
        }
        private void AddAuthIfNodeChecked(TreeNode node)
        {
            if (!node.Checked) return;

            user_auths yetki = userBLL.findAuth(Convert.ToInt32(node.Name));
            Uye.user_auths.Add(yetki);
        }

        private void DtgDataView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            int id = int.Parse(dataViewer1.dtgDataView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            btnKullaniciSil.Enabled = id > 1;
            Uye = userBLL.findUser(id);
            txtKullaniciAdi.Text = Uye.name;
            txtSifre.Text = Uye.password;
            
            HandleAllNodes(trvYetkiler.Nodes, UncheckTreeNode);
        
            foreach(var yetki in Uye.user_auths)
            {
                trvYetkiler.Nodes.Find(yetki.id.ToString(),true)[0].Checked = true;
            }
        }
        

        private void UserManagement_Load(object sender, EventArgs e)
        {
            FillAuths();
            FillUsers();
        }
        private void FillUsers()
        {
            dataViewer1.dtgDataView.DataSource = userBLL.GetUserList();
        }

        private void FillAuths()
        {
            trvYetkiler.BeginUpdate();
            foreach (var yetki in userBLL.YetkiListesi)
            {
                TreeNodeCollection nodeCollection = yetki.parent is null ? trvYetkiler.Nodes : trvYetkiler.Nodes.Find(yetki.parent.ToString(), false)[0].Nodes;
                nodeCollection.Add(yetki.id.ToString(), yetki.name);
            }
            trvYetkiler.ExpandAll();
            trvYetkiler.EndUpdate();
        }

        private void trvYetkiler_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode item in e.Node.Nodes)
                item.Checked = e.Node.Checked;
        }
        
        private void UpdateInsert()
        {
            Uye.name = txtKullaniciAdi.Text;
            Uye.password = txtSifre.Text;
            Uye.user_auths.Clear();
            HandleAllNodes(trvYetkiler.Nodes, AddAuthIfNodeChecked);
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            UpdateInsert();
            userBLL.Guncelle(Uye);
            DataRow satir = null;
            foreach (DataRow curRow in dataViewer1.Table.Rows)
            {
                if(Convert.ToInt32(curRow["ID"])== Uye.id)
                {
                    satir = curRow;
                    break;
                }
            }
            satir["ID"] = Uye.id;
            satir["Kullanıcı Adı"] = Uye.name;
            satir["Son Giriş"] = null;
            ShowMessage.Success("Güncelleme başarılı");
        }
        
        private void btnKullaniciOlustur_Click(object sender, EventArgs e)
        {
            Uye = new user();
            UpdateInsert();
            userBLL.Ekle(Uye);

            var satir = dataViewer1.Table.NewRow();
            satir["ID"] = Uye.id;
            satir["Kullanıcı Adı"]= Uye.name;
            satir["Kayıt Tarihi"] = DateTime.Now;
            satir["Son Giriş"] = null;
            dataViewer1.Table.Rows.Add(satir);
            ShowMessage.Success("Ekleme başarılı");

        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            userBLL.Sil(Uye);
            dataViewer1.dtgDataView.Rows.Remove(dataViewer1.dtgDataView.SelectedRows[0]);
            ShowMessage.Success("Silme başarılı");
        }
    }
}