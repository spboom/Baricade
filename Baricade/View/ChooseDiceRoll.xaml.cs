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
    /// Interaction logic for chooseDiceRoll.xaml
    /// </summary>
    public partial class ChooseDiceRoll : Window
    {
        private MainWindow mainWindow;

        public ChooseDiceRoll(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            InitializeComponent();
        }

        private void btnOKClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Game.CurrentDiceRoll = Convert.ToInt32(cmbDiceThrow.Text);
            mainWindow.lblThrow.Content = Convert.ToInt32(cmbDiceThrow.Text);
        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}