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
using System.Windows.Forms;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Param.xaml
    /// </summary>
    /*Параметры приложения 
     !вход только администраторам
     -изменение логотипа
     -редактор каталогов
     -поверх всех окон
     -статистика
     

     */
    public partial class Param : System.Windows.Controls.UserControl
    {

        public Param(ref Grid rG)
        {
            
            InitializeComponent();
            Menu m = new Menu(rG, p_Param);
            G1.Children.Add(m);
            using (CRMContext dbContext = new CRMContext())
            {
                int cl=0, ma = 0, ta = 0, tcp = 0,tnp=0, tp = 0, tc = 0,mt=0,mw=0,mm=0;
                foreach (var item in dbContext.Clients)
                {
                    cl++;
                }
                foreach (var item in dbContext.Managers)
                {
                    ma++;
                    if (item.DateRecruitment<=DateTime.Today && item.DateRecruitment > (DateTime.Today).AddDays(-1)) mt++;
                    if (item.DateRecruitment <= (DateTime.Today).AddDays(-1) && item.DateRecruitment >= (DateTime.Today).AddDays(-7)) mw++;
                    if (item.DateRecruitment <= (DateTime.Today).AddDays(-7) && item.DateRecruitment >= (DateTime.Today).AddMonths(-1)) mm++;
                }
                foreach (var item in dbContext.Tasks)
                {
                    ta++;
                    if (item.CatalogStatus.Status == "Выполнена") tcp++;
                    if (item.CatalogStatus.Status == "Отменена") tc++;
                    if (item.CatalogStatus.Status == "Не выполнена") tnp++;
                    if (item.CatalogStatus.Status == "В процессе") tp++;
                }
                countTask.Content = ta;
                countClients.Content = cl;
                countManagers.Content = ma;
                countComplete.Content = tcp;
                countCancel.Content = tc;
                countNoComplete.Content = tnp;
                countInProcess.Content = tp;
                countManToday.Content = mt;
                countManWeek.Content = mw;
                countManMonth.Content = mm;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeCatalog F = new ChangeCatalog();
            F.Show();
        }  
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.Tasks)
                {
                    dbContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                foreach (var item in dbContext.Managers)
                {
                    if(item.Name != "Харсеко Никита Игоревич") dbContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                foreach (var item in dbContext.Clients)
                {
                    dbContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                dbContext.SaveChanges();

            }
        }
        public static class csPathToFolder
        {
            public static string PathOfSelectedFolder { get; set; }
            public static string SelectedDrive { get; set; }

        }

        /*private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.setTop(true);
            
        }*/
    }
}
