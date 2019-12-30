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
    /// SalariedEmployeeForm.xaml 的交互逻辑
    /// </summary>
    public partial class SalariedEmployeeForm : Window
    {
        public SalariedEmployeeForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBox1.Text);
            string name = TextBox2.Text;
            string address = TextBox3.Text;
            double salary = float.Parse(TextBox4.Text);
            PayrollDatabase database = new FunctionPayrollDatabase();
            AddSalariedEmployee addSalariedEmployee= new AddSalariedEmployee(id, name, address, salary, database);
            addSalariedEmployee.Execute();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
