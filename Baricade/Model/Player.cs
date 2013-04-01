
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class Player : XmlData<Player>
    {
        private int playerId;
        private PlayerColor color;
        private PlayerSquare playerSquare;
        private int playerSquareId;
        private List<Pawn> playerPawns;
        private BaricadePiece barricade;

        public Player()
        {
            playerPawns = new List<Pawn>();
        }


        public PlayerColor Color
        {
            get { return color; }
            set { color = value; }
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

        public List<Pawn> PlayerPawns
        {
            get { return playerPawns; }
            private set { playerPawns = value; }
        }

        public int PlayerSquareId
        {
            get { return playerSquareId; }
            set { playerSquareId = value; }
        }

        public int PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
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