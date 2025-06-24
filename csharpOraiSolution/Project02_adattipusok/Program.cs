using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project02_adattipusok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int egeszSzam1 = 42; // Egész szám típus
            int egeszSzam2 = -7; // Másik egész szám
            double tizedesSzam = 3.14; // Tizedes tört típus
            string szoveg = "Hello, World!"; // Szöveg típus
            bool logikaiErtek = true; // Logikai érték (igaz/hamis)
            char karakter = 'a'; // Karakter típus
            


            Console.WriteLine($"Az '{karakter}' karakter kója: {(int)karakter}");

           

            Console.WriteLine("A program elindult...");
            Console.WriteLine("\n\n\nProgram vége!");
            Console.ReadLine(); // Várakozás a felhasználó beavatkozására
        }
    }
}
