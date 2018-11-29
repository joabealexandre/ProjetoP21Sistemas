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
            Jogadores = new List<Jogador>();
        }

        public IList<Game> Games { get; set; }
        public IList<Jogador> Jogadores { get; set; }
    }
}
