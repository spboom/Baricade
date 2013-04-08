using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class VillageSquare : Square
    {
        public VillageSquare(Board board)
            : base(board)
        {
            View = new VVillageSquare(this);
        }

        public override bool isWalkable()
        {
            return true;
        }

        public override bool mayContainBarricade()
        {
            return true;
        }

        public override bool mayContainPawn()
        {
            return true;
        }

        public override Square getReturnTo()
        {
            if (board.ForestSquare != null)
            {
                return board.ForestSquare;
            }
            else
            {
                return base.getReturnTo();
            }
        }
    }
}