using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JogadorGame : Jogador
    {
        public JogadorGame() { }

        public JogadorGame(Jogador jogador)
        {
            this.Id = jogador.Id;
            this.Nome = jogador.Nome;
            this.Kills = 0;
        }

        public int IdGame { get; set; }
    }
}
