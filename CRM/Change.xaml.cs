using CRM.BD;
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

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        public BD.Tasks del_task = null;
        public Change(BD.Tasks task)
        {
            InitializeComponent();
            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.CatalogTasks)
                {
                    l_task.Items.Add(item.Task);
                }
                foreach (var item in dbContext.CatalogStatus)
                {
                    l_status.Items.Add(item.Status);
                }
                foreach (var item in dbContext.Managers)
                {
                    l_manager.Items.Add(item.Name);
                }
                foreach (var item in dbContext.Clients)
                {
                    l_client.Items.Add(item.Name);
                }
                l_id.Text = task.Id.ToString();
                l_manager.Text = task.Manager;
                l_info.Text = task.Info;
                l_status.Text = task.Status;
                l_client.Text = task.Client;
                l_task.Text = task.Task;
                d_complete.SelectedDate = task.DateComplete;
                d_start.SelectedDate = task.DateStart;
                del_task = task;               
            }
            
            
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                
                var task = new BD.Tasks();
                task.Id = Convert.ToInt32(l_id.Text);
                task.Client = l_client.Text;
                task.Manager = l_manager.Text;
                task.Task = l_task.Text;
                task.Info = l_info.Text;
                task.Status = l_status.Text;
                task.DateStart = d_start.SelectedDate;
                task.DateComplete = d_complete.SelectedDate;
                dbContext.Entry(del_task).State = System.Data.Entity.EntityState.Deleted;
                dbContext.Tasks.Add(task);
                dbContext.SaveChanges();
            }
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void l_status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
