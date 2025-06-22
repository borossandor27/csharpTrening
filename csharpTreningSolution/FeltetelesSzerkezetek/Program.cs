using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeltetelesSzerkezetek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int homerseklet = 25;

            if (homerseklet > 30)
            {
                Console.WriteLine("Hőségriadó van!");
            }
            else if (homerseklet > 20)
            {
                Console.WriteLine("Kellemes meleg van.");
            }
            else if (homerseklet > 10)
            {
                Console.WriteLine("Hűvös van, de még elviselhető.");
            }
            else
            {
                Console.WriteLine("Hideg van.");
            }
        }
    }
}
