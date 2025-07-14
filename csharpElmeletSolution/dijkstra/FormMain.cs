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
            panel_Graf.Paint += new PaintEventHandler(graf.Megjelenit);
            panel_Graf.Invalidate(); // Frissíti a panelt, hogy újrarajzolja a gráfot
        }
    }
}
