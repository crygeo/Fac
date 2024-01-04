using Microsoft.AspNetCore.SignalR;
using ServidorFac.Objs.Inventario;
using System.Threading.Tasks;

public class CategoriaHub : Hub
{
    public async Task EnviarNuevaCategoria(Categoria categoria)
    {
        await Clients.All.SendAsync("NuevaCategoria", categoria);
    }
}


