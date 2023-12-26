using Command;
using Fac.src.Command.CmdConsole;
using Fac.src.Funciones.StyleConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Inform
{
    public class HelpCMD : CommandBase
    {
        public override void Execute(object parameter)
        {
            Ejecutar((string[])parameter);
        }

        private void Ejecutar(string[] parameter)
        {
            StyleConsole2 st = new();
            st.Margin = new(1, 1, 1, 1);
            st.Padding = new(1, 1, 1, 1);

            string msg = string.Empty;
            msg += "-  view [tabla]";

            Console.WriteLine(st.GenerarContenedor(msg, "--- Help ---"));
        }

    }
}
