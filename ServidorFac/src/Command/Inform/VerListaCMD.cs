using Command;
using Fac.src.Command.CmdConsole;
using Fac.src.Funciones.StyleConsole;
using Fac.src.Funciones.StyleConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Command.Inform
{
    public class VerListaCMD : CommandBase
    {
        private string[] Parametros;
        private readonly Servidor Servidor;

        public VerListaCMD(Servidor servidor)
        {
            this.Servidor = servidor;
            Parametros = new string[] { };
        }

        public override void Execute(object parameter)
        {
            this.Parametros = (string[])parameter;
            Ejecutar((string[])parameter);
        }

        public void Ejecutar(string[] parameter)
        {
            if (parameter.Length == 0) Parametros = new string[1] { "" };
            else Parametros = parameter;

            ViewParameter viewParameter = verificParameter(Parametros[0]);
            View(viewParameter);
        }

        private void View(ViewParameter view)
        {
            if (view == ViewParameter.None) printHelpView();
            if (view == ViewParameter.Productos) viewProductos();
            if (view == ViewParameter.Categorias) viewCategorias();

        }

        private void printHelpView()
        {
            StyleConsole2 cl = new StyleConsole2();
            cl.Padding = new Puntos(1, 1, 1, 1);
            cl.Margin = new Puntos(1, 1, 1, 1);

            string msg = string.Empty;
            msg += "Uso:\n";
            msg += "view [Tabla] *[Name/Id]\n";
            msg += "______________________________________________________\n\n";
            msg += "Tablas\n";
            msg += "- Categorias: Obtienes la lista de todas las categorias\n";
            msg += "- Productos: Obtienes la lista de todas las categorias\n";
            msg += "ID\n";
            msg += "- Id de la categoria\n";

            msg = cl.GenerarContenedor(msg, "Comando View");
            Console.WriteLine(msg);
        }
        private void viewCategorias()
        {
            Tabla tabla = new Tabla();
            tabla.Padding = 1;

            List<Celda> Cavecera = new List<Celda>()
            {
                new Celda { Text = "Id" },
                new Celda { Text = "Nombre" },
            };
            tabla.AddRow(Cavecera);

            foreach (var item in Servidor._inventario.ListaCategoria)
            {
                List<Celda> Row = new List<Celda>()
                {
                    new Celda { Text = item.Value.Id.ToString() },
                    new Celda { Text = item.Value.Name.ToString() },
                };
                tabla.AddRow(Row);
            }
            Console.WriteLine("\n" + tabla);
        }

        private void viewProductos()
        {
            Tabla tabla = new Tabla();
            tabla.Padding = 1;

            List<Celda> Cavecera = new List<Celda>()
            {
                new Celda { Text = "Id" },
                new Celda { Text = "Nombre" },
                new Celda { Text = "NickName" },
                new Celda { Text = "Factor" },
                new Celda { Text = "Categoria ID/Name" },
            };
            tabla.AddRow(Cavecera);

            foreach (var item in Servidor._inventario.ListaProductos)
            {
                List<Celda> Row = new List<Celda>()
                {
                    new Celda { Text = item.Value.Id.ToString() },
                    new Celda { Text = item.Value.Name.ToString() },
                    new Celda { Text = string.Join(",", item.Value.Nickname) },
                    new Celda { Text = item.Value.Factor.ToString() },
                    new Celda { Text = item.Value.Categoria.ToString()},

                };
                tabla.AddRow(Row);
            }
            Console.WriteLine("\n" + tabla);
        }

        private ViewParameter verificParameter(string parameter)
        {
            switch (parameter)
            {
                case "categorias":
                    return ViewParameter.Categorias;
                case "productos":
                    return ViewParameter.Productos;
                default:
                    return ViewParameter.None;
            }
        }

        
        private enum ViewParameter
        {
            None,
            Categorias,
            Productos,
        }
    }
}
