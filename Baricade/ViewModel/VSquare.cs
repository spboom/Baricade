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
        private Square square;
        protected char open = '(';
        protected char close = ')';

        public VSquare(Square square)
        {
            this.square = square;
        }
        public virtual String getString()
        {
            char piece = ' ';
            if (square.Piece != null)
            {
                piece = square.Piece.View.getChar();
            }
            return open + "" + piece + "" + close;
        }
    }
}
