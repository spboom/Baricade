using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class Factory
    {
        public Factory()
        {

        }

        public Game Load(String uri)
        {
            Loader loader = new Loader();


            return loader.Load(uri);
        }
    }
}
