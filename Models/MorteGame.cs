using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MorteGame
    {
        public int IdGame { get; set; }
        public int Kills { get; set; }
        public CausaMorte CausaMorte { get; set; }
    }
}
