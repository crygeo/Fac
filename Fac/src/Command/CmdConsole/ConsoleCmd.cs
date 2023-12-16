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
                Thread.Sleep(1000);
                Console.WriteLine("Bienvenido a la consola de comandos. Ingresa 'help' para obtener ayuda.");

                while (true)
                {
                    Console.Write("> ");
                    string input = Console.ReadLine();

                    // Procesar el comando
                    Handler.ProcesarComando(input);
                }
            });
        }

    }
}
