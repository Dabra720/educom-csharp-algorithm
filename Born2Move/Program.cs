using BornToMove.DAL;

namespace BornToMove
{
    internal class Program
    {
        static Controller controller = new Controller();

        static void Main(string[] _)
        {
            //crud.fillDatabase();

            controller.Start();
        }


    }
}