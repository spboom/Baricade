using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VRestSquare:VSquare
    {
        public VRestSquare(RestSquare square)
            : base(square)
        {
            open='[';
            close=']';
        }
    }
}
