using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;

namespace Baricade.Controller
{
    class GameController
    {
        private Game game;
        private Loader loader;

        internal Game Game
        {
            get { return game; }
            set { game = value; }
        }

        public GameController()
        {
            loader = new Loader();
            game = loader.Load("C:/Users/Sjors Boom/Dropbox/Baricadespel C# miniproject/bord1.xml");
        }
    }
}
