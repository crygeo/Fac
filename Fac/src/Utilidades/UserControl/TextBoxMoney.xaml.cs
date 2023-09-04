using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Utilidades.UserControls
{

    public partial class TextBoxMoney: UserControl
    {

        public static readonly DependencyProperty MoneyProperty = DependencyProperty.Register(nameof(Money),
                                                                                             typeof(double),
                                                                                             typeof(TextBoxMoney),
                                                                                             new PropertyMetadata((double)0));

        public static readonly DependencyProperty NameElmentProperty = DependencyProperty.Register(nameof(NameElment),
                                                                                             typeof(string),
                                                                                             typeof(TextBoxMoney));

        public static readonly DependencyProperty BackgroundOneProperty = DependencyProperty.Register(nameof(BackgroundOne),
                                                                                          typeof(SolidColorBrush),
                                                                                          typeof(TextBoxMoney),
                                                                                          new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public static readonly DependencyProperty BorderBrushOneProperty = DependencyProperty.Register(nameof(BorderBrushOne),
                                                                                          typeof(SolidColorBrush),
                                                                                          typeof(TextBoxMoney),
                                                                                          new PropertyMetadata(new SolidColorBrush(Colors.Blue)));



        public double Money
        {
            get { return (double)GetValue(MoneyProperty); }
            set { SetValue(MoneyProperty, value); }
        }

        public string NameElment
        {
            get { return (string)GetValue(NameElmentProperty); }
            set { SetValue(NameElmentProperty, value); }
        }

        public SolidColorBrush BackgroundOne
        {
            get { return (SolidColorBrush)GetValue(BackgroundOneProperty); }
            set { SetValue(BackgroundOneProperty, value); }
        }

        public SolidColorBrush BorderBrushOne
        {
            get { return (SolidColorBrush)GetValue(BorderBrushOneProperty); }
            set { SetValue(BorderBrushOneProperty, value); }
        }

        public TextBoxMoney()
        {

            InitializeComponent();

        }

        private void tBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Verifica si el carácter es un dígito o un punto decimal
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != ".")
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }

            // Verifica si ya hay un punto decimal en el TextBox
            if (e.Text == "." && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Cancela la entrada de múltiples puntos decimales
            }
        }

        private void tBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }
    }


}
