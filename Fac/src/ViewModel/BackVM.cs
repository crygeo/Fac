using Fac.src.Command;
using Command;
using Fac.src.Dats.Objet;
using Fac.src.Model;
using Fac.src.UserControls;
using Fac.src.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

namespace Fac.src.ViewModel
{
    public class BackVM : ViewModelBase
    {
        private BankM _bankM = new BankM();

        private ObservableCollection<Cheque> _selectedItems = new ObservableCollection<Cheque>();
        public ObservableCollection<Cheque> SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                if (_selectedItems != value)
                {
                    _selectedItems = value;
                    OnPropertyChanged(nameof(SelectedItems));
                }
            }
        }

        public ObservableCollection<Cheque> Cheques { get => _bankM.ObtenerCheques(); }
        public ObservableCollection<Transancion> Transancions { get => _bankM.ObtenerTransaciones(); }
        public ICommand EditarCheque { get; set; }
        public ICommand NuevoCheque { get; set; }
        public ICommand DeleteCheque { get; set; }
        public ICommand ChequeCobrado { get; set; }
        public ICommand ToggleItemSelectionCommand { get; set; }

        private double _totalSelectedAmount;
        public double TotalSelectedAmount
        {
            get
            {
                return _totalSelectedAmount;
            }
            private set
            {
                if (_totalSelectedAmount != value)
                {
                    _totalSelectedAmount = value;
                    OnPropertyChanged(nameof(TotalSelectedAmount));
                }
            }
        }


        public BackVM()
        {
            NuevoCheque = new NuevoCheque(this);
            EditarCheque = new EditarCheque(this);
            DeleteCheque = new DeleteCheque(this);
            ChequeCobrado = new ChequeCobrado(this);

            ToggleItemSelectionCommand = new ToggleItemSelectionCommand(SelectedItems);

            SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
        }

        private void SelectedItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefriscarDatos();
        }

        public void RefriscarDatos()
        {
            TotalSelectedAmount = SelectedItems.Sum(cheque => cheque.Cantidad);
        }

        public void GuardarDatos()
        {
            _bankM.GuardarDatos();
        }

    }
}
