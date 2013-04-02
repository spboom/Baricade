using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VPlayerSquare:VRestSquare
    {
        public VPlayerSquare(PlayerSquare square) : base(square) {}

        public override String getName()
        {
            if (Piece != null)
            {
                return "PlayerSquare" + "-" + Piece.View.getName();
            }

            return "PlayerSquare";
        }

        public override String getText()
        {
            return TextView.PlayerSquare_OpenTag + "" + Piece.View.getChar() + "" + TextView.PlayerSquare_CloseTag;
        }
    }
}