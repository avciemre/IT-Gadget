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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            using (Context ctx = new Context())
            {
                DgEmployee.ItemsSource = ctx.Employees.Select(x => new {
                    EmployeeFirstlName = x.EmployeeFirstlName,
                    EmployeeLastlName = x.EmployeeLastlName,
                    BirthDate = x.BirthDate,
                    Role = x.Role,
                    EmployeeLoginId = x.EmployeeLoginId,
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

        private void BtnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = EmployeeInput();
            try
            {
                using (Context ctx = new())
                {
                    ctx.Employees.Add(newEmployee);
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

        //private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private Employee EmployeeInput()
        {
            Employee newEmployee = new Employee();

            newEmployee.EmployeeFirstlName = TbFirstName.Text;
            newEmployee.EmployeeLastlName = TbLastName.Text;
            newEmployee.BirthDate = TbBirthDate.DisplayDate;
            newEmployee.Role = TbRole.Text;
            newEmployee.EmployeeLoginId = TbLoginId.Text;

            return newEmployee;
        }

        private void BtnClearFields_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        //private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void SetSource()
        {
            using (Context ctx = new())
            {
                var query = ctx.Employees.Select(x => x);
                DgEmployee.ItemsSource = query.ToList();
            }
        }

        private void ClearFields()
        {
            TbFirstName.Clear();
            TbLastName.Clear();
            TbBirthDate.DisplayDate = DateTime.Today;
            TbRole.Clear();
            TbLoginId.Clear();
        }
    }
}
