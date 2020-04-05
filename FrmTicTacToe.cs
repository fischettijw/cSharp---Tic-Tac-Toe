using System;
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
        static Label LblComputerPlayer;
        static int rowWon;
        static int colWon;
        static string diagWon;


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

            LblComputerPlayer = new Label()
            {
                AutoSize = false,
                Size = new Size(clientWidth, 30),
                Location = new Point(0, clientHeight - 36),
                Text = "Human Player's Turn",
                Font = new Font("Nightclub BTN", 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(LblComputerPlayer);


            PnlTicTacToe = new Panel()
            {
                Size = new Size(clientWidth, clientWidth),
                Location = new Point(0, 80),
            };
            this.Controls.Add(PnlTicTacToe);

            TimComputerPlayer = new Timer()
            {
                Enabled = false,
                Interval = 2000
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
            if (TimComputerPlayer.Enabled) return;

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
            LblComputerPlayer.Text = "Computer Player THINKING";
            TimComputerPlayer.Enabled = true;            //ComputerPlayer();
        }

        private void ComputerPlayer()
        {
            if (TryToWinOrBlock()) 
            {
                TimComputerPlayer.Enabled = false;
                MessageBox.Show($"Computer has WON !!!");
                LblComputerPlayer.Text = "Human Player's Turn";
                ClearBoardForAnotherGame();
                return; 
            };
            if (btnRC[1, 1].Text == "")
            {
                btnRC[1, 1].Text = "C";
                TimComputerPlayer.Enabled = false;
                LblComputerPlayer.Text = "Human Player's Turn";
                return;
                //if (HasGameBeenWon()) { return; };
            }
            if (HasGameBeenWon()) { return; };
            NextAvailableButton();
            TimComputerPlayer.Enabled = false;
            LblComputerPlayer.Text = "Human Player's Turn";
        }

        private bool TryToWinOrBlock()
        {
            foreach (Button btn in btnRC)
            {
                if (btn.Text == "")
                {
                    btn.Text = "C";
                    if (HasGameBeenWon()) 
                    { 
                        return true; 
                    };

                    btn.Text = "X";
                    if (HasGameBeenWon())
                    {
                        btn.Text = "C";
                        TimComputerPlayer.Enabled = false;
                        LblComputerPlayer.Text = "Human Player's Turn";
                        return false;
                    };




                    btn.Text = "";
                }
            }
            return false;
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
                        MessageBox.Show($"Computer has WON !!!");
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
            rowWon = -1; colWon = -1; diagWon = "";

            for (int i = 0; i < 3; i++)
            {
                row[i] = btnRC[i, 0].Text + btnRC[i, 1].Text + btnRC[i, 2].Text;
                if (row[i] == "XXX" | row[i] == "CCC") { rowWon = i; return true; };
                col[i] = btnRC[0, i].Text + btnRC[1, i].Text + btnRC[2, i].Text;
                if (col[i] == "XXX" | col[i] == "CCC") { colWon = i; return true; };
            }
            bDiag = btnRC[0, 0].Text + btnRC[1, 1].Text + btnRC[2, 2].Text;
            if (bDiag == "XXX" | bDiag == "CCC") { diagWon = "B"; return true; };
            fDiag = btnRC[2, 0].Text + btnRC[1, 1].Text + btnRC[0, 2].Text;
            if (fDiag == "XXX" | fDiag == "CCC") { diagWon = "F"; return true; };

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


//https://www.youtube.com/watch?v=6CM5x4B6BKA&t=553s

//1) Get TicTacToe
//2) Block TicTacToe
//3) Go in center
//4) Go in corner
//5) Go in any other space

