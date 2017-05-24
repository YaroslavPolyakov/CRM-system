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
    public partial class Add_cPositions : Window
    {
        public Add_cPositions()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                var position = new BD.CatalogPositions();
                position.Position = l_position.Text;
                if (l_pay.Text != "") position.Pay = Convert.ToDecimal(l_pay.Text);
                else position.Pay = Convert.ToDecimal(1);
                
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(position);
                if (!Validator.TryValidateObject(position, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    dbContext.CatalogPositions.Add(position);
                    dbContext.SaveChanges();
                }
                if (Validator.TryValidateObject(position, context, results, true))
                {
                    this.Close();
                }

            }
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
