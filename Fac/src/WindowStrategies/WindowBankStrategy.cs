using Fac.src.Interface;
using Fac.src.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fac.src.WindowStrategies
{
    public class WindowBankStrategy : IWindowStrategy
    {

        private Bank? bank = null;
        public void OpenWindow()
        {
            if (bank == null)
            {
                bank = new Bank();
                bank.ShowInTaskbar = true;
                bank.Closed += (sender, args) => bank = null;
                bank.Show();
            }
            else
            {
                if(bank.WindowState == WindowState.Minimized)
                {
                    bank.WindowState = WindowState.Normal;
                }
                bank.Activate();
            }

        }
    }
}

