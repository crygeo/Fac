using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet
{
    public class Trabajador : Persona
    {
        private static int Contador = 0;

        private int _code;
        private string _puesto;
        private string _telefono;
        public int Code { get { return _code; } set { SetProperty(ref _code, value); } }
        public string Puesto { get { return _puesto; } set { SetProperty(ref _puesto, value); } }
        public string Telefono { get { return _telefono; } set { SetProperty(ref _telefono, value); } }

        public Trabajador() : base()
        {
            Contador++;
            _puesto = string.Empty;
            _telefono = string.Empty;
        }


    }
}
