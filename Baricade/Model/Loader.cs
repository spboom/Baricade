using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Baricade.ViewModel;

namespace Baricade.Model
{
    class Loader
    {
        private String chosenStyle;
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
        private List<BaricadeSquare> baricadeSquares = new List<BaricadeSquare>();
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

            while (r.Read())
            {
                if (r.Name.ToLower() == "square")
                {
                    Square s = new Square();
                    if (s.readElement(r))
                    {
                        s.View = new VSquare(s);
                        insertInto(s.Id, s);
                    }
                }

                else if (r.Name.ToLower() == "villagesquare")
                {
                    VillageSquare s = new VillageSquare();
                    if (s.readElement(r))
                    {
                        insertInto(s.Id, s);
                    }
                }

                else if (r.Name.ToLower() == "baricadesquare")
                {
                    BaricadeSquare s = new BaricadeSquare();
                    if (s.readElement(r))
                    {
                        insertInto(s.Id, s);
                    }
                }

                else if (r.Name.ToLower() == "baricadevillageSquare")
                {
                    BaricadeVillageSquare s = new BaricadeVillageSquare();
                    if(s.readElement(r))
                    {
                        insertInto(s.Id, s);
                    }
                }

                else if (r.Name.ToLower() == "playersquare")
                {
                    PlayerSquare s = new PlayerSquare();
                    if(s.readElement(r))
                    {
                        playerSquares.Add(s);
                        insertInto(s.Id, s);
                    }
                }

                else if (r.Name.ToLower() == "Pawn")
                {

                }

                    else if (r.Name.ToLower() == "Pawn")
                {

                    }

                else if (r.Name.ToLower() == "player")
                {
                    Player p = new Player(playerList.Count+1, NumberOfPawns, playerSquares[playerList.Count]);
                    if (p.readElement(r))
                    {
                        _numberofPlayers++;
                        _numberOfHumanPlayers++;
                        playerList.Add(p);
                    }
                }

                else if (r.Name.ToLower() == "aiplayer")
                {
                    AIPlayer p = new AIPlayer(playerList.Count + 1, NumberOfPawns, playerSquares[playerList.Count]);
                    if (p.readElement(r))
                    {
                        _numberOfAIPlayers++;
                        _numberOfHumanPlayers++;
                        playerList.Add(p);
                    }
                }

                else if (r.Name.ToLower() == "finish")
                {
                    FinishSquare s = new FinishSquare();
                    if (s.readElement(r))
                    {
                        f = s;
                        insertInto(s.Id, s);
                    }
                }
                else if (r.Name.ToLower() == "forestsquare")
                {
                    ForestSquare s = new ForestSquare();
                    if (s.readElement(r))
                    {
                        forest = s;
                        insertInto(s.Id, s);
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
            link();
            checkPlayers();
            playerList.setCurrent(_currentPlayer);
            setHeight(playerList.peek().PlayerSquare, 0);
            return new Game(board, playerList,f);
        }

        private void checkPlayers()
        {
            if (playerList.Count != playerSquares.Count)
            {
                playerList = new Circuit<Player>();
                for (int i=0;i<playerSquares.Count;i++)
                {
                    Player player = new Player(i + 1, _numberOfPawns, playerSquares[playerList.Count]);
                    player.PlayerSquare = playerSquares[i];
                    playerList.Add(player);

                }
            }
        }

        private void setHeight(Square square, int height)
        {
            square.height = height;
            for (int i = 0; i < square.links.Length; i++)
            {
                if (square.links[i] != null)
                {
                    if (square.links[i].height < 0)
                    {
                        switch (i)
                        {
                            case 0:     //Direction.Up
                                setHeight(square.links[i], height + 1);
                                break;
                            case 2:     //Direction.Down
                                setHeight(square.links[i], height - 1);
                                break;
                            case 1:     //Direction.Right
                            case 3:     //Direction.Left
                                setHeight(square.links[i], height);
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
                if (linkList[i].Up >0)
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
                    linkList[i].links[Direction.Right]= linkList[linkList[i].Right];
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
    }
}