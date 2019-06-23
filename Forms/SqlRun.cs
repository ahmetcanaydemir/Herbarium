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
    public partial class SqlRun : Form
    {
        public SqlRun()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        herbariumEntities entities = new herbariumEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            using (var entities = new herbariumEntities())
            {
                try
                {
                    entities.Database.ExecuteSqlCommand(richTextBox1.Text);

                    label2.Text = "Komut başarı ile işlendi!";
                }
                catch(Exception ex)
                {
                    label2.Text = "HATA: " + ex.Message;
                    Class.Log.Error("[SQL Çalıştırma Hatası]", ex);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    richTextBox1.Text = @"/****** Tüm bitkileri silme kodu  ******/
DELETE FROM map_plant_grid;
DELETE FROM plant;
DBCC CHECKIDENT ('plant', RESEED, 0);";
                    break;
                case 1:
                    richTextBox1.Text = @"/****** Lokasyon sütunu ekleme kodu  ******/
ALTER TABLE plant ADD coordinates nvarchar(255);";
                    break;
                default:
                    break;
            }
        }

        private void SqlRun_Load(object sender, EventArgs e)
        {

        }
    }
}
