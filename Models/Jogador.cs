using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Jogador
    {
        public static int contador = 1;

        public Jogador()
        {
            Id = contador;
            contador++;
        }

        public Jogador(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; }
        public string  Nome { get; set; }
        public int Kills { get; set; }
    }
}
