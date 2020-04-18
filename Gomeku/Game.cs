using System.Drawing;

namespace Gomeku
{

    // 游戏管理器
    class Game
    {

        public Board board;
        private bool puttable;



        private PieceType currentPlayer;


        public void InitGame()
        {
            board = new Board();
            puttable = false;

            currentPlayer = PieceType.BLACK;

            Winner = PieceType.NONE;
        }


        public Game()
        {
            InitGame();
        }




        public PieceType Winner { get; private set; }

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

                    int targetX = board.LastNode.X;
                    int targetY = board.LastNode.Y;

                    int count = 1;
                    while (count < 5)
                    {
                        int offsetX = targetX + count * xDir;
                        int offsetY = targetY + count * yDir;

                        // 检查旁边位置的棋子
                        if (offsetX < 0 || offsetX >= 9 || offsetY < 0 || offsetY >= 9
                            || board.GetPieceType(offsetX, offsetY) != currentPlayer)
                        {
                            break;
                        }
                        count++;
                    }

                    if (count == 5)
                    {
                        Winner = currentPlayer;
                        return; // 玩家赢了，退出函数
                    }

                    // 存储一个方向上面的当前玩家的棋子的个数
                    countSet[xDir + 1, yDir + 1] = count;

                    // -1 是因为中间有一个重复的。也就是当前下的棋子它本身
                    if ((count + countSet[-xDir + 1, -yDir + 1]) - 1 >= 5)
                    {
                        Winner = currentPlayer;
                        return;
                    }

                }
            }


        }
    }
}
