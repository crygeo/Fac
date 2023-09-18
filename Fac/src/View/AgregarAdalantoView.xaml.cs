using Fac.src.Dats.Objet;
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
    /// Lógica de interacción para AgregarPersonal.xaml
    /// </summary>
    public partial class AgregarAdalantoView : Window
    {

        public static readonly DependencyProperty PrestamoProperty = DependencyProperty.Register(nameof(Prestamo),
                                                                                        typeof(PrestamosTrabajador),
                                                                                        typeof(AgregarAdalantoView),
                                                                                        new PropertyMetadata(new Trabajador("", "", "")));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command),
                                                                                        typeof(ICommand),
                                                                                        typeof(AgregarAdalantoView),
                                                                                        new PropertyMetadata(null));


        public PrestamosTrabajador Prestamo
        {
            get { return (PrestamosTrabajador)GetValue(PrestamoProperty); }
            set { SetValue(PrestamoProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public event EventHandler? Confirm;
        public event EventHandler? Cancel;

        public AgregarAdalantoView()
        {
            InitializeComponent();
        }

        private void ButtonAcepet(object sender, RoutedEventArgs e)
        {

            if (Prestamo.Trabajador == null)
            {
                MessageBox.Show("Escoje un Trabajador", "Alerta");
                return;
            }

            if (Prestamo.SilverPrestamo == 0)
            {
                MessageBox.Show("Inserte la cantidad a prestar.", "Alerta");
                return;
            }

            if (Prestamo.FechaEmicion == new DateTime())
            {
                MessageBox.Show("Inserte Fechas", "Alerta");
                return;
            }

            Command?.Execute(Prestamo);
            Confirm?.Invoke(this, new EventArgs());
            this.Close();
        }
        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            Cancel?.Invoke(this, new EventArgs());
            this.Close();

        }

    }
}
