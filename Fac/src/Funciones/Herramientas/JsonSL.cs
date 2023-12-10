using Fac.src.Dats.Objet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Funciones.Herramientas
{
    public class JsonSL
    {
        public static string [] Deserialize (string json)
        {
            return JsonConvert.DeserializeObject<string[]>(json);
        }

        public static string Serialize(string[] json)
        {
            return JsonConvert.SerializeObject(json);
        }
    }
}
