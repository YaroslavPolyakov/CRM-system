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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRM.BD;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar(ref Grid rG)
        {
            InitializeComponent();
            Menu m = new Menu(rG, p_Calendar);
            G1.Children.Add(m);

            using (CRMContext dbContext = new CRMContext())
            {
                
            }

        }
    }
}
