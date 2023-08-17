using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Born2Move
{
    internal class View
    {
        public void Welcome()
        {
            Console.WriteLine("Welkom!");
            Console.WriteLine("Het is weer tijd om te bewegen!");
        }

        public void ListOrSuggestion()
        {
            Console.WriteLine("Maak een keuze:");
            Console.WriteLine();
            Console.WriteLine("1. Krijg een suggestie");
            Console.WriteLine("2. Kies een oefening");
            Console.WriteLine();
        }

        public void ShowSuggestion(Move move)
        {
            Console.WriteLine("Onze suggestie:");
            Console.WriteLine("Naam: " + move.name + " | Sweatrate: " + move.sweatRate);
        }

        public void ShowMoveList(List<Move> allMoves)
        {
            Console.WriteLine("Kies uit onderstaande bewegingen:");
            for (int i = 0; i < allMoves.Count; i++)
            {
                Move move = allMoves[i];
                Console.WriteLine((i + 1) + ". " + move.name + " Sweatrate: " + move.sweatRate);
            }
            Console.WriteLine("0. Maak een nieuwe beweging aan.");
        }
    }
}
