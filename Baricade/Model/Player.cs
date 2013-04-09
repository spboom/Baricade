
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
        private Circuit<Player> circuit;

        public virtual bool Human
        {
            get { return true; }
        }

        public Player(Circuit<Player> circuit)
        {
            this.circuit = circuit;
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
            set { playerPawns = value; }
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
            List<int> order = new List<int>();
            while (order.Count <PlayerPawns.Count)
            {
                int random = r.Next(PlayerPawns.Count);
                if (!order.Contains(random))
                {
                    order.Add(random);
                }
            }
            Pawn p = null;
            List<Square> squares = new List<Square>();
            do
            {
                p = PlayerPawns[order[tries]];
                squares = new List<Square>();
                squares.AddRange(p.Square.getNext(p.Square, dice,p));
                if (squares.Count == 0)
                {
                    continue;
                }
                else
                {
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
                        if (Baricade != null)
                        {
                            List<Pawn> otherPawns = new List<Pawn>();
                            for (int i = 0; i < circuit.List.Count; i++)
                            {
                                Player player = circuit.List[i];
                                if (player != this)
                                {
                                    otherPawns.AddRange(player.playerPawns);
                                }
                            }
                            Pawn high = otherPawns[0];
                            for (int i = 0; i < otherPawns.Count; i++)
                            {
                                if (high.Square.height < otherPawns[i].Square.height)
                                {
                                    high = otherPawns[i];
                                }
                            }
                            Square baricadeTo = high.Square.getEmptyNext();
                            if (baricadeTo != null)
                            {
                                Baricade.moveTo(baricadeTo);
                            }
                            else
                            {
                                Console.WriteLine("GODDANGIT!!");
                            }
                        }
                        return;
                    }
                }
            }
            while (++tries < order.Count);

            p.Square.Board.Game.nextPlayer();
        }
    }
}
