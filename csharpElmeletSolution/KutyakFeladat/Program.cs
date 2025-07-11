using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KutyakFeladat;
using KotyakFeladat;
using System.ComponentModel;

namespace KutyakFeladat
{

    /***
* A program eredete https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-180531/
* 
*/

    internal class Program
    {
        public static Dictionary<int, string> Kutyanevek = new Dictionary<int, string>();
        public static Dictionary<int, (string Nev, string EredetiNev)> KutyaFajtanevek = new Dictionary<int, (string, string)>();
        static List<Kutya> kutyak = new List<Kutya>();
        static void Main(string[] args)
        {
            Console.WriteLine("Program indul...");
            Console.Write("\nKutyanevek beolvasása...\t");
            KutyanevekBeolvasasa();
            Console.Write("\nKutyafajták beolvasása...\t");
            KutyaFajtakBeolvasasa();
            KutyaadatokBeolvasasa();
            feladat03();
            feladat06();
            feladat07();
            feladat08();
            feladat09();
            feladat10();
            Console.WriteLine("\nProgram vége!");
            Console.ReadLine();
        }

        private static void feladat10()
        {
            string outputFile = "nevstatisztika.txt";
            Console.WriteLine("Kutyanevek statisztika...");

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var kutyafajta in kutyak.GroupBy(a=>a.kutyanev).Select(b=> new {kutyanev=b.Key, db=b.Count()}).OrderByDescending(c=>c.db))
                {
                    writer.WriteLine($"{kutyafajta.kutyanev}; {kutyafajta.db} kutya");
                }
                
            }
            Console.WriteLine($"\n10. feladat: Kutyanevek statisztika kiírva a {outputFile} fájlba.");
        }

        private static void feladat09()
        {
            // legjobban leterhelt nap
            var legjobbanLeterheltNap = kutyak.GroupBy(a => a.utolso_orvosi_ellenorzes.Date)
                .Select(b => new { Datum = b.Key, Db = b.Count() })
                .OrderByDescending(c => c.Db)
                .FirstOrDefault();
            if (legjobbanLeterheltNap != null)
            {
                Console.WriteLine($"\n9. feladat: Legjobban leterhelt nap: {legjobbanLeterheltNap.Datum.ToShortDateString()}, kutyák száma: {legjobbanLeterheltNap.Db}");
            }
            else
            {
                Console.WriteLine("9. feladat: Nincs adat a kutyák orvosi ellenőrzéséről.");
            }
        }

        private static void feladat08()
        {
            // 2018-01-10 ellátott kutyák száma fajtánként
            Console.WriteLine("\n8. feladat: 2018 január 10-én ellátott kutyák fajtánként:");
            foreach (var item in kutyak.FindAll(a => a.utolso_orvosi_ellenorzes == DateTime.Parse("2018-01-10")).GroupBy(b => b.fajtanev).Select(c => new { fajta = c.Key, db = c.Count() }))
            {
                Console.WriteLine($"\t{item.fajta}: {item.db} kutya");
            }

        }

        private static void feladat07()
        {
            // legidősebb kutya neve és fajtája
            Kutya legidosebbKutya = kutyak.Find(a => a.eletkor == kutyak.Max(b => b.eletkor));
            Console.WriteLine($"\n7. feladat: Legidősebb kutya neve és fajtája: {legidosebbKutya.kutyanev}, {legidosebbKutya.fajtanev}");
        }

        private static void KutyaadatokBeolvasasa()
        {
            string[] adatok = File.ReadAllLines("kutyak.csv").Skip(1).ToArray();
            foreach (var line in adatok)
            {
                kutyak.Add(new Kutya(line));
            }
        }

        private static void feladat06()
        {
            double atlag = kutyak.Average(a => a.eletkor);
            Console.WriteLine($"\n6. feladat: A kutyák átlagéletkora: {atlag.ToString("#,##0.00")} év");
        }

        private static void feladat03()
        {
            Console.WriteLine($"\n3. feladat: kutyanevek száma: {Kutyanevek.Count()}");
        }

        private static void KutyaFajtakBeolvasasa()
        {
            string[] lines = File.ReadAllLines("KutyaFajtak.csv").Skip(1).ToArray();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                // 1. Kötelező ellenőrzés: az első mező (id) létezik és szám-e
                if (parts.Length >= 1 && int.TryParse(parts[0], out int id))
                {
                    // 2. A "név" (második mező) kötelező, ha hiányzik, hibát jelezünk
                    if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
                    {
                        Console.WriteLine($"\nHibás sor (hiányzó név): {line}");
                        continue; // Kilép a ciklusból, nem menti el
                    }
                    string nev = parts[1].Trim();

                    // 3. Az "eredetiNev" (harmadik mező) opcionális, ha hiányzik, null-t tárolunk
                    string eredetiNev = (parts.Length >= 3 && !string.IsNullOrWhiteSpace(parts[2]))
                        ? parts[2].Trim()
                        : null; // vagy "" (ha inkább üres stringet szeretnél)

                    KutyaFajtanevek[id] = (nev, eredetiNev);
                }
                else
                {
                    Console.WriteLine($"\nHibás sor (érvénytelen ID): {line}");
                }
            }
            Console.WriteLine($"\t{KutyaFajtanevek.Count} kutya fajtanév beolvasva");
        }

        private static void KutyanevekBeolvasasa()
        {
            string[] lines = File.ReadAllLines("kutyanevek.csv").Skip(1).ToArray();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 2 && int.TryParse(parts[0], out int id) && !string.IsNullOrWhiteSpace(parts[1]))
                {
                    Kutyanevek[id] = parts[1].Trim();
                }
            }
            Console.WriteLine("\t"+Kutyanevek.Count+" kutyanév beolvasva");
        }
    }
}
