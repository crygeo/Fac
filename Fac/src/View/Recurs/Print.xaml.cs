using Fac.src.Dats.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fac.src.View.Recurs
{
    /// <summary>
    /// Lógica de interacción para Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        public Print(Uri uri)
        {
            InitializeComponent();
            web.Navigate(uri);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintHtml(web);
        }

        public static void PrintHtml(WebBrowser webBrowser)
        {
            if (webBrowser == null)
                throw new ArgumentNullException(nameof(webBrowser));

            // Crea un flujo de impresión.
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Captura el flujo de impresión.
                var paginator = ((IDocumentPaginatorSource)webBrowser.Document).DocumentPaginator;

                // Establece las configuraciones de impresión.
                paginator.PageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

                // Imprime el documento.
                printDialog.PrintDocument(paginator, "Documento HTML");
            }
        }
      
    }
}
