
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
using System.ComponentModel.DataAnnotations;

namespace CRM
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Add_Manager: Window
    {
        public Add_Manager()
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
            }
        }

       


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (CRMContext dbContext = new CRMContext())
                {
                    var manager = new BD.Managers();
                    manager.Name = tb_name.Text;
                    manager.Login = tb_login.Text;
                    manager.Password = Hash.EncryptPassword(tb_login.Text, tb_password.Text);
                    manager.Position = cb_position.SelectedItem.ToString();
                    manager.Group = cb_group.SelectedItem.ToString();
                    manager.Address = tb_address.Text;
                    manager.Phone = tb_phone.Text;
                    manager.Passport = tb_passport.Text;
                    if (d_dateofbirth.SelectedDate >= (DateTime.Today).AddYears(18))
                    {
                        MessageBox.Show("Некорректный ввод даты рождения");
                    }
                    else
                    {
                        manager.DateOfBirth = d_dateofbirth.SelectedDate;
                    }
                    manager.DateRecruitment = d_daterecruitment.SelectedDate;
                    manager.Email = tb_email.Text;
                    manager.Info = tb_info.Text;

                    var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                    var context = new ValidationContext(manager);
                    if (!Validator.TryValidateObject(manager, context, results, true))
                    {
                        foreach (var error in results)
                        {
                            MessageBox.Show(error.ErrorMessage);
                        }
                    }
                    else
                    {
                        dbContext.Managers.Add(manager);
                        dbContext.SaveChanges();
                    }
                    if (Validator.TryValidateObject(manager, context, results, true))
                    {
                        this.Close();
                    }
                } }
            catch
            {
                MessageBox.Show("Ошибка! Некорректный ввод данных!");
            }
           

            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
