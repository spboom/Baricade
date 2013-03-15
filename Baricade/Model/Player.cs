using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Player
    {
        private int player;
        private PlayerSquare playerSquare;
        private Pawn[] playerPawns;

        public Player(int player, int pawns)
        {
            this.player = player;
            playerPawns = new Pawn[pawns];
            for(int i=0; i<pawns;i++)
            {
                playerPawns[i] = new Pawn();
            }
        }
    }
}
