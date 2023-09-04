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
using Utilidades.UserControls;

namespace Fac.src.View
{
    /// <summary>
    /// Lógica de interacción para ChequeV.xaml
    /// </summary>
    public partial class TransacionV : Window
    {

        public static readonly DependencyProperty ChequeProperty = DependencyProperty.Register(nameof(Transancion),
                                                                                        typeof(Transancion),
                                                                                        typeof(TransacionV),
                                                                                        new PropertyMetadata(new Transancion()));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command),
                                                                                        typeof(ICommand),
                                                                                        typeof(TransacionV),
                                                                                        new PropertyMetadata(null));



        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public Transancion Transancion
        {
            get { return (Transancion)GetValue(ChequeProperty); }
            set { SetValue(ChequeProperty, value); }
        }

        public event EventHandler? Confirm;


        public TransacionV()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (date1.CorrectDate)
            {
                Confirm?.Invoke(this, EventArgs.Empty);
                Command?.Execute(Transancion);
            }
            else
            {
                MessageBox.Show("Fecha Incorrecta", "Alerta");
            }
        }
    }
}
