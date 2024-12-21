
using Fac.src.Command.CmdConsole.Comandos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using MySql;
using ServidorFac.Servicios;

namespace ServidorFac
{
    public class Servidor
    {

        public Inventario _inventario { get; private set; }
        public ConectMysql _conectMysql { get; private set; }
        public ModeloJsonMysql modeloJsonMysql { get; private set; }
        public static bool IsOpenHost { get; private set; } = false;
        public CommandHandler CommandHandler { get; private set; }
        public IHubContext<CategoriaHub> HubContext {  get; set; }


        public static Servidor App {  get; private set; }
        public static IWebHost WebHost { get; private set; }


        private const string PATH_CONFIG = "src/MySql/ConfigMysql.json";
        private const string PATH_URL = "http://localhost:8080";

        public Servidor()
        {
            Console.Title = "Servidor de Fac";


            modeloJsonMysql = ModeloJsonMysql.buscarArchivo(PATH_CONFIG);
            _conectMysql = new ConectMysql(this);
            _inventario = new Inventario(this);
            CommandHandler = new CommandHandler(this);

        }



        public static async Task Main(string[] args)
        {
            App = new Servidor();

            await App.iniciarTask();
            
        }

        private async Task StartWebHost()
        {
            // Iniciar el host de Kestrel
            using (WebHost = new WebHostBuilder().UseUrls(PATH_URL).UseKestrel().UseStartup<Startup>().Build())
            {
                IsOpenHost = true;

                HubContext = WebHost.Services.GetRequiredService<IHubContext<CategoriaHub>>();

                await WebHost.RunAsync();
            }
        }

        private async Task CargarDatosInventario()
        {
            await _inventario.CargarDatosAsync();
        }

        private async Task iniciarTask()
        {
            await CargarDatosInventario();

            await Task.WhenAll(
                Task.Run(() => StartWebHost()), // Iniciar el host de Kestrel
                Task.Run(() => CommandHandler.StartConsoleHandling()) // Manejar comandos en la consola
        );
        }

    }

}