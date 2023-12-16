using Fac.src.Command.CmdConsole;
using Fac.src.MySql;
using Fac.src.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fac
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Inventario Inventario;
        public App()
        {
            ConsoleCmd cmd = new ConsoleCmd();
            Inventario = new Inventario();
        }



    }
}
