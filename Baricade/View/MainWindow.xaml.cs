using Baricade.Controller;
using Baricade.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Baricade.View
{
    public partial class MainWindow : System.Windows.Window
    {
        private GameController controller;

        public MainWindow(GameController controller)
        {
            this.controller = controller;

            InitializeComponent();
            setupGrid();
            fillGrid();
        }

        private void setupGrid()
        {
            Board board = controller.Game.Board;

            for (int i = 0; i < board.Width; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                gridPanel.ColumnDefinitions.Add(column);
            }

            for (int i = 0; i < board.Height; i++)
            {
                RowDefinition row = new RowDefinition();
                gridPanel.RowDefinitions.Add(row);
            }

            gridPanel.Width = board.Width * 40;
            gridPanel.Height = board.Height * 40;
            this.Width = gridPanel.Width * 1.2;
            this.Height = gridPanel.Height * 1.4;
        }

        private void fillGrid() {
            foreach (Square s in controller.Game.Board.TwoDBoard) {
                if (s != null)
                {
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Style/" + s.View.getName() + ".jpg"));
                    image.SetValue(Grid.RowProperty, s.View.Y);
                    image.SetValue(Grid.ColumnProperty, s.View.X);
                    gridPanel.Children.Add(image);
                }
            }
        }

        public GameController GameController
        {
            get { return controller; }
            set { controller = value; }
        }

        private void btnThrow_Click(object sender, RoutedEventArgs e)
        {
            GameController.Game.throwDice();
            lblThrow.Content = GameController.Game.CurrentDiceRoll;
        }

        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            GameController.Game.nextTurn();
        }
        
        // Game Menu
        private void mNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGame = new NewGame();
            newGame.Show();
        }

        private void mLoadGame_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.CurrentDirectory + "\\Data\\Saves";
            openFile.DefaultExt = ".xml";
            openFile.Filter = "XML Files|*.xml";

            if (openFile.ShowDialog() == true)
            {
                filename = openFile.FileName;
                GameController.Game = GameController.Loader.Load(filename);
            }            
        }

        private void mSaveGame_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = Environment.CurrentDirectory + "\\Data\\Saves";
            saveFile.DefaultExt = ".xml";
            saveFile.Filter = "XML Files|*.xml";

            if(saveFile.ShowDialog() == true)
            {
                filename = saveFile.FileName;
                new Saver(controller.Game, filename);
            }
        }

        private void mSaveModel_Click(object sender, RoutedEventArgs e)
        {
        }

        // Style Menu
        private void mTextStyle_Click(object sender, RoutedEventArgs e)
        {
        }
        
        private void mBarricadeStyle_Click(object sender, RoutedEventArgs e)
        {
        }

        // Cheat Menu
        private void mCurrentPlayer_Click(object sender, RoutedEventArgs e)
        {
            ChoosePlayer roll = new ChoosePlayer(this);
            roll.Show();
        }

        private void mCurrentDiceThrow_Click(object sender, RoutedEventArgs e)
        {
            ChooseDiceRoll roll = new ChooseDiceRoll(this);
            roll.Show();
        }
    }
}