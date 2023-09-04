using Command;
using Fac.src.Dats.Objet;
using Fac.src.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command
{
    public class ToggleItemSelectionCommand : CommandBase
    {
        private ObservableCollection<Cheque> selectedItems;

        public ToggleItemSelectionCommand(ObservableCollection<Cheque> selectedItems)
        {
            this.selectedItems = selectedItems;
        }


        public override void Execute(object parameter)
        {
            if (parameter is Cheque item)
            {
                if (selectedItems.Contains(item))
                {
                    selectedItems.Remove(item);
                }
                else
                {
                    selectedItems.Add(item);
                }
            }
        }

       
    }
}
