using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra
{
    internal class Edge
    {
        public Node From { get; set; }
        public Node To { get; set; }
        public long Distance { get; set; }
        public Edge(Node from, Node to, long distance)
        {
            From = from;
            To = to;
            Distance = distance;
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
