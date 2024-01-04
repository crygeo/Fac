using Fac.src.Dats.Objet.Inventario;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fac.src.Api
{
    public class ApiCliente
    {
        private readonly HttpClient _httpClient;
        private HubConnection _hubConnection;

        public ApiCliente(string baseUri)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };

            _hubConnection = new HubConnectionBuilder()
            .WithUrl($"{baseUri}/categoriaHub")  // Asegúrate de usar la URL correcta para tu hub
            .Build();

            InicializarEventos();
            ConectarAlHub();
        }

        public event Action<Categoria> NuevaCategoriaAgregada;
        public event Action<Producto> NuevoProductoAgregado;

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await ManejarExcepciones(async () => await _httpClient.GetFromJsonAsync<IEnumerable<Producto>>("api/productos")) ?? Array.Empty<Producto>();
        }

        public async Task<IEnumerable<Categoria>> ObtenerCategorias()
        {
            return await ManejarExcepciones(async () => await _httpClient.GetFromJsonAsync<IEnumerable<Categoria>>("api/categorias")) ?? Array.Empty<Categoria>();
        }

        private void InicializarEventos()
        {
            _hubConnection.On<Categoria>("NuevaCategoria", categoria =>
            {
                // Manejar el evento en el cliente
                Console.WriteLine("Nueva categoria");
                NuevaCategoriaAgregada?.Invoke(categoria);
            });

            _hubConnection.On<Producto>("NuevoProducto", producto =>
            {
                // Manejar el evento en el cliente
                NuevoProductoAgregado?.Invoke(producto);
            });
        }

        private async void ConectarAlHub()
        {
            try
            {
                await _hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                // Manejar la excepción al conectar al hub (puedes mostrar un mensaje o realizar otras acciones)
                Console.WriteLine($"Error al conectar al hub: {ex.Message}");
            }
        }

        private async Task<T> ManejarExcepciones<T>(Func<Task<T>> funcion)
        {
            try
            {
                return await funcion();
            }
            catch (HttpRequestException ex)
            {
                string msg = string.Empty;

                if (ex.InnerException is not null && ex.InnerException is WebException webException)
                {
                    if (webException.Status == WebExceptionStatus.ConnectFailure)
                    {
                        msg += "No se pudo conectar al servidor. Asegúrate de que el servidor esté en ejecución.";
                        // Puedes realizar otras acciones según tus necesidades
                    }
                    else
                    {
                        msg += $"Error en la solicitud: {ex.Message}";
                    }
                }
                else
                {
                    msg += $"Error en la solicitud: {ex.Message}";
                }

                MessageBox.Show(msg, "Alert");
                // Puedes devolver un valor predeterminado o lanzar nuevamente la excepción si deseas que el error se propague
                return default;
            }
        }
    }
}
