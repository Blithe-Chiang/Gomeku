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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.CreatePiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
