using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            const int minimumTipp = 1;
            const int maximumTipp = 45;
            const int darab = 5;

            int[] generaltSzamok = new int[darab];
            int[] tippeltSzamok = new int[darab];
            Random rnd = new Random();
            List<int> talalatok = new List<int>();

            for (int i = 0; i < generaltSzamok.Length; i++)
            {
                bool szerepelt = false;
                int szam = 0;
                do
                {
                    szerepelt = false;
                    szam = rnd.Next(minimumTipp, maximumTipp + 1);
                    for (int j = 0; j < i; j++)
                    {
                        if (generaltSzamok[j] == szam)
                        {
                            szerepelt = true;
                        }
                    }
                } while (szerepelt);
                generaltSzamok[i] = szam;                
            }

            Console.WriteLine("Adjon meg {0} darab számot {1} és {2} között:"
                ,darab,minimumTipp,maximumTipp);

            for (int i = 0; i < tippeltSzamok.Length; i++)
            {
                Console.Write("Kérem adja meg a(z) {0}. számot: ",i+1);
                int szam = 0;
                while (!int.TryParse(Console.ReadLine(), out szam) || szam < minimumTipp || szam > maximumTipp || Szerepelt(tippeltSzamok, szam))
                {
                    Console.Write("Nem megfelelő számot adott meg, vagy a megadott szám már szerepelt, kérem adjon meg egy {0} és {1} közötti számot: "
                        ,minimumTipp, maximumTipp);
                }
                tippeltSzamok[i] = szam;
            }

            //Array.Sort(tippeltSzamok);
            for (int i = 0; i < generaltSzamok.Length; i++)
            {
                for (int j = 0; j < tippeltSzamok.Length; j++)
                {
                    if (generaltSzamok[i] == tippeltSzamok[j])
                    {
                        talalatok.Add(tippeltSzamok[j]);
                    }
                }
            }
            Console.WriteLine("Generált számok: "+String.Join(", ", generaltSzamok));
            Console.WriteLine("Tippelt számok: "+String.Join(", ", tippeltSzamok));
            Console.WriteLine("Találatok száma: {0} db. Ezek a számol: {1}", talalatok.Count,
                String.Join(", ",talalatok));

            Console.ReadKey();
        }
        private static bool Szerepelt(int[] tomb, int szam)
        {
            int i = 0;
            while (i < tomb.Length && tomb[i] != szam)
            {
                i++;
            }
            bool szerepelt = false;
            if (i < tomb.Length)
            {
                szerepelt = true;
            }
            return szerepelt;
        }
    }
}
