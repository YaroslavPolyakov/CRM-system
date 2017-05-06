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
        object del_obj;
        public Delete(BD.Tasks t)
        {
            InitializeComponent();
            del_obj = t;
        }
        public Delete(BD.Managers m)
        {
            InitializeComponent();
            del_obj = m;
        }
        public Delete(BD.Clients c)
        {
            InitializeComponent();
            del_obj = c;
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (del_obj != null)
            {
                    using (CRMContext dbContext = new CRMContext())
                    {
                        dbContext.Entry(del_obj).State = System.Data.Entity.EntityState.Deleted;
                        dbContext.SaveChanges();
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
