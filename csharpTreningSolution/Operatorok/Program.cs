using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 5;

            // Aritmetikai kifejezések
            int osszeg = a + b; // 15
            int kulonbseg = a - b; // 5
            int szorzat = a * b; // 50
            double hanyados = (double)a / b; // 2.0 (fontos a típuskényszerítés double-re az egész számos osztás elkerülésére)
            int maradek = a % b; // 0

            Console.WriteLine($"Összeg: {osszeg}");
            Console.WriteLine($"Különbség: {kulonbseg}");
            Console.WriteLine($"Szorzat: {szorzat}");
            Console.WriteLine($"Hányados: {hanyados}");
            Console.WriteLine($"Maradék: {maradek}");

            // Összehasonlító kifejezések
            bool egyenlo = (a == b); // false
            bool nagyobb = (a > b); // true

            Console.WriteLine($"A és B egyenlő? {egyenlo}");
            Console.WriteLine($"A nagyobb B-nél? {nagyobb}");

            // Logikai kifejezések
            bool feltetel1 = (a > 0 && b < 10); // true && true -> true
            bool feltetel2 = (a < 0 || b > 10); // false || false -> false
            bool feltetel3 = !(a == b); // !false -> true

            Console.WriteLine($"Feltétel 1: {feltetel1}");
            Console.WriteLine($"Feltétel 2: {feltetel2}");
            Console.WriteLine($"Feltétel 3: {feltetel3}");
        }
    }
}
