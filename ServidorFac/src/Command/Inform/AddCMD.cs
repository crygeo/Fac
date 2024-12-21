using Command;
using Fac.src.Funciones.StyleConsole;
using Fac.src.Funciones.StyleConsole.Extras;
using MySqlX.XDevAPI.Relational;
using ServidorFac.Objs.Inventario;
using ServidorFac.src.Command.Elements;
using ServidorFac.src.Funciones.StyleConsole;
using ServidorFac.src.Interface;
using ServidorFac.src.Objs;
using ServidorFac.src.Objs.Otros;
using ServidorFac.src.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Command.Inform
{
    public class AddCMD : CommandBase
    {
        private readonly Servidor servidor;

        public override string Name { get; set; }
        public override string Description { get; set; }
        public override Nick NickName { get; set; }
        public override string Help { get; set; }
        public override List<CommandBase> SubCommandos { get; set; }

        public AddCMD(Servidor servidor)
        {
            this.servidor = servidor;

            Name = "Agregar";
            Description = "Comando usando para agregar un dato a una tabla.";
            NickName = new Nick(["add", "agregar", "insertar"]);
            Help = "Uso:\n    add [§CName Table§W]\n    Para saber la tablas disponibles usa §Rview tablas§W";

            SubCommandos = new List<CommandBase>
            {
                new SubCommand { Name = "help", Value = "help", Accion = printHelpView },
            };

            foreach (var table in servidor._inventario.Listas.Keys)
            {
                var newPar = new SubCommand
                {
                    Name = Pluralizador.SingularAPlural(table.Name.Split('.').Last()),
                    Value = table,
                    Accion = (() =>
                    {
                        addElemento(table);
                    })
                };

                SubCommandos.Add(newPar);
            }
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

        private void addElemento(Type table)
        {
            var lista = servidor._inventario.Listas[table];

            var constructor = table.GetConstructor(new Type[] {typeof(bool)});

            if (constructor != null)
            {
                var nuevoElemento = constructor.Invoke(new object[] {true});
                if (nuevoElemento is IInventarioItem) lista.AddItem((IInventarioItem)nuevoElemento);
            }

        }


    }


}
