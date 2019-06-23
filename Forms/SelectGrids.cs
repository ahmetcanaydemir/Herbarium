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
    public partial class SelectGrids : Form
    {
        public SelectGrids()
        {
            InitializeComponent();
        }
        public SelectGrids(string[] gridArr)
        {
            InitializeComponent();
            grids.Clear();
            foreach(var item in gridArr)
            {
                if (item == "Seçmek için tıklayın" ||item ==string.Empty) return;
                var grid = item.Trim().ToUpper();
                int numberY = Array.IndexOf(letters, grid[0])+1;
                int numberX = Convert.ToInt32(grid.Substring(1));
                Label lbl = new Label()
                {
                    AutoSize = false,
                    Size = new Size(60, 60),
                    Location = new Point(29 + ((numberX - 1) * 60), 31 + ((numberY - 1) * 60)),
                    BackColor = Color.PaleGreen,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 14f),
                    Text = letters[numberY - 1] + "" + numbers[numberX - 1]
                };
                grids.Add(lbl.Text);
                lbl.Click += (_, args) =>
                {
                    grids.Remove(lbl.Text);
                    pictureBox1.Controls.Remove(lbl);
                };
                pictureBox1.Controls.Add(lbl);
            }
        }

        static char[] letters = { 'A', 'B', 'C' };
        static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        public List<string> grids = new List<string>();
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int numberY =0;
            if(e.Y >32)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (numberY < e.Y-32)
                        numberY += 60;
                    else
                    {
                        numberY = i;
                        break;
                    }
                }
            }
            int numberX = 0;
            if(e.X> 32)
            {
               for(int i =0; i <= 10; i++)
                {
                    if (numberX < e.X-32)
                        numberX += 60;
                    else
                    {
                        numberX = i;
                        break;
                    }
                }
            }
            if (numberY > 3 || numberX > 10)
                return;
            Label lbl = new Label()
            {
                AutoSize = false,
                Size = new Size(60, 60),
                Location = new Point(29 + ((numberX-1) * 60), 31 + ((numberY-1) * 60)),
                BackColor = Color.PaleGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14f),
                Text = letters[numberY - 1] + "" + numbers[numberX - 1]
            };
            grids.Add(lbl.Text);
            lbl.Click += (_, args) =>
            {
                grids.Remove(lbl.Text);
                pictureBox1.Controls.Remove(lbl);
             };
            pictureBox1.Controls.Add(lbl);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectGrids_Load(object sender, EventArgs e)
        {

        }
    }
}
