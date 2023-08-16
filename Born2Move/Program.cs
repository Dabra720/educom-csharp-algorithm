using BornToMove.DAL;

namespace Born2Move
{
    internal class Program
    {
        //static Crud crud = new Crud();
       // static Controller controller = new Controller(crud);

        static MoveCrud crud = new MoveCrud();

        static void Main(string[] args)
        {
            //crud.fillDatabase();
            //controller.Start();
            /*Console.WriteLine("Creating Move");

            Move move = new Move("Jumping Jacks", "100x", 5);

            int id = crud.create(move);*/

            int id = 1003;

            Move newMove = crud.readMoveById(id);

            Console.WriteLine("Your new move is: ");
            Console.WriteLine(newMove.id + " | " + newMove.name);



            Console.WriteLine("Removing Move: 9");

            crud.delete(9);
        }


    }
}