using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class Pawn : Piece
    {
        public Pawn(Square s, Player p)
            : base(s, p)
        {
            View = new VPawn(this);
        }
        public Pawn()
            : base()
        {
            View = new VPawn(this);
        }
        /*
         * The method isHit replaces the pawn on the square with the one in the signature and
         * places it in the associated player's starting position.
         */
        public override bool isHit(Piece p) // Only a pawn can hit a pawn.
        {
            if (this.Square.mayPawnBeHit())
            {
                // If the current player tries to hit one of his own pawns, then return false.
                if (this.Player == p.Player)
                {
                    return false;
                }

                Square to = Square.getReturnTo();
                Square.removePawn(this);
                Square = to;
                Square.setPawn(this);
                return true;
            }
            return false;
        }

        public override bool pawnMayMoveTrough()
        {
            return true;
        }

        public override bool moveTo(Square s)
        {
            if (s != null)
            {
                if (s.isWalkable())
                {
                    if (s.mayContainPawn())
                    {
                        if (s.isOccupied())
                        {
                            if (s.Piece.isHit(this))
                            {
                                this.Square = s;
                                s.Piece = this;
                                return true;
                            }
                        }
                        else
                        {
                            this.Square = s;
                            s.Piece = this;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}