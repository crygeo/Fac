using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet
{
    public class Persona
    {
        public string Nombre { get; set; } = "";
        public string Dni { get; set; } = "";

        public Persona(string Nombre, string dni)
        {
            this.Nombre = Nombre;
            this.Dni = dni;
        }

        public Persona()
        {
        }
    }
}
