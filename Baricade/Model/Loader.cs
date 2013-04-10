using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class Loader
    {
        private int _numberOfHumanPlayers = 0;
        private int _numberOfAIPlayers = 0;
        private int _numberOfPawns = -1;
        private int _currentPlayer = -1;
        private int _currentDiceThrow = -1;
        private int _height = -1;
        private int _width = -1;
        private int _numberofPlayers = 0;

        private List<PlayerSquare> playerSquares;
        private List<Square> linkList = new List<Square>();
        private Circuit<Player> playerList = new Circuit<Player>();
        private List<BaricadePiece> baricades = new List<BaricadePiece>();
        private List<Pawn> pawns = new List<Pawn>();
        private List<Square> baricadeSquares = new List<Square>();
        private List<Connector> connectors = new List<Connector>();
        private Board board;

        public int NumberOfHumanPlayers
        {
            get { return _numberOfHumanPlayers; }
            set { _numberOfHumanPlayers = value; }
        }

        public Loader()
        {

        }

        public int NumberOFAIPlayers
        {
            get { return _numberOfAIPlayers; }
            set { _numberOfAIPlayers = value; }
        }

        public int NumberOfPawns
        {
            get { return _numberOfPawns; }
            set { _numberOfPawns = value; }
        }

        public int CurrentPlayer
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; }
        }

        public int CurrentDiceThrow
        {
            get { return _currentDiceThrow; }
            set { _currentDiceThrow = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public Game Load(String uri)
        {
            
            XmlReader r = XmlReader.Create(uri);
            board = null;
            FinishSquare f = null;
            ForestSquare forest = null;
            playerSquares = new List<PlayerSquare>();
            Square previous = null;
            
            linkList = new List<Square>();
            playerList = new Circuit<Player>();
            baricades = new List<BaricadePiece>();
            pawns = new List<Pawn>();
            baricadeSquares = new List<Square>();
            connectors = new List<Connector>();


            while (r.Read())
            {
                if (r.Name.ToLower() == "square")
                {
                    Square s = new Square(board);
                    if (s.readElement(r))
                    {
                        s.View = new VSquare(s);
                        insertInto(s.Id, s);
                        previous = s;
                    }
                }

                else if (r.Name.ToLower() == "villagesquare")
                {
                    VillageSquare s = new VillageSquare(board);
                    if (s.readElement(r))
                    {
                        insertInto(s.Id, s);
                        previous = s;
                    }
                }

                else if (r.Name.ToLower() == "baricadesquare")
                {
                    BaricadeSquare s = new BaricadeSquare(board);
                    if (s.readElement(r))
                    {
                        insertInto(s.Id, s);
                        baricadeSquares.Add(s);
                        previous = s;
                    }
                }

                else if (r.Name.ToLower() == "baricadevillagesquare")
                {
                    BaricadeVillageSquare s = new BaricadeVillageSquare(board);
                    if(s.readElement(r))
                    {
                        insertInto(s.Id, s);
                        baricadeSquares.Add(s);
                        previous = s;
                    }
                }

                else if (r.Name.ToLower() == "restsquare")
                {
                    RestSquare s = new RestSquare(board);
                    if(s.readElement(r))
                    {
                        insertInto(s.Id,s);
                    }
                }

                else if (r.Name.ToLower() == "playersquare")
                {
                    PlayerSquare s = new PlayerSquare(board);
                    if (s.readElement(r))
                    {
                        playerSquares.Add(s);
                        insertInto(s.Id, s);
                        previous = s;
                    }
                }

                else if (r.Name.ToLower() == "pawn")
                {
                    Pawn p = new Pawn();
                    if (p.readElement(r))
                    {
                        pawns.Add(p);
                    }

                }

                else if (r.Name.ToLower() == "baricade")
                {
                    BaricadePiece b = new BaricadePiece();
                    if (b.readElement(r))
                    {
                        baricades.Add(b);
                    }
                }

                else if (r.Name.ToLower() == "lowrowsquare")
                {
                    LowRowSquare s = new LowRowSquare(board);
                    if (s.readElement(r))
                    {
                        insertInto(s.Id, s);
                    }
                }

                else if (r.Name.ToLower() == "connector")
                {
                    Connector s = new Connector(board);
                    if (s.readElement(r))
                    {
                        insertInto(s.Id, s);
                        connectors.Add(s);
                    }
                }

                else if (r.Name.ToLower() == "player")
                {
                    Player p = new Player(playerList);
                    if (p.readElement(r))
                    {
                        _numberofPlayers++;
                        _numberOfHumanPlayers++;

                        p.PlayerSquare = (PlayerSquare)linkList[find(p.PlayerSquareId)];
                        p.PlayerId = playerList.Count + 1;
                        playerList.Add(p);
                    }
                }

                else if (r.Name.ToLower() == "aiplayer")
                {
                    AIPlayer p = new AIPlayer(playerList);
                    if (p.readElement(r))
                    {
                        _numberOfAIPlayers++;
                        _numberOfHumanPlayers++;
                        p.PlayerSquare = (PlayerSquare)linkList[find(p.PlayerSquareId)];
                        p.PlayerId = playerList.Count + 1;
                        playerList.Add(p);
                    }
                }

                else if (r.Name.ToLower() == "finishsquare")
                {
                    FinishSquare s = new FinishSquare(board);
                    if (s.readElement(r))
                    {
                        f = s;
                        insertInto(s.Id, s);
                        previous = s;
                    }
                }
                else if (r.Name.ToLower() == "forestsquare")
                {
                    ForestSquare s = new ForestSquare(board);
                    if (s.readElement(r))
                    {
                        forest = s;
                        insertInto(s.Id, s);
                        previous = s;
                    }
                }
                else if (r.Name.ToLower() == "board")
                {
                    Board b = new Board();
                    if (b.readElement(r))
                    {
                        board = b;
                        _numberOfPawns = board.NumberOfPawns;
                    }
                }
            }
            r.Close();
            link();
            setPiecesToSquares();
            setPawnsToPlayer();
            checkPlayers();
            checkPieces();
            playerList.setCurrent(_currentPlayer);
            setPosition(f, f.X, f.Y);
            conectors();
            board.Squares = linkList;
            board.Baricades = baricades;
            if (forest != null)
            {
                board.ForestSquare = forest;
            }
            Game game = new Game(board, playerList,f);
            board.Game = game;
            return game;
        }

        private void conectors()
        {
            for (int i = 0; i < connectors.Count; i++)
            {
                for (int d = 0; d < connectors[i].links.Length; d++)
                {
                    Square s = connectors[i].links[d];
                    if (s != null)
                    {
                        switch (d)
                        {
                            case 0:
                                s.links[2] = connectors[i].links[2];
                                break;
                            case 1:
                                s.links[3] = connectors[i].links[3];
                                break;
                            case 2:
                                s.links[0] = connectors[i].links[0];
                                break;
                            case 3:
                                s.links[1] = connectors[i].links[1];
                                break;
                        }
                    }
                }
            }
        }

        private void setPawnsToPlayer()
        {
            for (int i = 0; i < pawns.Count; i++)
            {
                for (int j = 0; j < playerList.Count; j++)
                {
                    if (playerList.peek().PlayerId == pawns[i].PlayerId)
                    {
                        pawns[i].Player = playerList.peek();
                        playerList.peek().addPawn(pawns[i],pawns[i].Square);
                        break;
                    }
                    playerList.pop();
                }
            }
        }

        private void checkPlayers()
        {
            if (playerList.Count != playerSquares.Count)
            {
                playerList = new Circuit<Player>();
                for (int i = 0; i < playerSquares.Count; i++)
                {
                    Player player = new Player(playerList);
                    player.PlayerId = playerList.Count + 1;
                    player.PlayerPawns = new List<Pawn>();
                    player.PlayerSquare = playerSquares[i];
                    switch (i+1)
                    {
                        case 1:
                            player.Color = PlayerColor.Blue;
                            break;
                        case 2:
                            player.Color = PlayerColor.Green;
                            break;
                        case 3:
                            player.Color = PlayerColor.Red;
                            break;
                        case 4:
                            player.Color = PlayerColor.Yellow;
                            break;
                    }
                    for (int j = 0; j < NumberOfPawns; j++)
                    {
                        player.PlayerPawns.Add(new Pawn(player.PlayerSquare, player));
                    }
                    playerList.Add(player);
                }
            }
        }

        public void checkPieces()
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                Player p = playerList.pop();
                while (p.PlayerPawns.Count != NumberOfPawns)
                {
                    if (p.PlayerPawns.Count > NumberOfPawns)
                    {
                        if (p.PlayerSquare.Pieces.Count > 0)
                        {
                            p.PlayerPawns.Remove(p.PlayerSquare.Pieces[0]);
                            p.PlayerSquare.Pieces.RemoveAt(0);
                        }
                        else
                        {
                            int lowPos = 0;
                            for (int j = 0; i < p.PlayerPawns.Count; i++)
                            {
                                if (p.PlayerPawns[j].Square.height < p.PlayerPawns[lowPos].Square.height)
                                {
                                    lowPos = j;
                                }
                            }
                            p.PlayerPawns[lowPos].Square.removePawn(p.PlayerPawns[lowPos]);
                            p.PlayerPawns.RemoveAt(lowPos);
                        }
                    }
                    else
                    {
                        p.PlayerPawns.Add(new Pawn(p.PlayerSquare, p));
                    }
                }
            }
            int last = 0;
            while (baricadeSquares.Count != baricades.Count)
            {
                if (baricades.Count < baricadeSquares.Count)
                {
                    for(int i=last;i<baricadeSquares.Count;i++)
                    {
                        if (!baricadeSquares[i].isOccupied())
                        {
                            baricades.Add(new BaricadePiece(baricadeSquares[i]));
                            last=i+1;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < baricadeSquares.Count; i++)
                    {
                        if (baricadeSquares[i].isTransversable())
                        {
                            baricades.Remove((BaricadePiece)baricadeSquares[i].Piece);
                            break;
                        }
                    }
                }
            }
        }
            

        private void setPiecesToSquares()
        {
            for (int i = 0; i < pawns.Count; i++)
            {
                Pawn p = pawns[i];
                p.Square = linkList[find(p.SquareId)];
                p.Square.setPawn(p);
            }
            for (int i = 0; i < baricades.Count; i++)
            {
                BaricadePiece b = baricades[i];
                b.Square = linkList[find(b.SquareId)];
                b.Square.Piece = b;
            }
        }

        private void setPosition(Square square, int x, int y)
        {
            square.height = board.Height-1 - y;
            square.X = x;
            square.Y = y;
            for (int i = 0; i < square.links.Length; i++)
            {
                if (square.links[i] != null)
                {
                    if (square.links[i].height < 0)
                    {
                        switch (i)
                        {
                            case 0:     //Direction.Up
                                setPosition(square.links[i], x, y - 1);
                                break;
                            case 1:     //Direction.Right
                                setPosition(square.links[i], x + 1, y);
                                break;
                            case 2:     //Direction.Down
                                setPosition(square.links[i], x, y + 1);
                                break;
                            case 3:     //Direction.Left
                                setPosition(square.links[i], x - 1, y);
                                break;
                        }
                    }
                }
            }
        }

        private void link()
        {
            for (int i = 0; i < linkList.Count; i++)
            {
                if (linkList[i].Up > 0)
                {
                    linkList[i].links[Direction.Up] = linkList[find(linkList[i].Up)];
                }

                if (linkList[i].Left > 0)
                {
                    linkList[i].links[Direction.Left] = linkList[find(linkList[i].Left)];
                }

                if (linkList[i].Down > 0)
                {
                    linkList[i].links[Direction.Down] = linkList[find(linkList[i].Down)];
                }

                if (linkList[i].Right > 0)
                {
                    linkList[i].links[Direction.Right] = linkList[find(linkList[i].Right)];
                }
            }
        }

        private int find(int p)
        {
            int min = 0, max = linkList.Count - 1,center;
            while (min <= max)
            {
                center = (max + min) / 2;
                if (p == linkList[center].Id)
                {
                    return center;
                }
                else if (p < linkList[center].Id)
                {
                    max = center - 1;
                }
                else if (p > linkList[center].Id)
                {
                    min = center + 1;
                }
            }
            return -1;
        }

        public Board getBoard()
        {
            return board;
        }

        public Circuit<Player> getPlayers()
        {
            return playerList;
        }

        private void insertInto(int i, Square s)
        {
            if (linkList.Count == 0)
            {
                linkList.Add(s);
            }
            else if (i > linkList[linkList.Count - 1].Id)
            {
                linkList.Add(s);
            }
            else
            {
                int min = 0, max = linkList.Count, center;
                while (min <= max)
                {
                    center = min + max / 2;
                    if (i == linkList[center].Id)
                    {
                        throw new Exception("ID duplicate! int = " + i);
                    }
                    else if (i < linkList[center].Id)
                    {
                        max = center - 1;
                    }
                    else
                    {
                        min = center + 1;
                    }
                }
                linkList.Insert(min, s);
            }
        }

        internal Game Load(string s, int humanPlayers)
        {
            int humans=0;
            Game game = Load(s);
            Circuit<Player> players = new Circuit<Player>();
            for (int i = 0; i < baricades.Count; i++)
            {
                baricades[i].Square.Piece = null;
                baricades[i].Square = null;
            }
            
            baricades = new List<BaricadePiece>();
            while (baricades.Count < baricadeSquares.Count)
            {
                BaricadePiece b = new BaricadePiece();
                baricadeSquares[baricades.Count].Piece = b;
                b.Square = baricadeSquares[baricades.Count];
                baricades.Add(b);
            }

            for(int i=0;i<game.Players.Count;i++)
            {
                Player p = game.Players.pop();
                for(int j=0;j<p.PlayerPawns.Count;j++)
                {
                    p.PlayerPawns[j].Square.removePawn(p.PlayerPawns[j]);
                }
                PlayerColor color = p.Color;
                int id = p.PlayerId;
                PlayerSquare square = p.PlayerSquare;

                if (humans < humanPlayers)
                {
                    p = new Player(players);
                    humans++;
                }
                else
                {
                    p = new AIPlayer(players);
                }
                p.PlayerSquare = square;
                p.PlayerId = id;
                p.Color = color;

                for (int j = 0; j < game.Board.NumberOfPawns; j++)
                {
                    p.addPawn(new Pawn(null,p));
                }
                players.Add(p);
            }
            game.Players = players;
            return game;
        }
    }
}