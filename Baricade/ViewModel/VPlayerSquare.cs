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
        public VPlayerSquare(PlayerSquare square)
            : base(square)
        {
            open='<';
            close='>';
        }
    }
}
