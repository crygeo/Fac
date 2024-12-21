using Microsoft.AspNetCore.Mvc;
using InventaSINC.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventaSINC.Objs;
using MongoDB.Driver;

namespace InventaSINC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : BaseController<Usuario>    
    {

        public UsuariosController(UsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
        }

        
    }
}
