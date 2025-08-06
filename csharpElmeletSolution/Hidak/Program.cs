using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Hidak
{
    internal class Program
    {
        static List<Hid> hidak = new List<Hid>();
        static void Main(string[] args)
        {
            Console.WriteLine("Program indul...");
            _AdatokBeolvasasa("hidak20.csv");
            feladat01();
            feladat02();
            feladat03();
            feladat04();
            Console.WriteLine("\nProgram vége!");
            // A program vége előtt várakozunk, hogy lássuk az eredményt
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez...");
            Console.ReadKey();
        }

        private static void feladat04()
        {
            Console.WriteLine("\n4. feladat. Hány híd szerepel az adatokban országonként?");
            // Számold meg, hány híd szerepel az adatokban országonként!
            var orszagok = hidak.GroupBy(h => h.orszag) 
                               .Select(g => new { Orszag = g.Key, HidakSzama = g.Count() })
                               .OrderBy(o => o.Orszag)
                               .ToList();
            if (orszagok.Count == 0)
                {
                Console.WriteLine("Nincs híd az adatokban.");
            }
            else
            {
                foreach (var orszag in orszagok)
                {
                    Console.WriteLine($"\t{orszag.Orszag}: {orszag.HidakSzama} híd");
                }
            }
        }

        private static void feladat03()
        {
            Console.WriteLine("\n3. feladat. Mely hidak pilon távolsága nagyobb, mint 1500 méter?");
            // Listázd ki az összes hidat, amelynek a pilon távolsága nagyobb, mint 1500 méter!
            var nagyPilonHidak = hidak.Where(h => h.pilon_tavolsag_m.HasValue && h.pilon_tavolsag_m.Value > 1500).ToList();
            if (nagyPilonHidak.Count == 0)
            {
                Console.WriteLine("Nincs olyan híd, amelynek a pilon távolsága nagyobb, mint 1500 méter.");
            }
            else
            {
                foreach (var hid in nagyPilonHidak)
                {
                    Console.WriteLine($"\t{hid.helyezes}. {hid.nev} - {hid.elhelyezkedes} ({hid.pilon_tavolsag_m} m)");
                }
            }
        }

        private static void feladat02()
        {
            Console.WriteLine("\n2. feladat. Kínai hidak:");
            // Listázd ki az összes kínai hidat!
            var kinaiHidak = hidak.Where(h => h.elhelyezkedes.Contains("Kína")).ToList();
            if (kinaiHidak.Count == 0)
            {
                Console.WriteLine("Nincs kínai híd.");
            }
            else
            {
                foreach (var hid in kinaiHidak)
                {
                    Console.WriteLine($"\t{hid.helyezes}. {hid.nev} - {hid.elhelyezkedes} ({hid.teljes_hossz_m} m)");
                }
            }
        }

        private static void feladat01()
        {
            Console.WriteLine("1. feladat. A 2010 után átadott hidak:");
            // Listázd ki az összes hidat, amit 2010 után adtak át!
            var ujHidak = hidak.Where(h => h.atadas_eve > 2010).ToList();
            if (ujHidak.Count == 0)
            {
                Console.WriteLine("Nincs 2010 után átadott híd.");
            }
            else
            {
                foreach (var hid in ujHidak)
                {
                    Console.WriteLine($"\t{hid.helyezes}. {hid.nev} - {hid.elhelyezkedes} ({hid.teljes_hossz_m} m)");
                }
            }
        }

        private static void _AdatokBeolvasasa(string file)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
            {
                string sor;
                sr.Peek(); // Ellenőrizzük, hogy van-e adat a fájlban
                sr.ReadLine(); // Az első sor általában fejléc, kihagyjuk
                while ((sor = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(sor)) continue; // Üres sorok kihagyása
                    try
                    {
                        Hid hid = new Hid(sor);
                        hidak.Add(hid);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba a sor feldolgozása közben: {ex.Message}");
                    }
                }
                // Példa: kiíratjuk az első 5 hidat
                foreach (var hid in hidak.Take(5))
                {
                    Console.WriteLine($"{hid.helyezes}. {hid.nev} - {hid.elhelyezkedes} ({hid.teljes_hossz_m} m)");
                }
            }
        }
    }
}
