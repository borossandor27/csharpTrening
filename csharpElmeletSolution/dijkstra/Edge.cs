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
        private long _distance;
        public long Distance { 
            get { return _distance; } 
            set { if (value < 0)
                {
                    throw new ArgumentException("Csomópontok közötti távolság nem lehet negatív!");
                } 
                _distance = value; } 
            } 
        
        public Edge(Node from, Node to, long distance)
        {
            this.From = from;
            this.To = to;
            this.Distance = distance;
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
            this.Distance = weight; // Beállítjuk a Distance property-t
        }

        public override string ToString()
        {
            return $"{From} -> {To} ({Distance})";
        }
        public override bool Equals(object obj)
        {
            if (obj is Edge edge)
            {
                return From.Equals(edge.From) && To.Equals(edge.To) && Distance == edge.Distance;
            }
            return false;
        }

    }
}
