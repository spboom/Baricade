using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VFinishSquare : VRestSquare
    {
        public VFinishSquare(FinishSquare square) : base(square) { }

        public override String getName()
        {
            return "finishSquare";
        }

        public override String getText()
        {
            return TextView.FinishSquare_OpenTag + "" + getPieceString() + "" + TextView.FinishSquare_CloseTag;
        }
    }
}