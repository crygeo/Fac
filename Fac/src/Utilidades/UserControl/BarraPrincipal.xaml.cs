using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Utilidades.UserControls
{
    /// <summary>
    /// Lógica de interacción para BarraPrincipal.xaml
    /// </summary>
    public partial class BarraPrincipal : UserControl
    {

        public static readonly DependencyProperty MaximizeProperty = DependencyProperty.Register(nameof(Maximize),
                                                                                  typeof(bool),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(true));

        public static readonly DependencyProperty MinimizeProperty = DependencyProperty.Register(nameof(Minimize),
                                                                                  typeof(bool),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(true));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title),
                                                                                  typeof(string),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(""));

        public static readonly DependencyProperty WindowProperty = DependencyProperty.Register(nameof(Window),
                                                                                  typeof(Window),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(null));

        public static readonly DependencyProperty BackgroundProProperty = DependencyProperty.Register(nameof(BackgroundPro),
                                                                                 typeof(SolidColorBrush),
                                                                                 typeof(BarraPrincipal),
                                                                                 new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x29, 0x2B, 0x2F))));

        public static readonly DependencyProperty BackgroundButtonOverProperty = DependencyProperty.Register(nameof(BackgroundButtonOver),
                                                                                typeof(SolidColorBrush),
                                                                                typeof(BarraPrincipal),
                                                                                new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x29, 0x2B, 0x2F))));

        public static readonly DependencyProperty BackgroundButtonClickProperty = DependencyProperty.Register(nameof(BackgroundButtonClick),
                                                                               typeof(SolidColorBrush),
                                                                               typeof(BarraPrincipal),
                                                                               new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x29, 0x2B, 0x2F))));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius),
                                                                               typeof(CornerRadius),
                                                                               typeof(BarraPrincipal),
                                                                               new PropertyMetadata(null));


        public static readonly DependencyProperty BorderBrushInterProperty = DependencyProperty.Register(nameof(BorderBrushInter),
                                                                              typeof(SolidColorBrush),
                                                                              typeof(BarraPrincipal),
                                                                              new PropertyMetadata(null));

        public static readonly DependencyProperty BorderThicknessInterProperty = DependencyProperty.Register(nameof(BorderThicknessInter),
                                                                               typeof(Thickness),
                                                                               typeof(BarraPrincipal),
                                                                               new PropertyMetadata(null));

        //---------------------------------------------------------------------------------------------------------------------------------


        public bool Maximize
        {
            get => (bool)GetValue(MaximizeProperty);
            set => SetValue(MaximizeProperty, value);
        }
        public bool Minimize
        {
            get => (bool)GetValue(MinimizeProperty);
            set => SetValue(MinimizeProperty, value);
        }
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public Window Window
        {
            get => (Window)GetValue(WindowProperty);
            set => SetValue(WindowProperty, value);
        }

        public SolidColorBrush BackgroundPro
        {
            get => (SolidColorBrush)GetValue(BackgroundProProperty);
            set => SetValue(BackgroundProProperty, value);
        }

        public SolidColorBrush BackgroundButtonOver
        {
            get => (SolidColorBrush)GetValue(BackgroundButtonOverProperty);
            set => SetValue(BackgroundButtonOverProperty, value);
        }

        public SolidColorBrush BackgroundButtonClick
        {
            get => (SolidColorBrush)GetValue(BackgroundButtonClickProperty);
            set => SetValue(BackgroundButtonClickProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public SolidColorBrush BorderBrushInter
        {
            get => (SolidColorBrush)GetValue(BorderBrushInterProperty);
            set => SetValue(BorderBrushInterProperty, value);
        }

        public Thickness BorderThicknessInter
        {
            get => (Thickness)GetValue(BorderThicknessInterProperty);
            set => SetValue(BorderThicknessInterProperty, value);
        }

        //--------------------------------------------------------------------------------------

        public BarraPrincipal()
        {
            InitializeComponent();

        }


        //--------------------------------------------------------------------------------------

        private void window_Movible(object sender, MouseButtonEventArgs e)
        {
            if (Window == null) { ErrorWindow(); return; }

            if (e.LeftButton == MouseButtonState.Pressed) Window.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (Window == null) { ErrorWindow(); return; }
            Window.Close();
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            if (Window == null) { ErrorWindow(); return; }

            Window.WindowState = (Window.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            if (Window == null) { ErrorWindow(); return; }
            Window.WindowState = WindowState.Minimized;
        }

        private static void ErrorWindow()
        {
            throw new Exception("No hay ventana en que interacctuar, Name=\"NombreWindow\" & Window=\"{Binding ElementName=NombreDeLaVentana}\"");
        }

    }
}
