using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet
{
    public class PrestamosTrabajador
    {
        public Trabajador Trabajador { get; set;}
        public double SilverPrestamo { get; set;}
        public DateTime FechaEmicion { get; set;} = DateTime.Now;
        public bool Cancelado { get; set;} = false;

        public PrestamosTrabajador(Trabajador trabajor)
        {
            Trabajador = trabajor;
        }
    }
}
