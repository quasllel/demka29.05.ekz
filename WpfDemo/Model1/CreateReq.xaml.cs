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
    /// Логика взаимодействия для CreateReq.xaml
    /// </summary>
    public partial class CreateReq : Page
    {
        DataBase _dataBase = new DataBase();
        public CreateReq()
        {
            InitializeComponent();
            string[] deviceNames = _dataBase.getDeviceNames();
            for(int i = 0; i < deviceNames.Length; i++)
            {
                deviceNames[i] = deviceNames[i].Trim();
            }
            deviceComboBox.ItemsSource = deviceNames;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameText = FIO.Text;
            string phoneText = phone.Text;
            string emailText= email.Text;
            string numberText = number.Text;
            string descriptionText= description.Text;
            string deviceText = deviceComboBox.SelectedItem.ToString();
            string status = "Ожидание";
            try
            {
                bool requestAdded = _dataBase.addNewReq(nameText, phoneText, emailText, deviceText, numberText, descriptionText, status);

            if (requestAdded)
            {
                MessageBox.Show("Запрос успешно добавлен!");
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }
            }
            catch 
            {
                MessageBox.Show("Что-то пошло не так");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateReq());
        }
    }
}
