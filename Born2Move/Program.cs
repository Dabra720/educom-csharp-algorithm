using BornToMove.DAL;

namespace BornToMove
{
    internal class Program
    {
        static Controller controller = new Controller();

        static void Main(string[] args)
        {
            //crud.fillDatabase();

            controller.Start();
        }


    }
}