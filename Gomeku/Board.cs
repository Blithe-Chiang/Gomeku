using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomeku
{
    class Board
    {

        private const int NODE_DISTANCE = 75;
        private const int NODE_RADIUS = 10;
        private const int OFFSET = 73;

        private static readonly Point NO_MATCH_POINT = new Point(-1, -1);

        // 记录棋盘里面的棋子状况
        private int[,] boardData = new int[9, 9];


        public Piece CreatePiece(int x, int y, bool isBlack)
        {
            Point nodeId = FindTheClosetNode(x, y);

            // 修正坐标
            int x1 = nodeId.X * NODE_DISTANCE + OFFSET;
            int y1 = nodeId.Y * NODE_DISTANCE + OFFSET;


            Piece piece = null;
            if (isBlack)
            {
                boardData[nodeId.X, nodeId.Y] = 1;
                piece = new BlackPiece(x1, y1);
            }
            else
            {
                boardData[nodeId.X, nodeId.Y] = 2;
                piece = new WhitePiece(x1, y1);
            }

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
            if (boardData[nodeId.X, nodeId.Y] != 0)
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
            if (pos > NODE_DISTANCE * 8 + OFFSET + NODE_RADIUS)
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
    }
}
