using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace concentracia
{
    public partial class Form1 : Form
    {
        Panel panel1 = new Panel();
        PictureBox[,] pictureBoxes = new PictureBox[10, 10];
        int width = 15;
        int height = 3;

        public Form1()
        {
            InitializeComponent();
            settingWindow();
            createPole();
        }

        private void settingWindow()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            menuStrip1.BackColor = Color.LightCyan;
            panel1.Dock = DockStyle.Fill;
            panel1.BackColor = Color.LightCoral;

            this.Controls.Add(panel1);
        }

        private void createPole()
        {
            panel1.Controls.Clear();

            pictureBoxes = new PictureBox[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int sizeX = 150;
                    int sizeY = 80;

                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Location = new Point(30 + (sizeX + 10) * i, 50 + (sizeY + 10) * j);
                    pictureBoxes[i, j].Size = new Size(sizeX, sizeY);
                    pictureBoxes[i, j].Name = i.ToString() + j.ToString();
                    pictureBoxes[i,j].BackColor = Color.LightCyan;
                    pictureBoxes[i, j].BorderStyle = BorderStyle.Fixed3D;

                    panel1.Controls.Add(pictureBoxes[i,j]);
                }
            }
        }
    }
}