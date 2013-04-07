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
    public abstract class Piece : XmlData<Piece>
    {
        private Player player;
        private int playerId;
        private Square square;
        private int squareId;
        private VPiece view;
        
        public int SquareId
        {
            get { return squareId; }
            set { squareId = value; }
        }

        internal VPiece View
        {
            get { return view; }
            set { view = value; }
        }

        public Piece(Square square, Player player = null)
        {
            Square = square;
            Square.Piece = this;
            Player = player;
        }

        public Piece()
        {
            View = new VPiece(this);
        }

        public Square Square
        {
            get { return square; }
            set { square = value; }
        }

        public Player Player
        {
            get { return player; }
            set
            {
                if (value != null)
                {
                    PlayerId = value.PlayerId;
                }
                player = value;
            }
        }

        public int PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        /*
         * This method is used to move a piece to a a square after the path to the square is valid.
         */
        public abstract bool moveTo(Square s);
        

        /*
         * This method checks if it's legal to strike this pawn and if so sends it to its destination.
         */
        public abstract bool isHit(Piece p);


        public abstract bool pawnMayMoveTrough();
    }
}