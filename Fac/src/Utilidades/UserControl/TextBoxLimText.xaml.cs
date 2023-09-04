using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Utilidades.UserControls
{
   
    public partial class TextBoxLimText : UserControl
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                             typeof(string),
                                                                                             typeof(TextBoxLimText),
                                                                                             new PropertyMetadata(""));

        public static readonly DependencyProperty NameElmentProperty = DependencyProperty.Register(nameof(NameElment),
                                                                                             typeof(string),
                                                                                             typeof(TextBoxLimText));

        public static readonly DependencyProperty LengthTextProperty = DependencyProperty.Register(nameof(LengthText),
                                                                                            typeof(int),
                                                                                            typeof(TextBoxLimText));

        public static readonly DependencyProperty VisibleCountProperty = DependencyProperty.Register(nameof(VisibleCount),
                                                                                           typeof(Visibility),
                                                                                           typeof(TextBoxLimText));

        public static readonly DependencyProperty ReturnProperty = DependencyProperty.Register(nameof(Return),
                                                                                          typeof(bool),
                                                                                          typeof(TextBoxLimText));

        public static readonly DependencyProperty BackgroundOneProperty = DependencyProperty.Register(nameof(BackgroundOne),
                                                                                          typeof(SolidColorBrush),
                                                                                          typeof(TextBoxLimText),
                                                                                          new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public static readonly DependencyProperty BorderBrushOneProperty = DependencyProperty.Register(nameof(BorderBrushOne),
                                                                                          typeof(SolidColorBrush),
                                                                                          typeof(TextBoxLimText),
                                                                                          new PropertyMetadata(new SolidColorBrush(Colors.Blue)));

        public static readonly DependencyProperty SoloNumerosProperty = DependencyProperty.Register(nameof(SoloNumeros),
                                                                                         typeof(bool),
                                                                                         typeof(TextBoxLimText),
                                                                                         new PropertyMetadata(false, SoloNumerosChanged));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string NameElment
        {
            get { return (string)GetValue(NameElmentProperty); }
            set { SetValue(NameElmentProperty, value); }
        }

        public int LengthText
        {
            get { return (int)GetValue(LengthTextProperty); }
            set { SetValue(LengthTextProperty, value); }
        }

        public Visibility VisibleCount
        {
            get { return (Visibility)GetValue(VisibleCountProperty); }
            set { SetValue(VisibleCountProperty, value); }
        }

        public bool Return
        {
            get { return (bool)GetValue(ReturnProperty); }
            set { SetValue(ReturnProperty, value); }
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


        public bool SoloNumeros
        {
            get { return (bool)GetValue(SoloNumerosProperty); }
            set { SetValue(SoloNumerosProperty, value); }
        }
        public TextBoxLimText()
        {

            InitializeComponent();

        }

        private void tBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (SoloNumeros && !char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // Evita que se ingrese el carácter no numérico
            }
        }

        private static void SoloNumerosChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBoxLimText textBoxLimText)
            {
                bool newValue = (bool)e.NewValue;
                textBoxLimText.SoloNumeros = newValue;
            }
        }

        private void tBox_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.CaretIndex = 0;
            }
        }
    }


}
