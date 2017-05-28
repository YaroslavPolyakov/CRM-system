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
using XMLE;

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

            if (!IAm.isAdmin)
            {
                dg_Managers.Columns.Remove(dgc_address);
                dg_Managers.Columns.Remove(dgc_dateB);
                dg_Managers.Columns.Remove(dgc_dateR);
                dg_Managers.Columns.Remove(dgc_login);
                dg_Managers.Columns.Remove(dgc_pass);
                b_o.Visibility = Visibility.Collapsed;
            }

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
            if (IAm.isAdmin)
            {
                Add_Manager add_Manager = new Add_Manager();
                add_Manager.Show();
            }
            else
            {
                MessageBox.Show("Вы не имеете прав на добавление менеджеров!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Change(object sender, RoutedEventArgs e)
        {
            if (dg_Managers.SelectedItem != null)
            {
                if (IAm.isAdmin || IAm.myName == ((BD.Managers)dg_Managers.SelectedItem).Name)
                {
                    Change_Manager change_Task = new Change_Manager((BD.Managers)dg_Managers.SelectedItem);
                    change_Task.Show();
                }
                else
                {
                    MessageBox.Show("Вы не имеете прав на изменение этого менеджера!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите менеджера.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {


            if (dg_Managers.SelectedItem != null)
            {
                if (IAm.isAdmin && IAm.myName != ((BD.Managers)dg_Managers.SelectedItem).Name)
                {
                    Delete delete_Task = new Delete((BD.Managers)dg_Managers.SelectedItem);
                    delete_Task.Show();
                }
                else
                {
                    MessageBox.Show("Вы не имеете прав на удаление этого менеджера!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите менеджера.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            List<BD.Managers> manager = new List<BD.Managers>();
            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.Managers)
                {
                    manager.Add(item);
                }
            }
            XMLE.XML.Save_Managers(manager);
        }

        private void Button_Open(object sender, RoutedEventArgs e)
        {
            List<BD.Managers> manager = new List<BD.Managers>();
            XML.openXml_managers();
        }

    }
}
