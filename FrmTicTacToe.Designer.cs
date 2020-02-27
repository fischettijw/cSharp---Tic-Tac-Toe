namespace cSharp___Tic_Tac_Toe
{
    partial class FrmTicTacToe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xPnlTicTacToe = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // xPnlTicTacToe
            // 
            this.xPnlTicTacToe.Location = new System.Drawing.Point(0, 80);
            this.xPnlTicTacToe.Name = "xPnlTicTacToe";
            this.xPnlTicTacToe.Size = new System.Drawing.Size(400, 400);
            this.xPnlTicTacToe.TabIndex = 0;
            this.xPnlTicTacToe.Visible = false;
            // 
            // FrmTicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 565);
            this.Controls.Add(this.xPnlTicTacToe);
            this.Name = "FrmTicTacToe";
            this.Load += new System.EventHandler(this.FrmTicTacToe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xPnlTicTacToe;
    }
}

