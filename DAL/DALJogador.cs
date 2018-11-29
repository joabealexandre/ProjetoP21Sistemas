﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class DALJogador : IPersistense<Jogador>
    {
        private string connectionString = "";

        public DALJogador()
        {
            connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=QuakeLog;Integrated Security=True";
        }

        public void Save(Jogador entity)
        {
            using(var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Jogador (Nome, Kills) Values(@v1, @v2)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", entity.Nome);
                cmd.Parameters.AddWithValue("@v2", entity.Kills);

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

        public List<Jogador> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Game";
                SqlCommand cmd = new SqlCommand(sql, conn);
                List<Jogador> jogadores;
                Jogador j = null;

                try
                {
                    conn.Open();
                    
                    using(var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                            jogadores = new List<Jogador>();
                        else
                            return null;

                        while (reader.Read())
                        {
                            j = new Jogador
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Nome = reader["Nome"].ToString(),
                                Kills = Convert.ToInt32(reader["Kills"].ToString())
                            };

                            jogadores.Add(j);
                        }
                        return jogadores;
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

        public Jogador GetByNome(string nome)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Jogador WHERE Nome = @v1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@v1", nome);
                Jogador jogador = null;

                try
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            jogador = new Jogador
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Nome = reader["Nome"].ToString(),
                                Kills = Convert.ToInt32(reader["Kills"].ToString())
                            };
                        }
                        return jogador;
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
    }
}