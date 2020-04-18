namespace Gomeku
{
    class BlackPiece : Piece
    {
        public BlackPiece(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.black;
        }


        public override PieceType GetPieceType()
        {
            return PieceType.BLACK;
        }
    }
}
