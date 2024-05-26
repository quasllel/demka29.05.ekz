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

namespace WpfDemo.Model1
{
    /// <summary>
    /// Логика взаимодействия для ReqEdit.xaml
    /// </summary>
    public partial class ReqEdit : Page
    {
        DataBase _dataBase = new DataBase();
        public ReqEdit()
        {
            InitializeComponent();
            string[] workers = _dataBase.getAllWorker();
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = workers[i].Trim();
            }
            workersComboBox.ItemsSource = workers;

            string[] status = _dataBase.getAllStatus();
            for(int i = 0; i < status.Length; i++)
            {
                status[i] = status[i].Trim();
            }
            statusComboBox.ItemsSource = status;

            string[] id = _dataBase.getAllReqId();

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = id[i].Trim();
            }
            reqComboBox.ItemsSource = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(reqComboBox.SelectedItem != null && statusComboBox.SelectedItem != null && workersComboBox.SelectedItem != null)
            {
                try{
                    bool updInfo = _dataBase.updateRequest(int.Parse(reqComboBox.SelectedItem.ToString()), descBox.Text,statusComboBox.SelectedItem.ToString(), workersComboBox.SelectedItem.ToString());
                    if (updInfo == true) {
                        MessageBox.Show("Заявка успешно изменена!");
                        NavigationService.Navigate(new ReqEdit());
                    }
                    else
                    {
                        MessageBox.Show("Заявка не изменена. Введиие корректные данные!");
                        NavigationService.Navigate(new ReqEdit());
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Вы заполнени не все поля!");
            }
 

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReqEdit());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }
}
