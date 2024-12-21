using ServidorFac.src.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Interfaces
{
    public interface IItemsDB
    {
        Task<List<IInventarioItem>> GetLista();
        Task<int> AddItem(IInventarioItem item);
    }
}
