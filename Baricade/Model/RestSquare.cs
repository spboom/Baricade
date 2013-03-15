using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class RestSquare : Square
    {
        public RestSquare()
            :base()
        {
            mayContainBaricade = false;
        }
    }
}
