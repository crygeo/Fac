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
        private Dictionary<int, Producto> ListaProductos;
        private Dictionary<int, Categoria> ListaCategoria;

        private CategoriaDB _categoriaDB;
        private ProductosDB _productosDB;

        public Inventario()
        {
            _categoriaDB = new(this);
            _productosDB = new(this);


            ListaCategoria = _categoriaDB.GetLista().Result;
            ListaProductos = _productosDB.GetLista().Result;
        }

        public Categoria GetCategoriaID(int id) { return ListaCategoria[id]; }

        public Producto GetProducto(int id) {  return ListaProductos[id]; }
    }
}
