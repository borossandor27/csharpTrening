using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dijkstra;

namespace dijkstra
{
    internal class Edge
    {
        public Node From { get; set; }
        public Node To { get; set; }
        private long _weight;
        public long Weight { 
            get { return _weight; } 
            set { if (value < 0)
                {
                    throw new ArgumentException("Csomópontok közötti távolság nem lehet negatív!");
                } 
                _weight = value; } 
            }

        public bool IsSelected { get; internal set; }
        public bool IsHighlighted { get; internal set; }
        public bool IsFinished { get; internal set; }

        public Edge(Node from, Node to, long distance)
        {
            this.From = from;
            this.To = to;
            this.Weight = distance;
            this.IsSelected = false;
            this.IsHighlighted = true;
            this.IsFinished = false;
        }

        public Edge(string line, List<Node> availableNodes)
        {
            var parts = line.Split(',');
            if (parts.Length < 3)
            {
                throw new FormatException("Az élek fájl formátuma érvénytelen. Minden sor három értéket kell tartalmazzon: forrás, cél, súly.");
            }
            string sourceName = parts[0].Trim();
            string targetName = parts[1].Trim();
            int weight = int.Parse(parts[2].Trim());
            Node sourceNode = availableNodes.FirstOrDefault(n => n.Name == sourceName);
            Node targetNode = availableNodes.FirstOrDefault(n => n.Name == targetName);
            if (sourceNode == null || targetNode == null)
            {
                throw new InvalidOperationException($"A csúcsok nem találhatók: {sourceName}, {targetName}");
            }
            if (sourceNode == null)
            {
                throw new InvalidOperationException($"A forráscsomópont '{sourceName}' nem található.");
            }
            if (targetNode == null)
            {
                throw new InvalidOperationException($"A célcsomópont '{targetName}' nem található.");
            }

            this.From = sourceNode;
            this.To = targetNode;
            this.Weight = weight; // Beállítjuk a Weight property-t
        }

        public override string ToString()
        {
            return $"{From} -> {To} ({Weight})";
        }
        public override bool Equals(object obj)
        {
            if (obj is Edge edge)
            {
                return From.Equals(edge.From) && To.Equals(edge.To) && Weight == edge.Weight;
            }
            return false;
        }

    }
}
