using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class ForestSquare : RestSquare
    {
        private ArrayList pawns;

        public ForestSquare()
            : base()
        {
            pawns = new ArrayList();
        }

        public void addPawn(Pawn p)
        {
            pawns.Add(p);
        }

        public void removePawn(Pawn p)
        {
            pawns.Add(p);
        }

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