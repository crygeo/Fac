using Microsoft.AspNetCore.Mvc;
using ServidorFac;
using ServidorFac.Objs.Inventario;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{

    public ProductosController()
    {
    }

    [HttpGet]
    public ActionResult<IEnumerable<Producto>> Get()
    {
        return Ok(Servidor.App._inventario.ListaProductos.Values);
    }

    // Otros métodos HTTP para realizar operaciones CRUD
}
