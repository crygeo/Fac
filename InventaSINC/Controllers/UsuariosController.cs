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
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _usuarioRepositorio.Collection.Find(_ => true).ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id:length(24)}", Name = "GetUsuarioById")]
        public async Task<ActionResult<Usuario>> GetById(string id)
        {
            var usuario = await _usuarioRepositorio.Collection.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create(Usuario usuario)
        {
            usuario.Id = "";
            await _usuarioRepositorio.Collection.InsertOneAsync(usuario);
            return CreatedAtRoute("GetUsuarioById", new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Usuario usuarioIn)
        {
            var result = await _usuarioRepositorio.Collection.ReplaceOneAsync(u => u.Id == id, usuarioIn);
            if (result.MatchedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _usuarioRepositorio.Collection.DeleteOneAsync(u => u.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
