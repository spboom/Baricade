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
        private Board board;
        private Square firstSelectedSquare;
        private Square secondSelectedSquare;

        public MainWindow(GameController controller)
        {
            this.controller = controller;
            this.board = controller.Game.Board;

            InitializeComponent();
            setupGrid();
            fillGrid();
        }
        
        public GameController GameController
        {
            get { return controller; }
            set { controller = value; }
        }

        private Square FirstSelectedSquare
        {
            get { return firstSelectedSquare; }
            set { firstSelectedSquare = value; }
        }

        private Square SecondSelectedSquare
        {
            get { return secondSelectedSquare; }
            set { secondSelectedSquare = value; }
        }

        private void setupGrid()
        {
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

        private void fillGrid()
        {
            foreach (Square s in board.TwoDBoard)
            {
                if (s != null)
                {
                    Image image = new Image();
                    image.Name = "y" + s.View.Y + "x" + s.View.X;

                    String path = "pack://application:,,,/Style/" + board.View.Style + "/" + s.View.getName() + ".jpg";
                    image.Source = new BitmapImage(new Uri(path));

                    image.SetValue(Grid.RowProperty, s.View.Y);
                    image.SetValue(Grid.ColumnProperty, s.View.X);

                    gridPanel.Children.Add(image);
                }
            }
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Image image = e.Source as Image;
            selectSquare(image);
        }

        private void selectSquare(Image image)
        {
            if (FirstSelectedSquare == null && SecondSelectedSquare == null)
            {
                FirstSelectedSquare = getSquareFromCell(image.Name);

                /*if (FirstSelectedSquare.Piece == null)
                {
                    FirstSelectedSquare = null;
                }*/
            }

            else if (FirstSelectedSquare != null && SecondSelectedSquare == null)
            {
                SecondSelectedSquare = getSquareFromCell(image.Name);
            }

            if (SecondSelectedSquare != null && FirstSelectedSquare != null)
            {
                if (FirstSelectedSquare.Piece != null)
                {
                    GameController.Game.movePiece(FirstSelectedSquare.Piece, SecondSelectedSquare);
                }

                FirstSelectedSquare = null;
                SecondSelectedSquare = null;
            }
        }

        private Square getSquareFromCell(String cell)
        {
            String[] coordinates = cell.Substring(1).Split('x');
            return board.TwoDBoard[Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1])];
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

            if (saveFile.ShowDialog() == true)
            {
                filename = saveFile.FileName;
                new Saver(controller.Game, filename);
            }
        }

        private void mSaveModel_Click(object sender, RoutedEventArgs e)
        {
        }

        // Style Menu
        private void mChooseStyle_Click(object sender, RoutedEventArgs e)
        {
            StyleChooser styleChooser = new StyleChooser(this);
            styleChooser.Show();
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