using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Pawn : Piece
    {
        public Pawn(Square s, Player p) : base(s, p) { }

        /*
         * The method isHit replaces the pawn on the square with the one in the signature and
         * places it in the associated player's starting position.
         */
        public override bool isHit(Piece p) // Only a pawn can hit a pawn.
        {
            if (p is Piece)
            {
                // If the current player tries to hit one of his own pawns, then return false.
                if (this.Player == p.Player)
                {
                    return false;
                }

                // If the pawn is on village square, then send it to the forest square on the board.
                if (this.Square is VillageSquare)
                {
                    this.Square.Piece = null;
                    this.Square.Board.ForestSquare.addPawn(this);

                }
                else // go to player square
                {
                    this.Square.Piece = null;
                    this.Player.addPawn(this);
                }

                return true;
            }
            return false;
        }
    }
}