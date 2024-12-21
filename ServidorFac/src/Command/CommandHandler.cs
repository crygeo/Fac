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
        private List<CommandBase> comandos;
        private readonly Servidor servidor;
        private List<(string, CommandBase)> commandsNick;

        public string NameConsole = "servidor";
        public CommandHandler(Servidor servidor)
        {
            this.servidor = servidor;
            // Inicializar diccionario de comandos
            comandos = new List<CommandBase>();
            commandsNick = new List<(string, CommandBase)>();

            AddComandos();
            
        }

        public void ProcesarComando(string cmd, string[] parametros)
        {
            var matchingCommand = commandsNick.FirstOrDefault(pair => pair.Item1.Equals(cmd, StringComparison.OrdinalIgnoreCase));

            if (matchingCommand != default)
            {
                matchingCommand.Item2.Execute(parametros);
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

        private void AddComandos()
        {
            CommandBase cmdView = new VerCMD(servidor);
            VerificarYAgregar(cmdView);

            CommandBase cmdHelp = new HelpCMD(comandos);
            VerificarYAgregar(cmdHelp);

            CommandBase cmdAgregar = new AddCMD(servidor);
            VerificarYAgregar(cmdAgregar);

        }

        private void VerificarYAgregar(CommandBase command)
        {
            comandos.Add(command);

            foreach (var nick in command.NickName.ToArray())
            {
                var conflictingCommand = commandsNick.FirstOrDefault(c => c.Item1.Equals(nick, StringComparison.OrdinalIgnoreCase));

                if (conflictingCommand != default)
                {
                    // Si el nick ya está registrado, muestra un mensaje de error con información adicional.
                    throw new InvalidOperationException($"Error: El nick '{nick}' ya está registrado para los comandos '{conflictingCommand.Item2.Name}' y '{command.Name}'.");
                }

                commandsNick.Add((nick, command));
            }
        }
    }
}
