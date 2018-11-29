using System;
using System.IO;
using System.Windows.Forms;
using View;

namespace MainApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnRankingJogador_Click(object sender, EventArgs e)
        {
            var viewRankingJogador = new RankingGeralJogadores();
            viewRankingJogador.ShowDialog();
        }

        private void btnRankingMortes_Click(object sender, EventArgs e)
        {
            var viewRankingMortes = new RankingGeralMortes();
            viewRankingMortes.ShowDialog();
        }
    }
}
