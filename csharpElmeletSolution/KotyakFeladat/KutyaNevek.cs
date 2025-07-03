using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotyakFeladat
{
    internal class KutyaNevek
    {
        public int id;
        public string nev;
        public KutyaNevek(string beolvasottSor)
        {
            string[] adatok = beolvasottSor.Split(';');
            if (adatok.Length != 2)
            {
                throw new ArgumentException("A sor nem tartalmazza a szükséges adatokat.");
            }
            id = int.Parse(adatok[0]);
            nev = adatok[1];
        }
    }
}
