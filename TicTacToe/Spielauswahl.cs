using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Spielauswahl : Form
    {
        public Spielauswahl()
        {
            InitializeComponent();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            TicTacToe frm = new TicTacToe();
            frm.Show();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            Muehle frm = new Muehle();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnH_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("Hello, world!");
        }
    }
}
