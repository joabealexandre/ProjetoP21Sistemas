using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using Models;

namespace Controller
{
    public class JogadorController
    {
        private DALJogador jogadorDAL;

        public JogadorController()
        {
            jogadorDAL = new DALJogador();
        }

        public void SalvarJogadorNoBanco(Jogador jogador)
        {
            jogadorDAL.Save(jogador);
        }

        public void SalvarJogadorNoBanco(List<Jogador> jogadores)
        {
            foreach (var item in jogadores)
            {
                SalvarJogadorNoBanco(item);
            }   
        }

        public List<Jogador> BuscarJogadores()
        {
            var jogadores = jogadorDAL.GetAll();
            return jogadores;
        }

        public DataTable BuscarJogadoresDataTable(string nome = "")
        {
            var jogadores = jogadorDAL.GetAllDataTable(nome);
            return jogadores;
        }
    }
}
