using Fac.src.Dats.Objet.Inventario;
using Fac.src.Funciones.Herramientas;
using Fac.src.Servicios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.MySql.Inven
{
    public class ProductosDB
    {

        //Nombre de los Stored Procedures de la base de datos.
        //
        private const string GET_PRODUCTO_ALL = "productos.get.all";
        private const string GET_PRODUCTO_NAME = "productos.get.name";
        private const string ADD_PRODUCTO = "productos.add";
        private const string UPD_PRODUCTO = "productos.upd";
        private const string DEL_PRODUCTO = "productos.del";

        private readonly ConectMysql _conectMysql;
        private readonly Inventario _inventario;

        public ProductosDB(Inventario inv)
        {
            _conectMysql = new();
            this._inventario = inv;

        }

        /// <summary>
        /// Este Metodo otienes un <Dictionary> de todos los productos creados el la base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<int, Producto>> GetLista()
        {
            Dictionary<int, Producto> lista = new();

            using (var cmd = new MySqlCommand(GET_PRODUCTO_ALL))
            {
                using (var result = await _conectMysql.EjecutarComandoObtenerResultados(cmd))
                {
                    while (await result.ReadAsync())
                    {
                        var item = new Producto()
                        {
                            Id = result.GetInt32("ProductoID"),
                            Name = result.GetString("Name"),
                            Nickname = JsonSL.Deserialize(result.GetString("Nickname")),
                            Factor = result.GetInt32("Factor"),
                            Categoria = _inventario.GetCategoriaID(result.GetInt32("CategoriaID"))
                        };

                        lista.Add(item.Id, item);
                    }
                }

            }

            return lista;
        }



        /// <summary>
        /// Este Metodo otienes un objeto tipo producto creada el la base de datos.
        /// Si la tabla tiene mas de un elemento con el mismo nombre, devolvera el primer elemento con el id mas bajo.
        /// </summary>
        /// <param name="name">Nombre del producto a buscar.</param>
        /// <returns></returns>
        public async Task<Producto> GetProductoForName(string name)
        {
            Producto obj = new();

            using (var cmd = new MySqlCommand(GET_PRODUCTO_NAME))
            {
                //Aqui agrega los parametros al commando.
                cmd.Parameters.AddWithValue("name", name);

                //Aqui commando se ejecuta y obtienes el resultado.
                using (var result = await _conectMysql.EjecutarComandoObtenerResultados(cmd))
                {
                    //Puedes hacer uso del resultado.
                    obj.Id = result.GetInt32("ProductoID");
                    obj.Name = result.GetString("Name");
                    obj.Nickname = JsonSL.Deserialize(result.GetString("Nickname"));
                    obj.Factor = result.GetInt32("Factor");
                    obj.Categoria = _inventario.GetCategoriaID(result.GetInt32("CategoriaID"));
                }
            }

            return obj;
        }


        /// <summary>
        /// Agrega un categoria a la base de datos.
        /// </summary>
        /// <param name="producto">Producto a agregar</param>
        /// <returns></returns>
        public async Task AddProducto(Producto producto)
        {
            using (var cmd = new MySqlCommand(ADD_PRODUCTO))
            {
                //Aqui agrega los parametros al commando.
                cmd.Parameters.AddWithValue("name", producto.Name);


                //Aqui commando se ejecuta.
                await _conectMysql.EjecutarComando(cmd);
            }

            return;
        }


        /// <summary>
        /// Elimina el producto de la base de datos.
        /// </summary>
        /// <param name="producto">Nombre del Producto a eliminar.</param>
        /// <returns></returns>
        public async Task DelProducto(Producto producto)
        {
            using (var cmd = new MySqlCommand(DEL_PRODUCTO))
            {
                cmd.Parameters.AddWithValue("productoID", producto.Id);

                await _conectMysql.EjecutarComando(cmd);
            }

        }

        /// <summary>
        /// Elimina un producto de la base de datos por id.
        /// </summary>
        /// <param name="id">Id del producto a eliminar.</param>
        /// <returns></returns>
        public async Task DelProducto(int id)
        {
            await DelProducto(new Producto { Id = id });
        }

        /// <summary>
        /// Edita un Producto de la base de datos.
        /// </summary>
        /// <param name="producto">Producto a editar.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdProducto(Producto producto)
        {
            if (producto.Id <= 0) throw new Exception("Producto sin ID.");
            using (var cmd = new MySqlCommand(UPD_PRODUCTO))
            {
                cmd.Parameters.AddWithValue("productoID", producto.Id);
                cmd.Parameters.AddWithValue("name", producto.Name);

                await _conectMysql.EjecutarComando(cmd);
            }

            return;
        }

    }
}
