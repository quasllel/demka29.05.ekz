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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {

        DataBase _db = new DataBase();
        public WorkerPage()
        {
            InitializeComponent();

            string[] status = _db.getAllStatus();
            string[] id = _db.getAllReqId();

            for (int i = 0; i < status.Length; i++)
            {
                status[i] = status[i].Trim();
            }
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = id[i].Trim();
            }
            statusBox.ItemsSource = status;
            idBox.ItemsSource = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkerPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if(startDate.SelectedDate.HasValue)
            {
                try
                {
                    bool reqStatus = _db.updateFullRequest(int.Parse(idBox.SelectedValue.ToString()), desc.Text, statusBox.SelectedValue.ToString(), startDate.SelectedDate.Value.ToShortDateString(), endDate.SelectedDate.Value.ToShortDateString());
                    if(reqStatus)
                    {
                        MessageBox.Show("Данные успешно внесены");
                        NavigationService.Navigate(new WorkerPage());
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
