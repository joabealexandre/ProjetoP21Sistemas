using Models;
using System.Collections.Generic;
using DAL;

namespace Controller
{
    public class GameController
    {
        private DALGame gameDAL { get; set; }

        public GameController()
        {
            gameDAL = new DALGame();
        }

        public void SalvarGameNoBanco(Game game)
        {
            //Salva Id e nome do Game no Banco
            gameDAL.Save(game);

            //Salva Jogadores do Game no Banco
            JogadorGameController jogadorGameController = new JogadorGameController();
            jogadorGameController.SalvarJogadorGameNoBanco(game.Jogadores);

            MorteController morteController = new MorteController();
            morteController.SalvarMorteNoBanco(game.Mortes);

        }

        public void SalvarGameNoBanco(List<Game> game)
        {
            foreach (var item in game)
            {
                SalvarGameNoBanco(item);
            }
        }
    }
}
