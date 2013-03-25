using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class BaricadePiece : Piece
    {
        public BaricadePiece(Square s, Player p = null) : base(s, p) {}

        public override string Name
        {
            get { return "barricade"; }
        }

        /*
         * Put the barricade into the current player's hand. 
         */
        public override bool gotHit(Pawn p)
        {
            this.Player = p.Player;
            p.Player.Baricade = this;
            this.Square.Piece = null;
            return true;
        }
    }
}