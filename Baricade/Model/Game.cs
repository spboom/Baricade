using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class Game
    {
        private Circuit<Player> players;
        private Board board;
        private Player currentPlayer;
        private int currentTurn;
        private int currentDiceRoll;
        private FinishSquare _finishSquare;
        private bool playerMovedPiece;
        private bool finished = false;

        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }
        
        public FinishSquare FinishSquare
        {
            get { return _finishSquare; }
            private set { _finishSquare = value; }
        }

        public bool PlayerMovedPiece
        {
            get { return playerMovedPiece; }
            set { playerMovedPiece = value; }
        }
        private bool diceTrown;

        public bool DiceTrown
        {
            get { return diceTrown; }
            set { diceTrown = value; }
        }

        public Game(Board board, Circuit<Player> players, FinishSquare finish)
        {
            this.board = board;
            this.players = players;
            currentPlayer = players.peek();
            _finishSquare = finish;
        }

        public Board Board
        {
            get { return board; }
            private set { board = value; }
        }

        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            private set { currentPlayer = value; }
        }

        public int CurrentTurn
        {
            get { return currentTurn; }
            private set { currentTurn = value; }
        }

        public int CurrentDiceRoll
        {
            get { return currentDiceRoll; }
            set
            {
                if (value <= 6 && value >= 1)
                {
                    currentDiceRoll = value;
                }
                else
                {
                    throwDice();
                }
            }
        }

        public Circuit<Player> Players
        {
            get { return players; }
            set
            {
                players = value;
                if (value != null)
                {
                    CurrentPlayer = value.peek();
                }
            }
        }

        /*
         *
         */
        public void nextTurn()
        {
            playerMovedPiece = false;
            diceTrown = false;
            CurrentDiceRoll = 0;
            currentTurn++;
            CurrentPlayer = nextPlayer();
        }

        /*
         *
         */
        public Player nextPlayer()
        {
            return players.next();
        }

        /*
         *
         */
        public void previousPlayer()
        {
            players.previous();
        }

        /*
         *
         */
        public void throwDice()
        {
            if (!diceTrown)
            {
                diceTrown = true;
                Random random = new Random();
                CurrentDiceRoll = random.Next(1,7);
            }
        }

        /*
         *
         */
        public bool movePiece(Piece piece, Square square)
        {
            if (!playerMovedPiece)
            {
                playerMovedPiece = piece.moveTo(square);;
                return playerMovedPiece;
            }
            if (CurrentPlayer.Baricade != null && !piece.pawnMayMoveTrough())
            {
                return piece.moveTo(square);
            }
            return false;
        }
    }
}