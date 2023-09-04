using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Utilidades.UserControls
{

    public partial class TextBoxDate : UserControl
    {

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(nameof(Date),
                                                                                             typeof(DateTime),
                                                                                             typeof(TextBoxDate),
                                                                                             new PropertyMetadata(DateTime.Now));

        public static readonly DependencyProperty NameElmentProperty = DependencyProperty.Register(nameof(NameElment),
                                                                                             typeof(string),
                                                                                             typeof(TextBoxDate));

        public static readonly DependencyProperty BackgroundOneProperty = DependencyProperty.Register(nameof(BackgroundOne),
                                                                                          typeof(SolidColorBrush),
                                                                                          typeof(TextBoxDate),
                                                                                          new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public static readonly DependencyProperty BorderBrushOneProperty = DependencyProperty.Register(nameof(BorderBrushOne),
                                                                                          typeof(SolidColorBrush),
                                                                                          typeof(TextBoxDate),
                                                                                          new PropertyMetadata(new SolidColorBrush(Colors.Blue)));



        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
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

        public TextBoxDate()
        {

            InitializeComponent();

        }

        private void tBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                e.Handled = true;

                int caretIndex = textBox.CaretIndex;

                if (e.Text.Length == 0) { return; }

                char newChar = e.Text.ToCharArray()[0];

                if (char.IsDigit(e.Text, e.Text.Length - 1))
                {
                    if (caretIndex < textBox.Text.Length)
                    {

                        if (caretIndex == 2 || caretIndex == 5)
                        {
                            caretIndex++;
                        }


                        if (caretIndex == 0 && int.Parse(e.Text) > 3)
                        {
                            return;
                        }
                        if (caretIndex == 3 && int.Parse(e.Text) > 1)
                        {
                            return;
                        }

                        char[] text = textBox.Text.ToCharArray();

                        text[caretIndex] = newChar;

                        var newDate = new string(text);
                        textBox.Text = newDate;


                        int newCaetIndex = caretIndex + 1;

                        if (!(newCaetIndex < textBox.Text.Length))
                            textBox.CaretIndex = 0;
                        else
                            textBox.CaretIndex = newCaetIndex;

                    }
                }



            }

        }

        private void tBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Space)
            {
                e.Handled = true; // Cancelar el evento para evitar el borrado
            }
        }

        private void tBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.CaretIndex = 0;
            }
        }

        public bool CorrectDate { get; private set; } = true;

        private void tBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                try
                {
                    Date = DateTime.Parse(textBox.Text);
                    CorrectDate = true;
                }
                catch (FormatException ex)
                {
                    CorrectDate = false;
                }
            }
        }
    }


}
