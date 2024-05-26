using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDemo.Model3;

namespace WpfDemo.Model1
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        CreateReq ReqCreatedPage = new CreateReq();
        AllReq AllReqPage = new AllReq();
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ReqCreatedPage);

        }

        private void Button_AllReq(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(AllReqPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());

        }

        private void Button_ReqEdit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReqEdit());
        }

        private void Button_QRCode(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QrCode());

        }
    }
}
