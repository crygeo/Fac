using ServidorFac.Objs.Inventario;
using Fac.src.MySql.Inven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using ServidorFac.src.Interface;
using ServidorFac.src.Tablas;
using ServidorFac.src.Interfaces;

namespace ServidorFac.Servicios
{
    public class Inventario
    {
        public Dictionary<Type, IInventarioCrud<IInventarioItem>> Listas { get; set; }

        private IItemsDB _categoriaDB;
        private IItemsDB _productosDB;

        private readonly Servidor servidor;


        public Inventario(Servidor sv)
        {
            this.servidor = sv;

            Listas = new();

            _categoriaDB = new CategoriaDB(sv);
            _productosDB = new ProductosDB(sv);

            Listas = new Dictionary<Type, IInventarioCrud<IInventarioItem>>
            {
                { typeof(Categoria), new ItemsCrud<Categoria>(servidor, _categoriaDB)  },
                { typeof(Producto), new ItemsCrud<Producto>(servidor, _productosDB)  },
            };



        }

        public async Task CargarDatosAsync()
        {
            var getListCategoria = _categoriaDB.GetLista();
            var getListaProductos = _productosDB.GetLista();

            Listas[typeof(Categoria)].ListaItems = await getListCategoria;
            Listas[typeof(Producto)].ListaItems = await getListaProductos;
        }


        public void AddItemForType(Type type, IInventarioItem item)
        {
            Listas[type].AddItem(item);
        }

    }
}
