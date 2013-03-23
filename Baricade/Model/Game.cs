using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Game
    {
        private Board board;
        private Circuit<Player> players;
        private FinishSquare _finishSquare;

        public Game(Board board, Circuit<Player> players)
        {
            this.board = board;
            this.players = players;
        }
    }
}
