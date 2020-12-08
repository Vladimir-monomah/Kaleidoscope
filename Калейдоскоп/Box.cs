using System;
using System.Drawing;
using System.Windows.Forms;

namespace Калейдоскоп
{
    class Box
    {
        int sx = 1;
        int sy = 1;
        static int width, height;
        Panel panel;
        Graphics graph;

        public enum Figure
        {
            line,circle
        };

        static Figure figure;
        static int line_x1;
        static int line_y1;
        static int line_x2;
        static int line_y2;
        static Color color;
        static Random rand=new Random();

        static int circle_x;
        static int circle_y;
        static int circle_r;

        public Box(Panel panel, int sx, int sy)
        {
            this.sx = sx;
            this.sy = sy;
            this.panel = panel;
            graph=panel.CreateGraphics();
        }

        static public void setSize(int w, int h)
        {
            width = w;
            height = h;
        }

        static public void choiceFigure()
        {
            int f = rand.Next(0, Enum.GetNames(typeof(Figure)).Length);
            figure = (Figure)f;
            color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
            switch (figure)
            {
                case Figure.line:
                    line_x1 = rand.Next(0, width);
                    line_y1 = rand.Next(0, height);
                    line_x2 = rand.Next(0, width);
                    line_y2 = rand.Next(0, height);
                    break;
                case Figure.circle:
                    circle_x = rand.Next(0, width);
                    circle_y = rand.Next(0, height);
                    circle_r = rand.Next(0, width / 4);
                    break;
            }
        } 

        private void drawLine()
        {
            Pen pen= new Pen(color);
            graph.DrawLine(pen, cx(line_x1), cy(line_y1), cx(line_x2), cy(line_y2));
        }

        private void drawCircle()
        {
            Brush brush = new SolidBrush(color);
            graph.FillEllipse(brush, 
                cx(circle_x) - circle_r, 
                cy(circle_y) - circle_r, 
                circle_r * 2, 
                circle_r*2);
        }

        public void drawFigure()
        {
            switch (figure)
            {
                case Figure.line:
                    drawLine();
                    break;
                case Figure.circle:
                    drawCircle();
                    break;
            }
        }

        private int cx(int x)
        {
            return sx == 1 ? x : width - x;
        }

        private int cy(int y)
        {
            return sy == 1 ? y : height - y;
        }
    }
}
