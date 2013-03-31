using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class BaricadePiece : Piece
    {
        public BaricadePiece(Square s, Player p = null) : base(s, p) { }
        public BaricadePiece() { }
        /*
         * Put the barricade into the current player's hand. This barricade must be placed on the board before the end of the turn.
         * 
         * TODO: Can a player hit his own barricade?
         */
        public override bool isHit(Piece p) // A barricade cannot be placed on a barricade, therefore only a pawn can hit a barricade.
        {
            if (p is Pawn)
            {
                this.Player = p.Player;
                p.Player.Baricade = this;
                this.Square.Piece = null;
                return true;
            }
            else return false;
        }
    }
}