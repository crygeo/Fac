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
        private Dictionary<string, CommandBase> comandos;

        public CommandHandler()
        {
            // Inicializar diccionario de comandos
            comandos = new Dictionary<string, CommandBase>
            {
                {"see", new VerListaCMD()},
                {"help", new HelpCMD() }
            };
        }

        public void ProcesarComando(string cmd, string[] parametros = null)
        {
            if (comandos.TryGetValue(cmd, out CommandBase command))
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
