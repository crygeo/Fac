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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Utilidades.UserControls
{
    /// <summary>
    /// Lógica de interacción para ButtonType01.xaml
    /// </summary>
    public partial class ButtonType01 : UserControl
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                  typeof(string),
                                                                                  typeof(ButtonType01),
                                                                                  new PropertyMetadata("Hello"));

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon),
                                                                                  typeof(Brush),
                                                                                  typeof(ButtonType01),
                                                                                  new PropertyMetadata(null));

        public static readonly DependencyProperty BackgroundOneProperty = DependencyProperty.Register(nameof(BackgroundOne),
                                                                                  typeof(SolidColorBrush),
                                                                                  typeof(ButtonType01),
                                                                                  new PropertyMetadata(new SolidColorBrush(Colors.Blue)));

        public static readonly DependencyProperty BackgroundTwoProperty = DependencyProperty.Register(nameof(BackgroundTwo),
                                                                                  typeof(SolidColorBrush),
                                                                                  typeof(ButtonType01),
                                                                                  new PropertyMetadata(null));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius),
                                                                                 typeof(CornerRadius),
                                                                                 typeof(ButtonType01),
                                                                                 new PropertyMetadata(null));

        public static readonly DependencyProperty MarginInternoProperty = DependencyProperty.Register(nameof(MarginInterno),
                                                                                 typeof(Thickness),
                                                                                 typeof(ButtonType01),
                                                                                 new PropertyMetadata(null));




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

        private readonly Storyboard StoryboardMouseOverEntrada;
        private readonly Storyboard StoryboardMouseOverSalida;

        public ButtonType01()
        {
            InitializeComponent();

            StoryboardMouseOverEntrada = new Storyboard();
            StoryboardMouseOverSalida = new Storyboard();
        }



        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
