using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VBaricadeSquare : VSquare
    {
        public VBaricadeSquare(BaricadeSquare square) : base(square) {}

        public override String getName()
        {
            return "BarricadeSquare" + "-" + Piece.View.getName();
        }

        public override String getText()
        {
            return TextView.BarricadeSquare_OpenTag + "" + Piece.View.getChar() + "" + TextView.BarricadeSquare_CloseTag;
        }
    }
}