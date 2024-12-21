using Command;
using Fac.src.Funciones.StyleConsole;
using Fac.src.MySql.Inven;
using Microsoft.AspNetCore.SignalR;
using ServidorFac.Objs.Inventario;
using ServidorFac.src.Funciones.StyleConsole;
using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ServidorFac.src.Command.Elements
{
    public class CmdCategorias : CommandBase
    {
        private readonly Servidor servidor;

        public override string Name { get; set; }
        public override string Description { get; set; }
        public override Nick NickName { get; set; }
        public override string Help { get; set; }
        public override List<CommandBase> SubCommandos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CmdCategorias(Servidor servidor)
        {
            this.servidor = servidor;

            Name = "Ver";
            Description = "Comando para ver toda la tablas de la base de datos.";
            NickName = Nick.Parse(new string[] { "vt" });
            Help = "Uso: ver, ver [Name Table]";
        }
        public override void Execute(object? parameter)
        {
            //if (parameter is Crud cmdText)
            //{
            //    if (cmdText == Crud.add) AddCategoria();
            //}
        }

        /*private async void AddCategoria()
        {
            Categoria cat = solicitarCategoria();

            if (cat == null) { Console.WriteLine("\n\n Error catogoria vacia \n\n"); return; }

            var result = await new CategoriaDB(servidor).AddCategoriaGetID(cat);

            if (result == -1)
            {
                PrintConsole.Line("\n\t§RError: §MLa categoria no se puede ingresar por que ya existe.\n");
            }

            if (result > 0)
            {
                PrintConsole.Line("\n\t§GInforme: §MLa categoria se a ingresado con exito.\n");

                cat.Id = result;

                //servidor._inventario.ListaCategoria.Add(result, cat);
                await servidor.HubContext.Clients.All.SendAsync("NuevaCategoria", cat);
            }


        }

        private void DelCategoria()
        {
            int id = solicitarId();
            if (id <= 0) { PrintConsole.Line("\n\n §RError: §MId debe ser mayor que 0\n\n"); return; }

            var result = new CategoriaDB(servidor).DelCategoria(new Categoria { Id = id });

            if (result.Result == -1)
            {
                PrintConsole.Line($"\n\t§RError: §MNo existe ninguna categoria con id {id}\n");
            }
            if (result.Result == 1)
            {
                PrintConsole.Line("\n\t§GInforme: §MLa categoria elimada con exito.\n");
            }
        }

        

        private int solicitarId()
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            string msg = string.Empty;
            msg += "    Insert:";

            Console.Write(msg);


            string id = solicitarDatos("Id");

            bool isNumer = !int.TryParse(id, out int result);

            while (id == string.Empty || id == null || isNumer)
            {
                var temps = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tId is null, reinter.");
                Console.ForegroundColor = temps;
                id = solicitarDatos("Name");
            }

            Console.ForegroundColor = temp;


            return result;

        }*/

        

    }

    public enum Crud
    {
        add,
        edit,
        delete,
    }
}
