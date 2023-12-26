using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Objs.Inventario
{
    public class Producto
    {
        private int _id;
        private string _name;
        private string[] _nickname;
        private Categoria _categoria;
        private int _factor;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string[] Nickname { get => _nickname; set => _nickname = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
        public int Factor { get => _factor; set => _factor = value; }

        public override string ToString()
        {
            return $"Cod: {Id}, Name: {Name}";
        }
    }
}
