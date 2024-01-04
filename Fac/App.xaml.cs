using Fac.src.Api;
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
        public static ApiCliente Api { get; set; }
        private static string URL_API = "http://localhost:8080";
        public App()
        {
            Api = new ApiCliente(URL_API);
        }



    }
}
