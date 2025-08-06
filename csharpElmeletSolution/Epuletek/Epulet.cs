using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epuletek
{
    internal class Epulet
    {
        public int Sorszam { get; set; }
        public string Nev { get; set; }
        public string VarosEsOrszag { get; set; }
        public double Magassag { get; set; } // méter
        public int? Emeletek { get; set; }    // lehet null
        public int EpultEv { get; set; }
        public string Koordinatak { get; set; }
        public double Lat;
        public double Long;

        public Epulet(string beolvasottSor)
        {
            string[] adatok = beolvasottSor.Split(';');
            if (adatok.Length < 7)
            {
                throw new ArgumentException("A sor nem tartalmaz elegendő adatot.");
            }
            Sorszam = int.Parse(adatok[0]);
            Nev = adatok[1];
            VarosEsOrszag = adatok[2];
            Magassag = double.Parse(adatok[3]);
            Emeletek = int.TryParse(adatok[4], out int parsed) ? parsed : (int?)null;
            EpultEv = int.Parse(adatok[5]);
            Koordinatak = adatok[6];
            (this.Lat, this.Long) = ParseCoordinates(Koordinatak);
        }
        /***
         * Ez egy fok-perc-másodperc (DMS) formátumból tizedes fok (decimal degrees) formára konvertáló függvény
         * paramétere egy string, amely a fok-perc-másodperc formátumot tartalmazza (mint a forrásfájlban)
         */
        public static double ConvertDmsToDecimal(string dms)
        {
            var regex = new Regex(@"(\d+)°\s*(\d+)′\s*(\d+)″");
            var match = regex.Match(dms);
            if (!match.Success) return 0;

            int degrees = int.Parse(match.Groups[1].Value);
            int minutes = int.Parse(match.Groups[2].Value);
            int seconds = int.Parse(match.Groups[3].Value);

            return degrees + minutes / 60.0 + seconds / 3600.0;
        }

        /***
         * A megszokott GPS formára alakítva
         */

        public static (double lat, double lon) ParseCoordinates(string koordinata)
        {
            var parts = koordinata.Split(',');
            var lat = ConvertDmsToDecimal(parts[0]);
            var lon = ConvertDmsToDecimal(parts[1]);

            // Ha a földrajzi irány "déli" vagy "nyugati", akkor negatív érték
            if (parts[0].Contains("d. sz.")) lat *= -1;
            if (parts[1].Contains("ny. h.")) lon *= -1;

            return (lat, lon);
        }

    }
}
