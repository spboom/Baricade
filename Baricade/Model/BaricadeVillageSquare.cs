using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class BaricadeVillageSquare : VillageSquare
    {
        public virtual bool isWalkable()
        {
            return true;
        }

        public virtual bool mayContainBarricade()
        {
            return true;
        }

        public virtual bool mayContainPawn()
        {
            return true;
        }
    }
}