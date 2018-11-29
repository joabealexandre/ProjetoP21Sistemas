using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Models;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = Environment.CurrentDirectory + "\\games.log";

            Run(filePath);
        }

        public static void Run(string filePath)
        {
            var jogoController = new JogoController();
            var jogo = jogoController.GetJogo(filePath);

            Console.WriteLine(jogoController.GetJogoString(jogo));

        }
    }
}
