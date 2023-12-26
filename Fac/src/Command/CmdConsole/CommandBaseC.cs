using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command.CmdConsole
{
    public abstract class CommandBaseC
    {
        public abstract void Execute(string [] parameter);
    }
}
