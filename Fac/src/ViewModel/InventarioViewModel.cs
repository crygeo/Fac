using Fac.src.Command.Inventario;
using Fac.src.Dats.Objet.Inventario;
using Fac.src.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fac.src.ViewModel
{
    public class InventarioViewModel
    {
        private readonly InventarioModel _inventario;

        public ICommand AgregarCategoria { get; set; }
        public ICommand EditarCategoria { get; set; }
        public ICommand EliminarCategoria { get; set; }
        public ICommand AgregarProducto{ get; set; }
        public ICommand EditarProducto{ get; set; }
        public ICommand EliminarProducto { get; set; }

        public ObservableCollection<Producto> Productos { get { return _inventario.Productos; } }
        public ObservableCollection<Categoria> Categorias { get { return _inventario.Categorias; } }

        public InventarioViewModel()
        {
            _inventario = new InventarioModel();

            AgregarCategoria = new AgregarCategoria();
        }
    }
}
