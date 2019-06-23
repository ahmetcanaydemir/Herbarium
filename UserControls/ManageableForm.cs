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

namespace Herbarium
{
    public partial class ManageableForm
    {
        class FormState
        {
            public Size Size;
            public Point Location;
            public bool FullScreen;
            public bool Maximize;
        }
        Form form;
        public ManageableForm(Form form)
        {
            this.form = form;
            form.Shown += ManageableForm_Shown;
            form.FormClosing += ManageableForm_FormClosing;
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
                filePath = path + form.Name.ToString() + ".json";
                if (!File.Exists(filePath)) return;
                string json = File.ReadAllText(filePath);
                ev.Result = Newtonsoft.Json.JsonConvert.DeserializeObject<FormState>(json);
            };
            backgroundWorker.RunWorkerCompleted += (se, ev) =>
            {
                if (ev.Result is null) return;
                FormState state = (FormState)ev.Result;
                form.FormBorderStyle = state.FullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
                form.WindowState = state.FullScreen ? FormWindowState.Maximized : FormWindowState.Normal;

                if (state.Maximize)
                    form.WindowState = FormWindowState.Maximized;
                else
                {
                    form.Size = state.Size;
                    form.Location = state.Location;
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

            filePath = path + form.Name.ToString() + ".json";
            FormState state = new FormState();

            state.FullScreen = form.FormBorderStyle == FormBorderStyle.None;

            state.Maximize = form.WindowState == FormWindowState.Maximized;
            state.Size = form.Size;
            state.Location = form.Location;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

    }
}
