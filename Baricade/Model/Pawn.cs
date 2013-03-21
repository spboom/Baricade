using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Pawn : Piece
    {
        public Pawn(Square s, Player p) : base(s, p) {}

        public override string Name {
            get { return Player.Color + "-pawn"; }
        }

        /*
         * The method gotHit replaces the pawn on the square with the one in the signature and
         * places it in the associated player's starting position.
         */
        public override bool gotHit(Pawn p)
        {
            // What if the current player puts the pawn on one of its own pawns?
            if(this.Player == p.Player) {
                return false;
            }

            Square temp = this.Square;
            this.moveTo(Player.PlayerSquare);
            p.moveTo(temp);

            return true;
        }
    }
}