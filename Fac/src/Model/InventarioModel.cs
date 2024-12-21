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

            CargarAllDatos();
            asignarEventos();
        }
        
        public async void CargarAllDatos()
        {
            await CargarProductos();
            await CargarCategorias();
        }

        public async Task CargarProductos()
        {
            var productos = await App.Api.InventarioMetodos.ObtenerProductos();

            recargarDatos<Producto>(Productos, productos);
        }

        public async Task CargarCategorias()
        {
            var categorias = await App.Api.InventarioMetodos.ObtenerCategorias();

            recargarDatos<Categoria>(Categorias, categorias);
           
        }

        private void asignarEventos()
        {
            App.Api.EventosInventario.NuevaCategoriaAgregada += EventosInventario_NuevaCategoriaAgregada;
            App.Api.EventosInventario.NuevoProductoAgregado += EventosInventario_NuevoProductoAgregado;
        }
        public void desasignarEventos()
        {
            App.Api.EventosInventario.NuevaCategoriaAgregada -= EventosInventario_NuevaCategoriaAgregada;
            App.Api.EventosInventario.NuevoProductoAgregado -= EventosInventario_NuevoProductoAgregado;
        }

        private void EventosInventario_NuevoProductoAgregado(Producto obj)
        {
            Console.WriteLine("Producto Agregada.");
        }

        private void EventosInventario_NuevaCategoriaAgregada(Categoria obj)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Categorias.Add(obj);
            });
        }

        private void recargarDatos<T>(ObservableCollection<T> Lista, IEnumerable<T> newList)
        {
            Lista.Clear();

            foreach(var item in newList)
            {
                Lista.Add(item);
            }

        }

    }
}
