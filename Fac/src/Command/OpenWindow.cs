using Command;
using Fac.src.Interface;
using Fac.src.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fac.src.Command
{
    public class OpenWindow : CommandBase
    {
        private Dictionary<string, IWindowStrategy> windowStrategies { get; set; }

        public OpenWindow(Dictionary<string, IWindowStrategy> windowStrategies)
        {
            this.windowStrategies = windowStrategies;
        }

        public override void Execute(object parameter)
        {
            if (parameter is string windowType && windowStrategies.ContainsKey(windowType))
            {
                windowStrategies[windowType].OpenWindow();
            }
        }
    }
}
