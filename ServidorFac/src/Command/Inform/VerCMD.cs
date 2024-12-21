using Command;
using Fac.src.Command.CmdConsole;
using Fac.src.Funciones.StyleConsole;
using Fac.src.Funciones.StyleConsole.Extras;
using ServidorFac.Objs.Inventario;
using ServidorFac.src.Funciones.StyleConsole;
using ServidorFac.src.Objs;
using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Command.Inform
{
    public class VerCMD : CommandBase
    {
        private readonly Servidor _servidor;

        public override List<CommandBase> SubCommandos {  get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override Nick NickName { get; set; }
        public override string Help { get; set; }

        public VerCMD(Servidor servidor)
        {
            this._servidor = servidor;

            Name = "Ver";
            Description = "Comando para ver toda la tablas de la base de datos.";
            NickName = new Nick(["view", "ver", "v", "vw", "vr"]);
            Help = "Uso:\n    ver\n    ver §Chelp§W\n    ver §Ctablas§W\n    ver [§CName Table§W]";

            #region SubComandos
            SubCommandos = [
                new SubCommand { Name = "help", Value = "help", Accion = printHelpView },
                new SubCommand { Name = "tablas", Value = "tablas", Accion = printTablesView },
            ];
            foreach (var item in servidor._inventario.Listas.Keys)
            {
                var newPar = new SubCommand
                {
                    Name = Pluralizador.SingularAPlural(item.Name.Split('.').Last()),
                    Value = item,
                    Accion = (() =>
                    {
                        printViewTable(item);
                    })
                };

                SubCommandos.Add(newPar);
            }
            #endregion


        }

        public override void Execute(object? parameter)
        {
            if (parameter is string[] args)
            {

                if (args.Length <= 0)
                {
                    SubCommandos[0].Execute(null);
                    return;
                }

                var param = buscarSubComandos(args[0]);

                if (param != null)
                {
                    param.Execute(null);
                    return;

                }

            }

            SubCommandos[0].Execute(null);
        }

        private void printHelpView()
        {
            StyleConsole2 cl = new StyleConsole2();
            cl.Padding = new Puntos(1, 1, 1, 1);
            cl.Margin = new Puntos(1, 1, 1, 1);

            string msg = string.Empty;
            msg += "\n";
            msg += Description;
            msg += "\n" + Help;

            msg = cl.GenerarContenedor(msg, $"§R{Name.ToLower()} {SubCommandos[0].Name}§W");
            PrintConsole.Line(" " + msg);
        }

        private void printTablesView()
        {
            StyleConsole2 cl = new StyleConsole2();
            cl.Padding = new Puntos(1, 1, 1, 1);
            cl.Margin = new Puntos(1, 1, 1, 1);

            string msg = string.Empty;
            foreach (var item in _servidor._inventario.Listas)
            {
                msg += $"  • §C{Pluralizador.SingularAPlural(item.Key.Name.Split('.').Last())}§W\n";
            }

            msg = cl.GenerarContenedor(msg, $"§R{SubCommandos[1].Name}§W");
            PrintConsole.Line(" " + msg);
        }

        private void printViewTable(Type table)
        {
            var lista = _servidor._inventario.Listas[table].ListaItems;

            Tabla tabla = new Tabla();
            tabla.Padding = 1;

            List<Celda> Cavecera = new List<Celda>();

            var propiedades = table.GetProperties();
            foreach (var prop in propiedades)
            {
                if (prop.PropertyType == typeof(Type)) break;
                Cavecera.Add(new Celda() { Text = prop.Name });
            }

            tabla.AddRow(Cavecera);

            foreach (var item in lista)
            {
                List<Celda> row = new List<Celda>();

                foreach (var prop in propiedades)
                {
                    if (prop.PropertyType == typeof(Type)) break;
                    object valorPropiedad = prop.GetValue(item);

                    string? textoCelda = (valorPropiedad != null) ? valorPropiedad.ToString() : string.Empty;
                    row.Add(new Celda() { Text = textoCelda ?? "" });
                }
                tabla.AddRow(row);
            }


            Console.WriteLine("\n" + tabla);
        }


    }
}
