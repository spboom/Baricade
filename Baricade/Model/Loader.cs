using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Baricade.Model
{
    class Loader
    {
        private String chosenStyle;
        private int _numberOfHumanPlayers = -1;
        private int _numberOFAIPlayers = -1;
        private int _numberOfPawns = -1;
        private int _currentPlayer = -1;
        private int _currentDiceThrow = -1;
        private int _height = -1;
        private int _width = -1;

        List<Link> linkList = new List<Link>();
        private Player[] playerList;
        private Board bord;

        public int NumberOfHumanPlayers
        {
            get { return _numberOfHumanPlayers; }
            set { _numberOfHumanPlayers = value; }
        }

        public int NumberOFAIPlayers
        {
            get { return _numberOFAIPlayers; }
            set { _numberOFAIPlayers = value; }
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

        public Loader(String uri)
        {
            XmlReader r = XmlReader.Create(uri);
            Board bord = null;
            while (r.Read())
            {
                if (r.Name.ToLower() == "square")
                {
                    Square s = new Square();
                    if (s.readElement(r))
                    {
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
                        insertInto(s.Id, s);
                    }
                }

                else if (r.Name.ToLower() == "finish")
                {
                    FinishSquare s = new FinishSquare();
                    if (s.readElement(r))
                    {
                        insertInto(s.Id, s);
                    }
                }
                else if (r.NodeType == XmlNodeType.Element)
                {
                    if (r.Name.ToLower() == "board")
                    {
                        bord = new Board();
                    }

                }
            }
            link();
        }

        private void link()
        {
            for (int i = 0; i < linkList.Count; i++)
            {
                if (linkList[i].Square.Up >0)
                {
                    linkList[i].Up = linkList[find(linkList[i].Square.Up)];
                }

                if (linkList[i].Square.Left > 0)
                {
                    linkList[i].Left = linkList[find(linkList[i].Square.Left)];
                }

                if (linkList[i].Square.Down > 0)
                {
                    linkList[i].Down = linkList[find(linkList[i].Square.Down)];
                }

                if (linkList[i].Square.Right > 0)
                {
                    linkList[i].Right = linkList[linkList[i].Square.Right];
                }
            }
        }

        private int find(int p)
        {
            int min = 0, max = linkList.Count - 1,center;
            while (min <= max)
            {
                center = (max + min) / 2;
                if (p == linkList[center].Square.Id)
                {
                    return center;
                }
                else if (p < linkList[center].Square.Id)
                {
                    max = center - 1;
                }
                else if (p > linkList[center].Square.Id)
                {
                    min = center + 1;
                }
            }
            return -1;
        }

        public Board getBoard()
        {
            return bord;
        }

        public Player[] getPlayers()
        {
            return playerList;
        }

        private void insertInto(int i, Square s)
        {
            if (linkList.Count == 0)
            {
                linkList.Add(new Link(s));
            }
            else if (i > linkList[linkList.Count - 1].Square.Id)
            {
                linkList.Add(new Link(s));
            }
            else
            {
                int min = 0, max = linkList.Count, center;
                while (min <= max)
                {
                    center = min + max / 2;
                    if (i == linkList[center].Square.Id)
                    {
                        throw new Exception("ID duplicate! int = " + i);
                    }
                    else if (i < linkList[center].Square.Id)
                    {
                        max = center - 1;
                    }
                    else
                    {
                        min = center + 1;
                    }
                }
                linkList.Insert(min, new Link(s));
            }
        }
    }
}
