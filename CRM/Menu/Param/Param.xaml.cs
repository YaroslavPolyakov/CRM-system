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
    /*Параметрый приложения 
     !вход только администраторам
     -изменение логотипа
     -редактор каталогов
     -папка для сохранения xml
     -поверх всех окон
     -шрифты 
     -цвета

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
                int cl=0, ma = 0, ta = 0, tcp = 0,tnp=0, tp = 0, tc = 0;
                foreach (var item in dbContext.Clients)
                {
                    cl++;
                }
                foreach (var item in dbContext.Managers)
                {
                    ma++;
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

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeCatalog F = new ChangeCatalog();
            F.Show();
        }  
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            DialogSelectFolder SelectFolder = new DialogSelectFolder();
            SelectFolder.ShowDialog();
            this.textBlock1.Text = csPathToFolder.PathOfSelectedFolder;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        public static class csPathToFolder
        {
            public static string PathOfSelectedFolder { get; set; }
            public static string SelectedDrive { get; set; }

        }

       
    }
}
