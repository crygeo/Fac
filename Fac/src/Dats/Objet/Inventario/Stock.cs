using Fac.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;

namespace Fac.src.Dats.Objet.Inventario
{
    public class Stock
    {
        private Producto _producto;
        private double _cantidadFinal;
        private double _precioFinal;
        public Stock(Producto producto)
        {
            _producto = producto;
            _cantidadFinal = 0;
            _precioFinal = 0;
        }

        public Task<VentaInforme> Sell(int cantidad)
        {
            return new Task<VentaInforme>(() =>
            {

                if (_cantidadFinal < cantidad) return new VentaInforme(TypeInforme.SinStock);
                
                _cantidadFinal -= cantidad;
                return new VentaInforme(TypeInforme.VentaExitosa);


            });
        }

        public Task<VentaInforme> Add(int cantidad)
        {
            return new Task<VentaInforme>(() =>
            {

                _cantidadFinal += cantidad;
                return new VentaInforme(TypeInforme.IngresoExitoso);


            });
        }
    }
}
