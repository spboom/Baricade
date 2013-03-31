using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    /*
     * A piece is put on a square and a piece belongs to a player (such as a pawn) 
     * or belongs to no one at first and exchanges owners throughout the game (such 
     * as a barricade).  
     */
    abstract class Piece : XmlData<Piece>
    {
        private Player player;
        private int playerId;
        private Square square;
        private VPiece view;

        internal VPiece View
        {
            get { return view; }
            set { view = value; }
        }

        public Piece(Square square, Player player = null)
        {
            this.square = square;
            this.player = player;
        }

        public Piece()
        {
        }

        public Square Square
        {
            get { return square; }
            set { square = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public int PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        /*
         * This method is used to move a piece to a a square after the path to the square is valid.
         */
        public bool moveTo(Square s)
        {
            if (this.Square is PlayerSquare)
            {
                this.Player.removePawn();
            }

            if (s.isWalkable())
            {
                if ((this is Pawn && s.mayContainPawn()) ^ (this is BaricadePiece && s.mayContainBarricade()))
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

            return false;
        }

        /*
         * This method checks if it's legal to strike this pawn and if so sends it to its destination.
         */
        public abstract bool isHit(Piece p);
    }
}