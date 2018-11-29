using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Models;
using DAL;

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

            //GravaJogoNoBanco(jogo);
        }

        public static void GravaJogoNoBanco(Jogo jogo)
        {
            //Grava Enum no banco
            CausaMorteController causaMorteController = new CausaMorteController();
            causaMorteController.SalvarEnumsBanco();

            JogoController jogoController = new JogoController();
            jogoController.SalvarJogoNoBanco(jogo);

        }
    }
}
