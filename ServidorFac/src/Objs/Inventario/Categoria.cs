using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Objs.Inventario
{
    public class Categoria
    {
        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public override string ToString()
        {
            return $"Cod: {Id}, Name: {Name}";
        }
    }
}
