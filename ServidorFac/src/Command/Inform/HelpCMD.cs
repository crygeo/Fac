using Command;
using Fac.src.Command.CmdConsole;
using Fac.src.Funciones.StyleConsole;
using ServidorFac.src.Funciones.StyleConsole;
using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Inform
{
    public class HelpCMD : CommandBase
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override Nick NickName { get; set; }
        public override string Help { get; set; }
        public override List<CommandBase> SubCommandos { get; set; }

        private readonly IEnumerable<CommandBase> _comandos;

        public HelpCMD(List<CommandBase> comandos)
        {
            _comandos = comandos;

            Name = "Ayuda";
            Description = "Ver todos los comandos disponibles";
            NickName = new Nick(["help", "h", "hp", "ayuda" ]);
            Help = "";

        }
        public override void Execute(object? parameter)
        {
            Ejecutar();
        }

        private void Ejecutar()
        {
            StyleConsole2 st = new();
            st.Margin = new(1, 1, 1, 1);
            st.Padding = new(1, 1, 1, 1);

            string msg = string.Empty;
            
            foreach (var item in _comandos)
            {
                var elem = item;
                msg += $"   §B{elem.Name} §R>>§W {elem.Description}\n";

            }

            PrintConsole.Line("\n " + st.GenerarContenedor(msg, "--- §RHelp §W---"));
        }

    }
}
