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

        private void btnThrowClick(object sender, RoutedEventArgs e)
        {
            game.throwDice();
            lblThrow.Content = game.CurrentDiceRoll;
        }
    }
}
