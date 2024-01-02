using Command;
using Fac.src.Command.Inventario;
using ServidorFac;
using ServidorFac.src.Command.Elements;
using ServidorFac.src.Command.Inform;
using ServidorFac.src.Funciones.StyleConsole;
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
        public string NameConsole = "servidor";
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

        public async Task StartConsoleHandling()
        {
            while(!Servidor.IsOpenHost)
            {
                await Task.Delay(1000);
            }

            PrintConsole.Line(" \n\n\n\t\t§CBienvenido a la consola de comandos. Ingresa '§Rhelp§C' para obtener ayuda.\n\n");
            while (true)
            {
                PrintConsole.Line($" \n\n[§B{NameConsole}§W]: §M>> ");

                string t = PrintConsole.ReadLine('R');

                if (t == null) break;

                string[] input = t.ToLower().Split(" ");

                string cmd = input[0];
                string[] parametros = input.Skip(1).ToArray();

                // Procesar el comando
                ProcesarComando(cmd, parametros);
            }

        }
    }
}
