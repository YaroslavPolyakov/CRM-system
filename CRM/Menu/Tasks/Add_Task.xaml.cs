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
using System.ComponentModel.DataAnnotations;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
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
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                var task = new BD.Tasks();
                Random rnd = new Random();
                try
                {
                    int i = 1 + rnd.Next(10000);
                    task.Id = i;
                }
                catch (Exception)
                {
                    MessageBox.Show("Повторите попытку");
                }
                task.Client = l_client.Text;
                task.Manager = l_manager.Text;
                task.Task = l_task.Text;
                task.Info = l_info.Text;
                task.Status = l_status.Text;
                task.DateStart = d_start.SelectedDate;
                task.DateComplete = d_complete.SelectedDate;

                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(task);
                if (!Validator.TryValidateObject(task, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    dbContext.Tasks.Add(task);
                    dbContext.SaveChanges();
                }
                if (Validator.TryValidateObject(task, context, results, true))
                {
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
