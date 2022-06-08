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
using Microsoft.EntityFrameworkCore;

namespace IT_Gadget.Data
{
    /// <summary>
    /// Interaction logic for CustomerData.xaml
    /// </summary>
    public partial class CustomerData : Window
    {
        public CustomerData()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                DgCustomers.ItemsSource = ctx.Customers.Select(x => new {
                    CustomerId = x.CustomerId,
                    CustomerFirstName = x.CustomerFirstName,
                    CustomerLastName = x.CustomerLastName,
                    CustomerAddress = x.CustomerAddress,
                    CustomerPhoneNimber = x.CustomerPhoneNumber,
                    CustomerEmail = x.CustomerEmail,
                    CustomerCity = x.CustomerCity,
                    CustomerZipCode = x.CustomerZipCode,
                }).ToList();
            }
        }

        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer newCustomer = CustomerFromFields();
            try
            {
                using (Context ctx = new())
                {
                    ctx.Customers.Add(newCustomer);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            SetSource();
            ClearFields();

        }
       
        //private void BtnSaveCustomer_Click(object sender, RoutedEventArgs e)
        //{
        //    Customer selectedCustomer = (Customer)DgCustomers.SelectedItem;

        //    if (selectedCustomer == null)
        //    {
        //        MessageBox.Show("Please select a customer to edit");
        //        return;
        //    }

        //    try
        //    {
        //        Customer editCustomer = CustomerFromFields();

        //        MessageBoxResult result = MessageBox.Show("Updating customer data", "Please confirm", MessageBoxButton.OKCancel);

        //        if (result == MessageBoxResult.Cancel)
        //            return;

        //        using (Context ctx = new Context())
        //        {
        //            Customer? targetCustomer = ctx.Customers.Where(c => c.CustomerId == selectedCustomer.CustomerId).FirstOrDefault();

        //            if (targetCustomer == null)
        //            {
        //                MessageBox.Show("No customer found");
        //                return;
        //            }

        //            targetCustomer.CustomerFirstName = editCustomer.CustomerFirstName;
        //            targetCustomer.CustomerLastName = editCustomer.CustomerLastName;
        //            targetCustomer.CustomerEmail = editCustomer.CustomerEmail;
        //            targetCustomer.CustomerPhoneNumber = editCustomer.CustomerPhoneNumber;
        //            targetCustomer.CustomerAddress = editCustomer.CustomerAddress;
        //            targetCustomer.CustomerCity = editCustomer.CustomerCity;
        //            targetCustomer.CustomerZipCode = editCustomer.CustomerZipCode;

        //            ctx.SaveChanges();

        //            SetSource();
        //            ClearFields();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error");
        //    }
        //}

        private void BtnClearFields_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        //private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        //{

        //    Customer? customer = (Customer)DgCustomers.SelectedItem;

        //    if (customer == null)
        //        return;

        //    try
        //    {
        //        using (Context ctx = new Context())
        //        {
        //            MessageBoxResult result = MessageBox.Show("Deleting user", "Please confirm", MessageBoxButton.OKCancel);
        //            if (result == MessageBoxResult.OK)
        //            {
        //                ctx.Customers.Remove(customer);
        //                ctx.SaveChanges();
        //            }
        //            else { return; }

        //            SetSource();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error");
        //    }
        //}

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
        
        private Customer CustomerFromFields()
        {
            Customer newCustomer = new Customer();

            newCustomer.CustomerFirstName = TbFirstName.Text;
            newCustomer.CustomerLastName = TbLastName.Text;
            newCustomer.CustomerPhoneNumber = TbPhoneNumber.Text;
            newCustomer.CustomerEmail = TbEmail.Text;
            newCustomer.CustomerAddress = TbAddress.Text;
            newCustomer.CustomerZipCode = TbZipCode.Text;
            newCustomer.CustomerCity = TbCity.Text;

            return newCustomer;
        }

        private void SetSource()
        {
            using (Context ctx = new())
            {
                var query = ctx.Customers.Select(x => x);
                DgCustomers.ItemsSource = query.ToList();
            }
        }

        private void ClearFields()
        {
            TbFirstName.Clear();
            TbLastName.Clear();
            TbPhoneNumber.Clear();
            TbEmail.Clear();
            TbAddress.Clear();
            TbZipCode.Clear();
            TbCity.Clear();
        }
    }
}
