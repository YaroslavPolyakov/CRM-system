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
    /// Логика взаимодействия для Team.xaml
    /// </summary>
    public partial class Team : UserControl
    {
        public Team(ref Grid rG)
        {
            InitializeComponent();
            Menu m = new Menu(rG, p_Team);
            G1.Children.Add(m);

        }


        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Add add_Zad = new Add();
            add_Zad.Show();
        }

        private void Button_Change(object sender, RoutedEventArgs e)
        {
            Change change_Zad = new Change();
            change_Zad.Show();
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            Delete delete_Zad = new Delete();
            delete_Zad.Show();
        }

    }
}
