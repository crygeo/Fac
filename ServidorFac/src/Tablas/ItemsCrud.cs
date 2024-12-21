using Fac.src.MySql.Inven;
using Microsoft.AspNetCore.SignalR;
using ServidorFac.Objs.Inventario;
using ServidorFac.src.Funciones.StyleConsole;
using ServidorFac.src.Interface;
using ServidorFac.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Tablas
{
    public class ItemsCrud<T> : IInventarioCrud<IInventarioItem>
    {
        public List<IInventarioItem> ListaItems { get; set; }

        private IItemsDB itemsDB;
        private readonly Servidor servidor;

        public ItemsCrud(Servidor servidor, IItemsDB ItemsDB)
        {
            this.servidor = servidor;
            this.itemsDB = ItemsDB;


            ListaItems = new List<IInventarioItem>();
        }

        public void AddItem(IInventarioItem items)
        {

            var result = itemsDB.AddItem(items).Result;

            if (result == -1)
            {
                PrintConsole.Line(" \n\n§RError: §MEl elemento no se puede ingresar por que ya existe.\n");
            }

            if (result > 0)
            {
                PrintConsole.Line(" \n\n§GInforme: §MEl elemento se a ingresado con exito.\n");

                items.Id = result;
                ListaItems.Add(items);

                servidor.HubContext.Clients.All.SendAsync("NuevaCategoria", items);
            }

        }

        public void DelItem(IInventarioItem item)
        {
            throw new NotImplementedException();
        }

        public void EditItem(IInventarioItem itemOld, IInventarioItem itemNew)
        {
            throw new NotImplementedException();
        }

        public IInventarioItem? GetItemsID(int id)
        {
            return ListaItems.FirstOrDefault(item => item.Id == id);
        }

        

    }

    //class HerramaientaStatic
    //{
    //    public static T? SolicitarItemConsola<T>() where T : IInventarioItem, new()
    //    {
    //        string msg = "    §CInsert:\n";

    //        // Crear una instancia de la clase T
    //        T item = new T();

    //        // Obtener las propiedades públicas de la clase T
    //        PropertyInfo[] propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

    //        foreach (var propiedad in propiedades)
    //        {
    //            // Verificar si la propiedad pertenece a la clase T y no a la interfaz IInventarioItem
    //            if (propiedad.DeclaringType == typeof(T))
    //            {
    //                // Solicitar datos solo para la propiedad Name de la clase Categoria
    //                if (propiedad.Name == "Name")
    //                {
    //                    string nombrePropiedad = propiedad.Name;
    //                    string valor = PrintConsole.SolicitarDatos($"§R{nombrePropiedad}");

    //                    // Convertir el valor a tipo adecuado
    //                    object valorConvertido = Convert.ChangeType(valor, propiedad.PropertyType);

    //                    // Asignar el valor a la propiedad
    //                    propiedad.SetValue(item, valorConvertido);
    //                }
    //            }
    //        }

    //        return item;
    //    }


    //}
}
