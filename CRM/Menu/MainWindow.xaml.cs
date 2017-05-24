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
using System.Data.Entity;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*public static bool TopMostCheck = true;
        public static void setTop(bool x)
        {
            TopMostCheck = false;
        }*/
        
        public MainWindow()
        {
            //Topmost = TopMostCheck;
            InitializeComponent();
            Managers M = new Managers(ref G);
            G.Children.Add(M);
            
            

            

        }

       
    }
}
