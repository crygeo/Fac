using Fac.src.ViewModel;
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
using System.Windows.Shapes;

namespace Fac.src.View
{
    /// <summary>
    /// Lógica de interacción para Pagos.xaml
    /// </summary>
    public partial class Pagos : Window
    {
        public Pagos()
        {
            InitializeComponent();
            Closed += View_Closed;
        }

        private void View_Closed(object? sender, EventArgs e)
        {
            if (dt.DataContext is PagosVM viewModel)
            {
                viewModel.GuardarDatos();
            }
        }
    }
}
