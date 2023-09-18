using Fac.src.Command;
using Fac.src.Dats.Objet;
using Fac.src.Interface;
using Fac.src.Model;
using Fac.src.WindowStrategies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fac.src.ViewModel
{
    public class PagosVM : ViewModelBase
    {
        private readonly PagosM Model;

        public ObservableCollection<PrestamosTrabajador> Prestamos { get => Model.ObtenerPrestamosTrabajadores(); }
        public ObservableCollection<Trabajador> Trabajadores { get => Model.ObtenerTrabajadores(); }
        public ICommand AddTrabajores { get; set; }

        public PagosVM()
        {
            Model = new PagosM();

            AddTrabajores = new AgregarPersonal(Trabajadores);
        }

        public void GuardarDatos() => Model.GuardarDatos();
    }
}
