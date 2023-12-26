using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Funciones.StyleConsole.Extras
{
    public class Celda
    {
        private int _height;
        private int _width;
        private AlignVertical _verticalAlign;
        private AlignHorizontal _horizontalAlign;
        private string _text;

        public Celda()
        {
            Height = 0;
            Width = 0;
            _horizontalAlign = AlignHorizontal.Left;
            _verticalAlign = AlignVertical.Top;
            Text = string.Empty;
        }

        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public AlignVertical VerticalAlign { get => _verticalAlign; set => _verticalAlign = value; }
        public AlignHorizontal HorizontalAlign { get => _horizontalAlign; set => _horizontalAlign = value; }
        public string Text { get => _text; set => _text = value; }
    }
}
