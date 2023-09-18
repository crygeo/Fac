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
        public int Code { get; set; }
        public string Puesto { get; set; } = "";
        
        public Trabajador(string puesto, string name, string dni) : base(name, dni)
        {
            Puesto = puesto;
            Code = Contador++;
        }


    }
}
