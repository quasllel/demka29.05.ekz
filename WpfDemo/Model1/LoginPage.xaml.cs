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
using WpfDemo.Model2;
using WpfDemo.Model3;

namespace WpfDemo.Model1
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        DataBase db = new DataBase();
        MenuPage menuPage = new MenuPage();
        ManagerMenu ManagerMenu = new ManagerMenu();
        WorkerPage workerPage = new WorkerPage();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string loginText = LoginField.Text;
            string passwordText = PasswordField.Text;
            string role = db.getRole(loginText);


            if (LoginField.Text != null & PasswordField.Text != null)
            {
                try
                {
                    bool resultAuth = db.Auth(loginText, passwordText);
                    if (resultAuth)
                    {

                        switch (role.Trim())
                        {
                            case "user":
                                {
                                    NavigationService.Navigate(menuPage);
                                    break;
                                }
                            case "manager":
                                {
                                    NavigationService.Navigate(ManagerMenu);
                                    break;
                                }
                            case "worker":
                                {
                                    NavigationService.Navigate(workerPage);
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Роль не определена!");
                                    break;
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные не найдены!");
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                        }
            }
            else
            {
                MessageBox.Show("Вы не ввели данные!");
            }
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }
    }
}
