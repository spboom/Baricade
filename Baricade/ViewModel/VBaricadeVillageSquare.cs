using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VBaricadeVillageSquare:VVillageSquare
    {
        public VBaricadeVillageSquare(BaricadeVillageSquare square) : base(square) {}

        public override String getName()
        {
            if (Piece != null)
            {
                return "BarricadeVillageSquare" + "-" + Piece.View.getName();
            }

            return "BarricadeVillageSquare";
        }

        public override String getText()
        {
            return TextView.BaricadeVillageSquare_OpenTag + "" + getPieceString() + "" + TextView.BaricadeVillageSquare_CloseTag;
        }
    }
}
