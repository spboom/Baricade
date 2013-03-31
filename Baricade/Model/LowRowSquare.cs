using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class LowRowSquare:Square
    {
        public LowRowSquare()
            : base()
        {
        }

        public override bool mayContainBarricade()
        {
            return false;
        }
    }
}
