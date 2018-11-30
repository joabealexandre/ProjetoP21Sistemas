using Models;
using Controller;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class TextAreaView : Form
    {
        public string TxtOutPut
        {
            get { return this.txtOutput.Text; }
            set { this.txtOutput.Text = value; }
        }

        public TextAreaView()
        {
            InitializeComponent();
        }

        /*private void RankingGeralMortes_Load(object sender, EventArgs e)
        {
        }*/
    }
}
