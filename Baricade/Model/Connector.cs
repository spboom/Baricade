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
        public Connector()
            : base()
        {
            View = new VConnector(this);
        }
    }
}
