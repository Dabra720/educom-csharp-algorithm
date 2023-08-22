using BornToMove.Business;
using BornToMove.DAL;
using Microsoft.IdentityModel.Tokens;
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
        private MoveCrud moveCrud= new MoveCrud();
        private BuMove buMove;
        private View view;

        public Controller()
        {
            //this.crud = crud;
            view = new View();
            buMove = new BuMove(moveCrud);
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
            Move move;

            while (true)
            {
                choice = Console.ReadLine();
                if(choice == "1")
                {
                    move = buMove.GetRandomMove();
                    Console.WriteLine("Onze suggestie:");
                    move.Show();
                    break;
                }
                if(choice == "2")
                {
                    List<Move> moves = buMove.GetAllMoves();

                    Console.WriteLine("Kies uit onderstaande bewegingen:");
                    view.ShowMoveList(moves); // Print alle moves 
                    Console.WriteLine("0. Maak een nieuwe beweging aan.");

                    move = PickMove(moves); 

                    Console.WriteLine("Dit heeft u gekozen:");
                    move.Show();
                    break;
                }
            }

            RateMove(move);


            var moveWithRating = buMove.GetMoveByName(move.Name);

            Console.WriteLine();
            Console.WriteLine("De bewerkte move:");
            Console.WriteLine("Naam: " + moveWithRating.Move.Name + " | Rating: " + moveWithRating.AverageRating);
            Console.WriteLine();
            Console.WriteLine("Bedankt voor uw feedback!");

        }

        public void RateMove(Move move)
        {
            string ratingStr;
            string voteStr;
            double rating, vote;

            Console.WriteLine();
            Console.WriteLine("Hoe vond je de oefening?");

            Console.WriteLine("Beoordeling: (1-5) ");
            while(true)
            {
                try
                {
                    ratingStr = Console.ReadLine();
                    rating = double.Parse(ratingStr);
                    if(rating >= 1 && rating <= 5) { 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tussen 1 en 5");
                    }
                }
                catch
                {
                    Console.WriteLine("Dat is geen juiste rating");
                }

            }

            Console.WriteLine("Intensiteit: (1-5) ");
            while (true)
            {
                try
                {
                    voteStr = Console.ReadLine();
                    vote = double.Parse(voteStr);
                    if (rating >= 1 && rating <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tussen 1 en 5");
                    }
                }
                catch
                {
                    Console.WriteLine("Dat is geen juiste rating");
                }

            }

            buMove.SaveRating(rating, vote, move);

        }

        public Move PickMove(List<Move> moves)
        {
            string choice;
            Move move;
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
                        Console.WriteLine("Je hebt gekozen! " + move.Name);
                        break;
                    }
                    

                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Geen beweging!");
                }
            }

            return move;
        }

        public int MakeNewMove()
        {
            string name, description="";
            int sweatRate;
            Move move;

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
            while(description.IsNullOrEmpty())
            {
                description = Console.ReadLine();

            }

            Console.WriteLine("Hoeveelheid zweet van 1 tot 5:");
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    sweatRate = int.Parse(input);
                    break;
                }
                catch
                {
                    Console.WriteLine("Een cijfer tussen 1 en 5");
                }
            }

            move = new Move { Name = name, Description = description , sweatRate = sweatRate };

            int id = buMove.SaveMove(move);

            return id;
        }
    }
}
