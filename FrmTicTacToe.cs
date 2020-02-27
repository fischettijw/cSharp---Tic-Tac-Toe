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
        static Panel PnlTicTacToe = new Panel();
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

            Label LblTicTacToeTitle = new Label();
            this.Controls.Add(LblTicTacToeTitle);
            LblTicTacToeTitle.AutoSize = false;
            LblTicTacToeTitle.Size = new Size(this.ClientSize.Width, 60);
            LblTicTacToeTitle.Location = new Point(0, 5);
            LblTicTacToeTitle.Text = "Tic-Tac-Toe";
            LblTicTacToeTitle.Font = new Font("Nightclub BTN", 36);
            LblTicTacToeTitle.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(PnlTicTacToe);
            PnlTicTacToe.Size = new Size(clientWidth, clientWidth);
            PnlTicTacToe.Location = new Point(0,80);
            PnlTicTacToe.BorderStyle = BorderStyle.FixedSingle;





        }

        public void CreateTicTacToeBoard()
        {
            int btnSize = xPnlTicTacToe.Width / 4;
            int btnSpacing = (xPnlTicTacToe.Width - (btnSize * 3)) / 4;

            for (int r = 0; r <= 2; r++)
            {
                for (int c = 0; c <= 2; c++)
                {
                    btnRC[r, c] = new Button();
                    PnlTicTacToe.Controls.Add(btnRC[r, c]);

                    btnRC[r, c].Text = $"{(r * 3) + c}"; //"X";
                    btnRC[r, c].TextAlign = ContentAlignment.MiddleCenter;
                    btnRC[r, c].Font = new Font("Nightclub BTN", 48);
                    int x = (btnSpacing * (c + 1)) + (c * btnSize);
                    int y = (btnSpacing * (r + 1)) + (r * btnSize);
                    btnRC[r, c].Location = new Point(x, y);
                    btnRC[r, c].Size = new Size(new Point(btnSize, btnSize));

                    btnRC[r, c].Click += FrmTicTacToe_Click;
                }
            }
        }

        private void FrmTicTacToe_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Text);
        }
    }
}


//https://youtu.be/6CM5x4B6BKA?t=561
