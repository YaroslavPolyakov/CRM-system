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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Delete : Window
    {
        
        public Delete()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

               /* using (CRMContext dbContext = new CRMContext())
                {
                    BD.Tasks t = new BD.Tasks();
                    t.Id = Id;
                    foreach (var item in dbContext.Tasks)
                    {
                        if (item.Id == t.Id)
                        {
                            dbContext.Tasks.Remove(item);
                            dbContext.SaveChanges();
                        }
                    }
                }
            */
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
