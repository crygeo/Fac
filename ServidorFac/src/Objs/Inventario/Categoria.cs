using Fac.src.MySql.Inven;
using ServidorFac.src.Funciones.StyleConsole;
using ServidorFac.src.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Objs.Inventario
{
    public class Categoria : IInventarioItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Type Type { get; set; } = typeof(Categoria);

        public override string ToString()
        {
            return $"Cod: {Id}, Name: {Name}";
        }

        public Categoria() {}

        public Categoria(bool soli)
        {
            if (soli)
            {
                string msg = string.Empty;
                msg += "    §CInsert:";
                PrintConsole.Line(msg);

                Name = PrintConsole.SolicitarDatos("§RName");
            }
        }
    }
}
