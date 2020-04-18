using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomeku
{

    // 游戏管理器
    class Game
    {

        public Game()
        {

        }


        private Board board = new Board();
        private bool puttable = false;

        private PieceType currentPlayer = PieceType.BLACK;

        public bool CanBePlaced(int x, int y)
        {
            bool result = board.CanBePlaced(x, y);
            puttable = result;
            return result;
        }


        public Piece CreatePiece(int x, int y)
        {
            if (!puttable)
            {
                return null;
            }

            Piece piece = board.CreatePiece(x, y, currentPlayer);

            if (currentPlayer == PieceType.BLACK)
            {
                currentPlayer = PieceType.WHITE;
            }
            else if (currentPlayer == PieceType.WHITE)
            {
                currentPlayer = PieceType.BLACK;
            }

            return piece;
        }

        private void CheckWinner()
        {

        }
    }
}
