// Graf.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dijkstra
{
    internal class Graf
    {
        public List<Node> nodes { get; private set; } = new List<Node>(); // nodes lista publikus get, privát set
        public List<Edge> edges { get; private set; } = new List<Edge>(); // edges lista publikus get, privát set

        Graphics g;
        private long _maxWidthValue = 800; // Maximális szélesség
        private  long _maxHeightValue = 600; // Maximális magasság
        private long _minWidthValue = 100; // Minimális szélesség
        private long _minHeightValue = 100; // Minimális magasság
        private const int _NodeRadius = 20; // Csomópontok sugara
        private const int _EdgeRadius = 20;
        private static readonly Pen _penNormal = new Pen(Color.Black, 2);
        private static readonly Pen _penSelected = new Pen(Color.Red, 2);
        private static readonly Pen _penHighlighted = new Pen(Color.Green, 2);
        private static readonly Pen _penFinish = new Pen(Color.Blue, 2);
        private Brush _brushNode = new SolidBrush(Color.LightBlue); // Csomópontok színe
        public Graf(String nodesFile = "nodes.csv", String edgesFile = "edges.csv")
        {
            csucsokBetoltese(nodesFile);
            // Az élek betöltése előtt már rendelkezésre állnak a csomópontok
            elekBetoltese(edgesFile);
        }

        private void elekBetoltese(string edgesFile)
        {
            Console.WriteLine("Élek betöltése...");
            if (!File.Exists(edgesFile))
            {
                throw new FileNotFoundException($"A fájl nem található: {edgesFile}");
            }
            using (var reader = new StreamReader(edgesFile))
            {
                reader.ReadLine(); // Fejléc sor átugrása, ha van
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Itt adjuk át a 'nodes' listát az Edge konstruktorának
                    Edge edge = new Edge(line, this.nodes); // Átadjuk a 'this.nodes' listát
                    edges.Add(edge);
                }
            }
        }

        private void csucsokBetoltese(string nodesFile)
        {
            Console.WriteLine("Csúcsok betöltése...");
            if (!File.Exists(nodesFile))
            {
                throw new FileNotFoundException($"A fájl nem található: {nodesFile}");
            }
            using (var reader = new StreamReader(nodesFile))
            {
                string line;
                reader.ReadLine(); // Fejléc sor átugrása, ha van
                while ((line = reader.ReadLine()) != null)
                {
                    Node node = new Node(line);
                    nodes.Add(node);
                }
            }
            _maxWidthValue = (long)(nodes.Max(n => n.x) * 1.2);// Maximális szélesség beállítása a csomópontok x koordinátái alapján
            _maxHeightValue =(long) (nodes.Max(n => n.y) *1.2); // Maximális magasság beállítása a csomópontok y koordinátái alapján

        }

        public void AddNode(Node node) 
        {
            this.nodes.Add(node); // Hozzáadja a csomópontot a listához
        }

        public void AddEdge(Edge edge)
        {
            this.edges.Add(edge); // Hozzáad egy élt a listához
        }


        internal void Megjelenit(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Control panel = sender as Control;
            if (panel == null) return;

            float panelWidth = panel.Width;
            float panelHeight = panel.Height;

            float scaleX = panelWidth / (float)_maxWidthValue;
            float scaleY = panelHeight / (float)_maxHeightValue;
            float scale = Math.Min(scaleX, scaleY);

            // Élek kirajzolása
            foreach (var edge in edges)
            {
                Pen penToUse = _penNormal; // vagy állapot alapján kiválasztva

                float fromX = edge.From.x * scale;
                float fromY = edge.From.y * scale;
                float toX = edge.To.x * scale;
                float toY = edge.To.y * scale;

                g.DrawLine(penToUse, fromX, fromY, toX, toY);

                // Él címkéje középre
                float midX = (fromX + toX) / 2;
                float midY = (fromY + toY) / 2;
                g.DrawString(edge.Weight.ToString("0"), SystemFonts.DefaultFont, Brushes.Black, midX, midY);
            }

            // Csomópontok kirajzolása
            foreach (var node in nodes)
            {
                float nodeX = node.x * scale;
                float nodeY = node.y * scale;

                g.FillEllipse(_brushNode, nodeX - _NodeRadius, nodeY - _NodeRadius, _NodeRadius * 2, _NodeRadius * 2);
                g.DrawString(node.Name, SystemFonts.DefaultFont, Brushes.Black, nodeX - 10, nodeY - 10);
            }

        }

    }
}