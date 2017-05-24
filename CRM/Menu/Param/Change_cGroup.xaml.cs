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
                dbContext.Entry(group).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                
            }

            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
