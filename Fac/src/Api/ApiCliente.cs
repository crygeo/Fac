using Fac.src.Dats.Objet.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Api
{
    public class ApiCliente
    {
        private readonly HttpClient _httpClient;

        public ApiCliente(string baseUri)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<Producto>>("api/productos");
                Console.WriteLine(response.Count());
                return response ?? Array.Empty<Producto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");

                if (ex.InnerException is not null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                if (ex.Message is not null)
                {
                    // Imprime o registra detalles de la respuesta
                    Console.WriteLine($"Response: {ex.Message}");
                }

                throw;
            }

        }
    }
}
