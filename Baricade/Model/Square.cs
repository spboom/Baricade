using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Baricade.Model
{
    abstract class Square : XmlData<Square>
    {
        private Piece _piece;
        private int id;
        public int up, left, right, down;
        public Square[] links;
        protected bool mayContainBaricade;

        public Piece Piece
        {
            get { return _piece; }
            
            set 
            {
                _piece = value; 
            }
        }

        public abstract string Name { get; }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Up
        {
            get { return up; }
            set { up = value; }
        }

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        public int Down
        {
            get { return down; }
            set { down = value; }
        }
        
        public Square()
        {
            mayContainBaricade = true;
        }

<<<<<<< HEAD
        public void setDirection(int direction, Square s)
        {
            if (direction <= 3 && direction >= 0)
            {
                links[direction] = s;
            }
        }
        public List<Square> getNext(Square from, int stepsleft)
        {
            List<Square> next = new List<Square>();
            for (int i = 0; i < links.Length; i++)
            {
                if (links[i] != null && !links[i].Equals(from))
                {
                    if (stepsleft > 0)
                    {
                        next.AddRange(links[i].getNext(this, stepsleft - 1));
                    }
                    else
                    {
                        next.Add(links[i]);
                    }
                }
            }
            return next;
        }
=======
        //public abstract bool isAvailable();
>>>>>>> 5f549ac154fb830405acbef96503f3a39058844e
    }
}
