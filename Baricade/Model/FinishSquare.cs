using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class FinishSquare : RestSquare
    {
        public FinishSquare() : base() {}

        public override string Name
        {
            get { return "finishSquare"; }
        }
    }
}
