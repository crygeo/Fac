using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats.Objet.Inventario
{
    public class Item
    {
        private int _id;
        private Producto _producto;
        private double _cantidad;
        private double _precio;
        private string _descripcion;
        private Proveedor _provedor;
        private DateTime _datecreate;

        public int Id { get => _id; set => _id = value; }
        public double Cantidad { get => _cantidad; set => _cantidad = value; }
        public DateTime Datecreate { get => _datecreate; set => _datecreate = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public Producto Producto { get => _producto; set => _producto = value; }
        public Proveedor Provedor { get => _provedor; set => _provedor = value; }


    }
}
