using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomeku
{
    public partial class Form1 : Form
    {

        private Board board = new Board();
        private bool puttable = false;

        public Form1()
        {
            InitializeComponent();
        }

        // color of next piece
        private bool isBlack = true;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!puttable)
            {
                return;
            }

            if (isBlack)
            {
                this.Controls.Add(board.CreatePiece(e.X,e.Y,PieceType.BLACK));
                isBlack = false;
            }
            else
            {
                this.Controls.Add(board.CreatePiece(e.X,e.Y,PieceType.WHITE));
                isBlack = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
            {
                puttable = true;
                this.Cursor = Cursors.Hand;
            }
            else
            {
                puttable = false;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
