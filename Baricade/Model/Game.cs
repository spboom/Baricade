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

        public Game(Board board, Circuit<Player> players, FinishSquare finish)
        {
            this.board = board;
            this.players = players;
            currentPlayer = players.peek();
            _finishSquare = finish;
            playerMovedPiece = false;
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
            private set { players = value; }
        }

        /*
         *
         */
        public void nextTurn()
        {
            playerMovedPiece = false;
            CurrentDiceRoll = 0;
            currentTurn++;
        }

        /*
         *
         */
        public void nextPlayer()
        {
            players.next();
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
            Random random = new Random();
            CurrentDiceRoll = random.Next(6) + 1;
        }

        /*
         *
         */
        public bool movePiece(Piece piece, Square square)
        {

            playerMovedPiece = true;
            return true;
        }
    }
}