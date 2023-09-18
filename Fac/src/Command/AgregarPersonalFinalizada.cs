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
    public class AgregarPersonalFinalizada : CommandBase
    {
        private readonly ObservableCollection<Trabajador> trabajadors;

        public AgregarPersonalFinalizada(ObservableCollection<Trabajador> list)
        {
            this.trabajadors = list;
        }

        public override void Execute(object parameter)
        {
            if(parameter is Trabajador trabajador)
            {
                trabajadors.Add(trabajador);
            }
        }





    }

}

