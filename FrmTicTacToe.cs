﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharp___Tic_Tac_Toe
{

    public partial class FrmTicTacToe : Form
    {
        static readonly Button[,] btnRC = new Button[3, 3];
        static Panel PnlTicTacToe;
        static readonly int clientWidth = 400;
        static readonly int clientHeight = clientWidth + 100;
        static Timer TimComputerPlayer;

        public FrmTicTacToe()
        {
            InitializeComponent();
        }

        public void FrmTicTacToe_Load(object sender, EventArgs e)
        {
            CustomizeForm();
            CreateTicTacToeBoard();
        }

        public void CustomizeForm()
        {
            this.ClientSize = new Size(new Point(clientWidth, clientHeight));
            this.MaximizeBox = false;
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimizeBox = true;
            this.MinimumSize = new Size(this.Width, this.Height);

            this.Icon = Properties.Resources.TicTacToe;

            int sW = Screen.PrimaryScreen.WorkingArea.Width;
            int sH = Screen.PrimaryScreen.WorkingArea.Height;
            int fW = this.Width;
            int fH = this.Height;
            this.Location = new Point((sW - fW) / 2, (sH - fH) / 2);

            this.Text = "Tic-Tac-Toe   by Joseph Fischetti";

            Label LblTicTacToeTitle = new Label()
            {
                AutoSize = false,
                Size = new Size(clientWidth, 60),
                Location = new Point(0, 18),
                Text = "Tic-Tac-Toe",
                Font = new Font("Nightclub BTN", 36),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(LblTicTacToeTitle);

            PnlTicTacToe = new Panel()
            {
                Size = new Size(clientWidth, clientWidth),
                Location = new Point(0, 80),
            };
            this.Controls.Add(PnlTicTacToe);

            TimComputerPlayer = new Timer()
            {
                Enabled = false,
                Interval = 1000
            };

            TimComputerPlayer.Tick += TimComputerPlayer_Tick;

        }

        private void TimComputerPlayer_Tick(object sender, EventArgs e)
        {
            ComputerPlayer();
        }

        public void CreateTicTacToeBoard()
        {
            int btnSize = PnlTicTacToe.Width / 4;
            int btnSpacing = (PnlTicTacToe.Width - (btnSize * 3)) / 4;

            for (int r = 0; r <= 2; r++)
            {
                for (int c = 0; c <= 2; c++)
                {
                    int x = (btnSpacing * (c + 1)) + (c * btnSize);
                    int y = (btnSpacing * (r + 1)) + (r * btnSize);

                    btnRC[r, c] = new Button()
                    {
                        Text = "",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Nightclub BTN", 48),
                        Location = new Point(x, y),
                        Size = new Size(new Point(btnSize, btnSize)),
                        BackColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat,
                        Tag = "",
                    };
                    PnlTicTacToe.Controls.Add(btnRC[r, c]);

                    btnRC[r, c].Click += FrmTicTacToe_Click;


                }
            }
        }


        public void FrmTicTacToe_Click(object sender, EventArgs e)
        {
            // Player is Human if entering via Button Click
            if ((sender as Button).Text != "")
            {
                SystemSounds.Beep.Play(); return;
            }
            { (sender as Button).Text = "X"; }

            if (HasGameBeenWon())
            {
                MessageBox.Show($"Human has WON !!!");
                ClearBoardForAnotherGame();
            }

            if (IsGameTied())
            {
                MessageBox.Show("COMPUTER and HUMAN have TIED !!!");
                ClearBoardForAnotherGame();
            }

            TimComputerPlayer.Enabled = true;
            //ComputerPlayer();
        }

        private void ComputerPlayer()
        {
            TimComputerPlayer.Enabled = false;
            NextAvailableButton();
        }

        private void NextAvailableButton()
        {
            foreach (Button btn in btnRC)
            {

                if (btn.Text == "")
                {
                    btn.Text = "C";
                    if (HasGameBeenWon())
                    {
                        MessageBox.Show("Computer has WON !!!");
                        ClearBoardForAnotherGame();
                    }

                    if (IsGameTied())
                    {
                        MessageBox.Show("COMPUTER and HUMAN have TIED !!!");
                        ClearBoardForAnotherGame();
                    }
                    break;
                }
            }
        }

        private void ClearBoardForAnotherGame()
        {
            DialogResult yn = MessageBox.Show("Play Another Game?", "Tic-Tac-Toe Game is Over", MessageBoxButtons.YesNo);
            if (yn == DialogResult.Yes)
            {
                foreach (Button btn in btnRC)
                {
                    btn.Text = "";
                }
                return;
            }
            Application.Exit();
        }

        private bool HasGameBeenWon()
        {
            string[] row = new string[3];
            string[] col = new string[3];
            string fDiag;
            string bDiag;

            for (int i = 0; i < 3; i++)
            {
                row[i] = btnRC[i, 0].Text + btnRC[i, 1].Text + btnRC[i, 2].Text;
                if (row[i] == "XXX" | row[i] == "CCC") return true;
                col[i] = btnRC[0, i].Text + btnRC[1, i].Text + btnRC[2, i].Text;
                if (col[i] == "XXX" | col[i] == "CCC") return true;
            }
            bDiag = btnRC[0, 0].Text + btnRC[1, 1].Text + btnRC[2, 2].Text;
            if (bDiag == "XXX" | bDiag == "CCC") return true;
            fDiag = btnRC[2, 0].Text + btnRC[1, 1].Text + btnRC[0, 2].Text;
            if (fDiag == "XXX" | fDiag == "CCC") return true;

            return false;
        }

        private static bool IsGameTied()
        {
            foreach (Button btn in btnRC)
            {
                if (btn.Text == "") { return false; }
            }
            return true;
        }
    }
}

