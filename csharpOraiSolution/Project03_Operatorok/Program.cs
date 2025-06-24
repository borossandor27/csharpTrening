using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project03_Operatorok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kérem az első száot: ");

            int egeszSzam1 = int.Parse(Console.ReadLine()); // A kapott szöveget egész számmá alakítjuk

            Console.Write("\nKérek egy másik számot: ");

            int egeszSzam2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{egeszSzam1}/{egeszSzam2} = {egeszSzam1/(float)egeszSzam2}");
            Console.WriteLine( "Program vége!");
            Console.ReadLine(); // Várakozás a felhasználó beavatkozására
        }
    }
}
