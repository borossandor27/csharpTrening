using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Char
{
    internal class Program
    {
        static void Main()
        {
            // Karakter (char) példák
            char betu = 'A';
            Console.WriteLine($"char változó értéke: {betu}");
            Console.WriteLine($"char típusa: {betu.GetType()}");

            // String (string) példák
            string szo = "Alma";
            Console.WriteLine($"\nstring változó értéke: {szo}");
            Console.WriteLine($"string típusa: {szo.GetType()}");

            // string hossz (karakterszám)
            Console.WriteLine($"\nA \"{szo}\" szó {szo.Length} karakterből áll.");

            // string karakterei elérhetők indexeléssel
            Console.WriteLine($"A szó első betűje: {szo[0]}"); // Ez char típusú!

            // char + char nem ad össze szöveget!
            char c1 = 'a';
            char c2 = 'b';
            Console.WriteLine($"\nchar + char (számként): {c1 + c2}"); // int összeadás
            Console.WriteLine($"char összefűzéshez: {"" + c1 + c2}"); // string-gé konvertálva

            // összehasonlítás
            Console.WriteLine($"\nAz 'a' és \"a\" összehasonlítása:");
            Console.WriteLine($"'a' == \"a\" → HIBA lenne fordításkor, mert különböző típus");

            // típuskonverzió
            string egyKarakteresSztring = "A";
            char karakter = egyKarakteresSztring[0]; // string -> char
            Console.WriteLine($"\nEgy karakter kinyerése a sztringből: {karakter}");

            Console.Write("\nAdj meg egy szót: ");
            string input = Console.ReadLine();

            foreach (char c in input)
            {
                Console.WriteLine($"Karakter: {c}, Unicode: {(int)c}");
            }
            Console.WriteLine("\nProgram vége!");
            Console.Read();
        }
    }
}
