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
    public class CategoriaDB
    {
        //Nombre de los Stored Procedures de la base de datos.
        private const string GET_CATEGORIA_ALL = "categoria.get.all";
        private const string GET_CATEGORIA_NAME = "categoria.get.name";
        private const string ADD_CATEGORIA = "categoria.add";
        private const string UPD_CATEGORIA = "categoria.upd";
        private const string DEL_CATEGORIA = "categoria.del";

        //Obtengo una connecion a la base de datos.
        private readonly ConectMysql _conectMysql;
        private readonly Inventario _inventario;

        public CategoriaDB(Inventario inv)
        {
            _conectMysql = new();
            this._inventario = inv;
        }

        /// <summary>
        /// Este Metodo otienes un <Dictionary> de todas las categorias creadas el la base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<int, Categoria>> GetLista()
        {
            Dictionary<int, Categoria> lista = new();

            using (var cmd = new MySqlCommand(GET_CATEGORIA_ALL))
            {
                using (var result = await _conectMysql.EjecutarComandoObtenerResultados(cmd))
                {
                    while (await result.ReadAsync())
                    {
                        var item = new Categoria()
                        {
                            Id = result.GetInt32("CategoriaID"),
                            Name = result.GetString("Name"),
                        };

                        lista.Add(item.Id, item);
                    }


                }
            }

            return lista;
        }

        /// <summary>
        /// Este Metodo otienes un objeto tipo categoria creada el la base de datos.
        /// Si la tabla tiene mas de un elemento con el mismo nombre, devolvera el primer elemento con el id mas bajo.
        /// </summary>
        /// <param name="name">Nombre de la categoria a buscar.</param>
        /// <returns></returns>
        public async Task<Categoria> GetCategoriaForName(string name)
        {
            Categoria obj = new();

            using (var cmd = new MySqlCommand(GET_CATEGORIA_NAME))
            {
                //Aqui agrega los parametros al commando.
                cmd.Parameters.AddWithValue("name", name);

                //Aqui commando se ejecuta y obtienes el resultado.
                using (var result = await _conectMysql.EjecutarComandoObtenerResultados(cmd))
                {
                    //Puedes hacer uso del resultado.
                    obj.Id = result.GetInt32("CategoriaID");
                    obj.Name = result.GetString("Name");
                }
            }

            return obj;
        }


        /// <summary>
        /// Agrega un categoria a la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a agregar</param>
        /// <returns></returns>
        public async Task AddCategoria(Categoria categoria)
        {
            using (var cmd = new MySqlCommand(ADD_CATEGORIA))
            {
                //Aqui agrega los parametros al commando.
                cmd.Parameters.AddWithValue("name", categoria.Name);

                //Aqui commando se ejecuta.
                await _conectMysql.EjecutarComando(cmd);
            }

            return;
        }


        /// <summary>
        /// Elimina la categoria de la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a eliminar.</param>
        /// <returns></returns>
        public async Task DelCategoria(Categoria categoria)
        {
            using (var cmd = new MySqlCommand(DEL_CATEGORIA))
            {
                cmd.Parameters.AddWithValue("categoriaID", categoria.Id);

                await _conectMysql.EjecutarComando(cmd);
            }

        }

        /// <summary>
        /// Elimina la categoria de la base de datos por id.
        /// </summary>
        /// <param name="id">Id de la categoria a eliminar.</param>
        /// <returns></returns>
        public async Task DelCategoria(int id)
        {
            await DelCategoria(new Categoria { Id = id });
        }

        /// <summary>
        /// Edita una categoria de la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a editar.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdCategoria(Categoria categoria)
        {
            if (categoria.Id <= 0) throw new Exception("Categoria sin ID.");
            using (var cmd = new MySqlCommand(UPD_CATEGORIA))
            {
                cmd.Parameters.AddWithValue("categoriaID", categoria.Id);
                cmd.Parameters.AddWithValue("name", categoria.Name);

                await _conectMysql.EjecutarComando(cmd);
            }

            return;
        }
    }
}

