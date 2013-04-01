using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Baricade.ViewModel;
namespace Baricade.Model
{
    public class Square : XmlData<Square>
    {
        private VSquare view;
        protected Board board;
        private Piece _piece;
        private int id;
        public int up, left, right, down;
        public Square[] links;
        public int height = -1;

        public Square()
        {
            view = new VSquare(this);
            links = new Square[4];

        }

        public int X
        {
            get { return view.X; }
            set { view.X = value; }
        }

        public int Y
        {
            get { return view.Y; }
            set { view.Y = value; }
        }

        public Piece Piece
        {
            get { return _piece; }

            set
            {
                _piece = value;
            }
        }

        public Board Board
        {
            get { return board; }
            set { board = value; }
        }

        public VSquare View
        {
            get { return view; }
            set { view = value; }
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

        /*
         * Can player move a piece to this square?
         */
        public virtual bool isWalkable() // Overridden at subclasses.
        {
            return true;
        }

        public virtual bool mayContainBarricade() // Overridden at subclasses.
        {
            return true;
        }

        public virtual bool mayContainPawn() // Overridden at subclasses.
        {
            return true;
        }

        /*
         * Can player move a piece across this square?
         */
        public bool isTransversable()
        {
            return !(Piece is BaricadePiece);
        }

        /*
         * Is there a piece on this square?
         */
        public bool isOccupied()
        {
            return !(Piece == null);
        }
    }
}