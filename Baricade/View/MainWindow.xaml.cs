using Baricade.Model;
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
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private Game game;

        public MainWindow(Game game)
        {
            this.game = game;

            InitializeComponent();
        }

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        private void btnThrow_Click(object sender, RoutedEventArgs e)
        {
            game.throwDice();
            lblThrow.Content = game.CurrentDiceRoll;
        }

        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {

        }
        
        // Game Menu
        private void mNewGame_Click(object sender, RoutedEventArgs e)
        {
        }

        private void mLoadGame_Click(object sender, RoutedEventArgs e)
        {
        }

        private void mSaveGame_Click(object sender, RoutedEventArgs e)
        {
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