using Command;
using Fac.src.Dats.Objet;
using Fac.src.UserControls;
using Fac.src.View;
using Fac.src.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fac.src.Command
{
    public class AdelantoCancelado : CommandBase
    {


        public AdelantoCancelado()
        {
        }

        public override void Execute(object parameter)
        {
            if (parameter is PrestamosTrabajador prestamo)
            {
                prestamo.Cancelado = !prestamo.Cancelado;
            }
        }





    }

}

