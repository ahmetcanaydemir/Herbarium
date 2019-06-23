using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium.Class
{
  public class ManagebleForm: Form
    {
        string filePath;
        BackgroundWorker backgroundWorker;
        public ManagebleForm() {
            this.FormClosing += ManagebleForm_FormClosing;
            this.Shown += ManagebleForm_Load;
        }

        private void ManagebleForm_Load(object sender, EventArgs e)
        {
            
            LoadFormStates();
        }

        private void ManagebleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormStates();
        }

        readonly string path = Constants.AppDataKonum + "Form\\";
        public void LoadFormStates()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (se, ev) =>
            {
                filePath = path + Name.ToString() + ".json";
                if (!File.Exists(filePath)) return;
                string json = File.ReadAllText(filePath);
                ev.Result= JsonConvert.DeserializeObject<FormState>(json);
            };
            backgroundWorker.RunWorkerCompleted += (se, ev) =>
            {
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
            string json = JsonConvert.SerializeObject(state, Formatting.Indented);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        private void InitializeComponent()
        {
        }
    }
    class FormState
    {
        public Size Size;
        public Point Location;
        public bool FullScreen;
        public bool Maximize;
    }
}
