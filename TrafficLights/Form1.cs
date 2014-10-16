using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//solomatin.cs.vsu.ru@gmail.com

namespace TaskOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SolidBrush BlackBrush = new SolidBrush(Color.Black);
        TrafficLight s = new TrafficLight(1000, 300, 1000, TrafficLightColor.Red);

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s.ChangeColor += (sender2, e2) =>
            {
                Draw();
            };
        }

        private void Draw()
        {
            Graphics gr = this.CreateGraphics();
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.FillRectangle(BlackBrush, 10, 10, 100, 250);

            Color c;
            Brush b;
            switch (s.Color)
            {
                case TrafficLightColor.Red:
                    c = Color.Red;
                    b = new SolidBrush(c);
                    g.FillEllipse(b, 25, 25, 70, 70);
                    break;
                case TrafficLightColor.Yellow:
                    c = Color.Yellow;
                    b = new SolidBrush(c);
                    g.FillEllipse(b, 25, 95, 70, 70);
                    break;
                case TrafficLightColor.Green:
                    c = Color.Green;
                    b = new SolidBrush(c);
                    g.FillEllipse(b, 25, 165, 70, 70);
                    break;
            }

            gr.DrawImage(bitmap, 0, 0, Width, Height);
            gr.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }
    }
}
