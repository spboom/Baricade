using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class FinishSquare : RestSquare
    {
        public FinishSquare() : base() { }

        public virtual bool isWalkable()
        {
            return true;
        }

        public virtual bool mayContainBarricade()
        {
            return false;
        }

        public virtual bool mayContainPawn()
        {
            return true;
        }
    }
}