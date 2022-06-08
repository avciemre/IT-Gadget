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
using IT_Gadget.Resources;
using IT_Gadget.DbClasses;

namespace IT_Gadget
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        public Sales()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                DgOrders.ItemsSource = ctx.Orders.Select(x => new
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    Quantity = x.Quantity,
                    EmployeeId = x.EmployeeId,
                    CustomerId = x.CustomerId,
                }).ToList();
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            options.Show();
            Hide();
        }

        private void BtnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            //Order newOrder = OrderInput();
            //try
            //{
            //    using (Context ctx = new())
            //    {
            //        ctx.Orders.Add(newOrder);
            //        ctx.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error");
            //}

            //SetSource();
            //ClearFields();
        }
        private void BtnClearFields_Click(object sender, RoutedEventArgs e)
        {

        }

       /// private Order OrderInput()
        //{
            //Order newOrder = new Order();

            //newOrder.ProductId = TbProductId.;
            //newOrder.ProductName = TbProductName.Text;
            //newOrder.Description= TbDescription.Text;
            //newOrder.Quantity = TbQuantity;
            //newOrder.EmployeeId = TbEmployeeId.Text;
            //newOrder.CustomerId = TbCustomerId.Text;

            //return newOrder;
        //}
    }
}
