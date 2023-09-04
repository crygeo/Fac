using Fac.src.Dats.Objet;
using Fac.src.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Fac.src.UserControls
{
    /// <summary>
    /// Lógica de interacción para ChequeUC.xaml
    /// </summary>
    public partial class ChequeUC : UserControl
    {
        public static readonly DependencyProperty EditChequeProperty = DependencyProperty.Register(nameof(EditCheque),
                                                                                        typeof(ICommand),
                                                                                        typeof(ChequeUC),
                                                                                        new PropertyMetadata(null));

        public static readonly DependencyProperty DeleteChequeProperty = DependencyProperty.Register(nameof(DeleteCheque),
                                                                                        typeof(ICommand),
                                                                                        typeof(ChequeUC),
                                                                                        new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register(nameof(Selected),
                                                                                       typeof(ICommand),
                                                                                       typeof(ChequeUC),
                                                                                       new PropertyMetadata(null));

        public static readonly DependencyProperty ChequeCobradoProperty = DependencyProperty.Register(nameof(ChequeCobrado),
                                                                                      typeof(ICommand),
                                                                                      typeof(ChequeUC),
                                                                                      new PropertyMetadata(null));

        public static readonly DependencyProperty ChequeProperty = DependencyProperty.Register(nameof(Cheque),
                                                                                       typeof(Cheque),
                                                                                       typeof(ChequeUC),
                                                                                       new PropertyMetadata(null));

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(nameof(IsSelected),
                                                                                      typeof(bool),
                                                                                      typeof(ChequeUC),
                                                                                      new PropertyMetadata(false));



        public ICommand EditCheque
        {
            get { return (ICommand)GetValue(EditChequeProperty); }
            set { SetValue(EditChequeProperty, value); }
        }

        public ICommand DeleteCheque
        {
            get { return (ICommand)GetValue(DeleteChequeProperty); }
            set { SetValue(DeleteChequeProperty, value); }
        }


        public Cheque Cheque
        {
            get { return (Cheque)GetValue(ChequeProperty); }
            set { SetValue(ChequeProperty, value); }
        }

        public ICommand Selected
        {
            get { return (ICommand)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); Selected?.Execute(Cheque); }
        }

        public ICommand ChequeCobrado
        {
            get { return (ICommand)GetValue(ChequeCobradoProperty); }
            set { SetValue(ChequeCobradoProperty, value); }
        }

        public ChequeUC()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsSelected = !IsSelected;
        }

       

    }
}
