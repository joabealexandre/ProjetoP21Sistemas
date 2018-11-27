using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public List<Jogador> Jogadores { get; set; }
        public List<Morte> TotalGameMortes { get; set; }
    }
}
