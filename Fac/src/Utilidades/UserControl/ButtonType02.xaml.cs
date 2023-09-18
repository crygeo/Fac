using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Utilidades.UserControls
{
    /// <summary>
    /// Lógica de interacción para ButtonType01.xaml
    /// </summary>
    public partial class ButtonType02 : UserControl
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                  typeof(string),
                                                                                  typeof(ButtonType02),
                                                                                  new PropertyMetadata("Hello"));

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon),
                                                                                  typeof(Brush),
                                                                                  typeof(ButtonType02),
                                                                                  new PropertyMetadata(null));

        public static readonly DependencyProperty BackgroundOneProperty = DependencyProperty.Register(nameof(BackgroundOne),
                                                                                  typeof(SolidColorBrush),
                                                                                  typeof(ButtonType02),
                                                                                  new PropertyMetadata(new SolidColorBrush(Colors.Blue), changedEventBackgroundOne));


        public static readonly DependencyProperty BackgroundTwoProperty = DependencyProperty.Register(nameof(BackgroundTwo),
                                                                                  typeof(SolidColorBrush),
                                                                                  typeof(ButtonType02),
                                                                                  new PropertyMetadata(null, changedEventBackgroundTwo));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius),
                                                                                 typeof(CornerRadius),
                                                                                 typeof(ButtonType02),
                                                                                 new PropertyMetadata(null));

        public static readonly DependencyProperty MarginInternoProperty = DependencyProperty.Register(nameof(MarginInterno),
                                                                                 typeof(Thickness),
                                                                                 typeof(ButtonType02),
                                                                                 new PropertyMetadata(null));


        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command),
                                                                                typeof(ICommand),
                                                                                typeof(ButtonType02),
                                                                                new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(nameof(CommandParameter),
                                                                               typeof(object),
                                                                               typeof(ButtonType02));



        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Brush Icon
        {
            get => (Brush)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public SolidColorBrush BackgroundOne
        {
            get => (SolidColorBrush)GetValue(BackgroundOneProperty);
            set => SetValue(BackgroundOneProperty, value);

        }

        public SolidColorBrush BackgroundTwo
        {
            get => (SolidColorBrush)GetValue(BackgroundTwoProperty);
            set => SetValue(BackgroundTwoProperty, value);

        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Thickness MarginInterno
        {
            get => (Thickness)GetValue(MarginInternoProperty);
            set => SetValue(MarginInternoProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }



        private Duration duration = new(TimeSpan.FromMilliseconds(200));
        private ColorAnimation? colorAnimationEntre;
        private ColorAnimation? colorAnimationLeave;

        private const int DoubleClickInterval = 300;

        private DateTime lastClickTime = DateTime.Now;

        public ButtonType02()
        {
            InitializeComponent();

        }


        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BackgroundTwo != null)
            {
                BackgroundOne.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimationEntre);
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BackgroundTwo != null)
            {
                BackgroundOne.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimationLeave);
            }
        }



        private static void changedEventBackgroundOne(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ButtonType02 buttonType02)
            {
                if ((buttonType02.colorAnimationEntre == null || buttonType02.colorAnimationLeave == null) && buttonType02.BackgroundTwo != null)
                {
                    var colorOne = buttonType02.BackgroundOne.Color;
                    var colorTwo = buttonType02.BackgroundTwo.Color;

                    buttonType02.colorAnimationEntre = new ColorAnimation(colorOne, colorTwo, buttonType02.duration);
                    buttonType02.colorAnimationLeave = new ColorAnimation(colorTwo, colorOne, buttonType02.duration);
                }
            }
        }

        private static void changedEventBackgroundTwo(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ButtonType02 buttonType02)
            {
                if ((buttonType02.colorAnimationEntre == null || buttonType02.colorAnimationLeave == null) && buttonType02.BackgroundTwo != null)
                {
                    var colorOne = buttonType02.BackgroundOne.Color;
                    var colorTwo = buttonType02.BackgroundTwo.Color;

                    buttonType02.colorAnimationEntre = new ColorAnimation(colorOne, colorTwo, buttonType02.duration);
                    buttonType02.colorAnimationLeave = new ColorAnimation(colorTwo, colorOne, buttonType02.duration);
                }
            }
        }

        private void border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - lastClickTime).TotalMilliseconds <= DoubleClickInterval)
            {
                // Doble clic detectado
                lastClickTime = DateTime.Now;

                // Aquí puedes poner tu lógica para manejar el doble clic en el Border
                DoubleClickLeft();
            }
            else
            {
                // Primer clic
                lastClickTime = DateTime.Now;

            }
        }

        private void DoubleClickLeft()
        {
            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(CommandParameter);
            }
        }

    }
}
