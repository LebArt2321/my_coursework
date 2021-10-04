using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Finalochka
{
    
    public partial class Form1 : Form
    {
        PictureBox[,] pic1 = new PictureBox[1000, 1000];
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            string q;
            q = textBox1.Text;
            if (textBox1.Text == "2" || textBox1.Text == "3")
                MessageBox.Show("Решений нет");


            if (textBox1.Text != "")
            {
                int N = Int32.Parse(q);
                int ost, third = -1, j = 1, pyat = -1, cnt = 5;
                int[] a = new int[N + 1];
                ost = N % 12;
                for (int i = 2; i <= N; i += 2)
                {
                    a[j] = i;
                    j++;
                }
                if (ost == 3 || ost == 9)
                {
                    a[j] = 2;
                    for (int k = 1; k < j - 1; k++)
                        a[k] = a[k + 1];
                    a[j - 1] = a[j];

                }
                for (int i = 1; i <= N; i += 2)
                {
                    a[j] = i;
                    j++;
                    if (a[j - 1] == 5)
                        pyat = j - 1;
                }
                if (ost == 8)
                {
                    j = N / 2 + 1;
                    if (N % 2 != 0)
                        j += 2;
                    for (j = j; j <= N; j++)
                    {
                        third = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = third;
                        j++;
                    }
                }
                if (ost == 2 && N >= 3)
                {
                    third = a[N / 2 + 1];
                    a[N / 2 + 1] = a[N / 2 + 2];
                    a[N / 2 + 2] = third;
                    if (N >= 5)
                    {
                        a[N] = 5;
                    }
                    for (int i = pyat; i < N; i++)
                        a[i] = a[i + 1];
                    a[N - 1] = N - 1;
                }
                if (ost == 3 || ost == 9)
                {
                    a[N - 1] = 1;
                    a[N] = 3;
                    j = N / 2 + 1;
                    for (int k = j; k < N - 1; k++)
                    {
                        a[k] = cnt;
                        cnt += 2;
                    }

                }
                for (int i = 1; i <= N; i++)
                {
                    for (int l = 1; l <= N; l++)
                    {

                        PictureBox pic2 = new PictureBox();
                        if (a[i] == l)
                            pic2.Image = Properties.Resources.ферзь22;
                        else pic2.Image = Properties.Resources.la;

                        if (N > 9 && i == 1 && l == 1) pic1[i, l].Image = Properties.Resources.la;
                        if (N == 2 && i != 1 && l != 2)
                        {
                            pic2.Image = Properties.Resources.la;
                        }
                        if (N == 3 && i == 2 && l == 1)
                            pic2.Image = Properties.Resources.la;
                        if (N == 3 && i == 3 && l == 3)
                            pic2.Image = Properties.Resources.la;
                        pic2.BorderStyle = BorderStyle.FixedSingle;
                        pic2.SizeMode = PictureBoxSizeMode.AutoSize;
                        pic2.Location = new Point(pic2.Location.X + (i * 100), pic2.Location.Y + (l * 100));
                        pic1[i, l] = pic2;
                        Controls.Add(pic1[i, l]);
                        //Application.Restart();
                        if ((N % 12 == 3 || N % 12 == 9) && (N>20))
                            pic1[1, 2].Image = Properties.Resources.la;
                    }
                }
                

            }
            
            
        }

        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2.FlatStyle = FlatStyle.Flat;
            //button2.FlatAppearance.BorderSize = 0;
            Application.Restart();
        }

    }
}
