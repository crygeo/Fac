using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Exceptions
{
    public class TypeInforme
    {
        public static int Cont = 0;
        public string Name { get; set; }
        public string Message { get; set; }
        public int Value { get; private set; }

        public TypeInforme()
        {
            Value = Cont++;
            Name = string.Empty;
            Message = string.Empty;
        }

        public static TypeInforme SinStock = new TypeInforme()
        {
            Name = "Sin Stock",
            Message = "Producto sin Stock. No se procedera la venta.",
        };

        public static TypeInforme VentaExitosa = new TypeInforme()
        {
            Name = "Venta Exitosa",
            Message = "Ok.",
        };

        public static TypeInforme IngresoExitoso = new TypeInforme()
        {
            Name = "Ingreso Exitoso",
            Message = "Ok.",
        };
    }



}
