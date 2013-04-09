using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class PlayerSquare : RestSquare
    {
        private List<Pawn> _pieces = new List<Pawn>();

        public override Piece Piece
        {
            get
            {
                if (Pieces.Count >= 1)
                {
                    return Pieces[0];
                }
                return null;
            }
            set
            {
                base.Piece = value;
            }
        }

        internal List<Pawn> Pieces
        {
            get { return _pieces; }
            set { _pieces = value; }
        }
        public PlayerSquare(Board board)
            : base(board)
        {
            View = new VPlayerSquare(this);
        }

        public override bool isWalkable()
        {
            return false;
        }

        public override bool mayContainBarricade()
        {
            return false;
        }

        private void addPawn(Pawn p)
        {
            Pieces.Add(p);
        }

        public override bool mayContainPawn()
        {
            return true;
        }

        public override void setPawn(Pawn p)
        {
            p.Square = this;
            Pieces.Add(p);
        }

        public override void removePawn(Pawn p)
        {
            p.Square = null;
            bool check = Pieces.Remove(p);
        }
    }
}