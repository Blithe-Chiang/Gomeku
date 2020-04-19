using System.Drawing;

namespace Gomeku
{

    // 游戏管理器
    class Game
    {
        public Board Board { get; private set; }
        private bool puttable;
        private PieceType currentPlayer;
        public PieceType Winner { get; private set; }


        public void InitGame()
        {
            Board = new Board();
            puttable = false;

            currentPlayer = PieceType.BLACK;

            Winner = PieceType.NONE;
        }


        public Game()
        {
            InitGame();
        }


        public bool CanBePlaced(int x, int y)
        {
            bool result = Board.CanBePlaced(x, y);
            puttable = result;
            return result;
        }


        public Piece CreatePiece(int x, int y)
        {
            if (!puttable)
            {
                return null;
            }

            Piece piece = Board.CreatePiece(x, y, currentPlayer);


            // 在玩家刚刚下完棋子的时候，判断他是否获胜
            CheckWinner();

            // 切换下棋玩家
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

            // 存储所有方向上面的玩家的棋子的个数
            int[,] countSet = new int[3, 3];

            countSet.Initialize();

            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    // 除去中间的情况
                    if (xDir == 0 && yDir == 0)
                    {
                        continue;
                    }

                    int targetX = Board.LastNode.X;
                    int targetY = Board.LastNode.Y;

                    int count = 1;
                    while (count < 5)
                    {
                        int offsetX = targetX + count * xDir;
                        int offsetY = targetY + count * yDir;

                        // 检查旁边位置的棋子
                        if (offsetX < 0 || offsetX >= 9 || offsetY < 0 || offsetY >= 9
                            || Board.GetPieceType(offsetX, offsetY) != currentPlayer)
                        {
                            break;
                        }
                        count++;
                    }

                    /* 下面的都是和检查是否有玩家获胜相关的代码  */


                    // 检查当前方向是有5个同样颜色的棋子
                    if (count == 5)
                    {
                        Winner = currentPlayer;
                        return; 
                    }

                    // 存储一个方向上的当前玩家的棋子的个数
                    countSet[xDir + 1, yDir + 1] = count;

                   
                    // 检查相对方向上面加起来是否满足获胜条件
                    if ((count + countSet[-xDir + 1, -yDir + 1]) - 1 >= 5)  // -1 是因为中间有一个重复的。也就是当前下的棋子它本身
                    {
                        Winner = currentPlayer;
                        return;
                    }

                }
            }


        }


        public Point Undo()
        {
            if (Board.pointStack.Count > 0)
            {
                Point point = Board.pointStack.Pop();
                currentPlayer = Board.GetPieceType(point.X, point.Y);

                return point;
            }
            return Board.NO_MATCH_POINT;
        }
    }
}
