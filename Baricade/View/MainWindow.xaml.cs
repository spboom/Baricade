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
        private Square[] highlighted = new Square[0];
        private String path;

        public MainWindow(GameController controller)
        {
            this.controller = controller;
            this.board = controller.Game.Board;

            InitializeComponent();

            if (board.View.Style == null)
            {
                board.View.Style = "Minimalistic";
            }
            path = "pack://application:,,,/Style/" + board.View.Style + "/";

            setupGrid();
            fillGrid();
            GameController.Game.throwDice();
            lblThrow.Content = GameController.Game.CurrentDiceRoll;
            changeColor(GameController.Game.CurrentPlayer.Color);
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
            gridPanel.RowDefinitions.Clear();
            gridPanel.ColumnDefinitions.Clear();

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

            gridPanel.Width = board.Width * 30;
            gridPanel.Height = board.Height * 30;
            this.Width = gridPanel.Width * 1.2;
            this.Height = gridPanel.Height * 1.4;
        }

        private void fillGrid()
        {
            gridPanel.Children.Clear();
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
                }
            }

            //baricades
            placeBaricades(true);

            //pawns
            placePawns(true);
        }

        private void placePawns(bool init = false)
        {
            for (int i = 0; i < controller.Game.Players.List.Count; i++)
            {
                for (int j = 0; j < controller.Game.Players.List[i].PlayerPawns.Count; j++)
                {
                    Piece p = controller.Game.Players.List[i].PlayerPawns[j];
                    if (init)
                    {
                        p.View.Image = new Image();

                        p.View.Image.Source = new BitmapImage(new Uri(path + p.View.getName() + ".png"));

                        gridPanel.Children.Add(p.View.Image);
                    }
                    p.View.Image.Name = "y" + p.Square.View.Y + "x" + p.Square.View.X;

                    p.View.Image.SetValue(Grid.RowProperty, p.Square.View.Y);
                    p.View.Image.SetValue(Grid.ColumnProperty, p.Square.View.X);

                }
            }
        }

        private void placeBaricades(bool init = false)
        {
            for (int i = 0; i < controller.Game.Board.Baricades.Count; i++)
            {
                Piece p = controller.Game.Board.Baricades[i];
                if (init)
                {
                    p.View.Image = new Image();

                    gridPanel.Children.Add(p.View.Image);
                }
                if (p.Square != null)
                {
                    p.View.Image.Name = "y" + p.Square.View.Y + "x" + p.Square.View.X;
                    p.View.Image.SetValue(Grid.RowProperty, p.Square.View.Y);
                    if (p.View.Image.Source == null)
                    {
                        p.View.Image.Source = new BitmapImage(new Uri(path + p.View.getName() + ".png"));
                    }

                    p.View.Image.SetValue(Grid.ColumnProperty, p.Square.View.X);
                }
                else
                {
                    p.View.Image.Name = "y0x0";
                    p.View.Image.SetValue(Grid.RowProperty, 0);

                    p.View.Image.SetValue(Grid.ColumnProperty, 0);

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
            bool movedPawn = false, movedBaricade = false;

            if (selectedPiece != null)
            {
                bool mayMoveTo = false;
                for (int i = 0; i < highlighted.Length; i++)
                {
                    if (s == highlighted[i])
                    {
                        mayMoveTo = true;
                        break;
                    }
                }
                if (selectedPiece is Pawn)
                {
                    highlight(new Square[0]);
                }
                if (!GameController.Game.PlayerMovedPiece || GameController.Game.CurrentPlayer.Baricade != null)
                {
                    Piece piece = null;

                    if (selectedPiece == GameController.Game.CurrentPlayer.Baricade)
                    {
                        movedBaricade = GameController.Game.CurrentPlayer.Baricade.moveTo(s);
                    }
                    else if (SelectedPiece.Player == GameController.Game.CurrentPlayer && mayMoveTo)
                    {
                        if (s.Piece != null && s.Piece is BaricadePiece)
                        {
                            s.Piece.View.Image.Source = null;
                            piece = s.Piece;
                            movedBaricade = movedPawn = GameController.Game.movePiece(selectedPiece, s);
                        }
                        else
                        {
                            movedPawn = GameController.Game.movePiece(SelectedPiece, s);
                        }
                    }
                    if (movedBaricade)
                    {
                        placeBaricades();
                    }
                    if (movedPawn)
                    {
                        placePawns();
                    }
                    if (movedBaricade || movedPawn)
                    {
                        SelectedPiece = piece;
                        Console.WriteLine("Move");
                        if (GameController.Game.CurrentPlayer.Baricade == null && GameController.Game.PlayerMovedPiece)
                        {
                            btnNextTurn.IsEnabled = true;
                        }
                        return;
                    }
                }
            }

            if (s.Piece != null && s.Piece is Pawn && (selectedPiece == null || GameController.Game.CurrentPlayer.Baricade == null) && s.Piece.Player.Equals(GameController.Game.CurrentPlayer))
            {
                selectedPiece = s.Piece;
                Console.WriteLine("Piece");
                highlight(selectedPiece.Square.getNext(null, controller.Game.CurrentDiceRoll, (Pawn)selectedPiece));
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
            lblThrow.Content = GameController.Game.CurrentDiceRoll;
            btnThrowDice.IsEnabled = false;
        }

        private void highlight(Square[] squares)
        {
            for (int i = 0; i < highlighted.Length; i++)
            {
                highlighted[i].View.Image.Opacity = 1;
            }
            if (!GameController.Game.PlayerMovedPiece)
            {

                for (int i = 0; i < squares.Length; i++)
                {
                    squares[i].View.Image.Opacity = 0.5;
                }
                highlighted = squares;
            }
            else
            {
                highlighted = new Square[0];
            }
        }

        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            GameController.Game.nextTurn();
            changeColor(GameController.Game.CurrentPlayer.Color);
            while (!GameController.Game.CurrentPlayer.Human)
            {
                GameController.Game.CurrentPlayer.bestmove(GameController.Game.CurrentDiceRoll);
                placeBaricades();
                placePawns();
                GameController.Game.nextTurn();
            }
            btnThrowDice.IsEnabled = true;
            btnNextTurn.IsEnabled = false;
        }

        private void changeColor(PlayerColor color)
        {
            switch (color)
            {
                case PlayerColor.Red:
                    lblPlayerColor.Foreground = Brushes.Red;
                    break;
                case PlayerColor.Blue:
                    lblPlayerColor.Foreground = Brushes.Blue;
                    break;
                case PlayerColor.Green:
                    lblPlayerColor.Foreground = Brushes.Green;
                    break;
                case PlayerColor.Yellow:
                    lblPlayerColor.Foreground = Brushes.Yellow;
                    break;
                default:
                    lblPlayerColor.Foreground = Brushes.Black;
                    break;
            }
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
                board = GameController.Game.Board;
                if (board.View.Style == null)
                {
                    board.View.Style = "Minimalistic";
                }
                path = "pack://application:,,,/Style/" + board.View.Style + "/";

                setupGrid();
                fillGrid();

                GameController.Game.throwDice();
                lblThrow.Content = GameController.Game.CurrentDiceRoll;
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