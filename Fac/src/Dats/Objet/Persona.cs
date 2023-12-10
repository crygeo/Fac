using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet
{
    public class Persona : ModelObject
    {
        private string _nombre;
        private string _dni;

        public string Nombre { get { return _nombre; } set { SetProperty(ref _nombre, value); } }
        public string Dni { get { return _dni; } set { SetProperty(ref _dni, value); } }

        public Persona()
        {
            this._nombre = "";
            this._dni = "";
        }
        
    }
}
