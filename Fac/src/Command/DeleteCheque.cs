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
using System.Windows;
using System.Windows.Input;

namespace Fac.src.Command
{
    public class DeleteCheque : CommandBase
    {

        private readonly BackVM vm;

        public DeleteCheque(BackVM vm)
        {
            this.vm = vm;
        }

        public override void Execute(object parameter)
        {
            if(parameter is Cheque cheque)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Seguro que quieres elimar este cheque?", "Cuidado", MessageBoxButton.YesNo);
                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    vm.Cheques.Remove(cheque);
                }
            }
        }





    }

}

