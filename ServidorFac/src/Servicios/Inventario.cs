using ServidorFac.Objs.Inventario;
using Fac.src.MySql.Inven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Servicios
{
    public class Inventario
    {
        public Dictionary<int, Producto> ListaProductos { get; set; }
        public Dictionary<int, Categoria> ListaCategoria { get; set; }

        private CategoriaDB _categoriaDB;
        private ProductosDB _productosDB;

        private readonly Servidor servidor;


        public Inventario(Servidor sv)
        {
            this.servidor = sv;

            _categoriaDB = new(sv);
            _productosDB = new(sv);

            ListaCategoria = new();
            ListaProductos = new();
        }

        public async Task CargarDatosAsync()
        {
            var getListCategoria = _categoriaDB.GetLista();
            var getListaProductos = _productosDB.GetLista();

            ListaCategoria = await getListCategoria;
            ListaProductos = await getListaProductos;
        }

        public Categoria GetCategoriaID(int id) { return ListaCategoria[id]; }

        public Producto GetProducto(int id) { return ListaProductos[id]; }
    }
}
