using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace concentracia
{
    public partial class Form1 : Form
    {
        Panel panel1 = new Panel();
        PictureBox[,] pictureBoxes = new PictureBox[10, 10];
        int width = 6;
        int height = 6;
        int rachet = 0;

        int[] photoMassiv = new int[2];
        PictureBox[] para = new PictureBox[2];

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            settingWindow();
            createPole();
            addPhoto();
            //scrit();
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
            int cshet = 0;

            pictureBoxes = new PictureBox[width, height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int sizeX = 60;
                    int sizeY = 60;


                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Location = new Point(30 + (sizeX + 10) * j, 50 + (sizeY + 10) * i);
                    pictureBoxes[i, j].Size = new Size(sizeX, sizeY);
                    pictureBoxes[i, j].Name = i.ToString() + j.ToString();
                    pictureBoxes[i,j].BackColor = Color.LightCyan;
                    pictureBoxes[i, j].BorderStyle = BorderStyle.Fixed3D;
                    pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[i, j].Click += new EventHandler(clickPicture);
                    pictureBoxes[i, j].Tag = cshet;

                    panel1.Controls.Add(pictureBoxes[i,j]);


                    cshet += 1;
                }
            }
        }

        private void addPhoto()
        {
            int xx = 0;
            int yyy = 1;
            int delenie = (width * height) / 2;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
            photoMassiv = new int[width * height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    photoMassiv[xx] = yyy;
                    yyy += 1;
                    xx += 1;

                    if (yyy == delenie + 1)
                    {
                        yyy = 1;
                    }        
                }
            }

            for (int a = photoMassiv.Length - 1; a >= 0; a--)
            {
                int b = random.Next(a);
                int c = photoMassiv[a];
                photoMassiv[a] = photoMassiv[b];
                photoMassiv[b] = c;
            }

            int qwer = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pictureBoxes[i, j].Image = Image.FromFile($"C:\\Users\\student1\\Desktop\\Новая папка\\{photoMassiv[qwer]}.jpg");
                    qwer += 1;
                }
            }
        }

        private void scrit()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pictureBoxes[i, j].Image = Image.FromFile("C:\\Users\\student1\\Downloads\\bc.png");

                }
            }
        }

        private void clickPicture(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;

           openPhoto( pictureBox );
        }

        private void openPhoto(object sender)
        {
            
            var pictureBox = sender as PictureBox;
            pictureBox.Image = Image.FromFile($"C:\\Users\\student1\\Desktop\\Новая папка\\{photoMassiv[Convert.ToInt32(pictureBox.Tag)]}.jpg");

            para[rachet++] = (pictureBox);

            if (rachet >= 2)
            {
                int index1 = Convert.ToInt32(para[0].Tag);
                int index2 = Convert.ToInt32(para[1].Tag);

                photoMassiv 

                if (index1 == index2)
                    MessageBox.Show("Изображения совпадают!");
                else
                    MessageBox.Show("различны.");
                    //para[0].Image = Image.FromFile($"C:\\Users\\student1\\Desktop\\Новая папка\\{photoMassiv[Convert.ToInt32(para[0].Tag)]}.jpg");
                    //para[1].Image = Image.FromFile($"C:\\Users\\student1\\Desktop\\Новая папка\\{photoMassiv[Convert.ToInt32(para[1].Tag)]}.jpg");

                Array.Clear(para, 0, para.Length);
                rachet = 0;
            }
        }

    }
}