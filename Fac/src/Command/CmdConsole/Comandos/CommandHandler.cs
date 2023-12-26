using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command.CmdConsole.Comandos
{
    public class CommandHandler
    {
        private Dictionary<string, CommandBaseC> comandos;

        public CommandHandler()
        {
            // Inicializar diccionario de comandos
            comandos = new Dictionary<string, CommandBaseC>
            {
                {"view", new VerListaCMD()},
                {"help", new HelpCMD() }
            };
        }

        public void ProcesarComando(string cmd, string[] parametros = null)
        {
            if (comandos.TryGetValue(cmd, out CommandBaseC command))
            {
                command.Execute(parametros);
            }
            else
            {
                Console.WriteLine("Comando no reconocido. Ingresa 'help' para obtener ayuda.");

            }
        }
    }
}
