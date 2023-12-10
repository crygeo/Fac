using Fac.src.Command;
using Fac.src.Dats.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Lógica de interacción para AdelantosUC.xaml
    /// </summary>
    public partial class AdelantosUC : UserControl
    {

        public static readonly DependencyProperty AdelantoProperty = DependencyProperty.Register(nameof(Adelanto),
                                                                                        typeof(PrestamosTrabajador),
                                                                                        typeof(AdelantosUC),
                                                                                        new PropertyMetadata(null));

        public static readonly DependencyProperty EditarPrestamosProperty = DependencyProperty.Register(nameof(EditarPrestamos),
                                                                                        typeof(ICommand),
                                                                                        typeof(AdelantosUC),
                                                                                        new PropertyMetadata(null));

        public static readonly DependencyProperty DeletePrestamosProperty = DependencyProperty.Register(nameof(DeletePrestamos),
                                                                                        typeof(ICommand),
                                                                                        typeof(AdelantosUC),
                                                                                        new PropertyMetadata(null));

        public static readonly DependencyProperty AdelantoCobradoProperty = DependencyProperty.Register(nameof(AdelantoCobrado),
                                                                                        typeof(ICommand),
                                                                                        typeof(AdelantosUC),
                                                                                        new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register(nameof(Selected),
                                                                                      typeof(ICommand),
                                                                                      typeof(AdelantosUC),
                                                                                      new PropertyMetadata(null));

        public static readonly DependencyProperty ImprimirProperty = DependencyProperty.Register(nameof(Imprimir),
                                                                                      typeof(ICommand),
                                                                                      typeof(AdelantosUC),
                                                                                      new PropertyMetadata(null));

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(nameof(IsSelected),
                                                                                     typeof(bool),
                                                                                     typeof(AdelantosUC),
                                                                                     new PropertyMetadata(false));


        public PrestamosTrabajador Adelanto
        {
            get { return (PrestamosTrabajador)GetValue(AdelantoProperty); }
            set { SetValue(AdelantoProperty, value); }
        }
        public ICommand EditarPrestamos
        {
            get { return (ICommand)GetValue(EditarPrestamosProperty); }
            set { SetValue(EditarPrestamosProperty, value); }
        }

        public ICommand DeletePrestamos
        {
            get { return (ICommand)GetValue(DeletePrestamosProperty); }
            set { SetValue(DeletePrestamosProperty, value); }
        }

        public ICommand AdelantoCobrado
        {
            get { return (ICommand)GetValue(AdelantoCobradoProperty); }
            set { SetValue(AdelantoCobradoProperty, value); }
        }

        public ICommand Selected
        {
            get { return (ICommand)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        public ICommand Imprimir
        {
            get { return (ICommand)GetValue(ImprimirProperty); }
            set { SetValue(ImprimirProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); Selected?.Execute(Adelanto); }
        }


        public AdelantosUC()
        {
            InitializeComponent();
        }
    }
}
