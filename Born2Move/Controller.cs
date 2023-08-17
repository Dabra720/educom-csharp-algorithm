using BornToMove.Business;
using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BornToMove
{
    internal class Controller
    {
        //private Crud crud;
        //private MoveCrud crud;
        private BuMove buMove;
        private View view;

        public Controller()
        {
            //this.crud = crud;
            view = new View();
            buMove = new BuMove();
        }

        public void Start()
        {
            Console.WriteLine("Welkom!");
            Console.WriteLine("Het is weer tijd om te bewegen!");

            Console.WriteLine("Maak een keuze:");
            Console.WriteLine();
            Console.WriteLine("1. Krijg een suggestie");
            Console.WriteLine("2. Kies een oefening");
            Console.WriteLine();

            string choice = "";

            while (true)
            {
                choice = Console.ReadLine();
                if(choice == "1")
                {
                    Move suggestion = buMove.GetRandomMove();
                    Console.WriteLine("Onze suggestie:");
                    suggestion.Show();
                    break;
                }
                if(choice == "2")
                {
                    List<Move> moves = buMove.GetAllMoves();

                    Console.WriteLine("Kies uit onderstaande bewegingen:");
                    view.ShowMoveList(moves); // Print alle moves 
                    Console.WriteLine("0. Maak een nieuwe beweging aan.");

                    Move move = PickMove(moves); 

                    Console.WriteLine("Dit heeft u gekozen:");
                    move.Show();
                    break;
                }
            }


            Console.WriteLine();
            Console.WriteLine("Hoe vond je de oefening?");
            Console.WriteLine("Beoordeling: (1-5) ");
            Console.ReadLine();
            Console.WriteLine("Intensiteit: (1-5) ");
            Console.ReadLine();


        }

        public Move PickMove(List<Move> moves)
        {
            string choice = "";
            Move move = null;
            while(true)
            {
                choice = Console.ReadLine();
                try
                {
                    int index = int.Parse(choice);
                    if(index == 0)
                    {
                        int id = MakeNewMove();
                        move = buMove.GetMoveById(id);
                        break;
                    }
                    else
                    {
                        move = moves[index - 1];
                        Console.WriteLine("Je hebt gekozen! " + move.name);
                        break;
                    }
                    

                }
                catch(Exception ex) 
                {
                    Console.WriteLine("Geen beweging!");
                }
            }

            return move;
        }

        public int MakeNewMove()
        {
            string name, description;
            int sweatRate;
            Move move = null;

            Console.WriteLine("Maak een nieuwe beweging:");

            Console.WriteLine("Naam:");
            while (true)
            {
                name = Console.ReadLine();
                if (buMove.GetMoveByName(name) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Deze oefening bestaat al");
                }
            }

            Console.WriteLine("Beschrijving:");
            description = Console.ReadLine();

            Console.WriteLine("Hoeveelheid zweet van 1 tot 5:");
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    sweatRate = int.Parse(input);
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Een cijfer tussen 1 en 5");
                }
            }

            move = new Move { name = name, description = description, sweatRate = sweatRate };

            int id = buMove.SaveMove(move);

            return id;
        }
    }
}
