using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    /// <summary>
    /// Háziállatok nevét, fajtáját, nemét, életkorát, lábak számát és gazdájának nevét tárolja
    /// </summary>
    class HaziAllat
    {
        private string nev;
        private string fajta;
        private bool neme;
        private int eletkor;
        private int labakSzama;
        private string gazda;

        public HaziAllat(string nev, string fajta, bool neme, int eletkor, int labakSzama, string gazda)
        {
            this.nev = nev;
            this.fajta = fajta;
            this.neme = neme;
            this.eletkor = eletkor;
            this.labakSzama = labakSzama;
            this.gazda = gazda;

            if (this.eletkor < 0)
            {
                this.eletkor = 0;
            }
            if (this.labakSzama < 0)
            {
                this.labakSzama = 0;
            }
        }
        /// <summary>
        /// Létrehoz egy új háziállatot, amelynek az életkora 0, lábainak száma 4
        /// </summary>
        /// <param name="nev">Az állat neve</param>
        /// <param name="fajta">A állat fajtája</param>
        /// <param name="neme">Az állat neme (true -> hím, false -> nőstény)</param>
        /// <param name="gazda">Az állat gazdájának neve</param>
        public HaziAllat(string nev, string fajta, bool neme, string gazda)
        {
            this.nev = nev;
            this.fajta = fajta;
            this.neme = neme;
            this.gazda = gazda;
            this.eletkor = 0;
            this.labakSzama = 4;
        }
        /// <summary>
        /// Kiírja a konzolra az állat összes adatát egy sorban.
        /// </summary>
        public void Kiir()
        {
            Console.WriteLine(this.ToString());
        }
        /// <summary>
        /// Kiírja a konzolra az állat összes adatát
        /// </summary>
        /// <param name="tobbSorban">Megadja, hogy egy vagy több sorban írja ki az adatokat</param>
        public void Kiir(bool tobbSorban)
        {
            if (tobbSorban)
            {
                Console.WriteLine("{0} - {1}",nev,eletkor);
                Console.WriteLine("\t{0} - {1}",neme ? "hím" : "nőstény",fajta);
                Console.WriteLine("\tGazda: {0} - Lábak: {1} db",gazda,labakSzama);
            }
            else
            {
                this.Kiir();
            }
        }

        public string Nev { get => nev; set => nev = value; }
        public string Fajta { get => fajta; }
        public bool Neme { get => neme; }
        public int Eletkor { get => eletkor; 
            set {
                if (value > eletkor)
                {
                    eletkor = value;
                }                
            } 
        }
        public int LabakSzama { get => labakSzama;
            set
            {
                if (value < labakSzama)
                {
                    labakSzama = value;
                }
                if (labakSzama < 0)
                {
                    labakSzama = 0;
                }
            }
        }
        public string Gazda { get => gazda; set => gazda = value; }

        public override string ToString()
        {
            return String.Format("{0} - {1} ({2} - {5})\tGazda: {3}\tLábak: {4} db",
                nev,
                eletkor,
                neme ? "hím" : "nőstény",
                gazda,
                labakSzama,
                fajta
                );
        }

        public static HaziAllat operator +(HaziAllat allat1, HaziAllat allat2)
        {
            if (allat1.fajta == allat2.fajta && allat1.neme != allat2.neme)
            {
                Random rnd = new Random();
                return new HaziAllat(allat1.nev + " " + allat2.nev,
                    allat1.fajta, rnd.Next(0, 2) == 1, allat1.gazda);
            }
            return null;
        }
    }
}
