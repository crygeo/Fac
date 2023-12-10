using Fac.src.Dats.Objet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                                                                                        typeof(AgregarAdalantoView));

        public static readonly DependencyProperty ListaEmpleadosProperty = DependencyProperty.Register(nameof(ListaEmpleados),
                                                                                        typeof(ObservableCollection<Trabajador>),
                                                                                        typeof(AgregarAdalantoView),
                                                                                        new PropertyMetadata(new ObservableCollection<Trabajador>()));

        public static readonly DependencyProperty EditableTrabajadorProperty = DependencyProperty.Register(nameof(EditableTrabajador),
                                                                                        typeof(bool),
                                                                                        typeof(AgregarAdalantoView),
                                                                                        new PropertyMetadata(false));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command),
                                                                                        typeof(ICommand),
                                                                                        typeof(AgregarAdalantoView),
                                                                                        new PropertyMetadata(null));


        public PrestamosTrabajador Prestamo
        {
            get { return (PrestamosTrabajador)GetValue(PrestamoProperty); }
            set { SetValue(PrestamoProperty, value); }
        }

        public ObservableCollection<Trabajador> ListaEmpleados
        {
            get { return (ObservableCollection<Trabajador>)GetValue(ListaEmpleadosProperty); }
            set { SetValue(ListaEmpleadosProperty, value); }
        }

        public bool EditableTrabajador
        {
            get { return (bool)GetValue(EditableTrabajadorProperty); }
            set { SetValue(EditableTrabajadorProperty, value); }
        }

        public event EventHandler? Confirm;
        public event EventHandler? Cancel;

        public AgregarAdalantoView()
        {
            InitializeComponent();
        }

        private void ButtonAcepet(object sender, RoutedEventArgs e)
        {

            if (Prestamo.Trabajador.Nombre == "")
            {
                MessageBox.Show("Escoje un Trabajador", "Alerta");
                return;
            }

            if (Prestamo.SilverPrestado == 0)
            {
                MessageBox.Show("Inserte la cantidad a prestar.", "Alerta");
                return;
            }

            if (Prestamo.FechaEmicion == new DateTime())
            {
                MessageBox.Show("Inserte Fechas", "Alerta");
                return;
            }

            if (Prestamo.FechaCobro == new DateTime())
            {
                MessageBox.Show("Inserte Fechas", "Alerta");
                return;
            }

            Confirm?.Invoke(Prestamo, new EventArgs());

            this.Close();
        }
        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            Cancel?.Invoke(this, new EventArgs());
            this.Close();

        }

    }
}
