using Herbarium.Class.BIL;
using Herbarium.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.Forms
{
    public partial class PlantForm : Form
    {
        SelectGrids selectGridsForm;
        herbariumEntities entities;
        bool isUpdate = false;
        public DataTable Tablo;
        string plantName;
        public string HerbNo => txtKod.Text;
        plant _plant;
        PlantBLL _plantBLL;

        Dictionary<string,string> oldRow;

        public PlantForm()
        {
            InitializeComponent();
            YeniBitki();
        }
        private void YeniBitki()
        {
            StartInitialize();
            this._plant = new plant();
            var count = entities.plant.Count();
            if (count > 0)
            {
                var list = entities.plant.OrderBy(x => x.id).ToList();
                int sayi = Convert.ToInt32(entities.plant.Max(x => x.id) + 1);
                txtKod.Text = string.Format("{0:D7}", sayi);
            }
            else
                txtKod.Text = string.Format("{0:D7}", 00001);
            txtKod.Enabled = true;
        }
        public PlantForm(int plantid,DataTable table)
        {
        
            InitializeComponent();
            StartInitialize();
            this._plant = entities.plant.Find(plantid);
            this.Tablo = table;
            var photo = _plantBLL.getPhoto(_plant);
            if (photo!=null)
            {
                lblPhoto.Visible = false;
                pboxResim.Image = photo;
            }
            txtKod.Text = _plant.herbno;
            FillAreas();
            oldRow = Log.PlantRowToDict(GetRowOfPlant());
           
            btnKEKaydet.Text = "Bitki Güncelle";
            isUpdate = true;
            txtKod.Enabled = true;
        }
        private DataRow GetRowOfPlant()
        {
            foreach (DataRow tSatir in Tablo.Rows)
            {
                if (tSatir["ID"].ToString() == _plant.id.ToString())
                {
                    return tSatir;
                }
            }
            return null;
        }
        private void FillAreas()
        {
            fillPlantValues();

            txtLocalName.Text = _plant.localname;
            txtSubsp.Text = _plant.subsp;
            txtVaryete.Text = _plant.variety;
            txtTypeExample.Text = _plant.typeexample;
            txtGrids.Text = string.Join(",",_plant.grid.Select(x=>x.name));
            txtlocalite.Text = _plant.localite;
            txtHabitat.Text = entities.habitat.Find(_plant.habitat).name.ToString();
            nmMin.Value = Convert.ToDecimal(_plant.minimum);
            nmMaks.Value = Convert.ToDecimal(_plant.maximum);
            dtPicker.Value = _plant.date.Value;
            rdbYes.Checked = _plant.endemism ?? false;


            // txtCoord.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.000000}", _plant.latitude) + ", " + String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.000000}", _plant.longitude);
            //txtCoord.Text = txtCoord.Text.Replace(", ", "").Length == 0 ? string.Empty: txtCoord.Text;
            txtCoord.Text = _plant.coordinates;
            //txtCoord_Validating(this, new CancelEventArgs());
            txtCollector.Text = _plant.collector;
            rchDetails.Text = _plant.explanation;
            txtDiagnose.Text = _plant.diagnose;
            if (_plant.district != null)
            {
                cmbIl.Text = _plant.district.city.name;
                cmbIlce.Text = _plant.district.name;
                cmbIlce.Enabled = true;
            }
            cmbGenus.Enabled = cmbSpecies.Enabled = true;

            generateSpeciesLabel();
        }

        private void StartInitialize()
        {
            _plantBLL = new PlantBLL();
            entities = _plantBLL.entities;
            FillSources();
        }
       // ManageableForm manageable;
        private void PlantForm_Load(object sender, EventArgs e)
        {
            if (!isUpdate && UserBLL.YekisiYok("Bitki Ekle"))
            {
                this.Close();
            }
            else if (isUpdate && UserBLL.YekisiYok("Bitki Görüntüle"))
            {
                this.Close();
            }
         //   manageable = new ManageableForm(this);
            ReLocatePanels();
        }
        private void ReLocatePanels()
        {
            panel2.Location = new Point(
                panel1.Width / 2 - panel2.Size.Width / 2,
                panel1.Height / 2 - panel2.Size.Height / 2);

            panelContainer.Location = new Point(
                tabPage1.Width / 2 - panelContainer.Size.Width / 2,panelContainer.Location.Y);
        }
        private void FillSources()
        {
            var list = entities.family.OrderBy(x => x.name).ToList();
            list.ForEach(x => x.name = x.name.ToUpper().Replace("İ","I"));
            cmbFamily.DataSource = list;
            cmbFamily.DisplayMember = "name";
            cmbFamily.ValueMember = "id";
            cmbFamily.SelectedIndex = -1;
            cmbIl.DataSource = entities.city.ToList();
            cmbIl.DisplayMember = "name";
            cmbIl.ValueMember = "id";
            cmbIl.SelectedIndex = -1;
            

            AutoCompleteSource(txtTypeExample, entities.plant.Select(x => x.typeexample).Distinct().ToArray());
            AutoCompleteSource(txtLocalName, entities.plant.Select(x => x.localname).Distinct().ToArray());
            AutoCompleteSource(txtSubsp, entities.plant.Select(x => x.subsp).Distinct().ToArray());
            AutoCompleteSource(txtVaryete, entities.plant.Select(x => x.variety).Distinct().ToArray());
            AutoCompleteSource(txtlocalite, entities.plant.Select(x => x.localite).Distinct().ToArray());
            AutoCompleteSource(txtDiagnose, entities.plant.Select(x => x.diagnose).Distinct().ToArray());
            AutoCompleteSource(txtCollector, entities.plant.Select(x => x.collector).Distinct().ToArray());

        }

        private async Task LoadComboBoxData()
        {
            if (cmbIl.DataSource == null)
            {
                cmbIl.DataSource = new List<string> { "Loading ..." };
                await Task.Run(() =>
                {
                    //Let's say you load items from a source and it's time consuming,
                    //Just for example
                    cmbIl.DataSource = entities.city.ToList();
                });
                cmbIl.DisplayMember = "name";
                cmbIl.ValueMember = "id";
            }
        }
        private void AutoCompleteSource(TextBox control, string[] arr)
        {
            var collection = new AutoCompleteStringCollection();
            collection.AddRange(arr);
            control.AutoCompleteCustomSource = collection;
        }

        private void fillPlantValues()
        {
            string familyName;
            string genusName;
            string myPlantName;
            if (_plant.issynonym ?? false)
            {
                var veri = entities.synonym.Find(_plant.speciesid);
                if (veri is null)
                {
                    errorProvider.SetError(cmbSpecies, "Tür boş bırakılamaz");
                    return;
                }
                familyName= veri.species.genus.family.name.ToUpper();
                genusName=  veri.species.genus.name;
                myPlantName = veri.name + " (sinonim)";
            }
            else
            {
                var veri = entities.species.Find(_plant.speciesid);
                if (veri is null)
                {
                    errorProvider.SetError(cmbSpecies, "Tür boş bırakılamaz");
                    return;
                }
               familyName=  veri.genus.family.name;
                genusName = veri.genus.name;
                myPlantName = veri.name;
            }

            cmbFamily.Text = familyName;
            cmbFamily_Leave(null, EventArgs.Empty);

            cmbGenus.Text = genusName;
            cmbGenus_Leave(null, EventArgs.Empty);
            cmbSpecies.Text = myPlantName;
          cmbSpecies_Leave(null, EventArgs.Empty);
        }

        private void cueTextBox5_Click(object sender, EventArgs e)
        {
            
        }
        private void txtGrids_Validating(object sender, CancelEventArgs e)
        {
            SetError(txtGrids, string.Empty);
            _plant.grid.Clear();
            button2.Enabled = true;
            if (txtGrids.Text.Trim() == string.Empty) return;
            //if(!_plantBLL.addGrids(_plant, txtGrids.Text.Trim()))
            //{
            //    SetError(txtGrids, "Girdiğiniz kareler doğru değildi. Her kareyi sadece virgül ile ayırın. (C5,A2,A3 gibi)");
            //    _plant.grid.Clear();
            //    button2.Enabled = false;
            //}
            foreach (var item in txtGrids.Text.Split(','))
            {
                grid grd = _plantBLL.findGrid(item);
                if (grd != null)
                {
                    _plant.grid.Add(grd);
                }
                else
                {
                    SetError(txtGrids, "Girdiğiniz kareler doğru değildi. Her kareyi sadece virgül ile ayırın. (C5,A2,A3 gibi)");
                    _plant.grid.Clear();
                    button2.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectGridsForm = new SelectGrids(txtGrids.Text.Split(','));
            selectGridsForm.ShowDialog();
            txtGrids.Text = string.Join(",", selectGridsForm.grids);
        }

        private void ResetColors()
        {
            foreach (Control c in panel2.Controls)
                c.BackColor = SystemColors.Control;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetColors();
            button1.BackColor = SystemColors.ActiveBorder;
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnKEKaydet_Click(object sender, EventArgs e)
        {
            if (_plant.speciesid == null)
            {
                ShowMessage.Error("Tür boş bırakılamaz");
                return;
            }
            if (_plantBLL.entities.plant.FirstOrDefault(x=>x.herbno== txtKod.Text.Trim() && x.id != _plant.id) != null)
            {
                ShowMessage.Error(txtKod.Text + " herbaryum numarası daha önce kullanılmış değiştirin");
                return;
            }
            _plant.localname = txtLocalName.Text;
            _plant.subsp = txtSubsp.Text;
            _plant.variety = txtVaryete.Text;
            _plant.endemism = rdbYes.Checked;
            _plant.typeexample = txtTypeExample.Text;
            _plant.localite = txtlocalite.Text;
            _plant.date = dtPicker.Value;
            _plant.minimum = Convert.ToDouble(nmMin.Value);
            _plant.maximum = Convert.ToDouble(nmMaks.Value);
            _plant.diagnose = txtDiagnose.Text;
            _plant.collector = txtCollector.Text;
            _plant.explanation = rchDetails.Text;
            _plant.herbno = txtKod.Text.Trim();
            _plant.coordinates = txtCoord.Text;

            //_plantBLL.addGrids(_plant, txtGrids.Text);
            _plant.habitat = _plantBLL.getHabitatId(txtHabitat.Text);

            city city = entities.city.FirstOrDefault(x => x.name == cmbIl.Text);
            if (city != null)
            {
                district district = entities.district.FirstOrDefault(x => x.name == cmbIlce.Text && x.cityid == city.id);
                district = district is null ? entities.district.FirstOrDefault(x=>x.cityid==city.id) : district;
                _plant.districtid = district.id;
            }
           // if (_plantBLL.Location!=null && _plantBLL.Location.Valid)
           // {
           //     _plant.latitude = Convert.ToDouble(_plantBLL.Location.DecLatitude);
            //    _plant.longitude = Convert.ToDouble(_plantBLL.Location.DecLongitude);
           // }

            if (!isUpdate)
            {
                _plantBLL.AddPlant(_plant);
                var satir = Tablo.NewRow();
                satir = SatiriDoldur(satir);
                Tablo.Rows.InsertAt(satir, 0);

                lblDurum.Text = _plant.herbno + " başarıyla eklendi!";
                Log.Debug( "[Yeni Bitki]: " + _plant.herbno, $"{_plant.herbno} kodlu {DateTime.Now.ToString()} tarihinde {UserBLL.ActiveUser.name} tarafından {cmbSpecies.Text} eklendi.\nEklenen bitkinin detayları:\n" + Log.PlantRowToJson(satir));
                StartInitialize();
                this._plant = new plant();
                var count = entities.plant.Count();
                if (count > 0)
                {
                    var list = entities.plant.OrderBy(x => x.id).ToList();
                    int sayi = Convert.ToInt32(entities.plant.OrderBy(x => x.id).ToList()[0].herbno.Substring(4)) + 1;
                    txtKod.Text = "KNYA" + string.Format("{0:D7}", sayi);
                }
                else
                    txtKod.Text = "KNYA" + string.Format("{0:D7}", 28001);
                YeniBitki();
                Temizle();
                timer1.Start();
                pnlBildirim.Visible = true;

            }
            else
            {
                _plantBLL.UpdatePlant(_plant);
                DataRow satir = GetRowOfPlant();
                SatiriDoldur(satir);
                satir.AcceptChanges();
                Log.Debug("[Güncellenen Bitki]: " + _plant.herbno, $"{_plant.herbno} kodlu {DateTime.Now.ToString()} tarihinde {UserBLL.ActiveUser.name} tarafından {cmbSpecies.Text} güncellendi.\nDeğişiklikler:\n"+Log.DiffBetweenTwoDict(Log.PlantRowToDict(satir),oldRow)+"\nGüncelleme sonrası:\n" + Log.PlantRowToJson(satir) +"\nGüncelleme öncesi:\n"+ Log.DictToJson(oldRow));
                timer1.Start();
                pnlBildirim.Visible = true;
                lblDurum.Text = _plant.herbno + " başarıyla güncellendi!";
            }
        }
        private void Temizle()
        {
            rdbNo.Checked = true;;
            txtGrids.Text = string.Empty;
            txtLocalName.Text = string.Empty;
            txtSubsp.Text = string.Empty;
            txtVaryete.Text = string.Empty;
            txtTypeExample.Text = string.Empty;
            cmbIl.Text=string.Empty;
            cmbIlce.Text = string.Empty;
            cmbGenus.Enabled = cmbSpecies.Enabled = cmbIlce.Enabled = false;
            txtlocalite.Text = string.Empty;
            txtHabitat.Text = string.Empty;
            nmMaks.Value = nmMin.Value = 0;
            dtPicker.Value = DateTime.Now;
            txtCoord.Text = string.Empty;
            txtCollector.Text = string.Empty;
            txtDiagnose.Text = string.Empty;
            rchDetails.Text = string.Empty;
            chkSwitch.Enabled = false;
            pboxHarita.Enabled = false;
            lblFamily.Text = string.Empty;
            lblGenus.Text = string.Empty;
            lblSpeciesName.Text = "Yeni Bitki";
            pboxResim.Image = null;
            lblPhoto.Visible = true;

        }
        private DataRow SatiriDoldur(DataRow satir)
        {
            satir["ID"] = _plant.id;
            satir["Kod"] = _plant.herbno;
            satir["Familya"] = cmbFamily.Text;
            satir["Cins"] = cmbGenus.Text;
            satir["Tür"] = cmbSpecies.Text.Replace(" (sinonim)", "").Trim();
            satir["Sinonim"] = _plant.issynonym ?? false ? "Evet" : "Hayır";
            satir["Kare"] = txtGrids.Text;
            satir["Türkçe İsim"] = _plant.localname;
            satir["Alt Tür"] = _plant.subsp;
            satir["Varyete"] = _plant.variety;
            satir["Endemik"] = _plant.endemism??false ? "Evet":"Hayır";
            satir["Tip Örneği"] = _plant.typeexample;
            satir["İl"] = cmbIl.Text;
            satir["İlçe"] = cmbIlce.Text;
            satir["Lokalite"] = _plant.localite;
            satir["Habitat"] = txtHabitat.Text;
            satir["Minimum"] = _plant.minimum;
            satir["Maksimum"] = _plant.maximum;
            satir["Tarih"] = (_plant.date ?? DateTime.Now).ToShortDateString();
            satir["Koordinatlar"] = txtCoord.Text;
            satir["Toplayıcı"] = _plant.collector;
            satir["Teşhis Eden"] = _plant.diagnose;
            satir["Açıklama"] = _plant.explanation;
            return satir;
        }


        int errorCount;
        void SetError(Control c, string message)
        {

            errorCount = message == string.Empty ? (errorCount > 0 ? errorCount - 1 : errorCount) : errorCount + 1;
            errorProvider.SetError(c, message);
            btnKEKaydet.Enabled = errorCount == 0;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void chkSwitch_CheckedChanged(object sender, EventArgs e)
        {
            return;
            if (!_plantBLL.Location.Valid) return;

            if (chkSwitch.Checked) // long latitude
                txtCoord.Text = _plantBLL.Location.DegLatitude + ", " + _plantBLL.Location.DegLongitude;
            else
                txtCoord.Text = $"{_plantBLL.Location.DecLatitude.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture)}, {_plantBLL.Location.DecLongitude.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture)}";

        }

        private void cmbFamily_Leave(object sender, EventArgs e)
        {
            string old = lblFamily.Text.Replace("Familya: ", "");
            string text = cmbFamily.Text.Trim();
            if (text == string.Empty ||text.Contains("DynamicProxies") ||old == text)
            {
                return;
            }
            int id = -1;
            family f = entities.family.Where(x => x.name == text || x.name == text.Replace("I","İ")).FirstOrDefault();
            if (f == null)
            {
                DialogResult dr = MessageBox.Show(cmbFamily.Text + " isminde bir familya bulunamadı yanlış yazdıysanız hayıra basın ve düzeltin. Yanlışlık yoksa kayıt oluşturulsun mu?", "Family Bulunamadı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { cmbGenus.Enabled = false; cmbSpecies.Enabled = false; return; }

                family newFamily = new family();
                newFamily.major = entities.major.ToList()[0];
                newFamily.name = text;
                entities.family.Add(newFamily);
                entities.SaveChanges();
                id = newFamily.id;
                Log.Debug( "[Yeni Familya]: " + text, "ID:" + id + "\nMajor:" + newFamily.major.name + "\n->Familya:" + newFamily.name);

            }
            else
            {
                id = f.id;
            }
            cmbGenus.DataSource = entities.genus.Where(x => x.familyid == id).OrderBy(x => x.name).ToList();
            cmbGenus.DisplayMember = "name";
            cmbGenus.ValueMember = "id";
            cmbGenus.Invalidate();
            cmbGenus.Enabled = true;
            cmbGenus.Text = "";
            cmbSpecies.Text = "";
            lblFamily.Text = "Familya: " + cmbFamily.Text;
            lblFamily.Visible = true;

            lblSpeciesName.Text = string.Empty;
        }

        
       
        private void cmbGenus_Leave(object sender, EventArgs e)
        {
            string old = lblGenus.Text.Replace("Cins: ", "");
            string text = cmbGenus.Text.Trim();
            if (text == string.Empty || text.Contains("DynamicProxies") || old == text)
            {
                return;
            }
            int id = -1;
            genus g = entities.genus.Where(x => x.name == text).FirstOrDefault();
            family f = entities.family.Where(x => x.name == cmbFamily.Text).FirstOrDefault();
            if (g == null)
            {
                DialogResult dr = MessageBox.Show(cmbGenus.Text + " isminde bir cins bulunamadı yanlış yazdıysanız hayıra basın ve düzeltin. Yanlışlık yoksa kayıt oluşturulsun mu?", "Cins Bulunamadı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { cmbSpecies.Enabled = false; return; }

                genus newGenus = new genus();
                newGenus.family = f;
                newGenus.name = text;
                entities.genus.Add(newGenus);
                entities.SaveChanges();
                id = newGenus.id;
                Log.Debug( "[Yeni Cins]: " + text, "ID:" + id + "\nMajor:" + f.major.name + "\nFamilya:" + f.name + "\n->Cins:" + text);
            }
            else
            {
                id = g.id;
            }

            var list = entities.synonym.Where(x => x.species.genusid == id).ToList();
            var list2 = entities.species.Where(x => x.genusid == id).Select(x=>x.name).ToList();
            List<string> turler = new List<string>();
            int turId = -1;
            foreach (synonym sinonim in list)
            {
                if (sinonim.speciesid != turId)
                {
                    turId = Convert.ToInt32(sinonim.speciesid);
                    turler.Add(sinonim.species.name);
                }
                turler.Add(sinonim.name + " (sinonim)");
            }
            foreach (string tur in list2)
            {
                if (turler.IndexOf(tur) == -1)
                    turler.Add(tur);
            }
            turler.Sort((x, y) => string.Compare(x, y));

            _plant.speciesid = null;
            cmbSpecies.DataSource = turler;
            cmbSpecies.Invalidate();
            cmbSpecies.Enabled = true;
            cmbSpecies.Text = "";
            lblGenus.Visible = true;
            lblGenus.Text = "Cins: " + cmbGenus.Text;
            lblSpeciesName.Text = string.Empty;
        }
        private void cmbSpecies_Leave(object sender, EventArgs e)
        {
            string text = cmbSpecies.Text.Trim().Replace(" (sinonim)", "");
            if(text == string.Empty || text.Contains("DynamicProxies"))
            {
                _plant.speciesid = null;
                return;
            }
            int id = -1;
            genus g = entities.genus.Where(x => x.name == cmbGenus.Text).FirstOrDefault();

            species s = entities.species.Where(x => x.name == text).FirstOrDefault();
            synonym sy = entities.synonym.Where(x => x.name == text).FirstOrDefault();

            _plant.issynonym = false;

            if (s != null)
            {
                id = s.id;
            }
            else if (sy != null)
            {
                id = sy.id;
                _plant.issynonym = true;
            }
            else
            {
                DialogResult dr = MessageBox.Show(cmbSpecies.Text + " isminde bir tür bulunamadı yanlış yazdıysanız hayıra basın ve düzeltin. Yanlışlık yoksa kayıt oluşturulsun mu?", "Tür Bulunamadı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }

                species newSpecies = new species();
                newSpecies.genus = g;
                newSpecies.name = text;
                entities.species.Add(newSpecies);
                entities.SaveChanges();
                id = newSpecies.id;
                Log.Debug( "[Yeni Tür]: " + text, "ID:" + id + "\nMajor:" + newSpecies.genus.family.major.name+ "\nFamilya:" + newSpecies.genus.family.name + "\nCins:" + newSpecies.genus.name+ "\n->Cins:" + text);

            }

            _plant.speciesid = id;

            plantName = cmbSpecies.Text;
            generateSpeciesLabel();
        }
        private void generateSpeciesLabel()
        {
            if (_plant.speciesid == null) { lblSpeciesName.Text = string.Empty; return; };

            string subsp = txtSubsp.Text.Trim() != string.Empty ?" subsp. "+txtSubsp.Text.Trim():string.Empty;
            string var = txtVaryete.Text.Trim() != string.Empty ?" var. "+ txtVaryete.Text.Trim():string.Empty;
            lblSpeciesName.Text = $"{plantName}{subsp}{var}";

        }

        private void txtHabitat_TextChanged(object sender, EventArgs e)
        {
            if (txtHabitat.Text.Length == 3)
            {
                AutoCompleteSource(txtHabitat, entities.habitat.Where(x => x.name.StartsWith(txtHabitat.Text)).Select(x => x.name).Distinct().ToArray());
            }
        }

        

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            city selectedCity = entities.city.Where(x => x.name == cmbIl.Text).FirstOrDefault();
            cmbIlce.Enabled = selectedCity != null;
            if (selectedCity == null)
                return;

            cmbIlce.DataSource = entities.district.Where(x => x.cityid == selectedCity.id).ToList();
            var list = entities.district.Where(x => x.cityid == selectedCity.id).ToList();
            cmbIlce.DisplayMember = "name";
            cmbIlce.ValueMember = "id";
            cmbIlce.Text = "";

            foreach (district item in cmbIlce.Items)
            {
                if (item.name == "MERKEZ")
                {
                    cmbIlce.SelectedItem = item;
                    break;
                }
            }
        }

        private void PlantForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }
        

        private void PlantForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] pic = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (pic != null)
                {
                    lblPhoto.Visible = false;
                    pboxResim.Image = Image.FromFile(pic[0]);
                    _plant.photo = System.IO.File.ReadAllBytes(pic[0]);
                }
            }
            catch (Exception)
            {
            }
        }

        private void lblPhoto_Click(object sender, EventArgs e)
        {
            SelectImageFromDialog();
        }
        private void SelectImageFromDialog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Resim seçin";
            open.RestoreDirectory = true;
            open.Filter = "Resim Dosyaları(*.jpg; *.jpeg; *.gif; *.bmp; *png)|*.jpg; *.jpeg; *.gif; *.bmp; *png";
            if (open.ShowDialog() == DialogResult.OK)
            {

                lblPhoto.Visible = false;
                pboxResim.Image = new Bitmap(open.FileName);
                _plant.photo = System.IO.File.ReadAllBytes(open.FileName);
            }
        }
        private void değiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectImageFromDialog();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _plant.photo = null;
            lblPhoto.Visible = true;
        }
        

        private void pboxResim_DoubleClick(object sender, EventArgs e)
        {
            _plantBLL.openImage(pboxResim.Image);
        }

        private void PlantForm_SizeChanged(object sender, EventArgs e)
        {
            ReLocatePanels();
        }

        private void txtCoord_Validating(object sender, CancelEventArgs e)
        {
            return;
            SetError(txtCoord, string.Empty);
            if (txtCoord.Text == string.Empty) return;
            _plantBLL.Location = new Class.BLL.Location(txtCoord.Text);
            if (!(pboxHarita.Enabled= chkSwitch.Enabled = _plantBLL.Location.Valid))
            {
                string errorMsg = "Yalnızca aşağıdaki formatların biri ile giriş yapabilirsiniz:\n21° 16' 674S, 27° 30' 318E\n21 16 674S, 27 30 318E\n9.182, -39.140625\n9.182 / -39.140625\n9.182,-39.140625\n9.182 -39.140625";
                SetError(txtCoord, errorMsg);
                return;
            }
            chkSwitch.Checked = _plantBLL.Location.mode == Class.BLL.Location.Mode.Degree;
        }

        private void txtSubsp_TextChanged(object sender, EventArgs e)
        {
            generateSpeciesLabel();
        }

        private void txtVaryete_TextChanged(object sender, EventArgs e)
        {

            generateSpeciesLabel();
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {   if(sayac==5)
            {
                pnlBildirim.Visible = true;
                sayac = 0;
                timer1.Stop();
                return;
            }  
            pnlBildirim.Visible = !pnlBildirim.Visible;
            sayac++;
        }

        private void txtKod_TextChanged(object sender, EventArgs e)
        {

        }

        private void pboxHarita_Click(object sender, EventArgs e)
        {
            
            foreach (var item in Login.tabbedApp.Tabs)
            {
                if (item.Caption == "Harita "+txtCoord.Text)
                {
                    Login.tabbedApp.SelectedTab = item;
                    return;
                }
            }
            var form = new Harita($"https://www.google.com/maps/search/{txtCoord.Text}/");
            form.Text = "Harita " + txtCoord.Text;
            Login.tabbedApp.Tabs.Add(new EasyTabs.TitleBarTab(Login.tabbedApp)
            {
                Content = form
            });
            Login.tabbedApp.SelectedTabIndex = Login.tabbedApp.Tabs.Count - 1;
        }
    }
}

