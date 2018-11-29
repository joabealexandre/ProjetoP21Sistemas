using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Jogo
    {
        public Jogo()
        {
            Games = new List<Game>();
            Jogadores = new List<Jogador>
            {
                new Jogador() { Nome = "<world>" }
            };
        }

        public List<Game> Games { get; set; }
        public List<Jogador> Jogadores { get; set; }
    }
}
