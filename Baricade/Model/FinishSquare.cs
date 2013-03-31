using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class FinishSquare : RestSquare
    {
        public FinishSquare() : base() { }

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