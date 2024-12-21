using ServidorFac.src.Command;
using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command
{
    public abstract class CommandBase : ICommandExtended
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }


        public abstract List<CommandBase> SubCommandos { get; set; }
        public abstract void Execute(object? parameter);
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract Nick NickName { get; set; }
        public abstract string Help { get; set; }

        protected void OnCanExecuteChanged(object parameter)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        public SubCommand? buscarSubComandos(string args)
        {
            if (SubCommandos == null ) return null;
            foreach (var i in SubCommandos)
            {
                if (i.Name.Equals(args, StringComparison.OrdinalIgnoreCase)) return (SubCommand?)i;
            }
            return null;
        }
    }
}
