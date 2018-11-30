using Controller;
using Models;
using System;
using System.IO;
using System.Windows.Forms;
using View;

namespace MainApplication
{
    public partial class Form1 : Form
    {
        private string _filePath;
        private Jogo _jogo;
        private JogoController _jogoController;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _filePath = Environment.CurrentDirectory + "\\games.log";
            _jogoController = new JogoController();
            _jogo = _jogoController.GetJogo(_filePath);
        }

        private void btnRankingJogador_Click(object sender, EventArgs e)
        {
            var viewRankingJogador = new RankingGeralJogadores();
            viewRankingJogador.ShowDialog();
        }

        private void btnRankingMortes_Click(object sender, EventArgs e)
        {
            var viewRankingMortes = new TextAreaView();

            var str = _jogoController.GetMortesJogoString(_jogo);
            viewRankingMortes.TxtOutPut = str;

            viewRankingMortes.ShowDialog();            
        }

        private void btnLogJogo_Click(object sender, EventArgs e)
        {
            var viewLogJogo = new TextAreaView
            {
                TxtOutPut = _jogoController.GetJogoString(_jogo)
            };

            viewLogJogo.ShowDialog();
        }

        private void btnSalvarBanco_Click(object sender, EventArgs e)
        {
            //Grava Enum no banco
            CausaMorteController causaMorteController = new CausaMorteController();
            causaMorteController.SalvarEnumsBanco();

            JogoController jogoController = new JogoController();
            jogoController.SalvarJogoNoBanco(_jogo);
        }
    }
}
