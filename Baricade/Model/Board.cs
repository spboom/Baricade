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

        private ForestSquare _forestSquare;

        public Board()
        {
        }
    }
}
