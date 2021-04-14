using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestDxf
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            InitControl(e, g);

            DrawAxis(g);
            DrawRectangle(g);
        }

        float scale = 1f;
        private void InitControl(PaintEventArgs e, Graphics g)
        {
            Rectangle clientRectangle = e.ClipRectangle;

            g.Clear(System.Drawing.Color.Black);

            Region regClip = g.Clip;

            g.Clip = new Region(clientRectangle);
            g.TranslateTransform(this.panel1.Width /2 , this.panel1.Height / 2);
            g.ScaleTransform(scale, scale);
            // 设置插值模式
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            // 设置平滑模式
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        }


        Pen penAxis = Pens.Silver;
        private void DrawAxis(Graphics g)
        {
            g.DrawLine(penAxis, -(this.panel1.Width /2) / scale, 0, (this.panel1.Width /2) / scale, 0);
            g.DrawLine(penAxis, 0, -(this.panel1.Height /2) / scale, 0, (this.panel1.Height /2) / scale);
        }

        Rectangle rectangle1 = new Rectangle(-100, -100, 100, 100);
        Rectangle rectangle2 = new Rectangle(0, 0, 100, 100);
        private void DrawRectangle(Graphics g)
        {
            g.DrawRectangle(Pens.White, rectangle1);
            g.DrawRectangle(Pens.White, rectangle2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            scale += 0.1f;
            //rectangle2.Width = (int)(rectangle.Width / scale);
            //rectangle2.Height = (int)(rectangle.Height / scale);

            Repaint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scale -= 0.1f;
            //rectangle2.Width = (int)(rectangle.Width / scale);
            //rectangle2.Height = (int)(rectangle.Height / scale);
            Repaint();
        }

        private void Repaint()
        {
            if (this.IsHandleCreated)
            {
                try
                {
                    this.EndInvoke(this.BeginInvoke(new Action(() =>
                    {
                        this.panel1.Refresh();
                    })));
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
