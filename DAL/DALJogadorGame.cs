using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALJogadorGame : IPersistense<JogadorGame>
    {
        private string connectionString = "";

        public DALJogadorGame()
        {
            connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=QuakeLog;Integrated Security=True";
        }

        public void Save(JogadorGame entity)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "INSERT INTO JogadoresGame (IdGame, IdJogador, Kills) Values(@v1, @v2, @v3)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", entity.IdGame);
                cmd.Parameters.AddWithValue("@v2", entity.Id);
                cmd.Parameters.AddWithValue("@v3", entity.Kills);

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

        public List<JogadorGame> GetAll()
        {
            /*using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM JogadoresGame";
                SqlCommand cmd = new SqlCommand(sql, conn);
                List<JogadorGame> jogGame;
                JogadorGame jg = null;

                try
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                            jogGame = new List<JogadorGame>();
                        else
                            return null;

                        while (reader.Read())
                        {
                            jg = new JogadorGame
                            {
                                = Convert.ToInt32(reader["IdGame"].ToString()),
                                IdGame = Convert.ToInt32(reader["IdGame"].ToString()),
                                Kills = Convert.ToInt32(reader["Kills"].ToString())
                            };

                            jogadores.Add(j);
                        }
                        return jogGame;
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
            }*/
            throw new NotImplementedException();
        }

        public JogadorGame GetByNome(string s)
        {
            throw new NotImplementedException();
        }

        
    }
}
