using Microsoft.AspNetCore.Mvc;
using ServidorFac;
using ServidorFac.Objs.Inventario;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{

    public CategoriasController()
    {
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        return Ok(Servidor.App._inventario.Listas[typeof(Categoria)].ListaItems);
    }

    // Otros métodos HTTP para realizar operaciones CRUD
}
