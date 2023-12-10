using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet
{
    public class PrestamosTrabajador : ModelObject
    {
        private Trabajador trabajador;
        private string observacion;
        private double silverPrestado;
        private DateTime fechaEmicion;
        private DateTime fechaCobro;
        private bool cancelado;

        public Trabajador Trabajador
        {
            get { return trabajador; }
            set { SetProperty(ref trabajador, value); }
        }

        public string Observacion
        {
            get { return observacion; }
            set { SetProperty(ref observacion, value); }
        }

        public double SilverPrestado
        {
            get { return silverPrestado; }
            set { silverPrestado = value; OnPropertyChanged(nameof(SilverPrestado)); }
        }

        public DateTime FechaEmicion
        {
            get { return fechaEmicion; }
            set { SetProperty(ref fechaEmicion, value); }
        }

        public DateTime FechaCobro
        {
            get { return fechaCobro; }
            set { SetProperty(ref fechaCobro, value); }
        }

        public bool Cancelado
        {
            get { return cancelado; }
            set { SetProperty(ref cancelado, value); }
        }

        public PrestamosTrabajador(Trabajador trabajador)
        {
            this.trabajador = trabajador;
            this.observacion = string.Empty;
            FechaEmicion = DateTime.Now;
            FechaCobro = FechaDeDescuento(FechaEmicion);
        }

        private static DateTime FechaDeDescuento(DateTime now)
        {

            if (now.Day < 15)
            {
                return new DateTime(now.Year, now.Month, 15);
            }
            else
            {
                return new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
            }
        }
    }
}
