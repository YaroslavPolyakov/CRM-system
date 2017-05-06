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
using CRM.BD;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        public Clients(ref Grid rG)
        {
            InitializeComponent();
            Menu m = new Menu(rG, p_Clients);
            G1.Children.Add(m);

            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.Clients)
                {
                    dg_Clients.Items.Add(item);
                }
            }

        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Add add_Zad = new Add();
            add_Zad.Show();
        }

        private void Button_Change(object sender, RoutedEventArgs e)
        {
            //Change change_Zad = new Change();
            //change_Zad.Show();
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            Delete delete_Zad = new Delete((BD.Clients)dg_Clients.SelectedItem);
            delete_Zad.Show();
        }
    }
}
