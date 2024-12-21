using Fac.src.Api.Interface;
using Fac.src.Dats.Objet.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http.Json;

namespace Fac.src.Api.Model
{
    public class MetodosInventario : IInventarioMetodos
    {

        private readonly HttpClient _httpClient;

        public MetodosInventario(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await ManejarExcepciones(async () => await _httpClient.GetFromJsonAsync<IEnumerable<Producto>>("api/productos")) ?? Array.Empty<Producto>();
        }

        public async Task<IEnumerable<Categoria>> ObtenerCategorias()
        {
            return await ManejarExcepciones(async () => await _httpClient.GetFromJsonAsync<IEnumerable<Categoria>>("api/categorias")) ?? Array.Empty<Categoria>();
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
