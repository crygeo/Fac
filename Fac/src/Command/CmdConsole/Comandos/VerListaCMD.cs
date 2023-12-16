using Command;
using Fac.src.Funciones.StyleConsole;
using Fac.src.Funciones.StyleConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command.CmdConsole.Comandos
{
    public class VerListaCMD : CommandBase
    {

        public override void Execute(object parameter)
        {
            Tabla tabla = new Tabla();
            List<Celda> Cavecera = new List<Celda>()
            {
                new Celda { Text = "Id" },
                new Celda { Text = "Nombre" },
            };
            tabla.AddRow(Cavecera);

            foreach (var item in App.Inventario.ListaCategoria)
            {
                List<Celda> Row = new List<Celda>()
                {
                    new Celda { Text = item.Value.Id.ToString() },
                    new Celda { Text = item.Value.Name.ToString() },
                };
                tabla.AddRow(Row);
            }
        }
    }
}
