using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class BaricadeSquare : Square
    {
        public BaricadeSquare() : base() {}

        public override string Name
        {
            get { return "barricadeSquare"; }
        }

        /*
         * This method looks if there is a Barricade on the BarricadeSquare. (This method is derived from an abstract method of Square.) 

        public override bool isAvailable()
        {
            if (this.Piece == null)
            {
                return true;
            }

            return false;
        }
        */
    }
}
