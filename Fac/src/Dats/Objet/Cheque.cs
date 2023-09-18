using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet
{
    public class Cheque 
    {

        private DateTime _fechaEmicion;
        private DateTime _fechaCaducidad;
        private string _nombre = "";
        private int _numeroCheque;
        private double _cantidad;
        private bool _cobrado;

        public DateTime FechaEmicion
        {
            get { return _fechaEmicion; }
            set { _fechaEmicion = value; OnPropertyChanged(nameof(FechaEmicion)); }
        }

        public DateTime FechaCaducidad
        {
            get { return _fechaCaducidad; }
            set { _fechaCaducidad = value; OnPropertyChanged(nameof(FechaCaducidad)); }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }

        public int NumeroCheque
        {
            get { return _numeroCheque; }
            set { _numeroCheque = value; OnPropertyChanged(nameof(NumeroCheque)); }
        }

        public double Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; OnPropertyChanged(nameof(Cantidad)); }
        }

        public bool Cobrado
        {
            get { return _cobrado; }
            set { _cobrado = value; OnPropertyChanged(nameof(Cobrado)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
