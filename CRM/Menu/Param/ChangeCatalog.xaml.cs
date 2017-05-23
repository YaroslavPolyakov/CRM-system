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
using CRM.BD;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для ChangeCatalog.xaml
    /// </summary>
    public partial class ChangeCatalog : Window
    {
        public ChangeCatalog()
        {
            InitializeComponent();
            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.CatalogGroupManagers)
                {
                    dg_cGroup.Items.Add(item);
                }
                foreach (var item in dbContext.CatalogPositions)
                {
                    dg_cPositions.Items.Add(item);
                }
                foreach (var item in dbContext.CatalogStatus)
                {
                    dg_cStatus.Items.Add(item);
                }
                foreach (var item in dbContext.CatalogTasks)
                {
                    dg_cTask.Items.Add(item);
                }
            }
        }

        private void Button_Add1(object sender, RoutedEventArgs e)
        {
            Add_cGroup w = new Add_cGroup();
            w.Show();
        }
        private void Button_Add2(object sender, RoutedEventArgs e)
        {
            Add_cTask w = new Add_cTask();
            w.Show();
        }
        private void Button_Add3(object sender, RoutedEventArgs e)
        {
            Add_cPositions w = new Add_cPositions();
            w.Show();
        }
        private void Button_Add4(object sender, RoutedEventArgs e)
        {
            Add_cStatus w = new Add_cStatus();
            w.Show();
        }

        private void Button_Change(object sender, RoutedEventArgs e)
        {
            if (dg_cGroup.SelectedItem != null)
            {
                Change_cGroup D = new Change_cGroup((BD.CatalogGroupManagers)dg_cGroup.SelectedItem);
                D.Show();
                dg_cGroup.SelectedItem = null;
            }
            if (dg_cPositions.SelectedItem != null)
            {
                Change_cPosition D = new Change_cPosition((BD.CatalogPositions)dg_cPositions.SelectedItem);
                D.Show();
                dg_cPositions.SelectedItem = null;
            }
            if (dg_cTask.SelectedItem != null)
            {
                Change_cTask D = new Change_cTask((BD.CatalogTasks)dg_cTask.SelectedItem);
                D.Show();
                dg_cTask.SelectedItem = null;
            }
            if (dg_cStatus.SelectedItem != null)
            {
                Change_cStatus D = new Change_cStatus((BD.CatalogStatus)dg_cStatus.SelectedItem);
                D.Show();
                dg_cStatus.SelectedItem = null;
            }
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            if (dg_cGroup.SelectedItem != null)
            {
                Delete D = new Delete((BD.CatalogGroupManagers)dg_cGroup.SelectedItem);
                D.Show();
            }
            if (dg_cPositions.SelectedItem != null)
            {
                Delete D = new Delete((BD.CatalogPositions)dg_cPositions.SelectedItem);
                D.Show();
            }
            if (dg_cTask.SelectedItem != null)
            {
                Delete D = new Delete((BD.CatalogTasks)dg_cTask.SelectedItem);
                D.Show();
            }
            if (dg_cStatus.SelectedItem != null)
            {
                Delete D = new Delete((BD.CatalogStatus)dg_cStatus.SelectedItem);
                D.Show();
            }
        }
    }
}
