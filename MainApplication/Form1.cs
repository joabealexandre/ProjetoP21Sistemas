using System;
using System.IO;
using System.Windows.Forms;
using ReaderStructure;

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
           var filePath = Environment.CurrentDirectory + "\\games.log";

            var Jogo = new GameFileReader(filePath).LerJogo();
        }
    }
}
