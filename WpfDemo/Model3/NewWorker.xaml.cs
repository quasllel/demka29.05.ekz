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
using WpfDemo.Model1;
using WpfDemo.Model2;

namespace WpfDemo.Model3
{
    /// <summary>
    /// Логика взаимодействия для NewWorker.xaml
    /// </summary>
    public partial class NewWorker : Page
    {

        DataBase _dataBase = new DataBase();
        public NewWorker()
        {
            InitializeComponent();
            string[] workers = _dataBase.getAllWorker();
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = workers[i].Trim();
            }
            workersComboBox.ItemsSource = workers;

            string[] id = _dataBase.getAllReqId();

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = id[i].Trim();
            }
            reqComboBox.ItemsSource = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerMenu());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (reqComboBox.SelectedItem != null && workersComboBox.SelectedItem != null)
            {
                try
                {
                    bool updInfo = _dataBase.updateWorker(int.Parse(reqComboBox.SelectedItem.ToString()), workersComboBox.SelectedItem.ToString());
                    if (updInfo == true)
                    {
                        MessageBox.Show("Заявка успешно изменена!");
                        NavigationService.Navigate(new NewWorker());
                    }
                    else
                    {
                        MessageBox.Show("Заявка не изменена. Введиие корректные данные!");
                        NavigationService.Navigate(new NewWorker());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Вы заполнени не все поля!");
            };
        
        }
    }
}
