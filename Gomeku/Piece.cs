using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomeku
{
    class Piece : PictureBox
    {
        private const int IMAGE_WIDTH = 50;

        public Piece(int x, int y)
        {
            this.Location = new Point(x - IMAGE_WIDTH/2, y - IMAGE_WIDTH/2);
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
            this.BackColor = Color.Transparent;
        }

    }
}
