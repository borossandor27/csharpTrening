using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regularis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program elindult...");
            Telefonszamos();
            EmailCimek();
            Optimalizalas();
            Console.WriteLine("Program vége!");
            // A program futása után a konzol ablak azonnal bezárul, ha nincs várakozás.
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez...");
            // Várakozás a felhasználó gombnyomására
            Console.ReadKey();
        }

        private static void Optimalizalas()
        {
            string input = "Lorem ipsum 123 dolor sit 456 amet, consectetur 789 adipiscing elit.";
            string pattern = @"\d+";

            // Normál regex
            var normalRegex = new Regex(pattern);

            // Compiled regex
            var compiledRegex = new Regex(pattern, RegexOptions.Compiled);

            // Teljesítmény teszt
            TestPerformance(normalRegex, input, "Normál regex");
            TestPerformance(compiledRegex, input, "Compiled regex");
        }

        static void TestPerformance(Regex regex, string input, string description)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 100000; i++)
            {
                regex.Matches(input);
            }

            stopwatch.Stop();
            Console.WriteLine($"{description}: {stopwatch.ElapsedMilliseconds} ms");
        }

        private static void EmailCimek()
        {
            string emails = "Írj a info@example.com vagy a support@company.com címre!";
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

            var emailMatches = Regex.Matches(emails, emailPattern);
            Console.WriteLine("Találatok:");

            foreach (Match email in emailMatches)
            {
                Console.WriteLine($"\t{email.Value}");
            }
        }

        private static void Telefonszamos()
        {
            string input = "A telefonszámom: +36 30 123 4567, másik szám: 06-20-555-6677";

            // Telefonszám mintát definiálás
            string pattern = @"(\+36|06)[\s-]?\d{1,2}[\s-]?\d{3}[\s-]?\d{4}";

            // Regex objektum létrehozása
            Regex regex = new Regex(pattern);

            // Egyezések keresése
            MatchCollection matches = regex.Matches(input);

            // Eredmények kiírása
            Console.WriteLine("Találatok:");
            foreach (Match match in matches)
            {
                Console.WriteLine($"\t {match.Value}");
            }
        }
    }
}
