namespace Born2Move
{
    internal class Program
    {
        static CRUD.Crud crud = new CRUD.Crud();
        static Controller.Controller controller = new Controller.Controller(crud);

        //static Database db = new Database();
        static void Main(string[] args)
        {
            controller.Start();
            /*Console.WriteLine("Hallo, Welkom!");
            Console.WriteLine();
            Console.WriteLine("Het is tijd om te bewegen!");
            Console.WriteLine();*/


            /*string choice = Console.ReadLine();
            bool next = false;
            while(!next)
            {
                Console.WriteLine("U heeft gekozen voor: " + choice);
                if (choice == "1")
                {
                    Console.WriteLine("Een bewegings suggestie");
                    next = true;
                    Move move = db.GetRandomMove();

                    Console.WriteLine("Suggestie: " + move.id + ". " + move.name);
                    break;
                }
                if (choice == "2") {
                    Console.WriteLine("Zelf kiezen uit lijst");
                    next = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Dat is geen optie, kies opnieuw:");
                    choice = Console.ReadLine();
                }

            }

            next = false;*/

            //Console.WriteLine("Keuze display:");
            //db.GetAllMoveIds().ForEach(id => Console.WriteLine(id));
            //List<Move> moves = db.GetAllMoves();

            //moves.ForEach(move =>  Console.WriteLine("Beweging: " + move.id + ". " + move.name));
            // If database is empty:
            //db.fillDatabase();



        }

        public void FirstChoice()
        {
            Console.WriteLine("Maak een keuze:");
            Console.WriteLine();
            Console.WriteLine("1. Krijg een suggestie");
            Console.WriteLine("2. Kies een oefening");
            Console.WriteLine();

            bool next = false;
            while (!next)
            {
                string choice = Console.ReadLine();
                Console.WriteLine("U heeft gekozen voor: " + choice);
                if (choice == "1")
                {
                    Console.WriteLine("Een bewegings suggestie");
                    Console.WriteLine();
                    //next = true;
                    Move move = db.GetRandomMove();

                    Console.WriteLine("Suggestie: " + move.id + ". " + move.name);
                    break;
                }
                if (choice == "2")
                {
                    Console.WriteLine("Zelf kiezen uit lijst");
                    Console.WriteLine();
                    //next = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Dat is geen optie, kies opnieuw:");
                }

            }
        }

        public 

    }
}