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
            pelda04();
            pelda05();
            pelda06();
            pelda07();
            pelda09();
            pelda10();
            pelda11();
            pelda12();
            pelda13();
            pelda14();
            pelda16();
            pelda17();
            pelda18();
            pelda19();
            pelda20();
            pelda21();
            Console.WriteLine("\nProgram vége!");
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez...");
            Console.ReadKey();
        }

        private static void pelda21()
        {
            // Nemzetiségek, ahol az átlagéletkor 40 év felett van
            Console.WriteLine("\nPélda 21:");
            var atlagEletkorNemzetiseg = pilotak
                .Where(p => !string.IsNullOrEmpty(p.nemzetiseg))
                .GroupBy(p => p.nemzetiseg)
                .Select(g => new
                {
                    Nemzetiseg = g.Key,
                    AtlagEletkor = g.Average(p => DateTime.Now.Year - p.szuletesi_datum.Year)
                })
                .Where(x => x.AtlagEletkor > 40)
                .ToList();
            if (atlagEletkorNemzetiseg.Count > 0)
            {
                foreach (var item in atlagEletkorNemzetiseg)
                {
                    Console.WriteLine($"\t{item.Nemzetiseg}: {item.AtlagEletkor.ToString("#,##0.00")} év");
                }
            }
            else
            {
                Console.WriteLine("\tNincs olyan nemzetiség, ahol az átlagéletkor 40 év felett lenne.");
            }
        }

        private static void pelda20()
        {
            // A 10 legfiatalabb versenyző
            Console.WriteLine("\nPélda 20: A 10 legfiatalabb versenyző");
            var legFiatalabbVersenyzok = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .OrderByDescending(p => p.szuletesi_datum)
                .Take(10)
                .ToList();
            if (legFiatalabbVersenyzok.Count > 0)
            {
                foreach (var pilota in legFiatalabbVersenyzok)
                {
                    Console.WriteLine($"\t{pilota.nev} ({pilota.szuletesi_datum:yyyy.MM.dd})");
                }
            }
            else
            {
                Console.WriteLine("\tSikertelen lekérdezés.");
            }
        }

        private static void pelda19()
        {
            // 1980 után született versenyzők nemzetiségenként
            Console.WriteLine("\nPélda 19:");
            var versenyzok1980Utan = pilotak
                .Where(p => p.szuletesi_datum.Year > 1980)
                .OrderBy(p => p.nemzetiseg)
                .ToList();
            if (versenyzok1980Utan.Count > 0)
            {
                var nemzetisegCsoportositas = versenyzok1980Utan
                    .GroupBy(p => p.nemzetiseg)
                    .Select(g => new { Nemzetiseg = g.Key, Versenyzok = g.ToList() })
                    .ToList();

                foreach (var csoport in nemzetisegCsoportositas)
                {
                    Console.WriteLine($"\t{csoport.Nemzetiseg}: {csoport.Versenyzok.Count} versenyző");
                    foreach (var pilota in csoport.Versenyzok)
                    {
                        Console.WriteLine($"\t\t{pilota.nev} ({pilota.szuletesi_datum:yyyy.MM.dd})");
                    }
                }
            }
            else
            {
                Console.WriteLine("\tNincs olyan versenyző, aki 1980 után született.");
            }
        }

        private static void pelda18()
        {
            // Legnépszerűbb rajtszám (versenyzők nevével)
            Console.WriteLine("\nPélda 18:");
            var legNepszerubbRajtszam = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .GroupBy(p => p.rajtszam)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();
            if (legNepszerubbRajtszam != null)
            {
                Console.WriteLine($"\tA legnépszerűbb rajtszám: {legNepszerubbRajtszam.Key} (Versenyzők: {string.Join(", ", legNepszerubbRajtszam.Select(p => p.nev))})");
            }
            else
            {
                Console.WriteLine("\tNincs olyan rajtszám, amelyet több versenyző is használna.");
            }
        }

        private static void pelda17()
        {
            // Átlagos születési év nemzetiségenként
            Console.WriteLine("\nPélda 17:");
            var atlagosSzuletesiEv = pilotak
                .Where(p => !string.IsNullOrEmpty(p.nemzetiseg) && !string.IsNullOrEmpty(p.rajtszam))
                .GroupBy(p => p.nemzetiseg)
                .Select(g => new
                {
                    Nemzetiseg = g.Key,
                    AtlagosSzuletesiEv = g.Average(p => DateTime.Now.Year - p.szuletesi_datum.Year)
                })
                .ToList();
            if (atlagosSzuletesiEv.Count > 0)
            {
                foreach (var item in atlagosSzuletesiEv)
                {
                    Console.WriteLine($"\t{item.Nemzetiseg}: {item.AtlagosSzuletesiEv.ToString("#,##0.00")} év");
                }
            }
            else
            {
                Console.WriteLine("\tNincs olyan nemzetiség, amelyből több versenyző lenne.");
            }
        }

        private static void pelda16()
        {
            // Legidősebb versenyző(ek) adatai
            Console.WriteLine("\nPélda 16:");
            var legIdosebbPilota = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .OrderBy(p => p.szuletesi_datum)
                .FirstOrDefault();
            if (legIdosebbPilota != null)
            {
                Console.WriteLine($"\tA legidősebb versenyző: {legIdosebbPilota.nev} ({legIdosebbPilota.szuletesi_datum:yyyy.MM.dd})");

            }
            else
            {
                Console.WriteLine("\tNincs versenyző adat.");
            }
        }

        private static void pelda14()
        {
            // A legmagasabb rajtszámú versenyző neve és nemzetisége
            Pilota legMagasabbRajtszamPilota = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .OrderByDescending(p => int.Parse(p.rajtszam))
                .FirstOrDefault();
            if (legMagasabbRajtszamPilota != null)
            {
                Console.WriteLine($"\nPélda 14: A legmagasabb rajtszámú versenyző: {legMagasabbRajtszamPilota.nev} ({legMagasabbRajtszamPilota.nemzetiseg})");
            }
            else
            {
                Console.WriteLine("\nPélda 14: Nincs versenyző adat.");
            }
        }

        private static void pelda13()
        {
            // A rajtszámmal rendelkező versenyzők átlagos életkora (feltételezve, hogy a születési dátumból számolható az életkor, vagy egy külön életkor oszlop létezik)
            var atlagosEletkor = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .Select(p => DateTime.Now.Year - p.szuletesi_datum.Year)
                .Average();
            Console.WriteLine($"\nPélda 13: A rajtszámmal rendelkező versenyzők átlagos életkora: {atlagosEletkor.ToString("#,##0.00")}");
        }

        private static void pelda12()
        {
            // Azoknak a nemzetiségeknek a listája, amelyekből egynél több versenyző van
            Console.WriteLine("\nPélda 12:");
            var nemzetisegTobbVersenyzo = pilotak
                .Where(p => !string.IsNullOrEmpty(p.nemzetiseg))
                .GroupBy(p => p.nemzetiseg)
                .Where(g => g.Count() > 1)
                .Select(g => new { nemzet = g.Key, letszam = g.Count() })
                .ToList();
            if (nemzetisegTobbVersenyzo.Count > 0) { 
                Console.WriteLine("\tA következő nemzetiségeknek van több versenyzője:");
                foreach (var nemzetiseg in nemzetisegTobbVersenyzo)
                {
                    Console.WriteLine($"\t{nemzetiseg.nemzet} ({nemzetiseg.letszam})");
                }
            }
            else
            {
                Console.WriteLine("\tNincs olyan nemzetiség, amelyből több versenyző lenne.");
            }
        }

        private static void pelda11()
        {
            // A legfiatalabb versenyző neve és születési dátuma
            Pilota legFiatalabbPilota = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .OrderByDescending(p => p.szuletesi_datum)
                .FirstOrDefault();
            if (legFiatalabbPilota != null)
            {
                Console.WriteLine($"\nPélda 11: A legfiatalabb versenyző: {legFiatalabbPilota.nev} ({legFiatalabbPilota.szuletesi_datum:yyyy.MM.dd})");
            }
            else
            {
                Console.WriteLine("\nPélda 11: Nincs versenyző adat.");
            }
        }

        private static void pelda10()
        {
            // Nemzetiségenként hány versenyző van?
            Console.WriteLine("\nPélda 10:");
            var nemzetisegCsoportositas = pilotak
                .Where(p => !string.IsNullOrEmpty(p.nemzetiseg))
                .GroupBy(p => p.nemzetiseg)
                .Select(g => new { Nemzetiseg = g.Key, VersenyzokSzama = g.Count() })
                .ToList();
            foreach (var csoport in nemzetisegCsoportositas) { 
                Console.WriteLine($"\t{csoport.Nemzetiseg}: {csoport.VersenyzokSzama} versenyző");
            }
        }

        private static void pelda09()
        {
            // 9.	Melyik pályán mennyi az átlagos köridő?
            Console.WriteLine("\nPélda 09: Benéztem, nincsenek verseny adatok!(");
            var atlagosKorido = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .GroupBy(p => p.rajtszam)
                .Select(g => new { Rajtszam = g.Key, AtlagKorido = g.Average(p => p.szuletesi_datum.Ticks) })
                .ToList();
            
        }

        private static void pelda07()
        {
            // Versenyzők száma, akiknek nincs rajtszáma
            int nincsRajtszam = pilotak.Count(p => string.IsNullOrEmpty(p.rajtszam));
            Console.WriteLine($"\nPélda 07: {nincsRajtszam} versenyzőnek nincs rajtszáma.");
        }

        private static void pelda06()
        {
            // Azoknak a versenyzőknek a neve és rajtszáma, akiknek van rajtszámuk (nem üres)
            List<Pilota> rajtszamosPilotak = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .ToList();
            Console.WriteLine("\nPélda 06 - Rajtszámmal rendelkező versenyzők:");
            foreach (Pilota pilota in rajtszamosPilotak)
            {
                Console.WriteLine($"\t{pilota.nev} ({pilota.rajtszam})");
            }
        }

        private static void pelda05()
        {
            // Hány versenyzőnek van rajtszáma?
            List<Pilota> rajtszamosPilotak = pilotak
                .Where(p => !string.IsNullOrEmpty(p.rajtszam))
                .ToList();
            Console.WriteLine($"\nPélda 05 - {rajtszamosPilotak.Count} versenyzőnek van rajtszáma.");
        }

        private static void pelda04()
        {
            Console.WriteLine("\nPélda 04 - A német nemzetiségű versenyzők:");
            // A német nemzetiségű versenyzők születési dátum szerint növekvő sorrendben
            var nemetPilota = pilotak
                .Where(p => p.nemzetiseg == "német")
                .OrderBy(p => p.szuletesi_datum)
                .ToList();
            foreach (Pilota pilota in nemetPilota)
            {
                Console.WriteLine($"\t{pilota.nev} ({pilota.szuletesi_datum:yyyy.MM.dd})");
            }
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
