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
        private Piece piece;
        public VPiece(Piece p)
        {
            piece = p;
        }

        public char getChar()
        {
            if (piece.Player!= null)
            {
                return piece.Player.Color.ToUpper().ToCharArray()[0];
            }
            return '*';
        }
    }
}
