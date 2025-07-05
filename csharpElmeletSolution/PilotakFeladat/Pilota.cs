using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotakFeladat
{
    internal class Pilota
    {
        public string nev;
        public DateTime szuletesi_datum;
        public string nemzetiseg;
        public string rajtszam;

        /// <summary>
        /// Pilta osztály konstruktora, amely egy sorban lévő adatokat hozzárendel a megfelelő tulajdonságokhoz.
        /// </summary>
        /// <param name="beolvasottSor"></param>
        /// <exception cref="ArgumentException"></exception>
        public Pilota(string beolvasottSor)
        {
            string[] adatok = beolvasottSor.Split(';');
            if (adatok.Length < 3)
            {
                throw new ArgumentException("A sor nem tartalmazza a szükséges adatokat.");
            }
            this.nev = adatok[0];
            this.szuletesi_datum = DateTime.Parse(adatok[1]);
            this.nemzetiseg = adatok[2];
            // Csak az aktív pilóták esetében van rajtszám!
            this.rajtszam = adatok[3];
        }
    }
}
