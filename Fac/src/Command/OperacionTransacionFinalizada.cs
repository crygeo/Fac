using Command;
using Fac.src.Dats.Objet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command
{
    public class OperacionTransacionFinalizada : CommandBase
    {
        private readonly ObservableCollection<Transancion> transanciones;

        public OperacionTransacionFinalizada(ObservableCollection<Transancion> transaciones)
        {
            this.transanciones = transaciones;
        }

        public override void Execute(object parameter)
        {
            if(parameter is Transancion cheque)
            {
                transanciones.Add(cheque);
            }
        }
    }
}
