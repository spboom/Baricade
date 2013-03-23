using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    /*
     * A piece is put on a square and a piece belongs to a player (such as a pawn) 
     * or belongs to no one at first and exchanges owners throughout the game (such 
     * as a barricade).  
     */
    abstract class Piece
    {
        private Player player;
        private Square square;

        public Piece(Square square, Player player = null)
        {
            this.square = square;
            this.player = player;
        }

        /*
         * The property Name is used to determine the filename of the image at the View. 
         */
        public abstract string Name { get; }

        public Square Square
        {
            get { return square; }
            protected set { square = value; }
        }

        public Player Player
        {
            get { return player; }
            protected set { player = value; }
        }

        protected void moveTo(Square s)
        {
            this.square = s;
            s.Piece = this;
        }

        /*
         * The method gotHit determines the destination of the struck piece, sends it, and puts the
         * the pawn in the signature inside the square.
         */ 
        public abstract bool gotHit(Pawn p);
    }
}