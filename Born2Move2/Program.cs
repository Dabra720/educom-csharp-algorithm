namespace Born2Move
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            try
            {
                Console.WriteLine("Hallo, Welkom!");
                Console.WriteLine("Het is tijd om te bewegen!");
                Console.WriteLine("Maak een keuze:");
                Console.WriteLine("1. Krijg een bewegingssuggestie");
                Console.WriteLine("2. Kies een oefening uit de lijst");
                Console.ReadLine();

            }
            finally
            {
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
#endif
        }
    }
}