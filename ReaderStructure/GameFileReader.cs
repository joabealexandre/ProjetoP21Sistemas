using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
        public Jogo Jogo { get; set; }


        /// <summary>
        /// Processa todo o jogo retornando o resultado do log
        /// </summary>
        /// <returns></returns>
        public Jogo LerJogo()
        {
            if (File.Exists(FilePath))
            {
                using(var reader = new StreamReader(FilePath))
                {
                    Jogo = new Jogo();
                    LerPartidas(reader);
                }
            }
            return Jogo;
        }

        /// <summary>
        /// Processa as linhas do jogo
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public void LerPartidas(StreamReader reader)
        {
            Game game = null;
            var linha = string.Empty;

            while (!string.IsNullOrEmpty(linha = reader.ReadLine()))
            {
                var str = linha.Trim().Split(' ');

                //Início do Game
                if(str[1].Contains(StatusGame.InitGame.ToString()))
                {
                    game = new Game();
                }

                //Informações sobre jogador - Adiciona ao Jogo/Game
                else if (str[1].Contains(StatusGame.ClientUserinfoChanged.ToString()))
                {
                    string nome = GetNomejogador(linha);
                    Jogador jogador = GetJogadorByName(nome);

                    //Adiciona novo jogador ao Jogo
                    if (!Jogo.Jogadores.Where(x => x.Id == jogador.Id).Any())
                        Jogo.Jogadores.Add(jogador);

                    if (!game.Jogadores.Where(x => x.Id == jogador.Id).Any())
                    {
                        var jogadorGame = new JogadorGame(jogador);
                        game.Jogadores.Add(jogadorGame);
                    }
                }

                //Kill
                else if (str[1].Contains(StatusGame.Kill.ToString()))
                {
                    GravaJogadaLinha(game, linha);
                }

                //Fim do Game
                else if (str[1].Contains(StatusGame.ShutdownGame.ToString())
                    || linha.Contains("-------------------------------------------------"))
                {
                    //Jogo ainda aberto, finalizando
                    if(game != null)
                    {
                        //Grava as kills no Jogo geral
                        if (game.Jogadores != null)
                        {
                            if(game.Id == 5)
                            {
                                Console.WriteLine("");
                            }

                            foreach (var item in game.Jogadores)
                            {
                                var j = Jogo.Jogadores.Find(x => x.Id == item.Id);
                                j.Kills += item.Kills; 
                            }
                        }

                        Jogo.Games.Add(game);
                        game = null;
                    }
                }
            }
        }

        public string GetNomejogador(string linha)
        {
            var txt = linha.Split('\\');
            return txt[1];
        }

        public Jogador GetJogadorByName(string nome)
        {
            Jogador jogador = Jogo.Jogadores.Where(x => x.Nome == nome).FirstOrDefault();

            if (jogador != null)
            {
                return jogador;
            }
            else
            {
                jogador = new Jogador
                {
                    Nome = nome
                };
            }

            return jogador;
        }

        public void GravaJogadaLinha(Game game, string linha)
        {
            var retorno = GetJogadoresECausa(linha);

            var jogador1 = retorno[0];
            var jogador2 = retorno[1];
            Enum.TryParse(retorno[2], out CausaMorte causaMorte);


            var morte = new Morte
            {
                Jogador1 = game.Jogadores.Find(x => x.Nome == jogador1),
                Jogador2 = game.Jogadores.Find(x => x.Nome == jogador2),
                CausaMorte = causaMorte
            };

            //** Se <world>
            if(jogador1 == "<world>")
            {
                foreach (var item in game.Jogadores)
                {
                    if (item.Nome.Contains(jogador2))
                    {
                        item.Kills = item.Kills != 0 ? item.Kills - 1 : 0 ; //Diminui 1 kill para morte por <world>
                    }
                }
            }
            //** Jogada normal
            else
            {
                foreach (var item in game.Jogadores)
                {
                    if (item.Nome.Contains(jogador1))
                    {
                        item.Kills++;
                    }
                }
            }

            game.Mortes.Add(morte);
        }

        /// <summary>
        /// Retorna os jogadores e causa morte
        /// </summary>
        /// <param name="linha">Linha do log</param>
        /// <returns></returns>
        public string[] GetJogadoresECausa(string linha)
        {
            var str = linha.Split(':')[3].Trim();
            var tempStr = str.Split(new string[] { "killed" }, StringSplitOptions.None);

            var jogador1 = tempStr[0].Trim();
            var jogador2 = tempStr[1].Trim().Split(new string[] { "by" }, StringSplitOptions.None)[0].Trim();

            var arrayLinha = linha.Trim().Split(' ');
            var causaMorte = arrayLinha.Last();

            return new string[] { jogador1, jogador2, causaMorte};
        }
    }
}
