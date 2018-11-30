using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DALMorte : IPersistense<Morte>
    {
        private string connectionString = "";

        public DALMorte()
        {
            connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=QuakeLog;Integrated Security=True";
        }

        public void Save(Morte entity)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "INSERT INTO MortesJogo (IdGame, IdJogadorUm, IdJogadorDois, idCausaMorte) " +
                    "           Values(@v1, @v2, @v3, @v4)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", entity.IdGame);
                cmd.Parameters.AddWithValue("@v2", entity.Jogador1.Id);
                cmd.Parameters.AddWithValue("@v3", entity.Jogador2.Id);
                cmd.Parameters.AddWithValue("@v4", (int)entity.CausaMorte);

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

        public List<Morte> GetAll()
        {
            throw new NotImplementedException();
        }

        public Morte GetByNome(string s)
        {
            throw new NotImplementedException();
        }
    }
}
