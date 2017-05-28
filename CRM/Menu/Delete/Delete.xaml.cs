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
            if (m.Name != "Харсеко Никита Игоревич") del_obj = m;
        }
        public Delete(BD.Clients c)
        {
            InitializeComponent();
            del_obj = c;
        }
        public Delete(BD.CatalogGroupManagers cg)
        {
            InitializeComponent();
            del_obj = cg;
        }
        public Delete(BD.CatalogPositions cp)
        {
            InitializeComponent();
            del_obj = cp;
        }
        public Delete(BD.CatalogStatus cs)
        {
            InitializeComponent();
            del_obj = cs;
        }
        public Delete(BD.CatalogTasks ct)
        {
            InitializeComponent();
            del_obj = ct;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка! Сначала удалите задачи c этим менеджером/клиентом!" );
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
