using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VPiece
    {
        protected Piece piece;

        public VPiece(Piece piece)
        {
            this.piece = piece;
        }

        public Piece Piece
        {
            get { return piece; }
            protected set { piece = value; }
        }

        public Square Square
        {
            get { return Piece.Square; }
            set { Piece.Square = value; }
        }

        public virtual string getName()
        {
            return null;
        }

        public virtual char getChar()
        {
            return ' ';
        }
    }
}