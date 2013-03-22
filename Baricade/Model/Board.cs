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
        private String style;
        private Link Veld;

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

        public void setveld(Link l)
        {
            Veld = l;
        }
        public Board()
        {
        }
    }
}
