﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Comberts
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    namespace Converters
    {
        public class CobradoConverterInverso : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool cobrado)
                {
                    return cobrado ? "Sin Cobrar" : "Cobrado";
                }
                return ""; // Valor predeterminado si no es un valor booleano
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

}
