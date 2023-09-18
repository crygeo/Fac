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
    public partial class AgregarPersonalV : Window
    {

        public static readonly DependencyProperty TrabajadorProperty = DependencyProperty.Register(nameof(Trabajador),
                                                                                        typeof(Trabajador),
                                                                                        typeof(AgregarPersonalV),
                                                                                        new PropertyMetadata(new Trabajador("", "", "")));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command),
                                                                                        typeof(ICommand),
                                                                                        typeof(AgregarPersonalV),
                                                                                        new PropertyMetadata(null));


        public Trabajador Trabajador
        {
            get { return (Trabajador)GetValue(TrabajadorProperty); }
            set { SetValue(TrabajadorProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public event EventHandler? Confirm;
        public event EventHandler? Cancel;

        public AgregarPersonalV()
        {
            InitializeComponent();
        }

        private void ButtonAcepet(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(Trabajador.Nombre))
            {
                MessageBox.Show("Inserte Nombre", "Alerta");
                return;
            }

            if (string.IsNullOrEmpty(Trabajador.Dni))
            {
                MessageBox.Show("Inserte DNI", "Alerta");
                return;
            }

            if (string.IsNullOrEmpty(Trabajador.Puesto))
            {
                MessageBox.Show("Inserte Puesto", "Alerta");
                return;
            }

            Command?.Execute(Trabajador);
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
