using InventaSINC.Objs;

namespace InventaSINC.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {

        public override string NameCollection { get; set; } = "Usuarios";

        public UsuarioRepositorio() : base()
        {
        }
    }
}
