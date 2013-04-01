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
            int board = 1;
            game = loader.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Data/Level/bord" + board + ".xml");
            //game = loader.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Data/Saves/test.xml");
            new Saver(Game, "test");
        }
    }
}
