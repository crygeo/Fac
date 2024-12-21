﻿using Fac.src.ViewModel;
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

namespace Fac.src.View.Inventario
{
    /// <summary>
    /// Lógica de interacción para InventarioView.xaml
    /// </summary>
    public partial class InventarioView : Window
    {
        public InventarioView()
        {
            InitializeComponent();
        }

        private void view_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(Main.DataContext is InventarioViewModel viewModel)
            {
                viewModel.CerrarVentanaCommand.Execute(null);
            }
        }
    }
}
