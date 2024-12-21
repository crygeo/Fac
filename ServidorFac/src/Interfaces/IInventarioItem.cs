using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Interface
{
    public interface IInventarioItem
    {
        int Id { get; set; }
        Type Type { get; set; }

    }
}
