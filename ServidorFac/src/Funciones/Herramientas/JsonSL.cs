using Newtonsoft.Json;
using ServidorFac.src.Objs.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.Herramientas
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
