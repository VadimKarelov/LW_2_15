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
        private List<Thread> threads = new List<Thread>();

        public Form1()
        {
            InitializeComponent();
            UpdateTrackBars();
        }

        private void Draw_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void CreateBall_Tick(object sender, EventArgs e)
        {
            CreateBall();
            DeleteBadBalls();
            UpdateTrackBars();
            rn = new Random();
        }

        private void Draw()
        {
            Bitmap bitmap = new Bitmap(pb_Field.Width, pb_Field.Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);
            for (int i = balls.Count - 1; i >= 0; i--)
            {
                Ball b = balls[i];

                var tempColor = b.Color;

                if (cb_Priority.Checked)
                {
                    switch (threads[i].Priority)
                    {
                        case ThreadPriority.Highest: tempColor = Color.Red; break;
                        case ThreadPriority.AboveNormal: tempColor = Color.Orange; break;
                        case ThreadPriority.Normal: tempColor = Color.Yellow; break;
                        case ThreadPriority.BelowNormal: tempColor = Color.YellowGreen; break;
                        case ThreadPriority.Lowest: tempColor = Color.Green; break;
                    }
                }

                g.FillEllipse(new SolidBrush(tempColor), b.X - b.Radius / 2, b.Y - b.Radius / 2, b.Radius, b.Radius);
                g.DrawString((i + 1).ToString(), new Font("Times", 14), new SolidBrush(Color.Black), b.X, b.Y);
            }
            g.DrawString($"{balls.Count.ToString()}", new Font("Times", 10), new SolidBrush(Color.Black), 0, 20);

            pb_Field.Image = bitmap;
        }

        private void CreateBall()
        {
            TrackBar tb = new TrackBar();
            Ball ball = new Ball(rn.Next(pb_Field.Width - tb.Width), rn.Next(pb_Field.Height), rn);
            balls.Add(ball);
            Thread thread = new Thread(new ThreadStart(ball.Update));
            threads.Add(thread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void DeleteBadBalls()
        {
            TrackBar tb = new TrackBar();
            for (int i = balls.Count - 1; i >= 0; i--)
            {
                if (balls[i].X < 0 || balls[i].Y < 0 || balls[i].X > pb_Field.Width - tb.Width || balls[i].Y > pb_Field.Height)                
                {
                    balls.RemoveAt(i);
                    threads.RemoveAt(i);
                }
            }
        }

        private void UpdateTrackBars()
        {
            CorrectTrackBarNumber();

            // changing values
            ThreadPriority[] t = { ThreadPriority.Lowest, ThreadPriority.BelowNormal, ThreadPriority.Normal, ThreadPriority.AboveNormal, ThreadPriority.Highest };
            List<ThreadPriority> states = t.ToList();

            var trackBars = gb_Priority.Controls;
            var labels = gb_Numbers.Controls;
            for (int i = 0; i < balls.Count; i++)
            {
                ((TrackBar)trackBars[i]).Value = states.IndexOf(threads[i].Priority) + 1;
                ((TrackBar)trackBars[i]).Tag = i;
                ((TrackBar)trackBars[i]).Location = new Point(0, i * ((TrackBar)trackBars[i]).Height);

                ((Label)labels[i]).Text = (i + 1).ToString();
                ((Label)labels[i]).Location = new Point(0, i * ((TrackBar)trackBars[i]).Height);
            }
        }

        private void CorrectTrackBarNumber()
        {
            // add extra TBs
            while (gb_Priority.Controls.Count < balls.Count)
            {
                TrackBar sb = new TrackBar();
                sb.Minimum = 1;
                sb.Maximum = 5;
                sb.TickFrequency = 1;
                sb.Value = 3;
                sb.Scroll += TrackBar_Scroll;
                gb_Priority.Controls.Add(sb);

                Label lbl = new Label();
                lbl.Text = "0";
                lbl.Font = new Font("Times", 14);
                gb_Numbers.Controls.Add(lbl);
            }

            // remove extra TBs
            while (gb_Priority.Controls.Count > balls.Count)
            {
                gb_Priority.Controls.RemoveAt(0);
                gb_Numbers.Controls.RemoveAt(0);
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;

            int index = int.Parse(tb.Tag.ToString());

            switch(tb.Value)
            {
                case 1: threads[index].Priority = ThreadPriority.Lowest; break;
                case 2: threads[index].Priority = ThreadPriority.BelowNormal; break;
                case 3: threads[index].Priority = ThreadPriority.Normal; break;
                case 4: threads[index].Priority = ThreadPriority.AboveNormal; break;
                case 5: threads[index].Priority = ThreadPriority.Highest; break;
            }
        }
    }
}
