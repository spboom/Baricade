
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

        public virtual bool Human
        {
            get { return true; }
        }

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
            addPawn(p, playerSquare);
        }

        public void addPawn(Pawn p, Square s)
        {
            playerPawns.Add(p);
            s.setPawn(p);
        }

        public int numberOfPawnsAtStart()
        {
            return PlayerSquare.Pieces.Count;
        }

        public void bestmove(int dice)
        {
            Random r = new Random();
            int tries = 0;
            int[] order = new int[PlayerPawns.Count];
            for (int i = 0; i < order.Length; i++)
            {
                order[i] = -1;
            }
            int index = 0;
            while (order[order.Length - 1] == -1)
            {
                int random = r.Next(PlayerPawns.Count);
                bool isin = false;
                for (int i = 0; i < order.Length; i++)
                {
                    if (order[i] == -1)
                    {
                        break;
                    }
                    if (order[i] == random)
                    {
                        isin = true;
                        break;
                    }
                }
                if (!isin)
                {
                    order[index++] = random;
                }
            }
            Pawn p = null;
            List<Square> squares = new List<Square>();
            do
            {
                p = PlayerPawns[order[tries]];
                squares = new List<Square>();
                squares.AddRange(p.Square.getNext(p.Square, dice));
                if (squares.Count != 0)
                {
                    break;
                }
            }
            while (++tries < order.Length);
            
            if (squares.Count == 0)
            {
                p.Square.Board.Game.nextPlayer();
                return;
            }
            Square square = squares[0];
            for (int i = 0; i < squares.Count; i++)
            {
                if (square.height < squares[i].height)
                {
                    square = squares[i];
                }
            }
            if (p.Square.Board.Game.movePiece(p, square))
            {
                return;
            }
        }
    }
}
