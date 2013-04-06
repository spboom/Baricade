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
    /// Interaction logic for StyleChooser.xaml
    /// </summary>
    public partial class StyleChooser : Window
    {
        private MainWindow mainWindow;

        public StyleChooser(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(lbStyle.SelectedIndex);
            switch (lbStyle.SelectedIndex)
            {
                case 0:
                    Close();
                    mainWindow.toTextMode();
                    break;
                case 1:
                    Close();
                    break;
            }
        }
    }
}