using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Baricade
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Model.Loader loader = new Model.Loader("C:/Users/Sjors Boom/Dropbox/Baricadespel C# miniproject/bord1.xml");
    }
}
