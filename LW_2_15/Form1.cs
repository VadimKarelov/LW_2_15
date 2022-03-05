using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LW_2_15
{
    public partial class Form1 : Form
    {
        private Random rn = new Random();
        private List<Ball> balls = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            //for (int i = 0; i < 100; i++)
                //CreateBall();
        }

        private void Draw_Tick(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pb_Field.Width, pb_Field.Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);
            foreach (Ball b in balls)
            {
                g.FillEllipse(new SolidBrush(b.Color), b.X - b.Radius / 2, b.Y - b.Radius / 2, b.Radius, b.Radius);
            }
            g.DrawString($"{balls.Count.ToString()}", new Font("Times", 10), new SolidBrush(Color.Black), 0, 0);

            pb_Field.Image = bitmap;
        }

        private void CreateBall_Tick(object sender, EventArgs e)
        {
            CreateBall();
            DeleteBadBalls();
            rn = new Random();
        }

        private void CreateBall()
        {
            Ball ball = new Ball(rn.Next(pb_Field.Width), rn.Next(pb_Field.Height), rn);
            balls.Add(ball);
            Thread thread = new Thread(new ThreadStart(ball.Update));
            thread.IsBackground = true;
            thread.Start();
        }

        private void DeleteBadBalls()
        {
            for (int i = balls.Count - 1; i >= 0; i--)
            {
                if (balls[i].X < 0 || balls[i].Y < 0 || balls[i].X > pb_Field.Width || balls[i].Y > pb_Field.Height)
                {
                    balls.RemoveAt(i);
                }
            }
        }
    }
}
