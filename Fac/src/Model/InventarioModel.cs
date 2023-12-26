using Fac.src.Dats.Objet.Inventario;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Model
{
    public class InventarioModel
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public ObservableCollection<Producto> Productos { get; set; }

        public InventarioModel() 
        {
            Categorias = new (App.Inventario.ListaCategoria.Values.ToList());
            Productos = new (App.Inventario.ListaProductos.Values.ToList());
        }
        
    }
}
