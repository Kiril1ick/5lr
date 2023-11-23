using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5lr
{
    public partial class Form1 : Form
    {
        double ver1;
        double ver2;
        double ver3;
        double ver4;
        double ver5;
        double ver6;
        double ver7;
        double ver8;
        int isp;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                raschet();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_DoubleClick(object sender, EventArgs e)
        {
            var form = new Form2();
            form.ShowDialog();
            form.Dispose();
        }

        private void panel8_DoubleClick(object sender, EventArgs e)
        {
            var form = new Form3();
            form.ShowDialog();
            form.Dispose();
        }

        private void raschet()
        {
            ver1 = double.Parse(textBox1.Text);
            ver2 = double.Parse(textBox2.Text);
            ver3 = double.Parse(textBox3.Text);
            ver4 = double.Parse(textBox4.Text);
            ver5 = double.Parse(textBox5.Text);
            ver6 = double.Parse(textBox6.Text);
            ver7 = double.Parse(textBox7.Text);
            ver8 = double.Parse(textBox8.Text);
            isp = int.Parse(textBox9.Text);

            Random rnd1 = new Random();
            Random rnd2 = new Random(rnd1.Next());
            Random rnd3 = new Random(rnd2.Next());
            Random rnd4 = new Random(rnd3.Next());
            Random rnd5 = new Random(rnd4.Next());
            Random rnd6 = new Random(rnd5.Next());
            Random rnd7 = new Random(rnd6.Next());
            Random rnd8 = new Random(rnd7.Next());

            bool b1;
            bool b2;
            bool b3;
            bool b4;
            bool b5;
            bool b6;
            bool b7;
            bool b8;

            double count = 0;


            double verParallel = 1 - (1-ver1*ver6)*(1-ver2*ver7)*(1-ver3*ver8);
            double verPosled = (1 - (1 - ver1) * (1 - ver2) * (1 - ver3)) * (1 - (1 - ver6) * (1 - ver7) * (1 - ver8));

            double verBez4 = ver4 * verPosled + (1 - ver4) * verParallel;
            double verBez5 = ver5 * verBez4 + (1 - ver5) * verBez4;

            label12.Text = verBez5.ToString();

            for (int i = 0; i < isp; i++)
            {
                b1 = rnd1.NextDouble() <= ver1;
                b2 = rnd2.NextDouble() <= ver2;
                b3 = rnd3.NextDouble() <= ver3;
                b4 = rnd4.NextDouble() <= ver4;
                b5 = rnd5.NextDouble() <= ver5;
                b6 = rnd6.NextDouble() <= ver6;
                b7 = rnd7.NextDouble() <= ver7;
                b8 = rnd8.NextDouble() <= ver8;

                if ((b1 && b4 && b5 && b8) || (b1 && b4 && b7) || (b1 && b6) || (b2 && b5 && b8) || (b2 && b7) || (b2 && b4 && b6) || (b3 && b5 && b4 && b6) || (b3 && b5 && b7) || (b3 && b8)) count++;
            }

            label13.Text = (count/isp).ToString();
        }
    }
}
