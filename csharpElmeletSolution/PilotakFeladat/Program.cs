using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotakFeladat
{
    internal class Program
    {
        public static List<Pilota> pilotak = new List<Pilota>();
        static void Main(string[] args)
        {
            Console.WriteLine("Program indul...");
            pilotaAdatokBeolvasasa();
            Console.WriteLine("\nProgram vége!");
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez...");
            Console.ReadKey();
        }

        private static void pilotaAdatokBeolvasasa()
        {
            string[] sorok = System.IO.File.ReadAllLines("pilotak.csv", Encoding.UTF8).Skip(1).ToArray();
            foreach (string sor in sorok)
            {
                pilotak.Add(new Pilota(sor));
            }
        }
    }
}
