using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public Game()
        {
            Jogadores = new List<Jogador>();
            Mortes = new List<Morte>();
        }

        public int Id { get; set; }
        public List<Jogador> Jogadores { get; set; }
        public List<Morte> Mortes { get; set; }
    }
}
