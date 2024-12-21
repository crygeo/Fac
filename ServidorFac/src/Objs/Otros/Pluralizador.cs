using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Objs.Otros
{
    using System;

    public class Pluralizador
    {
        public static string SingularAPlural(string palabraSingular)
        {
            if (string.IsNullOrEmpty(palabraSingular))
            {
                throw new ArgumentException("La palabra singular no puede ser nula o vacía.");
            }

            if (palabraSingular.EndsWith("s") || palabraSingular.EndsWith("x") || palabraSingular.EndsWith("z"))
            {
                return palabraSingular + "es";
            }
            else if (palabraSingular.EndsWith("y"))
            {
                // Cambia "y" a "ies" si la letra antes de "y" no es una vocal
                if (palabraSingular.Length > 1 && !EsVocal(palabraSingular[palabraSingular.Length - 2]))
                {
                    return palabraSingular.Substring(0, palabraSingular.Length - 1) + "ies";
                }
            }

            // Agrega "s" de manera predeterminada
            return palabraSingular + "s";
        }

        private static bool EsVocal(char letra)
        {
            return "aeiouAEIOU".IndexOf(letra) != -1;
        }

    }

}
