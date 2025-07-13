using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace dijkstra
{
    public partial class FormMain : Form
    {
        Graf graf;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            graf = new Graf();
            Console.WriteLine("Gráf adatok betöltve.");
            grafKirajzolása();
            panel_Graf.Paint += new PaintEventHandler(MainForm_Paint);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw a rectangle
            Pen penRectangle = new Pen(Color.Red, 3);
            Rectangle rect = new Rectangle(50, 50, 150, 100);
            g.DrawRectangle(penRectangle, rect);

            // Draw a filled ellipse
            SolidBrush brushEllipse = new SolidBrush(Color.Blue);
            Rectangle ellipseRect = new Rectangle(250, 50, 120, 80);
            g.FillEllipse(brushEllipse, ellipseRect);

            // Draw a line
            Pen penLine = new Pen(Color.Green, 2);
            g.DrawLine(penLine, 50, 200, 300, 200);

            // Draw a polygon (triangle)
            Point[] points = { new Point(50, 250), new Point(150, 250), new Point(100, 300) };
            Pen penPolygon = new Pen(Color.Purple, 4);
            g.DrawPolygon(penPolygon, points);

            penRectangle.Dispose();
            brushEllipse.Dispose();
            penLine.Dispose();
            penPolygon.Dispose();
        }

        private void grafKirajzolása()
        {
            //throw new NotImplementedException();
        }
    }
}
