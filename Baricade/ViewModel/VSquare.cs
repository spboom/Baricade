using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VSquare
    {
        protected Square square;

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
            return "Square" + "-" + Piece.View.getName();
        }

        public virtual String getText()
        {
            return TextView.Square_OpenTag + "" + Piece.View.getChar() + "" + TextView.Square_CloseTag;
        }
    }
}