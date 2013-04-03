using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;
using Baricade.View;
using System.Windows;
using Baricade.ViewModel;

namespace Baricade.Controller
{
    public class GameController
    {
        private Game game;
        private Loader loader;

        internal Game Game
        {
            get { return game; }
            set { game = value; }
        }

        internal Loader Loader
        {
            get { return loader; }
            set { loader = value; }
        }

        public GameController()
        {
            loader = new Loader();
            int board = 1;
            Game = Loader.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Data/Level/bord" + board + ".xml");
            Game.Board.View.Style = "Minimalistic";
            MainWindow MainWindow = new MainWindow(this);
            MainWindow.Show();
        }

        public void loadGame(String URI)
        {
            loader = new Loader();
            game = loader.Load(URI);
        }
    }
}