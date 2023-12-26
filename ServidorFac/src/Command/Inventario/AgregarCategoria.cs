using Command;
using Fac.src.MySql.Inven;
using ServidorFac;
using ServidorFac.Objs.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command.Inventario
{
    public class AgregarCategoria : CommandBase
    {
        private readonly Servidor servidor;

        public AgregarCategoria(Servidor servidor)
        {
            this.servidor = servidor;
        }

        public override async void Execute(object parameter)
        {
            if (parameter is Categoria categoria)
            {
                categoria.Id = await new CategoriaDB(servidor).AddCategoriaGetID(categoria);
                servidor._inventario.ListaCategoria.Add(categoria.Id, categoria);
            }
        }
    }
}
