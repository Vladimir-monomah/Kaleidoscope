using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калейдоскоп
{
    public partial class Form1 : Form
    {
        Box [,] box;
        int w, h;

        public Form1()
        {
            InitializeComponent();
            Init();
            timer.Enabled = true;
        }

        public void Init()
        {
            Box.setSize(panel1.Width, panel1.Height);
            w = panel.Width / panel1.Width;
            h = panel.Height / panel1.Height;
            int sx, sy;
            box = new Box[w, h];
            for (int i=0;i<w; i++)
                for (int j = 0; j < h; j++)
                {
                    Panel cell= new Panel();
                    cell.Parent = panel;
                    //cell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    cell.Location = new System.Drawing.Point(i*panel1.Width,j*panel1.Height);
                    cell.Size = new System.Drawing.Size(panel1.Width, panel1.Height);
                    sx = (i % 2 == 1) ? -1 : 1;
                    sy = (j % 2 == 1) ? -1 : 1;
                    box[i,j] = new Box(cell,sx,sy);
                }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Box.choiceFigure();
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    box[i, j].drawFigure();
        }
    }
}
