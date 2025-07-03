using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutyakFeladat;

namespace KutyakFeladat
{
    internal class Kutya
    {
        public int id;
        public int fajta_id;
        public string fajtanev;
        public int nev_id;
        public string kutyanev;
        public int eletkor;
        public DateTime utolso_orvosi_ellenorzes;

        public Kutya(string beolvasottSor)
        {
            string[] adatok = beolvasottSor.Split(';');
            if (adatok.Length != 5)
            {
                throw new ArgumentException("A sor nem tartalmazza a szükséges adatokat.");
            }
            id = int.Parse(adatok[0]);
            fajta_id = int.Parse(adatok[1]);
            fajtanev = KutyakFeladat.Program.KutyaFajtanevek[int.Parse(adatok[1])].Nev;
            nev_id = int.Parse(adatok[2]);
            kutyanev = KutyakFeladat.Program.Kutyanevek[int.Parse(adatok[2])];
            eletkor = int.Parse(adatok[3]);
            utolso_orvosi_ellenorzes = DateTime.Parse(adatok[4]);
        }
    }
}
