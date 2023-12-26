using Command;
using ServidorFac.Objs.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Categoria cat = new Categoria();
            cat.Name = solicitarDatos("Name: ");
        }

        private string solicitarDatos(string text)
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            string msg = string.Empty;
            msg += "    Insert:\n";
            msg += $"      └─ {text}";
            
            Console.Write(msg);

            Console.ForegroundColor = ConsoleColor.Red;
            var texts = Console.ReadLine() ?? "";

            Console.ForegroundColor = temp;

            return texts;

        }

    }

    public enum Crud
    {
        add,
        edit,
        delete,
    }
}
