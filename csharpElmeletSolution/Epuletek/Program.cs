using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epuletek
{
    internal class Program
    {
        static List<Epulet> epuletek = new List<Epulet>();
        static void Main(string[] args)
        {
            Console.WriteLine("Program indul...");
            _adatokBeolvasása("epuletek50.csv");
            Console.WriteLine("A program futtatasa befejezodott.");
            Console.WriteLine("Nyomj meg egy gombot a kilepeshez...");
            Console.ReadKey();
        }

        private static void _adatokBeolvasása(string adatforras)
        {
            using (var reader = new System.IO.StreamReader(adatforras))
            {
                reader.ReadLine(); // Fejléc kihagyása
                string sor;
                while ((sor = reader.ReadLine()) != null)
                {
                    try
                    {
                        Epulet epulet = new Epulet(sor);
                        epuletek.Add(epulet);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba a sor feldolgozása közben: {ex.Message}");
                    }
                }
            }
        }
    }
}
