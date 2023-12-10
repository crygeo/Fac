using Command;
using Fac.src.Dats.Objet;
using Fac.src.UserControls;
using Fac.src.View;
using Fac.src.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fac.src.Command.Prestamo
{
    public class CmdPrestamoEdit : CommandBase
    {

        public override void Execute(object parameter)
        {
            if (parameter is PrestamosTrabajador prestamo)
            {

                // Serializar el objeto original a JSON y luego deserializarlo en una nueva instancia
                string originalPrestamo = JsonConvert.SerializeObject(prestamo);
                PrestamosTrabajador? copiaPrestamo = JsonConvert.DeserializeObject<PrestamosTrabajador>(originalPrestamo);

                if (copiaPrestamo == null) return;

                AgregarAdalantoView view;


                view = new AgregarAdalantoView
                {
                    Title = "Editar Prestamo",
                    Prestamo = copiaPrestamo,
                    EditableTrabajador = false,
                    ListaEmpleados = new ObservableCollection<Trabajador> { copiaPrestamo.Trabajador }
                };

                view.Confirm += (sender, e) =>
                {
                    prestamo.Observacion = copiaPrestamo.Observacion;
                    prestamo.SilverPrestado = copiaPrestamo.SilverPrestado;
                    prestamo.FechaEmicion = copiaPrestamo.FechaEmicion;
                    prestamo.FechaCobro = copiaPrestamo.FechaCobro;
                    prestamo.Cancelado = copiaPrestamo.Cancelado;
                };

                view.ShowDialog();
            }

        }

    }

}

