using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Morte
    {
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public CausaMorte CausaMorte { get; set; }
    }
}
