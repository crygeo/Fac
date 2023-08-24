using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.Current.Windows.Count > 2) //hay que cambiar a 1 al final por que la ventana cmd tambien cuenta.
            {
                MessageBoxResult msg = MessageBox.Show("Hay otras ventanas abiertas. Deceas cerrar todas?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (msg == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window != Application.Current.MainWindow)
                        {
                            window.Close();
                        }
                    }

                }
            }
        }

    }
}
