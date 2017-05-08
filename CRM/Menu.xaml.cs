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
        UserControl u = null;
        Grid g = null;
       
        public Menu(Grid rG,UserControl rU)
        {
            InitializeComponent();
            u = rU;
            g = rG;
        }


        private void Button_Tasks(object sender, RoutedEventArgs e)
        {
            u.Visibility = Visibility.Collapsed;
            Tasks T = new Tasks(ref g);
            g.Children.Add(T);
        }

        private void Button_Command(object sender, RoutedEventArgs e)
        {
            u.Visibility = Visibility.Collapsed;
            Managers T = new Managers(ref g);
            g.Children.Add(T);
        }

        private void Button_Clients(object sender, RoutedEventArgs e)
        {
            u.Visibility = Visibility.Collapsed;
            Clients C = new Clients(ref g);
            g.Children.Add(C);
        }

        private void Button_Param(object sender, RoutedEventArgs e)
        {
            /*Param P = new Param();
            P.show();*/
        }

        private void Button_Calendar(object sender, RoutedEventArgs e)
        {
            u.Visibility = Visibility.Collapsed;
            Calendar C = new Calendar(ref g);
            g.Children.Add(C);
        }
    }
}
