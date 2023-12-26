using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Exceptions
{
    public class VentaInforme
    {
        public DateTime Fecha {  get; private set; }
        public TypeInforme TypeException { get; private set; }

        public VentaInforme(TypeInforme typeExceptions)
        {
            this.TypeException = typeExceptions;
            this.Fecha = DateTime.Now;

            Console.WriteLine($"Error: {typeExceptions.Message}");
        }
        
    }
}
