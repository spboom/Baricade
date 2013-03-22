using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Baricade.Model
{
    class Square : XmlData<Square>
    {
        private Image image;
        private Piece piece;
        private int id;
        public int up, left, right, down;
        public Square[] links;
        protected bool mayContainBaricade;

        protected Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }

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
    }
}
