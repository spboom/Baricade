using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.ViewModel
{
    class VBaricade : VPiece
    {
        private BaricadePiece barricade;

        public VBaricade(BaricadePiece baricade) : base(baricade)
        {
            this.barricade = baricade;
        }

        public BaricadePiece Barricade
        {
            get { return barricade; }
            private set { barricade = value; }
        }

        public override String getName()
        {
            return "Barricade";
        }

        public override char getChar()
        {
            return TextView.Barricade;
        }
    }
}
