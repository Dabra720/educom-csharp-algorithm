using BornToMove.DAL;

namespace Born2Move
{
    internal class Program
    {
        //static Crud crud = new Crud();

        static MoveCrud crud = new MoveCrud();
        static Controller controller = new Controller(crud);

        static void Main(string[] args)
        {
            //crud.fillDatabase();

            controller.Start();
        }


    }
}