using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class PlayerSquare : RestSquare
    {
        public PlayerSquare() : base() {}

        public override string Name
        {
            get { return "playerSquare"; }
        }
    }
}
