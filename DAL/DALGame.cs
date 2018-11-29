using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALGame : IPersistense<Game>
    {

        private string connectionString = "";

        public DALGame()
        {
            connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=QuakeLog;Integrated Security=True";
        }

        public void Save(Game entity)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Game (Id, Nome) Values (@v1, @v2)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", entity.Id);
                cmd.Parameters.AddWithValue("@v2", entity.Nome);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Game> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Game";
                SqlCommand cmd = new SqlCommand(sql, conn);
                List<Game> games;
                Game g = null;

                try
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                            games = new List<Game>();
                        else
                            return null;

                        while (reader.Read())
                        {
                            g = new Game
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Nome = reader["Nome"].ToString()
                            };

                            games.Add(g);
                        }
                        return games;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Game GetByNome(string s)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Game WHERE Nome = @v1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", s);
                Game game = null;

                try
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            game = new Game
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Nome = reader["Nome"].ToString()
                            };
                        }
                        return game;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Game GetGamesDataSet()
        {
            using(var conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Game";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString);

                DataSet game = new DataSet();
                adapter.Fill(game, "Game");
            }

            return null;
        }
    }
}
