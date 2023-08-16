using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Born2Move
{
    internal class Crud
    {
        private string connectionString = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=born2move";
        public SqlConnection connection;

        public Crud()
        {
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

        public Move GetMoveByName(string name)
        {
            Move move = null;
            string query = "SELECT * FROM [move] WHERE [name]=@name";
            try
            {
                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    connection.Open();

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        move = new Move(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetInt32(3));
                    }

                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

            return move;
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

        public int InsertMove(Move move)
        {
            try
            {
                string query = "INSERT INTO move([name], [description], [sweatRate]) VALUES(@name, @description, @sweatRate); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", move.name);
                    cmd.Parameters.AddWithValue("@description", move.description);
                    cmd.Parameters.AddWithValue("@sweatRate", move.sweatRate);
                    connection.Open();

                    int modified = Convert.ToInt32(cmd.ExecuteScalar());

                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                    return modified;
                }
            }
            catch (Exception ex) { return 0; }
           /* try
            {
                connection.Open();

                using var command = new SqlCommand("INSERT INTO move([name], [description], [sweatRate]) VALUES('" + move.name + "', '" + move.description + "', " + move.sweatRate + ")", this.connection);
                //int i = command.ExecuteNonQuery();
                int i = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine("i: " + i);
                
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                connection.Close();
            }*/
        }

        public void fillDatabase()
        {
            try
            {
                connection.Open();
                string path = @".\Data\insertData.sql";
                string[] files = File.ReadAllLines(path);
                string query = "";
                foreach (string file in files)
                {
                    query += file;
                }

                //string query = "INSERT INTO [move] ([name], [description], [sweatRate]) VALUES('Test', 'Test', 2)";
                SqlCommand cm = new SqlCommand(query, connection);
                cm.ExecuteNonQuery();

                Console.WriteLine("Database filled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database could not be filled");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
