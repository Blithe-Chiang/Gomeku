using System.Collections.Generic;
using System.Drawing;

namespace Gomeku
{
    class Board
    {

        private const int NODE_DISTANCE = 75;
        private const int NODE_RADIUS = 10;
        private const int OFFSET = 73;
        private const int GAPS = 8;
        public static readonly Point NO_MATCH_POINT = new Point(-1, -1);
        public Piece[,] PieceData { get; private set; } = new Piece[9, 9];

        // 当前玩家刚刚下的棋子的位置
        public Point LastNode { get; private set; } = NO_MATCH_POINT;

        // 记录下棋的轨迹
        public Stack<Point> pointStack = new Stack<Point>();


        public Piece CreatePiece(int x, int y, PieceType type)
        {
            Point nodeId = FindTheClosetNode(x, y);

            // 修正坐标
            int x1 = nodeId.X * NODE_DISTANCE + OFFSET;
            int y1 = nodeId.Y * NODE_DISTANCE + OFFSET;


            Piece piece = null;
            if (type == PieceType.BLACK)
            {
                piece = new BlackPiece(x1, y1);
            }
            else if (type == PieceType.WHITE)
            {
                piece = new WhitePiece(x1, y1);
            }

            LastNode = nodeId;
            pointStack.Push(LastNode);

            PieceData[nodeId.X, nodeId.Y] = piece;

            return piece;
        }


        public bool CanBePlaced(int x, int y)
        {

            // 找到最近的可以放置棋子的地方
            Point nodeId = FindTheClosetNode(x, y);
            if (nodeId == NO_MATCH_POINT)
            {
                return false;
            }

            // 判断该地方时候已经有了棋子
            if (PieceData[nodeId.X, nodeId.Y] != null)
            {
                return false;
            }

            // 如果上面的都满足的话返回true 

            return true;
        }


        public Point FindTheClosetNode(int x, int y)
        {

            // 计算 x方向
            int nodeX = FindTheClosetNode(x);
            if (nodeX == -1)
            {
                return NO_MATCH_POINT;
            }

            // 计算 y方向
            int nodeY = FindTheClosetNode(y);
            if (nodeY == -1)
            {
                return NO_MATCH_POINT;
            }

            return new Point(nodeX, nodeY);
        }


        public int FindTheClosetNode(int pos)
        {
            // 如果出了棋盘的边界 返回 -1
            if (pos > NODE_DISTANCE * GAPS + OFFSET + NODE_RADIUS)
            {
                return -1;
            }

            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;


            // 如果位置在offset区域内的话，remainder会是负数，这里让他变成正数
            if (remainder < 0)
            {
                remainder += NODE_DISTANCE;
                quotient -= 1;
            }

            if (remainder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
            {
                return quotient + 1;
            }
            else
            {
                return -1;
            }
        }


        public PieceType GetPieceType(int nodeIdX, int nodeidY)
        {
            if (PieceData[nodeIdX, nodeidY] == null)
            {
                return PieceType.NONE;
            }
            return PieceData[nodeIdX, nodeidY].GetPieceType();
        }
    }
}
