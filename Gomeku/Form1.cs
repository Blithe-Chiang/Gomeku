using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gomeku
{
    public partial class Form1 : Form
    {

        private Game game = new Game();


        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox_Board_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.CreatePiece(e.X, e.Y);
            if (piece != null)
            {
                this.pictureBox_Board.Controls.Add(piece);

                // 检查是否有玩家获胜
                if (game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("黑色获胜");
                    RePlay();
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白色获胜");
                    RePlay();
                }
            }
        }


        private void RePlay()
        {
            this.RemovePieces();
            game.InitGame();
        }


        // 移除所有的棋子
        private void RemovePieces()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Piece piece = game.Board.PieceData[i, j];
                    if (piece != null)
                    {
                        this.pictureBox_Board.Controls.Remove(piece);
                    }
                }
            }
        }

        
        private void pictureBox_Board_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand; // 显示手形图标
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void button_Undo_Click(object sender, EventArgs e)
        {
            Point point = game.Undo();

            if (point == Board.NO_MATCH_POINT)
            {
                return;
            }
            this.pictureBox_Board.Controls.Remove(game.Board.PieceData[point.X, point.Y]);
            game.Board.PieceData[point.X, point.Y] = null;
        }
    }
}
