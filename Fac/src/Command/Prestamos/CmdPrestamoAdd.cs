using Command;
using Fac.src.Dats.Objet;
using Fac.src.UserControls;
using Fac.src.View;
using Fac.src.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fac.src.Command.Prestamo
{
    public class CmdPrestamoAdd : CommandBase
    {
        private readonly ObservableCollection<PrestamosTrabajador> listPrestamos;
        private readonly ObservableCollection<Trabajador> empleados;

        public CmdPrestamoAdd(ObservableCollection<PrestamosTrabajador> listPrestamos, ObservableCollection<Trabajador> empleados)
        {
            this.listPrestamos = listPrestamos;
            this.empleados = empleados;
        }

        public override void Execute(object parameter)
        {
            AgregarAdalantoView view;


            view = new AgregarAdalantoView
            {
                Title = "Agregar Personal",
                Prestamo = new PrestamosTrabajador(new Trabajador()),
                EditableTrabajador = true,
                ListaEmpleados = empleados,
            };

            view.Confirm += View_Confirm;

            view.ShowDialog();
        }

        private void View_Confirm(object? sender, EventArgs e)
        {
            if(sender is PrestamosTrabajador prestamo)
            {
                listPrestamos.Add(prestamo);
            }
        }
    }

}

