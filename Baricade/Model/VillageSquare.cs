using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class VillageSquare : Square
    {
        public VillageSquare() : base() { }

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
            return board.ForestSquare;
        }
    }
}