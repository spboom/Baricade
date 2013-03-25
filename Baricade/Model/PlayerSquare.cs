using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class PlayerSquare : RestSquare
    {
        public PlayerSquare() : base() { }

        public virtual bool isWalkable()
        {
            return false;
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