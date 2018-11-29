using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALJogadoresGame : IPersistense<Game>
    {
        private string connectionString = "";

        public DALJogadoresGame()
        {
            connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=QuakeLog;Integrated Security=True";
        }

        public void Save(Game entity)
        {
            if (entity.Jogadores == null)
                return;

            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO JogadoresGame (IdGame, IdJogador) Values(@v1, @v2)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();

                    foreach (var jogador in entity.Jogadores)
                    {
                        cmd.Parameters.AddWithValue("@v1", entity.Id);
                        cmd.Parameters.AddWithValue("@v2", jogador.Id);
                        cmd.ExecuteNonQuery();
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

        public List<Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public Game GetByNome(string s)
        {
            throw new NotImplementedException();
        }

        
    }
}
