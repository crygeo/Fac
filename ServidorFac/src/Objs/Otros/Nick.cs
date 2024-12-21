using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Objs.Otros
{
    public class Nick
    {
        public List<string> Names { get; set; }

        public Nick()
        {
            Names = new List<string>();
        }

        public Nick(string[] nick)
        {
            Names = nick.ToList();
        }

        public void addNick(string nick)
        {
            Names.Add(nick);
        }
        public override string ToString()
        {
            return string.Join(", ", Names);
        }

        public string[] ToArray()
        {
            return Names.ToArray();
        }

        public static Nick Parse(string[] json)
        {
            Nick nick = new Nick();
            foreach (var item in json)
            {
                nick.Names.Add(item);
            }
            return nick;
        }

    }
}
