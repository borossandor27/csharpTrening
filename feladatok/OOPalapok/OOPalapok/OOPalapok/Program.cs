using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    class Program
    {
        static void Main(string[] args)
        {
            HaziAllat cica = new HaziAllat("Cirmi","Macska",false,3,4,"Géza");
            
            cica.LabakSzama = 5;
            Console.WriteLine(cica.LabakSzama);

            Console.WriteLine(cica);

            HaziAllat kutya = new HaziAllat("Bodri", "Kutya", true, "Feri");

            Console.WriteLine(kutya);
            kutya.Kiir(true);

            HaziAllat masikKutya = new HaziAllat("Masni", "Kutya", false, "Feri");

            var uj = kutya + masikKutya;
            Console.WriteLine(uj);
            
            Console.ReadKey();
        }
    }
}
