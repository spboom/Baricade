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
        private string color;
        private PlayerSquare playerSquare;
        private Pawn[] playerPawns;
        private Baricade barricade;

        public Player(int player, string color, int pawns)
        {
            this.player = player;
            this.color = color;

            playerPawns = new Pawn[pawns];
            
            for(int i=0; i<pawns;i++)
            {
                playerPawns[i] = new Pawn(PlayerSquare, this);
            }
        }

        public string Color
        {
            get { return color; }
            private set { color = value; }
        }

        public PlayerSquare PlayerSquare
        {
            get { return playerSquare; }
            private set { playerSquare = value; }
        }

        public Baricade Baricade
        {
            get { return barricade; }
            set { barricade = value; }
        }
    }
}
