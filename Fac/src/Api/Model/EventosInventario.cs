using Fac.src.Api.Interface;
using Fac.src.Dats.Objet.Inventario;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Api.model
{
    public class EventosInventario : IInventarioEvento
    {


        public ObservableCollection<Categoria> Categorias { get; set; }
        public ObservableCollection<Producto> Productos { get; set; }

        public event Action<Categoria> NuevaCategoriaAgregada;
        public event Action<Producto> NuevoProductoAgregado;

        private HubConnection _hub;

        public EventosInventario(HubConnection hub)
        {
            this._hub = hub;

            Categorias = new ObservableCollection<Categoria>();
            Productos = new ObservableCollection<Producto>();

            InicializarEventos();
        }

        private void InicializarEventos()
        {
            _hub.On<Categoria>("NuevaCategoria", categoria =>
            {
                // Manejar el evento en el cliente
                OnNuevaCategoriaAgregada(categoria);
            });

            _hub.On<Producto>("NuevoProducto", producto =>
            {
                // Manejar el evento en el cliente
                OnNuevoProductoAgregado(producto);
            });
        }


        protected virtual void OnNuevaCategoriaAgregada(Categoria categoria)
        {
            NuevaCategoriaAgregada?.Invoke(categoria);
        }

        protected virtual void OnNuevoProductoAgregado(Producto producto)
        {
            NuevoProductoAgregado?.Invoke(producto);
        }
    }
}
