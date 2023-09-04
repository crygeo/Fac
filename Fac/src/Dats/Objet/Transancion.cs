using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet
{
    public class Transancion : INotifyPropertyChanged
    {
        private DateTime _fechaProceso;
        private string _nombreProceso = "";
        private double _valorProceso;
        private bool _darBaja;
        private bool _isRevised;

        public DateTime FechaProceso
        {
            get { return _fechaProceso; }
            set { _fechaProceso = value; OnPropertyChanged(nameof(FechaProceso)); }
        }

        public string NombreProceso
        {
            get { return _nombreProceso; }
            set { _nombreProceso = value; OnPropertyChanged(nameof(NombreProceso)); }
        }

        public double ValorProceso
        {
            get { return _valorProceso; }
            set { _valorProceso = value; OnPropertyChanged(nameof(ValorProceso)); }
        }

        public bool DarBaja
        {
            get { return _darBaja; }
            set { _darBaja = value; OnPropertyChanged(nameof(DarBaja)); }
        }

        public bool IsRevised
        {
            get { return _isRevised; }
            set { _isRevised = value; OnPropertyChanged(nameof(IsRevised)); }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
