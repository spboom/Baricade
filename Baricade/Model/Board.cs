using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Board : XmlData<Board>
    {
        private int _height;
        private int _width;
        private int _numberOfPawns;
        private String style;
        private ForestSquare _forestSquare;
        private List<BaricadePiece> baricades;

        public List<BaricadePiece> Baricades
        {
            get { return baricades; }
            set { baricades = value; }
        }

        public ForestSquare ForestSquare
        {
            get { return _forestSquare; }
            private set { _forestSquare = value; }
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

        public int NumberOfPawns
        {
            get { return _numberOfPawns; }
            set
            {
                if (value <= 0)
                {
                    _numberOfPawns = value;
                }
                else
                {
                    _numberOfPawns = 4;
                }
            }
        }

        public Board()
        {
        }
    }
}
