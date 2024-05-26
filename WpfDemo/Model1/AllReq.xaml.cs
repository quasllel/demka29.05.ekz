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

    public partial class AllReq : Page
    {
        DataBase _dataBase = new DataBase();
        public AllReq()
        {
            InitializeComponent();
            ReqList.ItemsSource = _dataBase.getAllReq().DefaultView;
            ReqList.AutoGenerateColumns = true;
            ReqList.CanUserAddRows = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }
}
