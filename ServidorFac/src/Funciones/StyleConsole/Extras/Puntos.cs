using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Funciones.StyleConsole.Extras
{
    public class Puntos
    {
        public Puntos()
        {
            Izquierda = 0;
            Arriba = 0;
            Derecha = 0;
            Abajo = 0;
        }

        public Puntos(int izquierda, int arriba, int derecha, int abajo)
        {
            Izquierda = izquierda;
            Arriba = arriba;
            Derecha = derecha;
            Abajo = abajo;
        }

        public int Izquierda {  get; set; }
        public int Arriba { get; set; }
        public int Derecha { get; set; }
        public int Abajo { get; set; }

        
    }
}
