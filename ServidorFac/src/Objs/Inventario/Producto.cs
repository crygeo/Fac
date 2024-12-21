using ServidorFac.src.Funciones.StyleConsole;
using ServidorFac.src.Interface;
using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Objs.Inventario
{
    public class Producto : IInventarioItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Nick? Nickname { get; set; }
        public Categoria? Categoria { get; set; }


        private void SaveCate(Categoria a)
        {

        }
        public int Factor { get; set; }
        public Type Type { get; set; } = typeof(Producto);

        public Producto() { }
        public Producto(bool soli)
        {
            if (soli)
            {
                string msg = string.Empty;
                msg += "    §CInsert:";
                PrintConsole.Line(msg);

                Name = PrintConsole.SolicitarDatos("§RName");
                Name = PrintConsole.SolicitarDatos("§RName");
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name},NickName: {Nickname}, Categoria: {Categoria}, Factor: {Factor}";
        }

    }
}
