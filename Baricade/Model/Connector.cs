using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    class Connector:Square
    {
        public Connector(Board board)
            : base(board)
        {
            View = new VConnector(this);
        }
    }
}
