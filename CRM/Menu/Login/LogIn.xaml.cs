using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {

        public LogIn()
        {
            InitializeComponent();
           
        }


        



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            


            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.Managers)
                {
                    if(Hash.PasswordsMatch(Hash.EncryptPassword(loginTextBox.Text,passwordPasswordBox.Password),item.Password))
                        {
                        
                        if (item.Group != "Уволенные")
                        {   if (item.Position == "Администратор") IAm.isAdmin = true;
                            IAm.myName = item.Name;
                            MainWindow mainWnd = new MainWindow();
                            mainWnd.Show();
                            this.Close();
                        }
                        }
                    else
                    {
                        popup1.IsOpen = true;
                    }
                }
                
            }
            
        }

       
    }
}
