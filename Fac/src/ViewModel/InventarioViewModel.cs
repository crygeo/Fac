using Fac.src.Command.Inventario;
using Fac.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fac.src.ViewModel
{
    public class InventarioViewModel
    {
        private readonly InventarioModel inventario;

        public ICommand AgregarCategoria { get; set; }
        public ICommand EditarCategoria { get; set; }
        public ICommand EliminarCategoria { get; set; }
        public ICommand AgregarProducto{ get; set; }
        public ICommand EditarProducto{ get; set; }
        public ICommand EliminarProducto { get; set; }

        public InventarioViewModel()
        {
            AgregarCategoria = new AgregarCategoria();
        }
    }
}
