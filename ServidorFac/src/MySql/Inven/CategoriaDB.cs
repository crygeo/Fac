﻿using MySql;
using MySql.Data.MySqlClient;
using ServidorFac;
using ServidorFac.Objs.Inventario;
using ServidorFac.Servicios;
using ServidorFac.src.Interface;
using ServidorFac.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.MySql.Inven
{
    public class CategoriaDB : IItemsDB
    {
        //Nombre de los Stored Procedures de la base de datos.
        private const string GET_CATEGORIA_ALL = "categoria.get.all";
        private const string GET_CATEGORIA_NAME = "categoria.get.name";
        private const string ADD_CATEGORIA = "call fac.`categoria.add`(@name, @result);";
        private const string ADD_CATEGORIA_GET_ID = "categoria.add.get.id";
        private const string UPD_CATEGORIA = "categoria.upd";
        private const string DEL_CATEGORIA = "categoria.del";

        //Obtengo una connecion a la base de datos.
        public readonly Servidor servidor;


        public CategoriaDB(Servidor servidor)
        {
            this.servidor = servidor;
        }

        /// <summary>
        /// Este Metodo otienes un <Dictionary> de todas las categorias creadas el la base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task<List<IInventarioItem>> GetLista()
        {
            List<IInventarioItem> lista = new();

            using (var sql = servidor._conectMysql.Connection())
            {

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = sql;
                    cmd.CommandText = GET_CATEGORIA_ALL;
                    cmd.CommandType = CommandType.StoredProcedure;

                    await sql.OpenAsync();
                    using (var result = await cmd.ExecuteReaderAsync())
                    {

                        while (await result.ReadAsync())
                        {
                            var item = new Categoria()
                            {
                                Id = result.GetInt32("CategoriaID"),
                                Name = result.GetString("Name"),
                            };

                            lista.Add(item);
                        }

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

            using (var sql = servidor._conectMysql.Connection())
            {

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = sql;
                    cmd.CommandText = GET_CATEGORIA_NAME;
                    cmd.CommandType = CommandType.StoredProcedure;

                    await sql.OpenAsync();
                    using (var result = await cmd.ExecuteReaderAsync())
                    {
                        obj.Id = result.GetInt32("CategoriaID");
                        obj.Name = result.GetString("Name");

                    }

                }
            }


            return obj;
        }


        /// <summary>
        /// Agrega un categoria a la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a agregar</param>
        /// <returns></returns>
        public async Task<int> AddCategoriaGetID(Categoria categoria)
        {
            using (var sql = servidor._conectMysql.Connection())
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = sql;
                    cmd.CommandText = ADD_CATEGORIA_GET_ID;
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Aqui agrega los parametros al commando.
                    cmd.Parameters.AddWithValue("@name", categoria.Name);

                    var resultParameter = new MySqlParameter("@result", MySqlDbType.Int32);
                    resultParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParameter);



                    await sql.OpenAsync();
                    //Aqui commando se ejecuta.
                    await cmd.ExecuteNonQueryAsync();

                    return (int)resultParameter.Value;
                }

            }

        }

        /// <summary>
        /// Agrega un categoria a la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a agregar</param>
        /// <returns></returns>
        public async Task<int> AddItem(IInventarioItem elem)
        {
            if (elem is Categoria categoria)
            {

                using (var sql = servidor._conectMysql.Connection())
                {
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandText = ADD_CATEGORIA_GET_ID;
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Aqui agrega los parametros al commando.
                        cmd.Parameters.AddWithValue("@name", categoria.Name);

                        var resultParameter = new MySqlParameter("@result", MySqlDbType.Int32);
                        resultParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(resultParameter);



                        await sql.OpenAsync();
                        //Aqui commando se ejecuta.
                        await cmd.ExecuteNonQueryAsync();

                        return (int)resultParameter.Value;
                    }

                }

            }
            return (int)-1;
        }



        /// <summary>
        /// Elimina la categoria de la base de datos.
        /// </summary>
        /// <param name="categoria">Categoria a eliminar.</param>
        /// <returns></returns>
        public async Task<int> DelCategoria(Categoria categoria)
        {
            using (var sql = servidor._conectMysql.Connection())
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = sql;
                    cmd.CommandText = DEL_CATEGORIA;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("categoriaID", categoria.Id);

                    return await cmd.ExecuteNonQueryAsync();
                }
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
            using (var sql = servidor._conectMysql.Connection())
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = sql;
                    cmd.CommandText = UPD_CATEGORIA;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("categoriaID", categoria.Id);
                    cmd.Parameters.AddWithValue("name", categoria.Name);

                    await cmd.ExecuteReaderAsync();
                }
            }

            return;
        }


    }
}

