using Fac.src.Command.CmdConsole.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fac.src.Command.CmdConsole
{
    public class ConsoleCmd
    {
        public CommandHandler Handler;
        public ConsoleCmd()
        {
            Handler = new CommandHandler();

            Task.Run(() =>
            {
                Console.WriteLine("Bienvenido a la consola de comandos. Ingresa 'help' para obtener ayuda.");

                while (true)
                {
                    Console.Write("\n[servidor]: >> ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string [] input = Console.ReadLine().ToLower().Split(" ");
                    Console.ForegroundColor = ConsoleColor.White;

                    string cmd = input[0];
                    string[] parametros = input.Skip(1).ToArray(); 

                    // Procesar el comando
                    Handler.ProcesarComando(cmd, parametros);
                }
            });
        }

    }
}
