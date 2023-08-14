using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Born2Move
{
    internal class Database
    {
        private string connectionString = "Server=localhost;User ID=root;Password=ZwarteKoffie421;Database=born2move";
        public MySqlConnection connection;
        MySqlCommand cm;

        public Database()
        {
            this.connection = new MySqlConnection(connectionString);
        }

        public void TestDatabase()
        {
            if(!CheckDatabaseExist())
            {
                GenerateDatabase();
            }
            else { Console.WriteLine("Database already exists"); }
        }

        private bool CheckDatabaseExist()
        {
            try
            {
                this.connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.connection.Close();
            }
        }

        private void GenerateDatabase()
        {
           /* try
            {
                //cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("drop database {0}", "born2move"));
                cm = new MySqlCommand(sb.ToString(), this.connection);
                this.connection.Open();
                cm.ExecuteNonQuery();
                this.connection.Close();
            }
            catch
            {
                Console.WriteLine("Fail @ dropping database");
            }*/
            try
            {
                //Application.StartupPath is the location where the application is Installed
                //Here File Path Can Be Provided Via OpenFileDialog
                Console.WriteLine("Path: " + AppDomain.CurrentDomain.BaseDirectory);
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data\\born2move.sql"))
                {
                    Console.WriteLine("file found!");
                    string script = null;
                    script = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\born2move.sql");
                    string[] ScriptSplitter = script.Split(new string[] { "GO" }, StringSplitOptions.None);
                    
                    {
                        this.connection.Open();
                        foreach (string str in ScriptSplitter)
                        {
                            using (cm = this.connection.CreateCommand())
                            {
                                cm.CommandText = str;
                                cm.ExecuteNonQuery();
                            }
                        }
                    }
                } else { Console.WriteLine("file not found!"); }
            }
            catch
            {
                Console.WriteLine("Fail @ finding file");
            }
        }
        public void fillDatabase()
        {
            try
            {
                this.connection.Open();
                string query = "INSERT INTO move (name, description, sweatRate) VALUES (\"Push up\", \"Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes\", 3),\r\n(\"Planking\", \"Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast\", 3),\r\n(\"Squat\", \"Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes\", 3)";

                cm = new MySqlCommand(query, this.connection);
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
                this.connection.Close();
            }

        }
        public string InsertMove()
        {
            try
            {
                this.connection.Open();
            
                using var command = new MySqlCommand("INSERT INTO move(name, description, sweatRate) VALUES('Benchpress', 'POMPEN', 2)", this.connection);
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
                this.connection.Close();
            }
        }


    
    }
}
