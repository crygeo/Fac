using Command;
using Fac.src.Dats.Objet;
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
    public class OperacionTransacion : CommandBase
    {

        private readonly BackVM vm;

        public OperacionTransacion(BackVM vm)
        {
            this.vm = vm;
        }

        public override void Execute(object parameter)
        {
            Transancion transancion;
            if (parameter == null)
            {
                transancion = new Transancion()
                {
                    NombreProceso = "",
                    FechaProceso = DateTime.Now,
                    ValorProceso = 0,
                };

            }
            else
            {
                transancion = (Transancion)parameter;
            }

            TransacionV transancionV = new TransacionV();

            transancionV.Title = "Nueva transacion";
            transancionV.Transancion = transancion;
            transancionV.Command = new OperacionTransacionFinalizada(vm.Transancions);

            transancionV.Confirm += (sender, e) => {
                transancionV.Close();
            };

            transancionV.ShowDialog();

        }
       
    }
}
