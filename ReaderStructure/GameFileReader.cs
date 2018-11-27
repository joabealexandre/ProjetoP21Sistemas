using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Models;

namespace ReaderStructure
{
    public enum StatusGame
    {
        [Description("InitGame")]
        InitGame,
        [Description("ShutdownGame")]
        ShutdownGame,
        [Description("ClientUserinfoChanged")]
        ClientUserinfoChanged,
        [Description("Kill")]
        Kill
    }


    public class GameFileReader
    {
        public GameFileReader(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        /// <summary>
        /// Processa todo o jogo retornando o resultado do log
        /// </summary>
        /// <returns></returns>
        public Jogo LerJogo()
        {
            Jogo Jogos = new Jogo();

            if (File.Exists(FilePath))
            {
                using(var reader = new StreamReader(FilePath))
                {
                    Jogos.Games = LerPartidas(reader);
                }
            }

            return null;
        }

        /// <summary>
        /// Processa as linhas do jogo
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<Game> LerPartidas(StreamReader reader)
        {
            var jogo = new List<Game>();
            Game game = null;
            var linha = string.Empty;

            while (!string.IsNullOrEmpty(linha = reader.ReadLine()))
            {
                var str = linha.Trim().Split(' ');

                //Início do Game
                if(str[1].Contains(StatusGame.InitGame.ToString()))
                {
                    game = new Game
                    {
                        Inicio = str[0]
                    };
                }

                //Informações sobre jogador
                else if (str[1].Contains(StatusGame.ClientUserinfoChanged.ToString()))
                {

                }

                //Kill
                else if (str[1].Contains(StatusGame.Kill.ToString()))
                {

                }

                //Fim do Game
                else if (str[1].Contains(StatusGame.ShutdownGame.ToString())
                    || linha.Contains("-------------------------------------------------"))
                {
                    //Jogo ainda aberto, finalizando
                    if(game != null)
                    {

                    }
                }

            }


            return null;
        }

    }

}
