using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public partial class Change_cGroup : Window
    {
        BD.CatalogGroupManagers group;
        public Change_cGroup(BD.CatalogGroupManagers rg)
        {
            InitializeComponent();
            using (CRMContext dbContext = new CRMContext())
            {
                group = dbContext.CatalogGroupManagers.Find(rg.Group);
                l_id.Text = group.Group;
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                group.Group = l_id.Text;
                
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(group);
                if (!Validator.TryValidateObject(group, context, results, true))
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
                        dbContext.Entry(group).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
                if (Validator.TryValidateObject(group, context, results, true))
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
