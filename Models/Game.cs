using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public static int contador = 1;

        public Game()
        {
            Id = contador;
            Nome = "game_" + contador;
            Jogadores = new List<Jogador>();
            Mortes = new List<Morte>();
            contador++;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Jogador> Jogadores { get; set; }
        public List<Morte> Mortes { get; set; }
    }
}
