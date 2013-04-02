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
        public VLowRowSquare(LowRowSquare square)
            : base(square)
        { }
        public override String getName()
        {
            if (Piece != null)
            {
                return "LowRowSquare" + "-" + Piece.View.getName();
            }

            return "LowRowSquare";
        }

        public override String getText()
        {
            return TextView.Square_OpenTag + "" + Piece.View.getChar() + "" + TextView.Square_CloseTag;
        }
    }
}


