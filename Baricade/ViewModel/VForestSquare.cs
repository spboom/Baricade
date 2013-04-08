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
            return "forestSquare";
        }

        public override String getText()
        {
            return TextView.ForestSquare_OpenTag + "" + getPieceString() + "" + TextView.ForestSquare_CloseTag;
        }
    }
}