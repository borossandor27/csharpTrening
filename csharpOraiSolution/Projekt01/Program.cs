namespace Projekt01;

class Program
{
    public static void Main(string[] OsszesParameter)
    {
        //  parancssori argumentumok kiírása
        if (OsszesParameter.Length > 0)
        {
            Console.WriteLine("Parancssori argumentumok: ");
            foreach (var kapottEgyikParameter in OsszesParameter)
            {
                Console.WriteLine(kapottEgyikParameter);
            }
        }
        else
        {
            Console.WriteLine("Nincsenek parancssori argumentumok.");
        }
        Console.Write("\nKérek egy adatot: ");
        string input = Console.ReadLine();
        Console.WriteLine($"\nA kapott adat: {input}");
        Console.WriteLine("\nHello, World!");
        Console.ReadLine(); // Várakozás a felhasználó beavatkozására
    }
}
