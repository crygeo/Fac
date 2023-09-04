using Command;
using Fac.src.Command;
using Fac.src.Interface;
using Fac.src.View;
using Fac.src.WindowStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fac.src.ViewModel
{
    public class MainVM : ViewModelBase
    {
        private Dictionary<string, IWindowStrategy> windowStrategies;
        public ICommand OpenWindowCommand { get; set; }


        public MainVM()
        {
            windowStrategies = new Dictionary<string, IWindowStrategy>
            {
                { "BankWindow", new WindowBankStrategy() },
            };

            OpenWindowCommand = new OpenWindow(windowStrategies);

        }

    }
}
