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

namespace Fac.src.Command
{
    public class AgregarPersonal : CommandBase
    {
        private readonly ObservableCollection<Trabajador> trabajadors;

        public AgregarPersonal(ObservableCollection<Trabajador> list)
        {
            this.trabajadors = list;
        }

        public override void Execute(object parameter)
        {
            AgregarPersonalV addPersonal;

            if (parameter is Trabajador trabajador)
            {

                addPersonal = new AgregarPersonalV
                {
                    Title = "Editar Personal",
                    Trabajador = trabajador,
                    Command = new AgregarPersonalFinalizada(trabajadors)
                };

            }
            else
            {
                addPersonal = new AgregarPersonalV
                {
                    Title = "Agregar Personal",
                    Trabajador = new Trabajador(),
                    Command = new AgregarPersonalFinalizada(trabajadors)
                };
            }

            addPersonal.ShowDialog();
        }





    }

}

