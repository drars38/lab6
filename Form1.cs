using LAB6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
       
        Emmiter emitter;
        private ColorPoint colorPoint1;
        private ColorPoint colorPoint2;
        private ColorPoint colorPoint3;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            // а тут теперь вручную создаем
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
           
           
           
            // Инициализация точек ColorPoint
            colorPoint1 = new ColorPoint { Color = Color.Red, Radius = 50, X = 50, Y = 50 };
            colorPoint2 = new ColorPoint { Color = Color.Green, Radius = 30, X = 100, Y = 100 };
            colorPoint3 = new ColorPoint { Color = Color.Blue, Radius = 30, X = 150, Y = 150 };



            // привязываем поля к эмиттеру
            
            emitter.impactPoints.Add(colorPoint1);
            emitter.impactPoints.Add(colorPoint2);
            emitter.impactPoints.Add(colorPoint3);

            trackBar1.Maximum = picDisplay.Width;
            trackBar2.Maximum = picDisplay.Height;
            trackBar3.Maximum = picDisplay.Width;
            trackBar4.Maximum = picDisplay.Height;
            trackBar5.Maximum = picDisplay.Width;
            trackBar6.Maximum = picDisplay.Height;

            trackBar1.Scroll += (sender, e) => { colorPoint1.X = trackBar1.Value; Refresh(); };
            trackBar2.Scroll += (sender, e) => { colorPoint1.Y = trackBar2.Value; Refresh(); };
            trackBar3.Scroll += (sender, e) => { colorPoint2.X = trackBar3.Value; Refresh(); };
            trackBar4.Scroll += (sender, e) => { colorPoint2.Y = trackBar4.Value; Refresh(); };
            trackBar5.Scroll += (sender, e) => { colorPoint3.X = trackBar5.Value; Refresh(); };
            trackBar6.Scroll += (sender, e) => { colorPoint3.Y = trackBar6.Value; Refresh(); };

            // Установка начальных значений TrackBar
            trackBar1.Value = (int)colorPoint1.X;
            trackBar2.Value = (int)colorPoint1.Y;
            trackBar3.Value = (int)colorPoint2.X;
            trackBar4.Value = (int)colorPoint2.Y;
            trackBar5.Value = (int)colorPoint3.X;
            trackBar6.Value = (int)colorPoint3.Y;

            trackBarRadius.Maximum = 100; // Установите максимальный радиус
            trackBarRadius.Value = colorPoint1.Radius; // Установите начальное значение радиуса
            trackBarRadius.Scroll += (sender, e) =>
            {
                int newRadius = trackBarRadius.Value;
                colorPoint1.Radius = newRadius;
                colorPoint2.Radius = newRadius;
                colorPoint3.Radius = newRadius;
                Refresh();
            };
        }

        private void plcDisplay_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }


        

        
       
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            

          
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Eater newExplosion = new Eater(e.X, e.Y, 50);
                emitter.impactPoints.Add(newExplosion);
                picDisplay.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                foreach (var counters in emitter.impactPoints.ToList())
                {
                    if (counters is Eater)
                    {
                        emitter.impactPoints.Remove(counters);
                    }
                }
                picDisplay.Invalidate(); 
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
