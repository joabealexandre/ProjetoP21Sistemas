﻿using System;
using System.Collections.Generic;
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
                    game = new Game();
                }

                //Informações sobre jogador
                else if (str[1].Contains(StatusGame.ClientUserinfoChanged.ToString()))
                {
                    var nome = GetNomejogador(linha);

                    //Adiciona jogador que não existe ainda
                    if(!game.Jogadores.Where(x => x.Nome == nome).Any())
                    {
                        game.Jogadores.Add(new Jogador { Nome = nome });
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
                        // 1º Jogo não tem nenhuma ação (Kill -> verificar)
                        jogo.Add(game);
                        game = null;
                    }
                }
            }

            return jogo;
        }

        public string GetNomejogador(string linha)
        {
            var txt = linha.Split('\\');
            return txt[1];
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
                        item.Kills = item.Kills != 0 ? item.Kills - 1 : 0 ;
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
