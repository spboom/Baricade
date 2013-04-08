using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class BaricadeSquare : Square
    {
        public BaricadeSquare(Board board)
            : base(board)
        {
            View = new VBaricadeSquare(this);
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