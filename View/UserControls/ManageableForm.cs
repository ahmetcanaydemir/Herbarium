using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.UserControls
{
    public partial class ManageableForm : Form
    {
        class FormState
        {
            public Size Size;
            public Point Location;
            public bool FullScreen;
            public bool Maximize;
        }
        public ManageableForm()
        {
            InitializeComponent();
            Shown += ManageableForm_Shown;
            FormClosing += ManageableForm_FormClosing;
        }

        

        string filePath;
        BackgroundWorker backgroundWorker;
        readonly string path = Herbarium.Class.Constants.AppDataKonum + "Form\\";
        private void ManageableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormStates();
        }

        private void ManageableForm_Shown(object sender, EventArgs e)
        {
            LoadFormStates();
        }
        public void LoadFormStates()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (se, ev) =>
            {
                filePath = path + Name.ToString() + ".json";
                if (!File.Exists(filePath)) return;
                string json = File.ReadAllText(filePath);
                ev.Result = Newtonsoft.Json.JsonConvert.DeserializeObject<FormState>(json);
            };
            backgroundWorker.RunWorkerCompleted += (se, ev) =>
            {
                if (ev.Result is null) return;
                FormState state = (FormState)ev.Result;
                FormBorderStyle = state.FullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
                WindowState = state.FullScreen ? FormWindowState.Maximized : FormWindowState.Normal;

                if (state.Maximize)
                    WindowState = FormWindowState.Maximized;
                else
                {
                    Size = state.Size;
                    Location = state.Location;
                }
            };
            if (backgroundWorker.IsBusy)
                return;
            backgroundWorker.RunWorkerAsync();
        }
        public void SaveFormStates()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            filePath = path + Name.ToString() + ".json";
            FormState state = new FormState();

            state.FullScreen = FormBorderStyle == FormBorderStyle.None;

            state.Maximize = WindowState == FormWindowState.Maximized;
            state.Size = Size;
            state.Location = Location;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        private void ManageableForm_Load(object sender, EventArgs e)
        {

        }
    }
}
