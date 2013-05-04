using Baricade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.ViewModel
{
    class VVillageSquare:VSquare
    {
        public VVillageSquare(VillageSquare square) : base(square) {}

        public override String getName()
        {
            if (Square.Up != 0 && Square.links[0].Up == 0)
            {
                return "pointSquare";
            }

            return "villageSquare";
        }

        public override String getText()
        {
            return TextView.VillageSquare_OpenTag + "" + getPieceString() + "" + TextView.VillageSquare_CloseTag;
        }
    }
}