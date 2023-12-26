using Fac.src.Interface;
using Fac.src.View;
using Fac.src.View.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fac.src.WindowStrategies
{
    public class WindowInventarioStrategy : IWindowStrategy
    {

        private InventarioView? window = null;
        public void OpenWindow()
        {
            if (window == null)
            {
                window = new InventarioView();
                window.ShowInTaskbar = true;
                window.Closed += (sender, args) => window = null;
                window.Show();
            }
            else
            {
                if(window.WindowState == WindowState.Minimized)
                {
                    window.WindowState = WindowState.Normal;
                }
                window.Activate();
            }

        }
    }
}

