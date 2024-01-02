using Fac.src.Api;
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
            Categorias = new();
            Productos = new();

            cargarDatos();
        }
        
        private async void cargarDatos()
        {
            var apiCliente = new ApiCliente("http://localhost:8080");
            var productos = await apiCliente.ObtenerProductos();

            Productos.Clear();
            foreach (var item in productos)
            {
                Productos.Add(item);
            }
        }
    }
}
