using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VConnector:VSquare
    {
        public VConnector(Connector square)
            : base(square)
        {
        }

        public override String getName()
        {
            if (Piece != null)
            {
                return "Connector";
            }

            return "BarricadeVillageSquare";
        }

        public override String getText()
        {
            return TextView.Connector_OpenTag + "" + getPieceString() + "" + TextView.Connector_CloseTag;
        }
        public override char getPieceString()
        {
            return '|';
        }
    }
}
