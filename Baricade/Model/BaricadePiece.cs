using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class BaricadePiece : Piece
    {
        public BaricadePiece(Square s, Player p = null)
            : base(s, p)
        {
            View = new VBaricade(this);
        }
        public BaricadePiece()
        {
            View = new VBaricade(this);
        }
        /*
         * Put the barricade into the current player's hand. This barricade must be placed on the board before the end of the turn.
         * 
         * TODO: Can a player hit his own barricade?
         */
        public override bool isHit(Pawn p) // A barricade cannot be placed on a barricade, therefore only a pawn can hit a barricade.
        {
            Player = p.Player;
            Square from = Square;
            p.Player.Baricade = this;
            Square.Piece = null;
            p.Square.removePawn(p);
            from.setPawn(p);
            Square = null;
            return true;
        }

        public override bool moveTo(Square s)
        {
            if (s != null)
            {
                if (s.isWalkable())
                {
                    if (s.mayContainBarricade())
                    {
                        if (s.isOccupied())
                        {
                            return false;
                        }
                        else
                        {
                            s.Piece = this;
                            Square = s;
                            Player.Baricade = null;
                            Player = null;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override bool pawnMayMoveTrough()
        {
            return false;
        }
    }
}