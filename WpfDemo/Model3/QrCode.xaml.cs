using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace WpfDemo.Model3
{
    /// <summary>
    /// Логика взаимодействия для QrCode.xaml
    /// </summary>
    public partial class QrCode : Page
    {
        public QrCode()
        {
            InitializeComponent();
            GenerateQRCode("https://www.google.com");

        }

        private void GenerateQRCode(string url)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300
                }
            };
            var qrCodeBitmap = writer.Write(url);

            // Преобразование Bitmap в BitmapSource
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                qrCodeBitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            Image.Source = bitmapSource;
        }
   

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
