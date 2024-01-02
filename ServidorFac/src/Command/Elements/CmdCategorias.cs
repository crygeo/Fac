using Command;
using Fac.src.Funciones.StyleConsole;
using Fac.src.MySql.Inven;
using ServidorFac.Objs.Inventario;
using ServidorFac.src.Funciones.StyleConsole;
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
        public CmdCategorias(Servidor servidor)
        {
            this.servidor = servidor;
        }
        public override void Execute(object parameter)
        {
            if (parameter is Crud cmdText)
            {
                if (cmdText == Crud.add) AddCategoria();
            }
        }

        private void AddCategoria()
        {
            Categoria cat = solicitarCategoria();
            if (cat == null) { Console.WriteLine("\n\n Error catogoria vacia \n\n"); return; }

            var result = new CategoriaDB(servidor).AddCategoria(cat);

            if (result.Result == -1)
            {
                PrintConsole.Line("\n\t§RError: §MLa categoria no se puede ingresar por que ya existe.\n");
            }

            if (result.Result == 1)
            {
                PrintConsole.Line("\n\t§GInforme: §MLa categoria se a ingresado con exito.\n");
            }
        }

        private void DelCategoria()
        {
            int id = solicitarId();
            if (id <= 0) { PrintConsole.Line("\n\n §RError: §MId debe ser mayor que 0\n\n"); return; }

            var result = new CategoriaDB(servidor).DelCategoria(new Categoria { Id = id});

            if (result.Result == -1)
            {
                PrintConsole.Line($"\n\t§RError: §MNo existe ninguna categoria con id {id}\n");
            }
            if (result.Result == 1)
            {
                PrintConsole.Line("\n\t§GInforme: §MLa categoria elimada con exito.\n");
            }
        }

        private Categoria solicitarCategoria()
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            string msg = string.Empty;
            msg += "    Insert:";

            Console.Write(msg);


            string name = solicitarDatos("Name");

            while (name == string.Empty || name == null)
            {
                var temps = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tName is null, reinter.");
                Console.ForegroundColor = temps;
                name = solicitarDatos("Name");
            }

            Console.ForegroundColor = temp;


            return new Categoria()
            {
                Name = name
            };

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

        }

        private string solicitarDatos(string nameDato)
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            string msg = string.Empty;
            msg += $"\n        └─ {nameDato} >> ";
            Console.Write(msg);

            Console.ForegroundColor = ConsoleColor.Red;
            var text = Console.ReadLine() ?? "";
            Console.ForegroundColor = temp;

            return text;

        }

    }

    public enum Crud
    {
        add,
        edit,
        delete,
    }
}
