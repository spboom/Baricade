using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VLowRowSquare : VSquare
    {
        public VLowRowSquare(LowRowSquare square) : base(square) { }
        
        public override String getName()
        {
            return "lowRowSquare";
        }

        public override String getText()
        {
            return TextView.Square_OpenTag + "" + getPieceString() + "" + TextView.Square_CloseTag;
        }
    }
}


