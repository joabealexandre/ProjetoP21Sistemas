using System;
using System.Collections.Generic;
using DAL;
using Models;

namespace Controller
{
    public class JogadorGameController
    {
        private DALJogadorGame jogadorGameDAL;

        public JogadorGameController()
        {
            jogadorGameDAL = new DALJogadorGame();
        }

        public void SalvarJogadorGameNoBanco(JogadorGame jogadores)
        {
            jogadorGameDAL.Save(jogadores);
        }

        public void SalvarJogadorGameNoBanco(List<JogadorGame> jogadores)
        {
            foreach (var item in jogadores)
            {
                SalvarJogadorGameNoBanco(item);
            }
        }
    }
}
