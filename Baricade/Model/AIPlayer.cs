using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class AIPlayer : Player
    {
        public AIPlayer(Circuit<Player> circuit)
            :base(circuit)
        { }

        public override bool Human
        {
            get
            {
                return false;
            }
        }
    }
}
