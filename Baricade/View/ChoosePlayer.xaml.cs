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
    /// Interaction logic for ChoosePlayer.xaml
    /// </summary>
    public partial class ChoosePlayer : Window
    {
        private MainWindow mainWindow;

        public ChoosePlayer(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            InitializeComponent();
        }
    }
}
