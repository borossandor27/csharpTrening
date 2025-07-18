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
        public List<Node> nodes { get; private set; } = new List<Node>();
        public List<Edge> edges { get; private set; } = new List<Edge>();

        Graphics g;
        private long _maxWidthValue = 800;
        private long _maxHeightValue = 600;
        private long _minWidthValue = 100;
        private long _minHeightValue = 100;
        private const int _NodeRadius = 20;
        private const int _EdgeRadius = 20; // This constant is not used in the provided code
        private static readonly Pen _penNormal = new Pen(Color.Black, 2);
        private static readonly Pen _penSelected = new Pen(Color.Red, 2);
        private static readonly Pen _penHighlighted = new Pen(Color.Green, 2);
        private static readonly Pen _penFinish = new Pen(Color.Blue, 2);
        private Brush _brushNode = new SolidBrush(Color.LightBlue);

        public Graf(String nodesFile = "nodes.csv", String edgesFile = "edges.csv")
        {
            csucsokBetoltese(nodesFile);
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
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Edge edge = new Edge(line, this.nodes);
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
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    Node node = new Node(line);
                    nodes.Add(node);
                }
            }
            _maxWidthValue = (long)(nodes.Max(n => n.x) * 1.2);
            _maxHeightValue = (long)(nodes.Max(n => n.y) * 1.2);
        }

        public void AddNode(Node node)
        {
            this.nodes.Add(node);
        }

        public void AddEdge(Edge edge)
        {
            this.edges.Add(edge);
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
                Pen penToUse = _penNormal;

                float fromX = edge.From.x * scale;
                float fromY = edge.From.y * scale;
                float toX = edge.To.x * scale;
                float toY = edge.To.y * scale;

                g.DrawLine(penToUse, fromX, fromY, toX, toY);

                float midX = (fromX + toX) / 2;
                float midY = (fromY + toY) / 2;
                string edgeWeight = edge.Weight.ToString("0");
                SizeF stringSizeEdge = g.MeasureString(edgeWeight, SystemFonts.DefaultFont);

                // Adjust Y coordinate to draw text slightly above the midpoint of the edge
                g.DrawString(edgeWeight, SystemFonts.DefaultFont, Brushes.Black, midX - (stringSizeEdge.Width / 2), midY - (stringSizeEdge.Height) - 5); // Subtract an additional 5 pixels
            }

            // Csomópontok kirajzolása
            foreach (var node in nodes)
            {
                Pen penToUseForNode = _penNormal;

                float nodeX = node.x * scale;
                float nodeY = node.y * scale;

                g.FillEllipse(_brushNode, nodeX - _NodeRadius, nodeY - _NodeRadius, _NodeRadius * 2, _NodeRadius * 2);
                g.DrawEllipse(penToUseForNode, nodeX - _NodeRadius, nodeY - _NodeRadius, _NodeRadius * 2, _NodeRadius * 2);

                SizeF stringSizeNode = g.MeasureString(node.Name, SystemFonts.DefaultFont);
                g.DrawString(node.Name, SystemFonts.DefaultFont, Brushes.Black, nodeX - (stringSizeNode.Width / 2), nodeY - (stringSizeNode.Height / 2));
            }
        }
    }
}