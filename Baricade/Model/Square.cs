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
        public int[] distance;
        public int height = -1;

        public Square(Board board)
        {
            Board = board;
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

        public virtual Piece Piece
        {
            get { return _piece; }

            set
            {
                _piece = value;
                if (value != null)
                {
                    value.Square = this;
                }
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

        public Square[] getNext(Square from, int stepsleft, Pawn p)//TODO maymove trough
        {
            List<Square> next = new List<Square>();
            for (int i = 0; i < links.Length; i++)
            {
                if (links[i] != null && !links[i].Equals(from) && links[i].isWalkable())
                {
                    if (stepsleft > 1)
                    {
                        if (links[i].isTransversable())
                        {
                            next.AddRange(links[i].getNext(this, stepsleft - 1, p));
                        }
                    }
                    else if (stepsleft == 1)
                    {
                        if (links[i].isOccupied() && links[i].Piece.Player != null)
                        {
                            if (links[i].Piece.Player == p.Player)
                            {
                            }
                            else if (!links[i].mayPawnBeHit())
                            {
                            }
                            else
                            {
                                next.Add(links[i]);
                            }
                        }
                        else
                        {
                            next.Add(links[i]);
                        }
                    }
                }
            }
            return next.ToArray();
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

        public virtual void setPawn(Pawn p)
        {
            if (p.Square != null)
            {
                p.Square.removePawn(p);
            }
            p.Square = this;
            Piece = p;
        }

        public virtual void removePawn(Pawn p)
        {
            if (Piece != null)
            {
                Piece.Square = null;
            }
            Piece = null;
        }

        /*
         * Can player move a piece across this square?
         */
        public bool isTransversable()
        {
            if (isOccupied())
            {
                return Piece.pawnMayMoveTrough();
            }
            return true;
        }

        /*
         * Is there a piece on this square?
         */
        public bool isOccupied()
        {
            return !(Piece == null);
        }

        /*
         * Can a Pawn be hit on this square?
         */
        public virtual bool mayPawnBeHit()
        {
            return true;
        }

        public Square getEmptyNext(Square from, List<int> idDone)
        {
            idDone.Add(this.Id);
            for (int i = 0; i < links.Length; i++)
            {
                if (links[i] != null && links[i] != from)
                {
                    if (!links[i].isOccupied() && links[i].mayContainBarricade())
                    {
                        return links[i];
                    }
                }
            }
            Square to = null;
            for (int i = 0; i < links.Length; i++)
            {
                if (links[i] != null && !idDone.Contains(links[i].Id))
                {
                    to = links[i].getEmptyNext(this, idDone);
                    if (to != null)
                    {
                        return to;
                    }
                }
            }
            return null;
        }
    }
}