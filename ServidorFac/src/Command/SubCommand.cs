using Command;
using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Command
{
    public class SubCommand : CommandBase
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override Nick NickName { get; set; }
        public override string Help { get; set; }
        public object? Value { get; set; }
        public Action? Accion { get; set; }
        public override List<CommandBase> SubCommandos { get; set; }

        public override void Execute(object? parameter)
        {
            Accion?.Invoke();
        }
    }
}
