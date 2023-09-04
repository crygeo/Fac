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
    public class EditarChequeFinalizada : CommandBase
    {
        private readonly Cheque originalCheque;

        public EditarChequeFinalizada(Cheque originalCheque)
        {
            this.originalCheque = originalCheque;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Cheque copiaCheque)
            {
               
                originalCheque.Nombre = copiaCheque.Nombre;
                originalCheque.FechaCaducidad = copiaCheque.FechaCaducidad;
                originalCheque.FechaEmicion = copiaCheque.FechaEmicion;
                originalCheque.Cantidad = copiaCheque.Cantidad;
            }
        }
    }
}
