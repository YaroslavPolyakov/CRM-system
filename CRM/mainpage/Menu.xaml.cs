﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Zadachi(object sender, RoutedEventArgs e)
        {
            //mainWnd.MainBorder.Visibility = Visibility.Collapsed;
        }

        private void Button_Command(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Clients(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Param(object sender, RoutedEventArgs e)
        {

        }
    }
}
