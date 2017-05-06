using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Team.xaml
    /// </summary>
    public partial class Managers : UserControl
    {
        public Managers(ref Grid rG)
        {
            InitializeComponent();
            Menu m = new Menu(rG, p_Managers);
            G1.Children.Add(m);
             


            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.Managers)
                {
                    dg_Managers.Items.Add(item);
                }
            }

        }


        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Add_Manager add_Manager = new Add_Manager();
            add_Manager.Show();
        }

        private void Button_Change(object sender, RoutedEventArgs e)
        {
            
            Change_Manager change_Task = new Change_Manager((BD.Managers)dg_Managers.SelectedItem);
            change_Task.Show();
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            Delete delete_Task = new Delete();
            delete_Task.Show();
        }

    }
}
