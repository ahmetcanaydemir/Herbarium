using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
namespace Herbarium.Forms
{
    public partial class Container : TitleBarTabs
    {
        ManageableForm manageable;
        public static MainForm MainForm;
        public Container()
        {
            InitializeComponent();
            manageable = new ManageableForm(this);
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
            //CreateTab();
            this.FormClosing += (se, ev) => {
                MainForm.Kapat(); Login.ApplicationContext.Dispose(); Login.Kapat(); };
            }
        public override TitleBarTab CreateTab()
        {
            var form = new PlantForm();
            form.Tablo = MainForm.Table;
            form.Text = "Bitki Ekle";
            
            return new TitleBarTab(this)
            {
                Content = form
            };
        }
        private void Container_Load(object sender, EventArgs e)
        {

        }
    }
}
