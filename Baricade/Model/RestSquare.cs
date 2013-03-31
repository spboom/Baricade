using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class RestSquare : Square
    {
        public RestSquare() : base() { }

        public override bool isWalkable()
        {
            return true;
        }

        /*
         * A barricade cannot be placed on rest square.
         */
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