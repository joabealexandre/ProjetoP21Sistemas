using System;
using System.Collections.Generic;
using DAL;
using Models;

namespace Controller
{
    public class JogadorController
    {
        public void SalvarJogadorNoBanco(Jogador jogador)
        {
            DALJogador jogadorDAL = new DALJogador();
            jogadorDAL.Save(jogador);
        }

        public void SalvarJogadorNoBanco(List<Jogador> jogadores)
        {
            DALJogador jogadorDAL = new DALJogador();

            foreach (var item in jogadores)
            {
                jogadorDAL.Save(item);
            }   
        }
    }
}
