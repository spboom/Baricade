using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Player : XmlData<Player>
    {
        private int player;
        private PlayerColor color;
        private PlayerSquare playerSquare;
        private List<Pawn> playerPawns;
        private BaricadePiece barricade;

        public Player(int player, int pawns, PlayerSquare square)
        {
            this.player = player;

            playerPawns = new List<Pawn>();

            for (int i = 0; i < pawns; i++)
            {
                playerPawns.Add(new Pawn(square, this));
            }
        }

        public Player(int player, PlayerColor color, int pawns, PlayerSquare square)
        {
            this.player = player;
            this.color = color;

            playerPawns = new List<Pawn>();

            for (int i = 0; i < pawns; i++)
            {
                addPawn(new Pawn(PlayerSquare, this));
            }
        }

        public PlayerColor Color
        {
            get { return color; }
            private set { color = value; }
        }

        public PlayerSquare PlayerSquare
        {
            get { return playerSquare; }
            set { playerSquare = value; }
        }

        public BaricadePiece Baricade
        {
            get { return barricade; }
            set { barricade = value; }
        }

        /*
         * Add an new or existing pawn to the player and put it on the playerSquare.
         */
        public void addPawn(Pawn p)
        {
            playerPawns.Add(p);
            p.Square = PlayerSquare;
        }

        /*
         * If a pawn is moved from the playerSquare, then lower the amount.
         */
        public void removePawn()
        {
            playerPawns.RemoveAt(playerPawns.Count);
        }

        public int numberOfPawnsAtStart()
        {
            return playerPawns.Count;
        }
    }
}