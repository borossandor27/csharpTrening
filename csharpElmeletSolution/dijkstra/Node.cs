using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra
{
    internal class Node
    {
        public string Name { get; set; }
        public long x { get; set; }
        public long y { get; set; }
        public Node(string name, long x, long y)
        {
            Name = name;
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
