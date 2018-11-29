using Models;
using ReaderStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Controller
{
    public class JogoController
    {

        public Jogo GetJogo(string filePath)
        {
            var jogo = new GameFileReader(filePath).LerJogo();

            return jogo;
        }

        public string GetJogoString(Jogo jogo)
        {
            StringBuilder sb = new StringBuilder("");

            if (jogo == null || jogo.Games == null)
                return sb.ToString();

            for (int i = 0; i < jogo.Games.Count; i++)
            {
                sb.Append(jogo.Games[i].Nome + ": { "+ Environment.NewLine);
                sb.Append("\t total_kills: " + jogo.Games[i].Mortes.Count+ ";" + Environment.NewLine);

                //** Jogadores
                sb.Append("\t players: [");
                for (int j = 0; j < jogo.Games[i].Jogadores.Count; j++)
                {
                    sb.Append("\"" + jogo.Games[i].Jogadores[j].Nome + "\"" + (j != jogo.Games[i].Jogadores.Count -1 ? ", " : "]" + Environment.NewLine ));
                }

                //** Kills
                sb.Append("\t kills: {" + Environment.NewLine);
                for (int j = 0; j < jogo.Games[i].Jogadores.Count; j++)
                {
                    sb.Append("\t\t\"" + jogo.Games[i].Jogadores[j].Nome + "\": " + jogo.Games[i].Jogadores[j].Kills + (j != jogo.Games[i].Jogadores.Count - 1 ? "," + Environment.NewLine : Environment.NewLine));
                }
                sb.Append("\t }" + Environment.NewLine);

                sb.Append("}" + Environment.NewLine);
            }

            return sb.ToString(); ;
        }

        public string GetKillsJogadorPorGame(List<Morte> mortes)
        {
            return "";
        }

        public void SalvarJogoNoBanco(Jogo jogo)
        {
            JogadorController jogadorController = new JogadorController();
            jogadorController.SalvarJogadorNoBanco(jogo.Jogadores);

            GameController gameController = new GameController();
            gameController.SalvarGameNoBanco(jogo.Games);
        }
    }
}
