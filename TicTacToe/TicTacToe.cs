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
    public partial class TicTacToe : Form
    {
        private int miLasttipp = 0;
        private string msNextPlayer = "X";
        private int miZuganzahl = 0;
        private string[,] masTipp = new string[4, 4];
        private int miU = 0;
        private int miX = 0;
        private int miO = 0;

        private void changePlayer()
        {
            if (msNextPlayer == "X") msNextPlayer = "O";
            else msNextPlayer = "X";
            if (miZuganzahl == 9)
            {
                lblSpieler.Text = ("Unentschieden");
                back.Enabled = false;
                DialogResult vreset = MessageBox.Show("Es gab keinen Gewinner. Willst du das Spiel neu starten? ", "Unentschieden", MessageBoxButtons.YesNo);
                if (vreset == DialogResult.Yes)
                {
                    reset();
                }
                miU++;
                lblU.Text = miU.ToString();
                if (miU == 0 & miX == 0 & miO == 0) btnZurücksetzen.Enabled = false;
                else btnZurücksetzen.Enabled = true;

            }
            else lblSpieler.Text = msNextPlayer;
        }
        public TicTacToe()
        {
            InitializeComponent();
        }

        private string isFinished()
        {
            if ((masTipp[1,1] != "" & masTipp[1,1] == masTipp[1,2] & masTipp[1,1] == masTipp[1,3]) |
                (masTipp[2,1] != "" & masTipp[2,1] == masTipp[2,2] & masTipp[2,1] == masTipp[2,3]) |
                (masTipp[3, 1] != "" & masTipp[3, 1] == masTipp[3, 2] & masTipp[3,1] == masTipp[3, 3]) |
                (masTipp[1, 1] != "" & masTipp[1, 1] == masTipp[2, 1] & masTipp[1, 1] == masTipp[3, 1]) |
                (masTipp[1, 2] != "" & masTipp[1, 2] == masTipp[2, 2] & masTipp[1, 2] == masTipp[3, 2])  |
                (masTipp[1, 3] != "" & masTipp[1, 3] == masTipp[2, 3] & masTipp[1, 3] == masTipp[3, 3])|
                (masTipp[1, 1] != "" & masTipp[1, 1] == masTipp[2, 2] & masTipp[1, 1] == masTipp[3, 3])|
                (masTipp[1, 3] != "" & masTipp[1, 3] == masTipp[2, 2] & masTipp[1, 3] == masTipp[3, 1]))
            {
                if (msNextPlayer == "X")
                {
                    miX++;
                    lblX.Text = miX.ToString();
                }
                else
                {
                    miO++;
                    lblO.Text = miO.ToString();
                }
              
                return "Spieler " + msNextPlayer + " hat gewonnen.";
            }
            else
            {
                return "";
            }

        }

        private void setSpielzug(object sender)
        {
            Button btn;
            btn = sender as Button;
            btn.Text = msNextPlayer;
            btn.Enabled = false;
            if (msNextPlayer == ("X")) btn.BackColor = Color.Red;
            else btn.BackColor = Color.YellowGreen;
            back.Enabled = true;
            miZuganzahl = miZuganzahl + 1;
            if (miZuganzahl == 0) btnReset.Enabled = false;
            else btnReset.Enabled = true;
            string sRet = isFinished();
            if (sRet != string.Empty)
            {
                lblSpieler.Text = sRet;
                DialogResult vreset = MessageBox.Show(sRet+ " Willst du das Spiel neu starten?", "Gewonnen", MessageBoxButtons.YesNo);
                if (vreset == DialogResult.Yes)
                {
                    reset();
                }
                else {
                    btn1.Enabled = false;
                    btn2.Enabled = false;
                    btn3.Enabled = false;
                    btn4.Enabled = false;
                    btn5.Enabled = false;
                    btn6.Enabled = false;
                    btn7.Enabled = false;
                    btn8.Enabled = false;
                    btn9.Enabled = false;
                    back.Enabled = false;
                    }
            }
            else changePlayer();
            

        }
        private void btn1_Click(object sender, EventArgs e)
        {
            masTipp[1, 1] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 1;
        }
        private void TicTacToe_Load(object sender, EventArgs e)
        {
            lblSpieler.Text = msNextPlayer;
            btn1.BackColor = default(Color);
            btn2.BackColor = default(Color);
            btn3.BackColor = default(Color);
            btn4.BackColor = default(Color);
            btn5.BackColor = default(Color);
            btn6.BackColor = default(Color);
            btn7.BackColor = default(Color);
            btn8.BackColor = default(Color);
            btn9.BackColor = default(Color);
            back.Enabled = false;
            btnReset.Enabled = false;
            btnZurücksetzen.Enabled = false;
           

            //for (int gz = 2; gz < 12; gz = gz + 2)
            //{ 
            //    MessageBox.Show(gz.ToString());
            //}
            resetArray();
        }

        private void resetArray()
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    masTipp[i, j] = "";
                }
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            masTipp[1, 2] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            masTipp[1, 3] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            masTipp[2, 1] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            masTipp[2,2] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            masTipp[2,3]= msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            masTipp[3, 1] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            masTipp[3, 2] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            masTipp[3, 3] = msNextPlayer;
            setSpielzug(sender);
            miLasttipp = 9;
        }
        private void reset()
        {
            resetArray();
            msNextPlayer = ("X");
            lblSpieler.Text = msNextPlayer;
                back.Enabled = false;
                miZuganzahl = 0;
                btnReset.Enabled = false;
            if (miU == 0 & miX == 0 & miO == 0) btnZurücksetzen.Enabled = false;
            else btnZurücksetzen.Enabled = true;

            btn1.Text = ("");
                btn1.Enabled = true;
                btn1.BackColor = default(Color);

                btn2.Text = ("");
                btn2.Enabled = true;
                btn2.BackColor = default(Color);

                btn3.Text = ("");
                btn3.Enabled = true;
                btn3.BackColor = default(Color);

                btn4.Text = ("");
                btn4.Enabled = true;
                btn4.BackColor = default(Color);

                btn5.Text = ("");
                btn5.Enabled = true;
                btn5.BackColor = default(Color);

                btn6.Text = ("");
                btn6.Enabled = true;
                btn6.BackColor = default(Color);

                btn7.Text = ("");
                btn7.Enabled = true;
                btn7.BackColor = default(Color);

                btn8.Text = ("");
                btn8.Enabled = true;
                btn8.BackColor = default(Color);

                btn9.Text = ("");
                btn9.Enabled = true;
                btn9.BackColor = default(Color);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult vreset = MessageBox.Show("Bist du sicher, dass du das Spiel neu starten willst. Alle bisherigen Spielzüge gehen verloren.", "!!!Achtung!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vreset == DialogResult.Yes)
            {
                reset();
            }
            //else if (dialogResult == DialogResult.No)
            //{
            //    //
            //}
           
        }

        private void back_Click(object sender, EventArgs e)
        {
            miZuganzahl = miZuganzahl - 1;
            switch (miLasttipp)
            {
                case 1:
                    btn1.Text = ("");
                    btn1.Enabled = true;
                    btn1.BackColor = default(Color);
                    masTipp[1, 1] = "";
                    break;
                case 2:
                    btn2.Text = ("");
                    btn2.Enabled = true;
                    btn2.BackColor = default(Color);
                    masTipp[1, 2] = "";
                    break;
                case 3:
                    btn3.Text = ("");
                    btn3.Enabled = true;
                    btn3.BackColor = default(Color);
                    masTipp[1, 3] = "";
                    break;
                case 4:
                    btn4.Text = ("");
                    btn4.Enabled = true;
                    btn4.BackColor = default(Color);
                    masTipp[2, 1] = "";
                    break;
                case 5:
                    btn5.Text = ("");
                    btn5.Enabled = true;
                    btn5.BackColor = default(Color);
                    masTipp[2, 2] = "";
                    break;
                case 6:
                    btn6.Text = ("");
                    btn6.Enabled = true;
                    btn6.BackColor = default(Color);
                    masTipp[2, 3] = "";
                    break;
                case 7:
                    btn7.Text = ("");
                    btn7.Enabled = true;
                    btn7.BackColor = default(Color);
                    masTipp[3, 1] = "";
                    break;
                case 8:
                    btn8.Text = ("");
                    btn8.Enabled = true;
                    btn8.BackColor = default(Color);
                    masTipp[3, 2] = "";
                    break;
                case 9:
                    btn9.Text = ("");
                    btn9.Enabled = true;
                    btn9.BackColor = default(Color);
                    masTipp[3, 3] = "";
                    break;
            }
            back.Enabled = false;
            if (msNextPlayer == "X") msNextPlayer = "O";
            else msNextPlayer = "X";
            lblSpieler.Text = msNextPlayer;
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Die Spieler setzen abwechselnd ihre Steine. Der Spieler der zuerst 3 Steine vertikal, horizontal oder diagonal hat, hat gewonnen.", "Regeln", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (lblSpieler.Text == "X" | lblSpieler.Text == "O")
            {
                MessageBox.Show("Spieler " + lblSpieler.Text + " muss den nächsten Spielzug ausüben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult drLblSpieler = MessageBox.Show(lblSpieler.Text + " Willst du das Spiel neu starten?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (drLblSpieler == DialogResult.Yes)
                {
                    reset();
                }
                else { }
            }
        }

        private void lblO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spieler O hat " + miO + " mal gewonnen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnZurücksetzen_Click(object sender, EventArgs e)
        {
            DialogResult statistik = MessageBox.Show("Willst du wirklich die Statistik zurücksetzen?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (statistik == DialogResult.Yes) 
             {
                miO = 0;
                miU = 0;
                miX = 0;
                lblO.Text = "-";
                lblU.Text = "-";
                lblX.Text = "-";
                btnZurücksetzen.Enabled = false;
             } 
            else{ }
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Es gab " + miU + " Unentschieden", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblSpieler_Click(object sender, EventArgs e)
        {
            if (lblSpieler.Text == "X" | lblSpieler.Text == "O")
            {
                MessageBox.Show("Spieler " + lblSpieler.Text + " muss den nächsten Spielzug ausüben.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult drLblSpieler = MessageBox.Show(lblSpieler.Text + " Willst du das Spiel neu starten?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (drLblSpieler == DialogResult.Yes)
                {
                    reset();
                }
                else { }
            }
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spieler X hat " + miX + " mal gewonnen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lbl3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spieler O hat " + miO + " mal gewonnen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spieler X hat " + miX + " mal gewonnen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblU_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Es gab " +miU + " Unentschieden", "Info", MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
    }
}
