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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDemo.Model1;
using WpfDemo.Model2;

namespace WpfDemo.Model3
{
    /// <summary>
    /// Логика взаимодействия для ReqUpdate.xaml
    /// </summary>
    public partial class ReqUpdate : Page
    {
        DataBase _dataBase = new DataBase();
        public ReqUpdate()
        {
            InitializeComponent();
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
            if (startDate.SelectedDate.HasValue)
            {
                try
                {
                    bool reqStatus = _dataBase.updateOnlyDateInRequest(int.Parse(reqComboBox.SelectedValue.ToString()), startDate.SelectedDate.Value.ToShortDateString(), endDate.SelectedDate.Value.ToShortDateString());
                    if (reqStatus)
                    {
                        MessageBox.Show("Данные успешно внесены");
                        NavigationService.Navigate(new ReqUpdate());
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
    }
}
