using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class ForestSquare : RestSquare
    {
        private ArrayList pawns;

        public ForestSquare()
            : base()
        {
            View = new VForestSquare(this);
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

        public override bool isWalkable()
        {
            return false;
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