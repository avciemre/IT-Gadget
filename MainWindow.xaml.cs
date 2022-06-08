using IT_Gadget.Data;
using IT_Gadget.DbClasses;
using IT_Gadget.Resources;
using IT_Gadget;
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
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Configuration;
using ITGadget;
using System.Diagnostics;
#nullable disable
namespace IT_Gadget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (Context ctx = new Context())
            {
                var userQ = ctx.Employees.Select(x => x).ToList();

                foreach (Employee user in userQ)
                {
                    Trace.WriteLine($"Name: {user.EmployeeFirstlName} {user.EmployeeId}");
                }
                //Check EmployeeName
                string name = BxUserName.Text;
                string userId = BxUserId.Password;
                Employee userQuery = ctx.Employees.Where(x => x.EmployeeFirstlName == name).FirstOrDefault();
                if (userQuery == null)
                {
                    MessageBox.Show("Wrong Input! Please check User Name or User ID");
                    return;
                }
                string storedUserId = userQuery.EmployeeLoginId;
                //Check EmployeeId
                if (userId == storedUserId)
                {
                    TxtUserName.Text = string.Empty;
                    TxtUserId.Text = string.Empty;
                    //NavigationService nav = NavigationService.GetNavigationService(this);
                    //MainWindow mainWindow = new MainWindow();
                    //nav.Navigate(mainWindow);
                    Options options = new Options();
                    options.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Input! Please check User Name or User ID");
                }
            }
        }

        private void KeyLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                using (Context ctx = new Context())
                {
                    var userQ = ctx.Employees.Select(x => x).ToList();

                    foreach (Employee user in userQ)
                    {
                        Trace.WriteLine($"Name: {user.EmployeeFirstlName} {user.EmployeeId}");
                    }
                    //Check EmployeeName
                    string name = BxUserName.Text;
                    string userId = BxUserId.Password;
                    Employee userQuery = ctx.Employees.Where(x => x.EmployeeFirstlName == name).FirstOrDefault();
                    if (userQuery == null)
                    {
                        MessageBox.Show("Wrong Input! Please check User Name or User ID");
                        return;
                    }
                    string storedUserId = userQuery.EmployeeLoginId;
                    //Check EmployeeId
                    if (userId == storedUserId)
                    {
                        TxtUserName.Text = string.Empty;
                        TxtUserId.Text = string.Empty;
                        //NavigationService nav = NavigationService.GetNavigationService(this);
                        //MainWindow mainWindow = new MainWindow();
                        //nav.Navigate(mainWindow);
                        Options options = new Options();
                        options.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Input! Please check User Name or User ID");
                    }
                }
            }
        }
    }
}
