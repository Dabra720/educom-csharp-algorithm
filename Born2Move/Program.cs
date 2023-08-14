using MySqlConnector;

namespace Born2Move
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Database db = new Database();
            db.TestDatabase();

            db.fillDatabase();
            //string result = db.InsertMove();
            
            //Console.WriteLine(result);
        }

    }
}