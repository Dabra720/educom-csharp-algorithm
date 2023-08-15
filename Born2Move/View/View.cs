using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Born2Move.View
{
    internal class View
    {
        public void Welcome(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
        
        public string ListOrSuggestion()
        {
            Console.WriteLine("Maak een keuze:");
            Console.WriteLine();
            Console.WriteLine("1. Krijg een suggestie");
            Console.WriteLine("2. Kies een oefening");
            Console.WriteLine();

            string choice = "";

            bool next = false;
            while (!next)
            {
                choice = Console.ReadLine();
                Console.WriteLine("U heeft gekozen voor: " + choice);
                if (choice == "0" || choice == "1" || choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Dat is geen optie, kies opnieuw:");
                }

            }
            return choice;
        }

        public void ShowSuggestion(Move move)
        {

        }

        public void ShowMoves()
        {

        }
    }
}
