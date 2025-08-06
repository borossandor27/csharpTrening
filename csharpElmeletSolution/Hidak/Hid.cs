using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hidak
{
    internal class Hid
    {
        public int helyezes;
        public string nev;
        public string elhelyezkedes;
        public int? pilon_tavolsag_m;
        public int teljes_hossz_m;
        public int atadas_eve;
        public string orszag;

        public Hid(string beolvasottSor)
        {
       string[] adatok = beolvasottSor.Split(';');
            if (adatok.Length < 6)
            {
                throw new ArgumentException("A sor nem tartalmaz elegendő adatot.");
            }
            helyezes = int.Parse(adatok[0].Replace(".","").Trim());
            nev = adatok[1];
            elhelyezkedes = adatok[2].Trim();
            orszag = string.IsNullOrWhiteSpace(elhelyezkedes.Split(',')[1]) ? null : elhelyezkedes.Split(',')[1].Trim();
            pilon_tavolsag_m = string.IsNullOrWhiteSpace(adatok[3]) ? (int?)null : AlakitsdMeterre(adatok[3]);
            teljes_hossz_m = AlakitsdMeterre(adatok[4]);
            atadas_eve = int.Parse(adatok[5]);
        }
        int AlakitsdMeterre(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            // Átalakítás egységes formátumra
            input = input.ToLower().Replace(" ", " "); // nem törhető szóköz helyettesítése
            input = input.Replace("kb.", "").Trim();   // "kb." eltávolítása
            input = input.Replace(",", ".");           // decimális pont

            // Egység és szám kinyerése regex segítségével
            var match = Regex.Match(input, @"([\d.]+)\s*(km|m)");

            if (!match.Success)
                return 0;

            double szam = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            string egyseg = match.Groups[2].Value;

            if (egyseg == "km")
                return (int)(szam * 1000);
            else // "m"
                return (int)szam;
        }
    }
}
