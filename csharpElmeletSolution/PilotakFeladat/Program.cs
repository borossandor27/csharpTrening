using System;
using System.Collections;
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
            feladat03();
            feladat04();
            feladat05();
            feladat06();
            feladat07();
            Console.WriteLine("\nProgram vége!");
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez...");
            Console.ReadKey();
        }
        /// <summary>
        /// Annak meghatározása és kiírása, hogy mely rajtszámokat kapta meg több pilóta is az idényben. 
        /// </summary>
        private static void feladat07()
        {
            var duplikaltRajtszamok = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .GroupBy(p => p.rajtszam)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            Console.WriteLine($"\n7. feladat: {string.Join(", ", duplikaltRajtszamok)} ");
        }

        /// <summary>
        /// Annak meghatározása és kiírása, 
        /// hogy a legkisebb értékű rajtszám pilótájának mi a nemzetisége. 
        /// A rajtszám nélküli pilóták adatait nem kell figyelembe venni. 
        /// Feltételezhető, hogy a legkisebb rajtszámot csak egy pilóta kapta meg. 
        /// </summary>
        private static void feladat06()
        {
            Pilota legKisebbRajtszamPilota = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .OrderBy(p => int.Parse(p.rajtszam))
                .FirstOrDefault();
            Console.WriteLine($"\n6. feladat: {legKisebbRajtszamPilota.nemzetiseg}");
        }

        /// <summary>
        /// Annak meghatározása és kiírása, hogy mely pilóták születtek a XIX. században
        /// (1901. január 1. előtt), beleértve a születési dátumukat is.
        /// </summary>
        private static void feladat05()
        {
            Console.WriteLine("\n5. feladat:");
            var szazadPilota = pilotak.Where(p => p.szuletesi_datum.Year < 1901).ToList();
            foreach (Pilota pilota in szazadPilota)
            {
                Console.WriteLine($"\t{pilota.nev} ({pilota.szuletesi_datum:yyyy.MM.dd})");
            }
        }

        /// <summary>
        /// Annak meghatározása és kiírása, hogy az állomány utolsó sorában melyik pilóta neve szerepel.
        /// </summary>
        private static void feladat04()
        {
            Console.WriteLine($"\n4. feladat: {pilotak.Last().nev}");
        }

        /// <summary>
        /// Annak meghatározása és kiírása, hogy az állomány hány adatsort tartalmaz.
        /// </summary>
        private static void feladat03()
        {
            Console.WriteLine($"\n3. feladat: {pilotak.Count()}");
        }

        /// <summary>
        /// A 'pilotak.csv' állomány sorainak beolvasása és adatok tárolása összetett adatszerkezetben(pl.vektor, lista). Figyelembe kell venni, hogy az első sor a fejlécet tartalmazza.
        /// </summary>
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
