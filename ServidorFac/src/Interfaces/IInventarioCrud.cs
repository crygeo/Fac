using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Interface
{
    public interface IInventarioCrud <T>
    {
        public List<T> ListaItems { get; set; }
        public void AddItem(T items);
        public void DelItem(T item);
        public void EditItem(T itemOld, T itemNew);
        public T? GetItemsID(int id);

    }
}
