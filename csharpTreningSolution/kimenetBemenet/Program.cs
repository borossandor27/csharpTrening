using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kimenetBemenet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kérlek, add meg a neved: ");
            string felhasznaloNev = Console.ReadLine(); // Beolvas egy sort (string)

            Console.Write("Kérlek, add meg az életkorod: ");
            // Fontos: Console.ReadLine() MINDIG string-et ad vissza, ha számmá akarjuk alakítani, használnunk kell a Convert.ToInt32-t
            int felhasznaloKor = Convert.ToInt32(Console.ReadLine());

            // egyszerű adattípus hibákat elkerülendő, érdemes a TryParse-t használni
            Console.Write("Kérlek, add meg az életkorod újra: ");
            string bemenet = Console.ReadLine();
            int felhasznaloKor2= 0;
            int.TryParse(bemenet, out felhasznaloKor2); // A TryParse megpróbálja átalakítani a bemenetet, ha nem sikerül, akkor 0 értéket és False-t ad vissza.
            Console.WriteLine($"Ha jól adtad meg a korodat, akkor ez nem nulla: {felhasznaloKor2}");

            Console.WriteLine($"Szia, {felhasznaloNev}! Látom, {felhasznaloKor} éves vagy.");

            // String interpoláció (a $ jel előtt) a könnyebb formázáshoz
            Console.WriteLine($"Kétszer annyi idős leszel: {felhasznaloKor * 2} év.");
        }
    }
}
