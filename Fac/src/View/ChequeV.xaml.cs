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
    public partial class ChequeV : Window
    {

        public static readonly DependencyProperty ChequeProperty = DependencyProperty.Register(nameof(Cheque),
                                                                                        typeof(Cheque),
                                                                                        typeof(ChequeV),
                                                                                        new PropertyMetadata(new Cheque()));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command),
                                                                                        typeof(ICommand),
                                                                                        typeof(ChequeV),
                                                                                        new PropertyMetadata(null));



        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public Cheque Cheque
        {
            get { return (Cheque)GetValue(ChequeProperty); }
            set { SetValue(ChequeProperty, value); }
        }

        public event EventHandler? Confirm;


        public ChequeV()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(numChe.Text))
            {
                MessageBox.Show("Inserte Numero Cheque", "Alerta");
                return;
            }

            if (!date1.CorrectDate || !date2.CorrectDate)
            {
                MessageBox.Show("Fecha Incorrecta", "Alerta");
                return;
            }

            if (date1.Date > date2.Date)
            {
                MessageBox.Show("La fecha de caducidad no puede ser menor a la de emicion", "Alerta");
                return;
            }

            Command?.Execute(Cheque);
            Confirm?.Invoke(this, new EventArgs());
            this.Close();
        }
    }
}
