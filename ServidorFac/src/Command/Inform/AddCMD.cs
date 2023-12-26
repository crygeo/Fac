using Command;
using Fac.src.Funciones.StyleConsole;
using ServidorFac.src.Command.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Command.Inform
{
    public class AddCMD : CommandBase
    {
        private readonly Servidor servidor;

        public AddCMD(Servidor servidor)
        {
            this.servidor = servidor;
        }

        public override void Execute(object parameter)
        {
            if (parameter is string[] cmd && cmd.Length > 0)
            {
                if (cmd[0] == "categoria") new CmdCategorias(servidor).Execute(Crud.add);
            }
            else
            {
                StyleConsole2 st = new();
                st.Margin = new(1, 1, 1, 1);
                st.Padding = new(1, 1, 1, 1);

                string msg = string.Empty;
                msg += "-  add [tabla]\n\n";
                msg += "-------- Tablas --------\n";
                msg += "-  * Categoria \n";
                msg += "-  * Productos \n";

                Console.WriteLine(st.GenerarContenedor(msg, "--- add ---"));
            }
            
        }
    }

    public enum TiposAdd
    {
        Categoria,
        Producto
    }
}
