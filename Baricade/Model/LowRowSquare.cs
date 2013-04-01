using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class LowRowSquare:Square
    {
        public LowRowSquare()
            : base()
        {
            View = new VLowRowSquare(this);
        }

        public override bool mayContainBarricade()
        {
            return false;
        }
    }
}
