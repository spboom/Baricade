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
        private Game _game;
        private Loader _loader;

        internal Game Game
        {
            get { return _game; }
            set { _game = value; }
        }

        internal Loader Loader
        {
            get { return _loader; }
            set { _loader = value; }
        }

        public GameController()
        {
            Loader = new Loader();
            Game = Loader.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Data/Level/bord1.xml");

            Game.Board.View.Style = "Minimalistic";
            MainWindow MainWindow = new MainWindow(this);
            MainWindow.Show();
        }

        public void loadGame(String URI)
        {
            Game = Loader.Load(URI);
        }

        internal void Text()
        {
            View.TextView textview = new View.TextView(this);
        }

        internal void newGame(int humanPlayers, string p)
        {
            Game = Loader.Load(p, humanPlayers);
        }
    }
}