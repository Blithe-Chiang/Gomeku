using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomeku
{
    class PieceFactory
    {

        public static Piece Create(Func<int,int,Piece> creator, int x,int y)
        {
            return creator.Invoke(x, y);
        }
    }
}
