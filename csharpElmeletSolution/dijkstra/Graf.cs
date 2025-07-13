// Graf.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra
{
    internal class Graf
    {
        public List<Node> nodes { get; private set; } = new List<Node>(); // nodes lista publikus get, privát set
        public List<Edge> edges { get; private set; } = new List<Edge>(); // edges lista publikus get, privát set

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
        }

        public void AddNode(Node node) 
        {
            this.nodes.Add(node); // Hozzáadja a csomóponthoz a listához
        }

        public void AddEdge(Edge edge)
        {
            this.edges.Add(edge); // Hozzáad egy élt a listához
        }
    }
}