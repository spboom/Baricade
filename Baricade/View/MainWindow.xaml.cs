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
        private Piece selectedPiece;
        private Square selectedSquare;

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

        private Piece SelectedPiece
        {
            get { return selectedPiece; }
            set { selectedPiece = value; }
        }

        private Square SelectedSquare
        {
            get { return selectedSquare; }
            set { selectedSquare = value; }
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
            String path = "pack://application:,,,/Style/" + board.View.Style + "/";

            foreach (Square s in board.TwoDBoard)
            {
                if (s != null)
                {
                    s.View.Image = new Image();
                    s.View.Image.Name = "y" + s.View.Y + "x" + s.View.X;

                    try
                    {
                        s.View.Image.Source = new BitmapImage(new Uri(path + s.View.getName() + ".jpg"));
                    }
                    catch
                    {
                        s.View.Image.Source = new BitmapImage(new Uri("pack://application:,,,/Style/Minimalistic/square.jpg"));
                    }

                    s.View.Image.SetValue(Grid.RowProperty, s.View.Y);
                    s.View.Image.SetValue(Grid.ColumnProperty, s.View.X);
                    s.View.Image.Margin = new Thickness(1);

                    gridPanel.Children.Add(s.View.Image);

                    if (s.Piece != null)
                    {
                        s.Piece.View.Image = new Image();
                        s.Piece.View.Image.Name = "y" + s.View.Y + "x" + s.View.X;

                        s.Piece.View.Image.Source = new BitmapImage(new Uri(path + s.Piece.View.getName() + ".png"));

                        s.Piece.View.Image.SetValue(Grid.RowProperty, s.View.Y);
                        s.Piece.View.Image.SetValue(Grid.ColumnProperty, s.View.X);

                        gridPanel.Children.Add(s.Piece.View.Image);
                    }
                }
            }
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Image image = e.Source as Image;
            selectCell(image);
        }

        private void selectCell(Image image)
        {
            String[] coordinates = image.Name.Substring(1).Split('x');
            Square s = board.TwoDBoard[Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1])];

            if (SelectedPiece != null)
            {
                GameController.Game.movePiece(SelectedPiece, s);

                s.Piece.View.Image.Name = "y" + s.View.Y + "x" + s.View.X;
                s.Piece.View.Image.SetValue(Grid.RowProperty, s.View.Y);
                s.Piece.View.Image.SetValue(Grid.ColumnProperty, s.View.X);

                SelectedPiece = null;
                Console.WriteLine("Move");
                return;
            }

            if (s.Piece != null)
            {
                selectedPiece = s.Piece;
                Console.WriteLine("Piece");
            }
            else
            {
                if (s is PlayerSquare)
                {
                    Console.WriteLine("quack");
                }

                selectedSquare = s;
                Console.WriteLine("Square");
            }
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

        public void toTextMode()
        {
            Close();
            new TextView(controller);
        }
    }
}