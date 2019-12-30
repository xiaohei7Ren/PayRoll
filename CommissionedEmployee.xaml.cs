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
    /// CommissionedEmployee.xaml 的交互逻辑
    /// </summary>
    public partial class CommissionedEmployee : Window
    {
        public CommissionedEmployee()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBox1.Text);
            string name = TextBox2.Text;
            string address = TextBox3.Text;
            double baseRate = float.Parse(TextBox4.Text);
            double commissionRate = float.Parse(TextBox5.Text);
            PayrollDatabase database = new FunctionPayrollDatabase();
            AddCommissionedEmployee addCommissionedEmployee = new AddCommissionedEmployee(id, name, address, baseRate, commissionRate, database);
            addCommissionedEmployee.Execute();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
