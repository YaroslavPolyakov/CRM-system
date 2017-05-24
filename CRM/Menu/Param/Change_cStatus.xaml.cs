using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using System.Windows.Shapes;
using CRM.BD;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Add_cGroup.xaml
    /// </summary>
    public partial class Change_cStatus : Window
    {
        BD.CatalogStatus status;
        public Change_cStatus(BD.CatalogStatus rs)
        {
            InitializeComponent();
            using (CRMContext dbContext = new CRMContext())
            {
                status = rs;
                l_id.Text = status.Status;
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                status.Status = l_id.Text; var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(status);
                if (!Validator.TryValidateObject(status, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    try
                    {
                        dbContext.Entry(status).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
                if (Validator.TryValidateObject(status, context, results, true))
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
