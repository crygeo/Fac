using Fac.src.Dats.Objet.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Api.Interface
{
    internal interface IInventarioEvento
    {
        event Action<Categoria> NuevaCategoriaAgregada;
        event Action<Producto> NuevoProductoAgregado;
    }
}
