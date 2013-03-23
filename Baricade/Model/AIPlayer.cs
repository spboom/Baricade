using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class AIPlayer : Player
    {
        public AIPlayer(int player, int pawns)
            : base(player, pawns)
        {

        }
        public AIPlayer(int player, string color, int pawns)
            : base(player, color, pawns)
        {

        }
    }
}
