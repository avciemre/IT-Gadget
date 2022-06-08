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
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using IT_Gadget;
using IT_Gadget.Data;
using IT_Gadget.Resources;
using IT_Gadget.DbClasses;

namespace IT_Gadget.Data
{
    
    /// <summary>
    /// Interaction logic for ProductData.xaml
    /// </summary>
    public partial class ProductData : Window
    {
        public ProductData()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                DgProducts.ItemsSource = ctx.Products.Select(x => new {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Category = x.Category,
                    Price = x.Price,
                    Description = x.Description,
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

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = ProductInput();
            try
            {
                using (Context ctx = new())
                {
                    ctx.Products.Add(newProduct);
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

        //private void BtnEditProducts_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    ClearFields();
        //}


        private Product ProductInput()
        {
            Product newProduct = new Product();

            newProduct.ProductName = TbProductName.Text;
            newProduct.Price = TbPrice.MinLines;
            newProduct.Category = TbCategory.MinLines;
            newProduct.Description = TbDescription.Text;

            return newProduct;
        }

        private void SetSource()
        {
            using (Context ctx = new())
            {
                var query = ctx.Products.Select(x => x);
                DgProducts.ItemsSource = query.ToList();
            }
        }

        private void ClearFields()
        {
            TbProductName.Clear();
            TbPrice.Clear();
            TbCategory.Clear();
            TbDescription.Clear();
        }


    }
}
