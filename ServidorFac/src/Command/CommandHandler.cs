using Command;
using Fac.src.Command.Inventario;
using ServidorFac;
using ServidorFac.src.Command.Elements;
using ServidorFac.src.Command.Inform;
using ServidorFac.src.Inform;
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
        private readonly Servidor servidor;
        public CommandHandler(Servidor servidor)
        {
            this.servidor = servidor;
            // Inicializar diccionario de comandos
            comandos = new Dictionary<string, CommandBase>
            {
                {"view", new VerListaCMD(servidor)},
                {"help", new HelpCMD() },
                {"add", new AddCMD(servidor) }
            };
        }

        public void ProcesarComando(string cmd, string[] parametros)
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
