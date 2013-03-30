using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VForestSquare:VRestSquare
    {
        public VForestSquare(ForestSquare square) : base(square) {}

        public override String getName()
        {
            return "ForestSquare" + "-" + Piece.View.getName();
        }

        public override String getText()
        {
            return TextView.ForestSquare_OpenTag + "" + Piece.View.getChar() + "" + TextView.ForestSquare_CloseTag;
        }
    }
}