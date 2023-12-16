using Command;
using Fac.src.Funciones.StyleConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command.CmdConsole.Comandos
{
    public class HelpCMD : CommandBase
    {
        
        public override void Execute(object parameter)
        {
            StyleConsole2 st = new();
            st.Margin = new(1, 1, 1, 1);
            st.Padding = new(1, 1, 1, 1);
            Console.WriteLine(st.GenerarContenedor("Hola a todos\nEste es segunda linea.", "Comando Ver"));
        }
    }
}
