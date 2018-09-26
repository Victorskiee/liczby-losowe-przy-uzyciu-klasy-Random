using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace losowa_gra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            label5.Location = new Point(this.Width / 2 - 250, this.Height / 2 - 390);
            button1.Size = new System.Drawing.Size(250, 80);
            button1.Location = new Point(this.Width / 2 - 200, this.Height/2 - 250);
            button2.Size = new System.Drawing.Size(250, 80);
            button2.Location = new Point(this.Width / 2 - 200, this.Height / 2 - 140);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random miejsce = new Random();
            Point punkt = new Point();

            int x = miejsce.Next(50, this.Width - 150);
            int y = miejsce.Next(100, this.Height - 150);

            punkt = new Point(x, y);

            pictureBox1.Location = punkt;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Random miejsce = new Random();
            Point punkt = new Point();

            int x = miejsce.Next(50, this.Width - 150);
            int y = miejsce.Next(100, this.Height - 150);

            punkt = new Point(x, y);

            pictureBox1.Location = punkt;

            int licznik = 1;
            int wynik = licznik + Convert.ToInt32(label2.Text);
            if ((wynik % 5 == 0) && (timer1.Interval >= 600))
            {
                timer1.Interval = timer1.Interval - 200;
            }
            label2.Text = Convert.ToString(wynik);

            timer1.Stop();
            timer1.Start();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = MousePosition.X;
            int y = MousePosition.Y;

            if ((x < pictureBox1.Left) || (x > (pictureBox1.Left + pictureBox1.Width))
              || (y < pictureBox1.Top) || (y > (pictureBox1.Top + pictureBox1.Height)))
            {
                int licznik = 1;
                int wynik = licznik + Convert.ToInt32(label4.Text);
                label4.Text = Convert.ToString(wynik);

                if (wynik >= 10)
                {
                    timer1.Stop();
                    MessageBox.Show("Przegrana! Osiągnąłeś wynik: " + label2.Text);

                    pictureBox1.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label2.Text = "0";
                    label3.Visible = false;
                    label4.Visible = false;
                    label4.Text = "0";

                    label5.Text = "Jeszcze raz?";
                    label5.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            label5.Visible = false;

            pictureBox1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;

            pictureBox1.Location = new Point(this.Width / 2 - 80, this.Height / 2 - 100);
            label1.Location = new Point(this.Width / 2 - 390);
            label2.Location = new Point(this.Width / 2 - 220);
            label3.Location = new Point(this.Width / 2 + 150);
            label4.Location = new Point(this.Width / 2 + 350);

            timer1.Interval = 1200;
            timer1.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
