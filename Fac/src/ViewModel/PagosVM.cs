using Fac.src.Command;
using Fac.src.Command.Prestamo;
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
        public ICommand CmdPrestamoAdd { get; set; }
        public ICommand CmdPrestamoEdit { get; set; }
        public ICommand CmdPrestamoDelete { get; set; }
        public ICommand CmdPrestamoCobrado { get; set; }
        public ICommand CmdPrestamoImprimir { get; set; }

        public PagosVM()
        {
            Model = new PagosM();

            AddTrabajores = new AgregarPersonal(Trabajadores);

            CmdPrestamoAdd = new CmdPrestamoAdd(Prestamos, Trabajadores);
            CmdPrestamoEdit = new CmdPrestamoEdit();
            CmdPrestamoDelete = new CmdPrestamoDelete(Prestamos);
            CmdPrestamoCobrado = new CmdPrestamoCobrado();
            CmdPrestamoImprimir = new CmdPrestamoImprimir();
        }

        public void GuardarDatos() => Model.GuardarDatos();
    }
}
