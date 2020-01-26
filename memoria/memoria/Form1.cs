using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memoria
{
    public partial class Form1 : Form
    {
        static Random rnd = new Random();
        bool hasonlit = true;
        char[] valid = { 'b', 'b', 'g', 'g', 'm', 'm' };
        PictureBox[] kartyak;

        int k1 = -1;
        int k2 = -1;

        public Form1()
        {
            Osszekever();
            InitializeComponent();
            kartyak = new PictureBox[valid.Length];
            this.AutoSize = true;

            for (int i = 0; i < kartyak.Length; i++)
            {
                kartyak[i] = new PictureBox();

                kartyak[i].SetBounds(i * 200 + i * 10, 0, 200, 200);
                kartyak[i].Image = Properties.Resources.kartyahatter;

                kartyak[i].Click += KartyahatterClick;

                this.Controls.Add(kartyak[i]);


            }
        }

        private void KartyahatterClick(object sender, EventArgs e)
        {
            hasonlit = !hasonlit;
            int i = Array.IndexOf(kartyak, (sender as PictureBox));

            if (valid[i] == 'b') (sender as PictureBox).Image = Properties.Resources.Brady;
            if (valid[i] == 'g') (sender as PictureBox).Image = Properties.Resources.Gronk;
            if (valid[i] == 'm') (sender as PictureBox).Image = Properties.Resources.Michel;

            if (!hasonlit) k1 = i;
            else
            {
                k2 = i;
                MessageBox.Show(valid[k1] == valid[k2] ? "ügyi" : "nope");



                if (hasonlit)
                {
                    if (valid[k1] == valid[k2])
                    {
                        kartyak[k1].Dispose();
                        kartyak[k2].Dispose();
                    }
                    else
                    {
                        kartyak[k1].Image = Properties.Resources.kartyahatter;
                        kartyak[k2].Image = Properties.Resources.kartyahatter;
                    }

                }
            }
        }

        private void Osszekever()
        {
            for (int i = 0; i < 6; i++)
            {
                int x = rnd.Next(valid.Length);
                int y = rnd.Next(valid.Length);

                char cs = valid[x];
                valid[x] = valid[y];
                valid[y] = cs;
            }
        }
    }
}
