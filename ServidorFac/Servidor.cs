
using Fac.src.Command.CmdConsole.Comandos;
using MySql;
using Newtonsoft.Json;
using ServidorFac.Servicios;
using ServidorFac.src.Command;

namespace ServidorFac
{
    public class Servidor
    {
        public Inventario _inventario { get; private set; }
        public ConectMysql _conectMysql { get; private set; }
        public ModeloJsonMysql modeloJsonMysql { get; private set; }

        private const string PATH_CONFIG = "src/MySql/ConfigMysql.json";

        public Servidor()
        {
            modeloJsonMysql = ModeloJsonMysql.buscarArchivo(PATH_CONFIG);
            _conectMysql = new ConectMysql(this);
            _inventario = new Inventario(this);
        }

        

        
        public static void Main()
        {
            var servidor = new Servidor();

            CargarDatosInventario(servidor._inventario);

            Task.Run(() =>
            {
                
                Console.WriteLine("Bienvenido a la consola de comandos. Ingresa 'help' para obtener ayuda.");

                CommandHandler Handler = new(servidor);

                while (true)
                {
                    Console.Write("\n[servidor]: >> ");
                    Console.ForegroundColor = ConsoleColor.Red;

                    string? t = Console.ReadLine();
                    if (t == null) break;
                    string[] input = t.ToLower().Split(" ");
                    Console.ForegroundColor = ConsoleColor.White;

                    string cmd = input[0];
                    string[] parametros = input.Skip(1).ToArray();

                    // Procesar el comando
                    Handler.ProcesarComando(cmd, parametros);
                }
            }).Wait();
        }

        private static async void CargarDatosInventario(Inventario inv)
        {
            await inv.CargarDatosAsync();
        }

    }

}