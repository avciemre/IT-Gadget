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
using System.Windows.Shapes;
using IT_Gadget.Data;
#nullable disable
namespace IT_Gadget
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public MainWindow FirstPage;
        public Options OptionsPage;
        public Sales SalesPage;
        public User UserPage;
        public CustomerData CustomerInfoPage;
        public ProductData ProductInfoPage;

        public Options()
        {
            InitializeComponent();
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductData productData = new ProductData();
            productData.Show();
            Hide();
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Show();
            Hide();
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            CustomerData customerData = new CustomerData();
            customerData.Show();
            Hide();
        }

        //private void BtnOrders_Click(object sender, RoutedEventArgs e)
        //{
        //    Sales sales = new Sales();
        //    sales.Show();
        //    Hide();
        //}

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
