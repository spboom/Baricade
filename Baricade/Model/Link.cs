using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Link :XmlData<Link>
    {
        private Square _square;
        private Link _up;
        private Link _down;
        private Link _left;
        private Link _right;

        internal Square Square
        {
            get { return _square; }
            set { _square = value; }
        }

        internal Link Up
        {
            get { return _up; }
            set { _up = value; }
        }

        internal Link Down
        {
            get { return _down; }
            set { _down = value; }
        }

        internal Link Left
        {
            get { return _left; }
            set { _left = value; }
        }

        internal Link Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public Link(Square s)
        {
            _square = s;
        }
    }
}
