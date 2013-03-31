using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VLowRowSquare:VSquare
    {
        public VLowRowSquare(LowRowSquare square)
            : base(square)
        {
            public override String getName()
        {
            return "LowRowSquare" + "-" + Piece.View.getName();
        }

        public override String getText()
        {
            return TextView.LowRowSquare_OpenTag + "" + Piece.View.getChar() + "" + TextView.LowRowSquare_CloseTag;
        }
        }
    }
}
