using concentracia.Properties;
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
        int width = 4;
        int height = 4;
        int rachet = 0;

        int[] photoMassiv = new int[2];
        PictureBox[] para = new PictureBox[2];

        Random random = new Random();

        int chetWin = 0;
        int delenie = 0;

        public Form1()
        {
            InitializeComponent();

            toolStripComboBox1.SelectedIndex = 0;

            Activate();
        }

        private void Activate()
        {
            settingWindow();
            createPole();
            addPhoto();
            scrit();
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
                    pictureBoxes[i, j].BackColor = Color.LightCyan;
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
            int xx = 0; //по очереди проходит
            int yyy = 1; //цифры для массива
            delenie = (width * height) / 2; //половина
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
            photoMassiv = new int[width * height]; //новый массив

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    photoMassiv[xx] = yyy; //доабвляем числа
                    yyy += 1; //доавбление одного
                    xx += 1;

                    if (yyy == delenie + 1) //если прошла половина то это
                    {
                        yyy = 1;
                    }        
                }
            }

            for (int a = photoMassiv.Length - 1; a >= 0; a--) //рандом
            {
                int b = random.Next(a);
                int c = photoMassiv[a];
                photoMassiv[a] = photoMassiv[b];
                photoMassiv[b] = c;
            }


            int chet = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    pictureBoxes[i, j].Tag = photoMassiv[chet];
                    chet += 1;
                }
            }
        }

        private void scrit()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pictureBoxes[i, j].Image = Resources.bc;

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
            string resourceName = pictureBox.Tag.ToString();

            pictureBox.Image = Properties.Resources.ResourceManager.GetObject(resourceName) as Image;
            para[rachet++] = (pictureBox);
            pictureBox.Enabled = false;

            if (rachet >= 2)
            {
                int index1 = Convert.ToInt32(para[0].Tag);
                int index2 = Convert.ToInt32(para[1].Tag);


                if (index1 != index2)
                {
                    MessageBox.Show("Не совпадают!!!!!!!!!!!!!!!");
                    para[0].Image = Resources.bc;
                    para[1].Image = Resources.bc;
                    para[0].Enabled = true;
                    para[1].Enabled = true;
                }

                else
                {
                    MessageBox.Show("Совпадают.");
                    checkWin();
                    pictureBox.Enabled = false;
                }
                  
                Array.Clear(para, 0, para.Length);
                rachet = 0;

                
            }
        }
        private void checkWin()
        {
            chetWin++;
            if (chetWin == delenie)
            {
                MessageBox.Show("ТЫ победил");
                Activate();
            }

        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activate();
        }


        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                width = 4;
                height = 4;
            }
            if (toolStripComboBox1.SelectedIndex == 1)
            {
                width = 6;
                height = 6;
            }
            if (toolStripComboBox1.SelectedIndex == 2)
            {
                width = 8;
                height = 8;
            }

            Activate();
        }
    }
}