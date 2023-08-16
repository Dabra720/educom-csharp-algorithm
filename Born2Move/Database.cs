using BornToMove.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Born2Move
{
    internal class Database
    {
        private string connectionString = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=born2move";
        public SqlConnection connection;
        SqlCommand cm;
        
        public Database()
        {
            this.connection = new SqlConnection(connectionString);
        }

        private bool CheckDatabaseExist()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
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
                cm = new SqlCommand(query, connection);
                cm.ExecuteNonQuery();

                Console.WriteLine("Database filled.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Database could not be filled");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public string InsertMove(Move move)
        {
            try
            {
                connection.Open();
            
                using var command = new SqlCommand("INSERT INTO move([name], [description], [sweatRate]) VALUES('"+ move.name +"', '"+move.description+"', "+move.sweatRate+")", this.connection);
                int i = command.ExecuteNonQuery();
                Console.WriteLine("i: " + i);
                if(i > -1)
                {
                    return "Success";

                }
                return "Unsuccesful";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Failure";
            }
            finally
            {
                connection.Close();
            }
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
            catch(Exception ex)
            {

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
                    moves.Add(new Move{ 
                        id = result.GetInt32(0), 
                        name = result.GetString(1), 
                        description = result.GetString(2), 
                        sweatRate = result.GetInt32(3) 
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Geen 'moves' gevonden.");
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
                    move = new Move{ 
                        id = result.GetInt32(0), 
                        name = result.GetString(1), 
                        description = result.GetString(2), 
                        sweatRate = result.GetInt32(3) 
                    };
                }
            }
            catch(Exception ex)
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
