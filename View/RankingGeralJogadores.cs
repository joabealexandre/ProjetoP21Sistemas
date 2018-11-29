using System;
using System.Windows.Forms;
using Controller;
using Models;

namespace View
{
    public partial class RankingGeralJogadores : Form
    {
        public RankingGeralJogadores()
        {
            InitializeComponent();
        }

        private void RankingGeralJogadores_Load(object sender, EventArgs e)
        {
            JogadorController jogadorController = new JogadorController();
            var jogadores = jogadorController.BuscarJogadoresDataTable();

            dgvJogadores.DataSource = jogadores;
            dgvJogadores.Columns[0].Width = 40;
            dgvJogadores.Columns[1].Width = 120;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var nome = txtNomeBusca.Text;

            if (string.IsNullOrEmpty(nome))
                RankingGeralJogadores_Load(sender, e);

            JogadorController jogadorController = new JogadorController();
            var jogadores = jogadorController.BuscarJogadoresDataTable(nome);
            dgvJogadores.DataSource = jogadores;
        }
    }
}
