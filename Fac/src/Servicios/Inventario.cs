using Fac.src.Dats.Objet.Inventario;
using Fac.src.MySql.Inven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Servicios
{
    public class Inventario
    {
        public Dictionary<int, Producto> ListaProductos {  get; set; }
        public Dictionary<int, Categoria> ListaCategoria { get; set; }

        private CategoriaDB _categoriaDB;
        private ProductosDB _productosDB;

        public Inventario()
        {
            _categoriaDB = new(this);
            _productosDB = new(this);
        }

        public async Task CargarDatosAsync()
        {
            ListaCategoria = await _categoriaDB.GetLista();
            ListaProductos = await _productosDB.GetLista();
        }

        public Categoria GetCategoriaID(int id) { return ListaCategoria[id]; }

        public Producto GetProducto(int id) {  return ListaProductos[id]; }
    }
}
