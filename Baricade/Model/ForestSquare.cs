using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class ForestSquare : PlayerSquare
    {
        private ArrayList pawns;

        public ForestSquare(Board board)
            : base(board)
        {
            View = new VForestSquare(this);
            pawns = new ArrayList();
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