using Command;
using Fac.src.Dats.Objet;
using Fac.src.UserControls;
using Fac.src.View;
using Fac.src.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fac.src.Command
{
    public class EditarCheque : CommandBase
    {

        private readonly BackVM vm;

        public EditarCheque(BackVM vm)
        {
            this.vm = vm;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Cheque originalCheque)
            {
                // Serializar el objeto original a JSON y luego deserializarlo en una nueva instancia
                string originalChequeJson = JsonConvert.SerializeObject(originalCheque);
                Cheque? copiaCheque = JsonConvert.DeserializeObject<Cheque>(originalChequeJson);

                if (copiaCheque != null)
                {
                    ChequeV chequev;

                    chequev = new ChequeV
                    {
                        Title = "Editar Cheque",
                        Cheque = copiaCheque,
                        Command = new EditarChequeFinalizada(originalCheque)

                    };

                    chequev.Confirm += (sender, e) =>
                    {
                        vm.RefriscarDatos();
                    };

                    chequev.numChe.IsEnabled = false;

                    chequev.ShowDialog();

                }








            }
        }

    }
}
