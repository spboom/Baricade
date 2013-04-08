using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class BaricadeVillageSquare : VillageSquare
    {
        public BaricadeVillageSquare(Board board)
            : base(board)
        {
            View = new VBaricadeVillageSquare(this);
        }
        public override bool isWalkable()
        {
            return true;
        }

        public override bool mayContainBarricade()
        {
            return true;
        }

        public override bool mayContainPawn()
        {
            return true;
        }
    }
}