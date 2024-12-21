using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorFac.src.Funciones.StyleConsole
{
    public class PrintConsole
    {
        public static char charDir { get; set; } = '§';

        // Primera version
        public static void Line(string text)
        {
            List<string> lines = new List<string>();

            string stringtemp = string.Empty;

            foreach (char chartemp in text)
            {
                if (chartemp == charDir)
                {
                    if (!string.IsNullOrEmpty(stringtemp))
                    {
                        lines.Add(stringtemp);
                        stringtemp = string.Empty;
                    }
                }

                stringtemp += chartemp;

            }
            if (stringtemp != string.Empty)
            {
                lines.Add(stringtemp);
            }

            var tempColor = Console.ForegroundColor;
            foreach (string line in lines)
            {
                if (line[0] == charDir)
                {
                    Console.ForegroundColor = getConsoleColor(line[1]);
                }
                Console.Write(line.Substring(2));
            }
            Console.ForegroundColor = tempColor;

        }

        public static string ReadLine(char indexColor)
        {
            var color = Console.ForegroundColor;
            var newColor = getConsoleColor(indexColor);

            Console.ForegroundColor = newColor;
            string? text = Console.ReadLine();
            Console.ForegroundColor = color;

            if (text == null) return "";

            return text;
        }

        private static ConsoleColor getConsoleColor(char stColor)
        {
            if (stColor == 'R') return ConsoleColor.Red;
            if (stColor == 'B') return ConsoleColor.Blue;
            if (stColor == 'G') return ConsoleColor.Green;
            if (stColor == 'C') return ConsoleColor.Cyan;
            if (stColor == 'Y') return ConsoleColor.Yellow;
            if (stColor == 'M') return ConsoleColor.Magenta;
            if (stColor == 'W') return ConsoleColor.White;
            return ConsoleColor.White;
        }

        public static string SolicitarDatos(string nameDato)
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            string msg = string.Empty;
            msg += $"\n        └─ {nameDato} >> ";
            Console.Write(msg);

            Console.ForegroundColor = ConsoleColor.Red;
            var text = Console.ReadLine() ?? "";
            Console.ForegroundColor = temp;

            if (text == null)
            {
                PrintConsole.Line("\t\t\tName is null, reinter.");
                return SolicitarDatos(nameDato);
            }
            else return text;

        }

    }

}
