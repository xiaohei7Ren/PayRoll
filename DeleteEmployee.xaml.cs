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
using Payroll;

namespace PayrollUi
{
    /// <summary>
    /// DeleteEmployee.xaml 的交互逻辑
    /// </summary>
    public partial class DeleteEmployee : Window
    {
        public DeleteEmployee()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBox1.Text);
            PayrollDatabase database = new FunctionPayrollDatabase();
            DeleteEmployeeTransaction deleteEmployee= new DeleteEmployeeTransaction(id, database);
            deleteEmployee.Execute();
            
        }
    }
}
