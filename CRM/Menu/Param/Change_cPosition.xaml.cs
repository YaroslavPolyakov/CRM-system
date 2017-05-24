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
    public partial class Change_cPosition : Window
    {
        BD.CatalogPositions position;
        public Change_cPosition(BD.CatalogPositions rp)
        {
            InitializeComponent();
            using (CRMContext dbContext = new CRMContext())
            {
                position = dbContext.CatalogPositions.Find(rp.Position);
                l_id.Text = position.Position;
                l_id_Copy.Text = position.Pay.Value.ToString();
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                position.Position = l_id.Text;
                position.Pay = Convert.ToInt16(l_id_Copy.Text);
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
