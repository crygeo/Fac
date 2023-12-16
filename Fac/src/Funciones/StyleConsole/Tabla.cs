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

        private int _widthcolumn;
        private bool autowidth;

        private List<List<Celda>> Table;

        public int LengtCols { get => _lengtCols; set => _lengtCols = value; }
        public int LengtRows { get => _lengtRows; set => _lengtRows = value; }
        public int Widthcolumn { get => _widthcolumn; set { _widthcolumn = value; autowidth = false; } }

        public Tabla(int lengtCols = -1, int lengtRows = -1)
        {
            this.LengtCols = lengtCols;
            this.LengtRows = lengtRows;
            this.autowidth = true;


            Table = new();
        }


        public void AddRow(List<Celda> Row)
        {
            if (Row.Count > LengtCols && LengtCols != -1) throw new Exception($"La fila {Table.Count} a agregar tiene muchas columnas cuando el limite es de {LengtCols} columnas.");
            if (Table.Count >= LengtRows && LengtRows != -1) throw new Exception($"No puedes agregar mas fila a esta tabla, el limite son {LengtRows} filas.");
            if (autowidth)
            {
                int newWi = calculateWidthAction(Row);
                if(Widthcolumn < newWi) Widthcolumn = newWi;
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
                rowText += CrearFranja(TypeFranja.Top, Row.Count, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
                rowText += CrearFranja(TypeFranja.Bot, Row.Count, Widthcolumn);
            }

            if (typeRow == TypeRow.StarRow)
            {
                rowText += CrearFranja(TypeFranja.Top, Row.Count, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
            }

            if (typeRow == TypeRow.CenterRow)
            {
                rowText += CrearFranja(TypeFranja.Center, Row.Count, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
            }

            if (typeRow == TypeRow.FinalRow)
            {
                rowText += CrearFranja(TypeFranja.Center, Row.Count, Widthcolumn);
                rowText += CrearFila(Row, Widthcolumn);
                rowText += CrearFranja(TypeFranja.Bot, Row.Count, Widthcolumn);
            }

            return rowText;
        }

        private string CrearFranja(TypeFranja fg, int col, int x)
        {
            string line = string.Empty;

            if (fg == TypeFranja.Top)
            {
                for (int i = 0; i < col; i++)
                {
                    if (i == 0) line += L_T;
                    else line += C_T;

                    for (int j = 0; j < x; j++) line += L_H;

                    if (i == col - 1) line += R_T;
                }
            }

            if (fg == TypeFranja.Center)
            {
                for (int i = 0; i < col; i++)
                {
                    if (i == 0) line += L_C;
                    else line += C_C;

                    for (int j = 0; j < x; j++) line += L_H;

                    if (i == col - 1) line += R_C;
                }
            }

            if (fg == TypeFranja.Bot)
            {
                for (int i = 0; i < col; i++)
                {
                    if (i == 0) line += L_B;
                    else line += C_B;

                    for (int j = 0; j < Widthcolumn; j++) line += L_H;

                    if (i == col - 1) line += R_B;
                }
            }

            line += "\n";
            return line;
        }
        private string CrearFila(List<Celda> Row, int Widthcolumn)
        {
            string text = string.Empty;

            for (int i = 0; i < Row.Count; i++)
            {
                if (i == 0) text += L_V;
                text += TextoRelleno(Row[i].Text, Widthcolumn, Row[i].HorizontalAlign);
                text += L_V;
            }
            text += "\n";
            return text;
        }

        private string TextoRelleno(string text, int leng, AlignHorizontal alignHorizontal = AlignHorizontal.Left)
        {
            string newText = string.Empty;
            if (text.Length > leng)
            {
                newText = text.Substring(0, leng);
            }

            if (text.Length == leng) newText = text;

            if (text.Length < leng)
            {
                int dif = leng - text.Length;
                string rell = string.Empty;
                for (int i = 0; i < dif; i++) rell += SPACE;

                if (alignHorizontal == AlignHorizontal.Left) newText = text + rell;
                if (alignHorizontal == AlignHorizontal.Right) newText = rell + text;
                if (alignHorizontal == AlignHorizontal.Center) newText = rell.Insert((int)dif / 2, text);
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
