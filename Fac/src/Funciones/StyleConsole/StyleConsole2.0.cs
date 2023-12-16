using Fac.src.Funciones.StyleConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Funciones.StyleConsole
{
    public class StyleConsole2
    {
        private char tl = '┌';
        private char tr = '┐';
        private char bl = '└';
        private char br = '┘';
        private char lh = '─';
        private char lv = '│';
        private char space = ' ';

        public Puntos Margin;
        public Puntos Padding;
        public int PuntoTitulo;

        public StyleConsole2(Puntos Margin = null, Puntos Padding = null, int PuntoTitulo = 0)
        {
            if (Margin == null) this.Margin = new Puntos();
            if (Padding == null) this.Padding = new Puntos();
            this.PuntoTitulo = PuntoTitulo;
        }

        public string GenerarContenedor(string Message, string Name = "")
        {
            if (Name.Length > 45) throw new Exception("El titulo no puede ser mayor a 45 caracteres");

            string[] messageSeparado = Message.Split('\n');
            int messageMaxLength = ObtenerElLengthDeLaFraseMasLargaDeString(Message + "\n" + Name);

            var rt = string.Empty;

            //Agregar Margin arriba
            rt += MarginVertical(Margin.Arriba, messageMaxLength);

            #region Primera Fila
            //Inserto Izquina
            rt += MarginPadding(space, tl, lh);
            rt += RellenoText(messageMaxLength, Name, lh);
            rt += PaddingMargin(lh, tr, space);
            rt += "\n";
            #endregion

            #region Filas
            rt += PaddingVertical(Padding.Arriba, messageMaxLength);
            rt += "\n";

            for (int i = 0; i < messageSeparado.Length; i++)
            {
                rt += MarginPadding(space, lv, space);
                rt += messageSeparado[i];
                rt += RellenoText(messageMaxLength - messageSeparado[i].Length, space);
                rt += PaddingMargin(space, lv, space);
                rt += "\n";
            }
            #endregion

            //Agrego Padding Abajo
            rt += PaddingVertical(Padding.Abajo, messageMaxLength);

            rt += "\n";
            #region UltimaFila
            rt += MarginPadding(space, bl, lh);
            rt += RellenoText(messageMaxLength, lh);
            rt += PaddingMargin(lh, br, space);
            #endregion

           rt += MarginVertical(Margin.Abajo, messageMaxLength);
            
            return rt;

        }

        private int ObtenerElLengthDeLaFraseMasLargaDeString(string map)
        {
            int contador = 0;
            var arr = map.Split("\n");

            foreach (string str in arr)
            {
                if (str.Length > contador)
                {
                    contador = str.Length;
                }
            }
            return contador;
        }

        private string MarginPadding(char margin, char centro, char padding)
        {
            string txt = string.Empty;
            for (int i = 0; i < Margin.Izquierda; i++)
            {
                txt += margin;
            }
            txt += centro;
            for (int i = 0; i < Padding.Izquierda; i++)
            {
                txt += padding;
            }
            return txt;
        }
        private string PaddingMargin(char padding, char centro, char margin)
        {
            string txt = string.Empty;
            for (int i = 0; i < Padding.Derecha; i++)
            {
                txt += padding;
            }
            txt += centro;
            for (int i = 0; i < Margin.Derecha; i++)
            {
                txt += margin;
            }
            return txt;

        }
        private string PaddingVertical(int cant, int leng)
        {
            string txt = string.Empty;
            for (int i = 0; i < cant; i++)
            {

                txt += MarginPadding(space, lv, space);
                txt += RellenoText(leng, space);
                txt += PaddingMargin(space, lv, space);
            }
            return txt;

        }
        private string MarginVertical(int cant, int leng)
        {
            string txt = string.Empty;
            for (int i = 0; i < cant; i++)
            {
                txt += "\n";
            }
            return txt;
        }
        private string RellenoText(int leng, string text, char relleno)
        {
            string txt = relleno.ToString();
            txt += $" {text} ";
            for (int i = 0; i < leng - 3 - text.Length; i++)
            {
                txt += relleno;
            }
            return txt;
        }
        private string RellenoText(int leng, char relleno)
        {
            string txt = string.Empty;
            for (int i = 0; i < leng; i++)
            {
                txt += relleno;
            }
            return txt;
        }
    }
}
