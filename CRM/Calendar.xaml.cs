using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// 

    public partial class Calendar : UserControl
    {

       public class Person
        {
            public string Name { get; set; }
        }
        private List<Person> GenerateData()
        {
            using (CRMContext dbContext = new CRMContext())
            {
                List<Person> personList = new List<Person>();
                foreach (var item in dbContext.Managers)
                {
                    personList.Add(new Person { Name = item.Name.ToString() });
                }
                return personList;
            }
            
        }


        public Calendar(ref Grid rG)
        {
            InitializeComponent();
            Menu m = new Menu(rG, p_Calendar);
            G1.Children.Add(m);

            List<Person> personList = new List<Person>();


            using (CRMContext dbContext = new CRMContext())
            {
                //добавление менеджеров
                foreach (var item in GenerateData())
                {
                    DateTime date_t = DateTime.Now;
                    DateTime end_date_t = date_t.AddMonths(1);
                    for (; date_t != end_date_t; date_t = date_t.AddDays(1))
                    {
                        
                    }
                    dg_Calendar.Items.Add(item);
                }
                //добавление колонок
                DateTime date = DateTime.Now;
                DateTime end_date = date.AddMonths(1);
                for (; date != end_date; date = date.AddDays(1))
                {
                    DataGridColumn MyDataGridComboBoxColumn1 = new DataGridTextColumn();
                    MyDataGridComboBoxColumn1.Header = date.ToString(" dd\nMMM", CultureInfo.CreateSpecificCulture("ru-RU"));
                    dg_Calendar.Columns.Add(MyDataGridComboBoxColumn1);
                }
            }
        }
    }
}
