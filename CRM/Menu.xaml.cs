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
       /* public Menu(FrameworkElement main)
        {
            InitializeComponent();
            if (main is Grid)
            {
                var m = (Grid)main;
                _main = m;
            }
            
        }
        private Grid _main;*/

        private void Button_Zadachi(object sender, RoutedEventArgs e)
        {
            
            //_main.Children.Clear();
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
