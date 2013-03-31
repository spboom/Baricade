﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class AIPlayer : Player
    {
        public AIPlayer(int player, int pawns,PlayerSquare square)
            : base(player, pawns, square)
        {

        }
        public AIPlayer(int player, PlayerColor color, int pawns, PlayerSquare square)
            : base(player, color, pawns, square)
        {

        }
    }
}
