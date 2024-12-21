using Fac.src.Api.model;
using Fac.src.Api.Model;
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

        public MetodosInventario InventarioMetodos { get; set; }
        public EventosInventario EventosInventario { get; set; }

        public ApiCliente(string baseUri)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };

            _hubConnection = new HubConnectionBuilder()
            .WithUrl($"{baseUri}/categoriaHub")
            .Build();

            ConectarAlHub();

            InventarioMetodos = new MetodosInventario(_httpClient);
            EventosInventario = new EventosInventario(_hubConnection);
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

        
    }
}
