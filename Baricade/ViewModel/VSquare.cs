using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;
using System.Windows.Controls;

namespace Baricade.ViewModel
{
    public class VSquare
    {
        protected Square square;
        protected Image image;
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public VSquare(Square square)
        {
            this.square = square;
        }

        public Square Square
        {
            get { return square; }
            protected set { square = value; }
        }

        public Piece Piece
        {
            get { return square.Piece; }
            set { square.Piece = value; }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public virtual String getName()
        {
            if (Square.Up != 0 && Square.links[0].Down == 0)
            {
                return "pointSquare";
            }

            return "square";
        }

        public virtual String getText()
        {
            return TextView.Square_OpenTag + "" + getPieceString() + "" + TextView.Square_CloseTag;
        }

        public virtual char getPieceString()
        {
            if (Piece != null)
            {
                return Piece.View.getChar();
            }
            return ' ';
        }
    }
}