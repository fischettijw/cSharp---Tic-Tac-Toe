using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharp___Tic_Tac_Toe
{

    public partial class FrmTicTacToe : Form
    {
        static Button[,] btnRC = new Button[3, 3];
        static Panel PnlTicTacToe;
        static int clientWidth = 400;
        static int clientHeight = 600;
        public FrmTicTacToe()
        {
            InitializeComponent();
        }

        public void FrmTicTacToe_Load(object sender, EventArgs e)
        {
            CustomizeForm();
            CreateTicTacToeBoard();
        }

        private void CustomizeForm()
        {

            this.ClientSize = new Size(new Point(clientWidth, clientHeight));
            this.Text = "Tic-Tac-Toe   by Joseph Fischetti";

            Label LblTicTacToeTitle = new Label()
            {
                AutoSize = false,
                Size = new Size(this.ClientSize.Width, 60),
                Location = new Point(0, 5),
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
                        Text = $"{(r * 3) + c}",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Nightclub BTN", 48),
                        Location = new Point(x, y),
                        Size = new Size(new Point(btnSize, btnSize)),
                        BackColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat,
                    };
                    btnRC[r, c].Click += FrmTicTacToe_Click;

                    PnlTicTacToe.Controls.Add(btnRC[r, c]);
                }
            }
        }

        private void FrmTicTacToe_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Text);
        }
    }
}

// Simple AI
//https://youtu.be/6CM5x4B6BKA?t=561
