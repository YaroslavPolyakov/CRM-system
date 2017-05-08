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
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change_Client : Window
    {
        public BD.Clients del_client = null;
        public Change_Client(BD.Clients client)
        {
            InitializeComponent();
            using (CRMContext dbContext = new CRMContext())
            {
                tb_name.Text= client.Name;
                tb_address.Text = client.Address;
                tb_phone.Text = client.Phone;
                tb_email.Text = client.Email;
                tb_checkingAccoubt.Text = client.CheckingAccount;
                tb_bank.Text = client.Bank;
                tb_director.Text = client.Director;
                tb_acccountant.Text = client.Accountant;
                tb_info.Text = client.Info;
                del_client = client;         
            }
            
            
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                var client = new BD.Clients();

                client.Name = tb_name.Text;
                client.Address = tb_address.Text;
                client.Phone = tb_phone.Text;
                client.Email = tb_email.Text;
                client.CheckingAccount = tb_checkingAccoubt.Text;
                client.Bank = tb_bank.Text;
                client.Director = tb_director.Text;
                client.Accountant = tb_acccountant.Text;
                client.Info = tb_info.Text;
                dbContext.Entry(del_client).State = System.Data.Entity.EntityState.Deleted;
                dbContext.Clients.Add(client);
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
