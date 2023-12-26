using Fac.src.Funciones.StyleConsole.Extras;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Fac.src.Funciones.StyleConsole
{
    public class Tabla
    {
        private char L_T = '┌';
        private char L_C = '├';
        private char L_B = '└';

        private char C_T = '┬';
        private char C_C = '┼';
        private char C_B = '┴';

        private char R_T = '┐';
        private char R_C = '┤';
        private char R_B = '┘';

        private char L_H = '─';
        private char L_V = '│';
        private char SPACE = ' ';

        private int _lengtCols;
        private int _lengtRows;

        private List<int> Widthcolumn;
        public int Padding { get; set; }

        private List<List<Celda>> Table;

        public int LengtCols { get => _lengtCols; set => _lengtCols = value; }
        public int LengtRows { get => _lengtRows; set => _lengtRows = value; }

        public Tabla(int lengtCols = -1, int lengtRows = -1)
        {
            this.LengtCols = lengtCols;
            this.LengtRows = lengtRows;

            Widthcolumn = new();
            Table = new();
        }


        public void AddRow(List<Celda> Row)
        {
            if (Row.Count > Widthcolumn.Count)
            {
                int dif = Row.Count - Widthcolumn.Count;

                for (int i = 0; i < dif; i++) { Widthcolumn.Add(0); }
            }

            for (int i = 0; i < Row.Count; i++)
            {
                int LengText = Row[i].Text.Length + (Padding * 2);
                int LengTextSave = Widthcolumn[i];

                if (LengText > LengTextSave) Widthcolumn[i] = LengText + (Padding*2);
                //Console.WriteLine(Row[i].Text + " - " + LengText + " - " + LengTextSave);
            }


            Table.Add(Row);
        }



        private string GenerarTabla()
        {
            string tabla = string.Empty;

            if (Table.Count == 1)
            {
                tabla += printRow(Table[0], TypeRow.OneRow);
            }

            if (Table.Count > 1)
            {
                for (int i = 0; i < Table.Count; i++)
                {
                    if (i == 0) tabla += printRow(Table[i], TypeRow.StarRow);
                    if (i > 0 && i < Table.Count - 1) tabla += printRow(Table[i], TypeRow.CenterRow);
                    if (i >= Table.Count - 1) tabla += printRow(Table[i], TypeRow.FinalRow);
                }
            }

            return tabla;
        }

        public string printRow(List<Celda> Row, TypeRow typeRow)
        {

            string rowText = string.Empty;
            if (typeRow == TypeRow.OneRow)
            {
                rowText += CrearFranja(TypeFranja.Top, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
                rowText += CrearFranja(TypeFranja.Bot, Widthcolumn);
            }

            if (typeRow == TypeRow.StarRow)
            {
                rowText += CrearFranja(TypeFranja.Top, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
            }

            if (typeRow == TypeRow.CenterRow)
            {
                rowText += CrearFranja(TypeFranja.Center, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
            }

            if (typeRow == TypeRow.FinalRow)
            {
                rowText += CrearFranja(TypeFranja.Center, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
                rowText += CrearFranja(TypeFranja.Bot, Widthcolumn);
            }

            return rowText;
        }

        private string CrearFranja(TypeFranja fg, List<int> col)
        {
            string line = string.Empty;

            if (fg == TypeFranja.Top)
            {
                for (int i = 0; i < col.Count; i++)
                {
                    if (i == 0) line += L_T;
                    else line += C_T;

                    for (int j = 0; j < col[i]; j++) line += L_H;

                    if (i == col.Count - 1) line += R_T;
                }
            }

            if (fg == TypeFranja.Center)
            {
                for (int i = 0; i < col.Count; i++)
                {
                    if (i == 0) line += L_C;
                    else line += C_C;

                    for (int j = 0; j < col[i]; j++) line += L_H;

                    if (i == col.Count - 1) line += R_C;
                }
            }

            if (fg == TypeFranja.Bot)
            {
                for (int i = 0; i < col.Count; i++)
                {
                    if (i == 0) line += L_B;
                    else line += C_B;

                    for (int j = 0; j < col[i]; j++) line += L_H;

                    if (i == col.Count - 1) line += R_B;
                }
            }

            line += "\n";
            return line;
        }
        private string CrearFila(List<Celda> Row, List<int> Widthcolumn)
        {
            string text = string.Empty;

            for (int i = 0; i < Row.Count; i++)
            {
                if (i == 0) text += L_V;
                text += TextoRelleno(Row[i].Text, Widthcolumn[i], Row[i].HorizontalAlign, Padding);
                text += L_V;
            }
            text += "\n";
            return text;
        }

        private string TextoRelleno(string text, int leng, AlignHorizontal alignHorizontal = AlignHorizontal.Left, int Padding = 0)
        {
            string newText = string.Empty;
            if (text.Length > leng)
            {
                newText = text.Substring(0, leng);
            }

            if (text.Length == leng) newText = text;

            if (text.Length < leng)
            {
                int dif = leng - text.Length - (Padding * 2);
                string rell = string.Empty;


                for (int i = 0; i < dif; i++) rell += SPACE;

                for (int i = 0; i < Padding; i++) newText += SPACE;

                if (alignHorizontal == AlignHorizontal.Left) newText += text + rell;
                if (alignHorizontal == AlignHorizontal.Right) newText += rell + text;
                if (alignHorizontal == AlignHorizontal.Center) newText += rell.Insert((int)dif / 2, text);

                for (int i = 0; i < Padding; i++) newText += SPACE;
            }

            return newText;
        }
        private int calculateWidthAction(List<Celda> Row)
        {
            int max = 0;

            foreach (Celda celda in Row)
            {
                if (celda.Text.Length > max)
                {
                    max = celda.Text.Length;
                }
            }

            return max;
        }

        public override string ToString()
        {
            return GenerarTabla();
        }

    }
    public enum TypeFranja
    {
        Top, Bot, Center
    }
}
