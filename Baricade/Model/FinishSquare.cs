using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class FinishSquare : RestSquare//TODO winning
    {
        public FinishSquare(Board board)
            : base(board)
        {
            View = new VFinishSquare(this);
        }

        public override bool isWalkable()
        {
            return true;
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