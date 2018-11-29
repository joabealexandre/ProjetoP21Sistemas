using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class DALCausaMorte : IPersistense<CausaMorte>
    {
        private string connectionString = "";

        public DALCausaMorte()
        {
            connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=QuakeLog;Integrated Security=True";
        }

        public void Save(CausaMorte entity)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO CausaMorte (Id, Nome) Values(@v1, @v2)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", (int)entity);
                cmd.Parameters.AddWithValue("@v2", entity.ToString());

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

        //TO DO
        public List<CausaMorte> GetAll()
        {
            throw new NotImplementedException();
        }

        //TO DO
        public CausaMorte GetByNome(string s)
        {
            throw new NotImplementedException();
        }
    }
}
