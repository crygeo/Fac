using Command;
using Fac.src.Dats.Objet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fac.src.Command
{
    public class NuevoChequeFinalizada : CommandBase
    {
        private readonly ObservableCollection<Cheque> cheques;

        public NuevoChequeFinalizada(ObservableCollection<Cheque> cheques)
        {
            this.cheques = cheques;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Cheque cheque)
            {
                var existingCheque = cheques.FirstOrDefault(c => c.NumeroCheque == cheque.NumeroCheque);

                if (existingCheque != null)
                {
                    MessageBox.Show("Ya existe un cheque con este numero.");
                    return; 
                }
                cheques.Add(cheque);

            }
        }

       
    }
}
