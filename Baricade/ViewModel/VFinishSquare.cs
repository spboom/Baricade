using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VFinishSquare:VRestSquare
    {
        public VFinishSquare(Square square)
            :base(square)
        {
            open = '!';
            close='!'
        }
    }
}
