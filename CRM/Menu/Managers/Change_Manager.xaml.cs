using CRM.BD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public partial class Change_Manager : Window
    {
        public BD.Managers del_manager = null;
        public Change_Manager(BD.Managers manager)
        {
            InitializeComponent();
            using (CRMContext dbContext = new CRMContext())
            {
                foreach (var item in dbContext.CatalogPositions)
                {
                    cb_position.Items.Add(item.Position);
                }
                foreach (var item in dbContext.CatalogGroupManagers)
                {
                    cb_group.Items.Add(item.Group);
                }
                tb_name.Text = manager.Name;
                tb_login.Text = manager.Login;
                cb_position.SelectedItem = manager.Position;
                cb_group.SelectedItem = manager.Group;
                tb_address.Text = manager.Address;
                tb_phone.Text = manager.Phone;
                tb_passport.Text = manager.Passport;
                d_dateofbirth.SelectedDate = manager.DateOfBirth;
                d_daterecruitment.SelectedDate = manager.DateRecruitment;
                tb_email.Text = manager.Email;
                tb_info.Text = manager.Info;
                del_manager = manager;
            }
            

        }
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (CRMContext dbContext = new CRMContext())
            {
                del_manager.Name = tb_name.Text;
                del_manager.Login = tb_login.Text;
                if (tb_password.Text!=null) del_manager.Password = Hash.EncryptPassword(tb_login.Text, tb_password.Text);
                del_manager.Position = cb_position.SelectedItem.ToString();
                del_manager.Group = cb_group.SelectedItem.ToString();
                del_manager.Address = tb_address.Text;
                del_manager.Phone = tb_phone.Text;
                del_manager.Passport = tb_passport.Text;
                del_manager.DateOfBirth = d_dateofbirth.SelectedDate;
                del_manager.DateRecruitment = d_daterecruitment.SelectedDate;
                del_manager.Email = tb_email.Text;
                del_manager.Info = tb_info.Text;

                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(del_manager);
                if (!Validator.TryValidateObject(del_manager, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    try
                    {
                        dbContext.Entry(del_manager).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!Нельзя менять ключевое поле!");
                    }
                }
                if (Validator.TryValidateObject(del_manager, context, results, true))
                {
                    this.Close();
                }
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
