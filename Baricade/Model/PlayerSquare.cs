using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class PlayerSquare : RestSquare
    {
        private List<Pawn> _pieces = new List<Pawn>();

        internal List<Pawn> Pieces
        {
            get { return _pieces; }
            set { _pieces = value; }
        }
        public PlayerSquare() : base() { }

        public override bool isWalkable()
        {
            return false;
        }

        public override bool mayContainBarricade()
        {
            return false;
        }

        public override bool mayContainPawn()
        {
            return true;
        }
    }
}