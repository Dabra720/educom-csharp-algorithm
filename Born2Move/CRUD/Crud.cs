using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Born2Move.CRUD
{
    internal class Crud
    {
        private string connectionString = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=born2move";
        public SqlConnection connection;

        public Crud() { 
            connection = new SqlConnection(connectionString);
        }

        public List<int> GetAllMoveIds()
        {
            List<int> moves = new List<int>();
            try
            {
                connection.Open();

                string query = "SELECT [id] FROM move";

                SqlCommand cmd = new SqlCommand(query, connection);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    moves.Add(result.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return moves;
        }

        public List<Move> GetAllMoves()
        {
            List<Move> moves = new List<Move>();
            try
            {
                connection.Open();

                string query = "SELECT * FROM move";

                SqlCommand cmd = new SqlCommand(query, connection);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    moves.Add(new Move(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetInt32(3)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Geen 'moves' gevonden.");
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }

            return moves;
        }

        public Move GetMoveById(int id)
        {
            Move move = null;
            try
            {
                connection.Open();
                string query = "SELECT * FROM [move] WHERE [id]=" + id;

                SqlCommand command = new SqlCommand(query, connection);
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    move = new Move(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetInt32(3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                connection.Close();
            }

            return move;
        }

        public Move GetRandomMove()
        {
            Move move = null;
            Random rnd = new Random();

            List<int> moveIds = GetAllMoveIds();
            int randomId = rnd.Next(moveIds.Count);

            move = GetMoveById(moveIds[randomId]);

            return move;
        }
    }
}
