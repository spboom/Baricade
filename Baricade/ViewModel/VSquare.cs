using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    public class VSquare
    {
        protected Square square;
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

        public virtual String getName()
        {
            if (Piece != null)
            {
                return "Square" + "-" + Piece.View.getName();
            }

            return "Square";
        }

        public virtual String getText()
        {
            return TextView.Square_OpenTag + "" + Piece.View.getChar() + "" + TextView.Square_CloseTag;
        }
    }
}