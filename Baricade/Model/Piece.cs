using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Piece
    {
        private Square square;

        internal Square Square
        {
            get { return square; }
            set { square = value; }
        }

        public Piece(Square s)
        {
            square = s;
        }

        public void moveTo(Square s)
        {
            Square = s;
            Square.Piece = this;
        }
    }
}
