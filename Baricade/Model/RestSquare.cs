using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class RestSquare : Square
    {
        public RestSquare() :base()
        {
            mayContainBaricade = false;
        }

        public override string Name
        {
            get { return "restSquare"; }
        }

        /*
         * This method looks if there is a Piece on the RestSquare. (This method is derived from an abstract method of Square.) 
        public override bool isAvailable()
        {
            if(this.Piece == null) {
                return true;
            }

            return false;
        }
        */
    }
}