using Command;
using Fac.src.Dats.Objet.Inventario;
using Fac.src.MySql.Inven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command.Inventario
{
    public class AgregarCategoria : CommandBase
    {
        private readonly CategoriaDB CategoriaDB;

        public AgregarCategoria()
        {
            CategoriaDB = new(App.Inventario);
        }

        public override async void Execute(object parameter)
        {
            if (parameter is Categoria categoria)
            {
                categoria.Id = await CategoriaDB.AddCategoriaGetID(categoria);
                App.Inventario.ListaCategoria.Add(categoria.Id, categoria);
            }
        }
    }
}
