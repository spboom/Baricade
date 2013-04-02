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
            if (Piece != null)
            {
                return "RestSquare" + "-" + Piece.View.getName();
            }

            return "RestSquare";
        }

        public override String getText()
        {
            return TextView.RestSquare_OpenTag + "" + Piece.View.getChar() + "" + TextView.RestSquare_CloseTag;
        }
    }
}