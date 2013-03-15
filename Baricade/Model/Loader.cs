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
            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Element)
                {
                    if (r.Name == "Bord")
                    {

                    }
                }
            }
        }

        public Board getBoard()
        {
            return bord;
        }

        public Player[] getPlayers()
        {
            return playerList;
        }
    }
}
