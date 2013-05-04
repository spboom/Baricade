using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VRestSquare:VSquare
    {
        public VRestSquare(RestSquare square) : base(square) {}

        public override String getName()
        {
            if (Square.Up != 0 && Square.links[0].Up == 0)
            {
                return "pointSquare";
            }

            return "restSquare";
        }

        public override String getText()
        {
            return TextView.RestSquare_OpenTag + "" + getPieceString() + "" + TextView.RestSquare_CloseTag;
        }
    }
}