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
    public class NuevoCheque : CommandBase
    {

        private readonly BackVM vm;

        public NuevoCheque(BackVM vm)
        {
            this.vm = vm;
        }

        public override void Execute(object parameter)
        {
            ChequeV chequev;
            Cheque cheque;

            int numChe;
            int counCheque = vm.Cheques.Count;

            #region
            if (counCheque > 0)
                numChe = vm.Cheques[counCheque - 1].NumeroCheque + 1;
            else
                numChe = 0;
            #endregion

            cheque = new Cheque()
            {
                NumeroCheque = numChe,
                Nombre = "",
                FechaEmicion = DateTime.Now,
                FechaCaducidad = DateTime.Now,
                Cobrado = false,
                Cantidad = 0,
            };

            chequev = new ChequeV
            {
                Title = "Nuevo Cheque",
                Cheque = cheque,
                Command = new NuevoChequeFinalizada(vm.Cheques),
            };

            chequev.ShowDialog();
        }





    }

}

