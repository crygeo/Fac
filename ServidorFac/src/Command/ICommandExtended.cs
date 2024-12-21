using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServidorFac.src.Command
{
    internal interface ICommandExtended : ICommand
    {
        string Name { get; set; }
        string Description { get; set; }
        Nick NickName { get; set; }
        string Help { get; set; }

    }
}
