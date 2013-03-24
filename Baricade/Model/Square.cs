using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Baricade.ViewModel;
namespace Baricade.Model
{
    class Square : XmlData<Square>
    {
        private VSquare view
        protected Board board;
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

        public virtual string Name { get { return ""; } protected set { } }

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
            links = new Square[4];
        }

        public VSquare View
        {
            get { return view; }
            set { view = value; }
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
        //public abstract bool isAvailable();

        public virtual Square getReturnTo()
        {
            if (Piece != null)
            {
                if (Piece.Player != null)
                {
                    return Piece.Player.PlayerSquare;
                }
            }
            return null;
        }
    }
}