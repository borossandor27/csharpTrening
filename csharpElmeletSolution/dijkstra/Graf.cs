using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra
{
    internal class Graf
    {
        public List<Edge> Routes { get; set; } = new List<Edge>();
        public List<Node> Node { get; set; } = new List<Node>();
        public void AddRoute(Edge route)
        {
            if (!Routes.Contains(Route))
            {
                Routes.Add(Route);
            }
        }
        public void AddNode(Node Node)
        {
            if (!Node.Contains(Node))
            {
                Node.Add(Node);
            }
        }
    }
}
