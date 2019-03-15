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
    public partial class Muehle : Form
    {
        private int miNextPlayer = 1;
        private int miRSteinanzahl = 9;
        private int miBSteinanzahl = 9;
        private bool mbZugBegonnen = false;
        private bool mbMuehleSteinWeg = false;
        public Muehle()
        {
            InitializeComponent();

            pb.Image = new Bitmap(pb.Width, pb.Height);
        }

        private void Muehle_Load(object sender, EventArgs e)
        {
            using (var g = Graphics.FromImage(pb.Image))
            {
                MuehleLinie(btn1, btn3);
                MuehleLinie(btn3, btn5);
                MuehleLinie(btn5, btn7);
                MuehleLinie(btn7, btn1);
                MuehleLinie(btn9, btn11);
                MuehleLinie(btn11, btn13);
                MuehleLinie(btn13, btn15);
                MuehleLinie(btn15, btn9);
                MuehleLinie(btn17, btn19);
                MuehleLinie(btn19, btn21);
                MuehleLinie(btn21, btn23);
                MuehleLinie(btn23, btn17);
                MuehleLinie(btn2, btn18);
                MuehleLinie(btn4, btn20);
                MuehleLinie(btn6, btn22);
                MuehleLinie(btn8, btn24);
                pb.Refresh();
            }
        }

        private void MuehleLinie(Button btnFrom, Button btnTo)
        {
            using (var g = Graphics.FromImage(pb.Image))
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                g.DrawLine(pen, btnFrom.Left + btnFrom.Width / 2, btnFrom.Top + btnFrom.Height / 2, btnTo.Left + btnTo.Width / 2, btnTo.Top + btnTo.Height / 2);
            }
        }

        private void setSpielzug(object sender)
        {
            Button btn;
            btn = sender as Button;
            if (mbMuehleSteinWeg == true)
            {
                // Entfernen eines gegnerischen Steines nach einer Mühle
                btn.BackColor = Color.Black;
                btn.Enabled = false;
                nextPlayer();
                // prüfen, ob der Stein entfernt werden kann
                mbMuehleSteinWeg = false;
            }
            else
            {
                // Ziehen - es wurde bereits ein Stein in die Hand genommen
                if (mbZugBegonnen == true)
            {
                if (miNextPlayer == 1)
                {
                    btn.BackColor = Color.Red;
                    activateWithColor(false, Color.Black);
                    backToBlack(Color.DarkRed);
                    activateWithColor(false, Color.Red);
                    activateWithColor(true, Color.Blue);
                    mbZugBegonnen = false;
                    if (isMuehle(Color.Red, btn) == true)
                    {
                        // aktivieren alle blauen Steine
                        //MessageBox.Show("Mühle rot");
                            activateWithColor(true, Color.Blue);
                            activateWithColor(false, Color.Black);
                            activateWithColor(false, Color.Red);
                            mbMuehleSteinWeg = true;
                        }
                    else
                    {
                        nextPlayer();
                    }
                }
                else
                {
                    btn.BackColor = Color.Blue;
                    activateWithColor(false, Color.Black);
                    backToBlack(Color.LightBlue);
                    activateWithColor(false, Color.Blue);
                    activateWithColor(true, Color.Red);
                    mbZugBegonnen = false;
                    if (isMuehle(Color.Blue, btn) == true)
                    {
                        // aktivieren alle roten Steine
                        //MessageBox.Show("Mühle blau");
                            activateWithColor(true, Color.Red);
                            activateWithColor(false, Color.Black);
                            activateWithColor(false, Color.Blue);
                            mbMuehleSteinWeg = true;
                    }
                    else
                    {
                        nextPlayer();
                    }
                }
            
            }
            else
            // Setzen bzw. absetzen des Steines
            {
                if (miNextPlayer == 1)
                {
                    if (miRSteinanzahl == 0)
                    {
                        btn.BackColor = Color.DarkRed;
                        activateWithColor(true, Color.Black);
                        activateWithColor(false, Color.Red);
                        activateWithColor(false, Color.DarkRed);
                        mbZugBegonnen = true;
                    }
                    else
                    {
                        btn.BackColor = System.Drawing.Color.Red;
                        btn.Enabled = false;
                        miRSteinanzahl = miRSteinanzahl - 1;
                        lblRSteinanzahl.Text = miRSteinanzahl.ToString();
                        if (isMuehle(Color.Red, btn) == true)
                        {
                            // aktivieren alle blaue Steine
                            MessageBox.Show("Mühle rot");
                                activateWithColor(true, Color.Blue);
                                activateWithColor(false, Color.Red);
                                activateWithColor(false, Color.Black);


                            }
                        else
                        {
                            nextPlayer();
                            if (miBSteinanzahl == 0)
                            {
                                activateWithColor(true, Color.Blue);
                                activateWithColor(false, Color.Black);
                            }
                        }
                    }
                }
                else
                {
                    if (miBSteinanzahl == 0)
                    {
                        btn.BackColor = Color.LightBlue;
                        activateWithColor(true, Color.Black);
                        activateWithColor(false, Color.Blue);
                        activateWithColor(false, Color.LightBlue);
                        mbZugBegonnen = true;
                    }
                    else
                    {
                        btn.BackColor = System.Drawing.Color.Blue;
                        btn.Enabled = false;
                        miBSteinanzahl = miBSteinanzahl - 1;
                        lblBSteinanzahl.Text = miBSteinanzahl.ToString();
                        if (isMuehle(Color.Blue, btn) == true)
                        {
                            // aktivieren alle roten Steine
                            MessageBox.Show("Mühle blau");
                                activateWithColor(true, Color.Red);
                                activateWithColor(false, Color.Blue);
                                activateWithColor(false, Color.Black);
                            }
                        else
                        {
                            nextPlayer();
                            if (miRSteinanzahl == 0)
                            {
                                activateWithColor(true, Color.Red);
                                activateWithColor(false, Color.Black);
                            }
                        }
                    }
                }
            }

                //// prüfen, ob es eine Mühle gibt
                //if (miNextPlayer == 1)
                //{
                //    if (isMuehle(Color.Blue, btn)) MessageBox.Show("Mühle blau!");
                //    // alle roten Steine freigeben
                //    mbMuehleSteinWeg = true;
                //}
                //else
                //{
                //    if (isMuehle(Color.Red, btn)) MessageBox.Show("Mühle rot!");
                //}
            }
        }
        private void backToBlack(Color farbe)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    //Das Control ist ein Panel
                    //Mach damit was du willst z.B. Parent ändern
                    if (c.Name.Substring(0, 3) == "btn")
                    {
                        if (c.BackColor == farbe) c.BackColor = Color.Black;
                    }
                }
            }
        }

        private void nextPlayer()
        {
                if (miNextPlayer == 1) miNextPlayer = 2;
                else miNextPlayer = 1;
                if (miNextPlayer == 1) lblNextPlayer.BackColor = System.Drawing.Color.Red;
                else lblNextPlayer.BackColor = System.Drawing.Color.Blue;
        }
        private void activateWithColor(bool activate, Color farbe)
        {

            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    //Das Control ist ein Panel
                    //Mach damit was du willst z.B. Parent ändern
                    if(c.Name.Substring(0,3) == "btn")
                    {
                        if (c.BackColor == farbe) c.Enabled = activate;
                    }
                }
            }
        }
       
        private void btn1_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            setSpielzug(sender);
        }
        
        private bool isMuehle(Color farbe, Button btn)
        {

            if ((btn1.BackColor == farbe) && (btn2.BackColor == farbe) && (btn3.BackColor == farbe) && (btn.Name == btn1.Name || btn.Name == btn2.Name || btn.Name == btn3.Name))
            {
                return true;
            }
            if ((btn3.BackColor == farbe) && (btn4.BackColor == farbe) && (btn5.BackColor == farbe) && (btn.Name == btn3.Name || btn.Name == btn4.Name || btn.Name == btn5.Name))
            {
                return true;
            }
            if ((btn5.BackColor == farbe) && (btn6.BackColor == farbe) && (btn7.BackColor == farbe) && (btn.Name == btn5.Name || btn.Name == btn6.Name || btn.Name == btn7.Name))
            {
                return true;
            }
            if ((btn7.BackColor == farbe) && (btn8.BackColor == farbe) && (btn1.BackColor == farbe) && (btn.Name == btn7.Name || btn.Name == btn8.Name || btn.Name == btn1.Name))
            {
                return true;
            }

            if ((btn9.BackColor == farbe) && (btn10.BackColor == farbe) && (btn11.BackColor == farbe) && (btn.Name == btn9.Name || btn.Name == btn10.Name || btn.Name == btn11.Name))
            {
                return true;
            }
            if ((btn11.BackColor == farbe) && (btn12.BackColor == farbe) && (btn13.BackColor == farbe) && (btn.Name == btn11.Name || btn.Name == btn12.Name || btn.Name == btn13.Name))
            {
                return true;
            }
            if ((btn13.BackColor == farbe) && (btn14.BackColor == farbe) && (btn15.BackColor == farbe) && (btn.Name == btn13.Name || btn.Name == btn14.Name || btn.Name == btn15.Name))
            {
                return true;
            }
            if ((btn15.BackColor == farbe) && (btn16.BackColor == farbe) && (btn9.BackColor == farbe) && (btn.Name == btn15.Name || btn.Name == btn16.Name || btn.Name == btn9.Name))
            {
                return true;
            }

            if ((btn17.BackColor == farbe) && (btn18.BackColor == farbe) && (btn19.BackColor == farbe) && (btn.Name == btn17.Name || btn.Name == btn18.Name || btn.Name == btn19.Name))
            {
                return true;
            }
            if ((btn19.BackColor == farbe) && (btn20.BackColor == farbe) && (btn21.BackColor == farbe) && (btn.Name == btn19.Name || btn.Name == btn21.Name || btn.Name == btn21.Name))
            {
                return true;
            }
            if ((btn21.BackColor == farbe) && (btn22.BackColor == farbe) && (btn23.BackColor == farbe) && (btn.Name == btn21.Name || btn.Name == btn22.Name || btn.Name == btn23.Name))
            {
                return true;
            }
            if ((btn23.BackColor == farbe) && (btn24.BackColor == farbe) && (btn17.BackColor == farbe) && (btn.Name == btn23.Name || btn.Name == btn24.Name || btn.Name == btn17.Name))
            {
                return true;
            }

            if ((btn2.BackColor == farbe) && (btn10.BackColor == farbe) && (btn18.BackColor == farbe) && (btn.Name == btn2.Name || btn.Name == btn10.Name || btn.Name == btn18.Name))
            {
                return true;
            }
            if ((btn4.BackColor == farbe) && (btn12.BackColor == farbe) && (btn20.BackColor == farbe) && (btn.Name == btn4.Name || btn.Name == btn12.Name || btn.Name == btn20.Name))
            {
                return true;
            }
            if ((btn6.BackColor == farbe) && (btn14.BackColor == farbe) && (btn22.BackColor == farbe) && (btn.Name == btn6.Name || btn.Name == btn14.Name || btn.Name == btn22.Name))
            {
                return true;
            }
            if ((btn8.BackColor == farbe) && (btn16.BackColor == farbe) && (btn24.BackColor == farbe) && (btn.Name == btn8.Name || btn.Name == btn16.Name || btn.Name == btn24.Name))
            {
                return true;
            }

            return false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
