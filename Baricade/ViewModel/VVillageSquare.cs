using Baricade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.ViewModel
{
    class VVillageSquare:VSquare
    {
        public VVillageSquare(VillageSquare square)
            : base(square)
        {
            open = '{';
            close= '}';
        }
    }
}
