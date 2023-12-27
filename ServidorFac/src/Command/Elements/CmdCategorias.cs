using Command;
using Fac.src.MySql.Inven;
using ServidorFac.Objs.Inventario;
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

        private async void AddCategoria()
        {
            Categoria cat = solicitarCategoria();
            if (cat == null) { Console.WriteLine("\n\n Error catogoria vacia \n\n"); return; }

            await new CategoriaDB(servidor).AddCategoria(cat);

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
