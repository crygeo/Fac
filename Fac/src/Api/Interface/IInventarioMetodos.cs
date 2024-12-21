using Fac.src.Dats.Objet.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Api.Interface
{
    internal interface IInventarioMetodos
    {
        Task<IEnumerable<Producto>> ObtenerProductos();
        Task<IEnumerable<Categoria>> ObtenerCategorias();
    }
}
