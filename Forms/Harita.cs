using System;
using System.Windows.Forms;

namespace Herbarium.Forms
{
    public partial class Harita : Form
    {
        public Harita()
        {
            InitializeComponent();
        }
        public Harita(string url)
        {
            InitializeComponent();

            try
            {
                webBrowser1.Navigate(url);
            }
            catch (Exception ex)
            {
                Class.Log.Error("Harita yüklenemedi", ex);
            }
        }

        private void Harita_Load(object sender, EventArgs e)
        {

        }
    }
}
