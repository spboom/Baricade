using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class VillageSquare : Square
    {
        public VillageSquare() :base() {}

        public override string Name
        {
            get { return "villageSquare"; }
        }

        public override Square getReturnTo()
        {
            return board.ForestSquare;
        }
    }
}
